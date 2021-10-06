import asyncio
import can
import datetime
import pickle
import pandas as pd
import struct
import re
from sqlalchemy import create_engine
import scipy.io
import numpy as np
import sys
import requests
import datetime as dt
from pathlib import Path

def decode_error(data):
    codes = {
    0x10: "General reject",
    0x11: "Service not supported",
    0x12: "Subfunction not supported",
    0x13: "Message length or format incorrect",
    0x14: "responseTooLong",
    0x21: "Busy – Repeat request",
    0x7E: "Service or Subfunction not supported",
    0x7F: "Service or Subfunction not supported",
    0x22: "Conditions not correct",
    0x24: "Request sequence error",
    0x31: "Out of range",
    0x33: "Security access denied",
    0x35: "Invalid key",
    0x36: "Exceed attempts",
    0x78: "Busy – Response pending"
    }
    return codes.get(data[2], "Unknown error")


RX_MAX = 700

class Msg:
    time = 0
    data = [0]
    dlc = 0
    id = 0

class TPslot:
    time = 0
    rx_id = 0
    tx_id = 0
    rx_data_len = 0
    rx_data = [0]
    rx_data_rcv = 0
    payload_pos = 0
    frame_state = -1
    is_fc = False
    fc_flag = 0
    blocksize = 0
    seperation_time = 0

    def __repr__(self):
        return "{0} {1} [{2}] {3}".format(self.time, hex(self.rx_id), self.rx_data_len, ' '.join('{:02x}'.format(x) for x in self.rx_data))

    def __str__(self):
        return "{0} {1} [{2}] {3}".format(self.time, hex(self.rx_id), self.rx_data_len, ' '.join('{:02x}'.format(x) for x in self.rx_data))

frame_list = []

def get_tp_slot(msg, frame_state):
    global frame_list
    element = None
    if frame_state <= 1:  # create new element
        element = TPslot()
        element.rx_id = msg.id
        element.time = msg.time
        element.frame_state = frame_state
        return element

    frame_list_new = []
    while len(frame_list) > 0:
        element = frame_list.pop(0)
        if element.rx_id == msg.id:
            if element.frame_state == frame_state - 1:
                if frame_state == 16: frame_state = 1
                element.frame_state = frame_state
                continue #break #return element
        frame_list_new.append(element)
    frame_list = frame_list_new
    #print("Framelist size: {0}".format(len(frame_list_new)))
    return element  # none if not found

def rx_handle(msg):
    global frame_list
    frame_state = -1
    if (msg.data[0] & 0xF0) == 0x30: return None
    if (msg.data[0] & 0xF0) == 0x00: frame_state = 0
    if (msg.data[0] & 0xF0) == 0x10: frame_state = 1
    if (msg.data[0] & 0xF0) == 0x20: frame_state = (msg.data[0] & 0x0F) + 1

    f = get_tp_slot(msg, frame_state)

    if f:
        #  single frame
        if (msg.data[0] & 0xF0) == 0x00:
            f.rx_data_len = msg.data[0] & 0x0F
            f.rx_data = msg.data[1:f.rx_data_len+1]

        # first  frame
        if (msg.data[0] & 0xF0) == 0x10:
            f.rx_data_rcv = 0
            f.rx_data_len = msg.data[1] + (msg.data[0] & 0x0F) * 256
            if f.rx_data_len > RX_MAX:
                print("error")
            f.rx_data = msg.data[2:8]
            f.rx_data_rcv = + 6

        # consecutive Frame
        if (msg.data[0] & 0xF0) == 0x20:
            #print("CF: "+ str(f))
            if f.rx_data_rcv > 0:
                f.payload_pos = 7 * (msg.data[0] & 0xF0) - 1
                f.rx_data[f.payload_pos:f.payload_pos + msg.dlc - 1] = msg.data[1:msg.dlc]
                f.rx_data_rcv += msg.dlc
                if f.rx_data_rcv >= f.rx_data_len:
                    f.frame_state = 0

        #  Flow control Frame
        if (msg.data[0] & 0xF0) == 0x30:
            f.is_fc = True
            f.fc_flag = (msg.data[0] & 0x0F)
            f.blocksize = msg.data[1]
            f.seperation_time = msg.data[2]
            #print("Flow Control")

        if f.frame_state == 0:
            #print(f)
            return f
        frame_list.append(f)
    return None

def is_online():
    # check internet connection and VPN acess
    return False # for public version disable this
    r = requests.get('http://postgres-sm.ftm.mw.tum.de', timeout=1)
    if r.status_code == 200:
        return True
    else:
        print("Failed with {}".format(r.ret_code))
        return False

def parse_settingsfile(path):
    ids = []
    file = open(path, 'r')
    lines = file.readlines()
    for line in lines:
        rq = {}
        line = line.strip()
        if line and line[0] == '[':
            params = line.split(',')
            if params[0].split('=')[0].strip() == '[CCAN' and params[0].split('=')[1].strip() == 'UDS':
                rq['rqid'] = int(params[1])
                rq['resp_id'] = None
                rq['can_id'] = int(params[2], 16)
                rq['regs'] = [int(x, 0) for x in re.findall(r"REG *= *{(.*?)}", line)[0].split(',')]
                a = re.findall(r"TYPE *= *{(.*?)}", line)[0].split(',')
                rq['type'] = a[0]
                rq['startbit'] = int(a[1])
                rq['bitlen'] = int(a[2])
                rq['byteorder'] = a[3]
                rq['name'] = str(rq['rqid'])
                rq['unit'] = None
                rq['conv'] = [float(x) for x in re.findall(r"CONV *= *{(.*?)}", line)[0].split(',')]
                #print(rq)
                ids.append(rq)
    ids = pd.DataFrame(ids)
    #print(ids)
    labs = None
    if is_online():
        try:
            # Postgres username, password, and database name
            POSTGRES_ADDRESS = ''
            POSTGRES_PORT = '5432'
            POSTGRES_DBNAME = 'mobtrack'
            POSTGRES_USERNAME = ''
            POSTGRES_PASSWORD = ''
            postgres_str = ('postgresql://{username}:{password}@{ipaddress}:{port}/{dbname}'
            .format(username=POSTGRES_USERNAME,password=POSTGRES_PASSWORD,ipaddress=POSTGRES_ADDRESS,port=POSTGRES_PORT,dbname=POSTGRES_DBNAME))
            cnx = create_engine(postgres_str)

            q_str = '''SELECT request_id, (SELECT variable_name FROM vehicle.can_value where vehicle.can_value.value_id = vehicle.can_request.value_id),
                            (SELECT unit FROM vehicle.can_value where vehicle.can_value.value_id = vehicle.can_request.value_id),
                            (SELECT name_en FROM vehicle.can_value where vehicle.can_value.value_id = vehicle.can_request.value_id),
                            (SELECT name_de FROM vehicle.can_value where vehicle.can_value.value_id = vehicle.can_request.value_id)
                            FROM vehicle.can_request'''
            labs = pd.read_sql_query(q_str, cnx)
            lfile = open("labels.p", 'wb+')
            pickle.dump(labs, lfile)
        except:
            print("using local lable file")

    if labs is None:
            with open("labels.p", 'rb') as fr:
                labs = pickle.load(fr)
    print("Loading Labels")
    for i, row in ids.iterrows():
        if labs[labs.request_id == row.rqid].shape[0] > 0:
            #print(labs[labs.request_id == row.rqid].values[0][1])
            ids.iloc[i, ids.columns.get_loc('name')] = labs[labs.request_id == row.rqid].values[0][1] #rid, name, unit, name_en, name_de
            ids.iloc[i, ids.columns.get_loc('unit')] = labs[labs.request_id == row.rqid].values[0][2]

    #print(ids)
    print("Definition loaded. {0} Signals".format(ids.shape[0]))
    return ids


def convert_data(data, startbyte, startbit, length, sign, isfloat, mult, div, add, byteorder):
    num_bytes = int((length + startbit) / 8) + 1 * ((((length + startbit) % 8) > 0))
    len_mask = 0xFFFFFFFFFFFFFFFF >> (64 - length)
    pre = 0
    #print( ' '.join('{:02x}'.format(x) for x in data))
    #print(num_bytes)
    #print(startbit)

    if byteorder == 'LSB':
        for i in range(num_bytes):
            pre += data[i+startbyte] << (i * 8)
    else: # MSB
        for i in range(num_bytes):  # i = bytes-1; i > -1; i--){
            pre += data[i+startbyte] << ( (num_bytes-i-1) * 8)
    pre = (pre >> startbit) & len_mask
    if not isfloat:
        if sign:
            if (pre & (1 << (length-1))):  # negative
                return ((pre - (len_mask) * mult) / div)+add
        return ((pre * mult)/div) + add
    else:
        a = struct.unpack('f', pre.to_bytes(4, 'little', signed=True))[0]
        val = (( a * mult) / div) + add
        #print(val)
        return val


def long_id(sid):
    return 0x18DA00F1 + (((sid - 0x7E0) & 0xFF) << 8)

def isNaN(num):
    return num != num

def dt_to_ms(inp):
	if isNaN(inp):
		return 0 # np.NaN
	delta = inp - dt.datetime.utcfromtimestamp(0)
	return int(delta.total_seconds() * 1000)

def get_timeseries(start,end, step):
    end = int(end)
    start = int(start)
    times = range(start*1000, end*1000,step) # last is ms time step
    timescale = pd.DataFrame({"time": [*times]})
    timescale.time = timescale.time.apply(lambda x : dt.datetime.utcfromtimestamp(x/1000))
    timescale = timescale.set_index('time')
    return timescale

def uds_handle(frame, rql):
    if frame.rx_data[0] == 0x7F:
        print("Negative Response: {0} {1}   {2}".format(hex(frame.rx_id),
        ' '.join('{:02x}'.format(x) for x in frame.rx_data),decode_error(frame.rx_data)))
    else:
        #print(frame.rx_data[0])
        ok = False

        if frame.rx_data[0] == 0x62:
            #print(frame)
            fid = frame.rx_id
            reg = [frame.rx_data[0]-0x40, frame.rx_data[1], frame.rx_data[2]]
            value = frame.rx_data[3:-1]
            ok = True


        elif frame.rx_data[0] == 0x41:
            fid = frame.rx_id
            reg = [frame.rx_data[0] - 0x40, frame.rx_data[1]]
            value = frame.rx_data[3:-1]
            ok = True

        if ok:
            rqs = rql.loc[rql.regs.apply(lambda x: x == reg)]
            #print(rqs)
            for i,rq in rqs.iterrows():
                #print(rq)
                # convert value
                isfloat = False
                issign = False
                if rq.type == '-': issign = True
                if rq.type == 'f': isfloat = True
                val = convert_data(frame.rx_data, int(rq.startbit/8), (rq.startbit)%8, rq.bitlen, issign, isfloat, rq.conv[1], rq.conv[2], rq.conv[0], rq.byteorder)
                add_data({'time': frame.time, 'rqid': rq.rqid, 'name': rq['name'], 'value' : val, 'unit': rq.unit})

                # alle werte anzeigen
                print( [frame.time, rq.rqid, rq['name'], val, rq.unit])

dataList = []
dataListCounter = 0

def add_data(d):
    global dataList
    global dataListCounter
    dataList.append(d)
    dataListCounter += 1
    #print(dataList)

filename = datetime.datetime.now().strftime("%Y_%m_%d-%H_%M_%S")
otherpath = "data/other/"
Path(otherpath).mkdir(parents=True, exist_ok=True)
matpath = "data/"
file = open(otherpath + filename+ "_raw.pkl", 'ab+')

data = []
def decode(msg):
    #print([msg.time, msg.id, msg.dlc, msg.data])
    f = rx_handle(msg)
    if f:
        uds_handle(f, requests)

def print_message(msg):
    print([msg.timestamp, msg.arbitration_id, msg.dlc, msg.data])

def append_msg(msg):
    pickle.dump([msg.timestamp, msg.arbitration_id, msg.dlc, msg.data], file)
    #data.append([msg.timestamp, msg.arbitration_id, msg.dlc, msg.data])

server = None
requests = parse_settingsfile('ids.txt')

#data = pd.DataFrame(raw, columns=["time", "id", "dlc", "data"])
#data.time = pd.to_datetime(data.time*1000000000)
try:
    bus = can.Bus(bustype="vector", app_name='CANalyzer', channel=0, bitrate=500000)
    reader = can.AsyncBufferedReader()
    logger = can.BLFWriter("logfile.bin")
    print("Start listening")
except:
    print("Vector Dongle present?")
    quit()


listeners = [
    append_msg,
    reader,  # AsyncBufferedReader() listener
]

loop = asyncio.get_event_loop()
notifier = can.Notifier(bus, listeners, loop=loop)

async def wakeup():
    while True:
        await asyncio.sleep(1)

async def main():
    while True:
        try:
            msg = await reader.get_message()
            if msg:
                m = Msg()
                m.id = msg.arbitration_id
                m.time = msg.timestamp
                m.dlc = msg.dlc
                m.data = msg.data
                decode(m)
        except Exception as e:
            print(e)

def end():
    global dataList
    data = pd.DataFrame(dataList)
    data = data.fillna(np.nan)
    data = data.sort_values(by = ['time'])
    data['value'] = data['value'].astype(float)
    lfile = open(otherpath + filename +"_df.pkl", 'wb+')
    pickle.dump(data, lfile)
    file.close()

    #exp = {exp['columns'],exp['data']}

    timestep = 100 #ms
    direction='nearest'
    tolerance = pd.Timedelta("10s")
    print ("Converting values. please wait")
    times = get_timeseries(data.time.values[0], data.time.values[-1], timestep)
    data.time = pd.DatetimeIndex ( data.time*1000000000 ) #.astype ( np.int64 )/1000000

    for r in data.rqid.unique():
        d = data[data.rqid == r][['time', 'value']].rename(columns={"value": data[data.rqid == r].name.unique()[0]})
        print(data[data.rqid == r].name.unique()[0], end='                                      \r')
        
        times = pd.merge_asof(times, d, on='time', direction=direction, tolerance= tolerance)
        #print(times)
    print("Done                      ")
    #times = times.reindex(sorted(times.columns), axis=1) #reorder columns in alphabetical order
    times.time = pd.DatetimeIndex ( times.time ).astype ( np.int64 )/1000000
    exp = times.to_dict("split")
    scipy.io.savemat(matpath + filename + '.mat', mdict={'columns':exp['columns'], 'data':exp['data']}, long_field_names=True)
    print("\n\n\n###############\nMatlab saved\n###############\n\n\n")
    notifier.stop()
    bus.shutdown()

if __name__ == "__main__":
    try:
        loop = asyncio.get_event_loop()
        loop.create_task(main())
        loop.create_task(wakeup())
        loop.run_forever()
    except KeyboardInterrupt:
        print("Process interrupted")  
    finally:
        end()
        loop.close()
        sys.exit()