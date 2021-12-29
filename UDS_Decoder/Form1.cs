using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;

namespace UDS_Decoder
{
    public partial class uds_decoder : Form
    {
        private static uds_decoder form = null;
        SerialPort _serialPort;
        bool uart_connected = false;
        Thread sthread;
        int msgcounter = 0;

        NumberFormatInfo nfi = new NumberFormatInfo();
        NumberStyles nsi = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
        bool update_bitmask = false;

        public uds_decoder()
        {
            InitializeComponent();
            gb_interpolate.Visible = false;
            gb_torque.Visible = false;
            nfi = NumberFormatInfo.InvariantInfo;
            //nfi.NumberDecimalSeparator = ".";
            get_com_ports();
            form = this;
            _serialPort = new SerialPort();
            _serialPort.BaudRate = 115200;
            sthread = new Thread(() => watch_serial());
            sthread.Start();
            sthread.Suspend();
        }

        private string filter_serial(string str)
        {
            //Debug.WriteLine(str);
            // remove request
            Match m0 = Regex.Match(str, @"\d+\t(\S+) ...  (\S{2}) (22)(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?..", RegexOptions.Singleline);
            while (m0.Success)
            {
                set_text_box_string(tb_req_id, m0.Groups[1].Value);
                inclement_msg_counter();
                str = str.Replace(m0.Groups[0].Value, "");
                //Debug.WriteLine(m0.Groups[0].Value);
                m0 = m0.NextMatch();
            }

            // single line response
            Match m = Regex.Match(str, @"\d+\t(\S+) ...  (\S{2})(?> (62))(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?", RegexOptions.None);
            while (m.Success)
            {
                fill_data(m.Groups);
                inclement_msg_counter();
                str = str.Replace(m.Groups[0].Value, "");
                m = m.NextMatch();
            }

            // multi line response
            Match m1 = Regex.Match(str, @"\d+\t(\S+) ...  (1\d)(?> (\S{2}))(?> 62)?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?..\d+\t(?>\S+) ...  30 00 01 55 55 55 55 55 .(?>\d+\t(?>\S+) ...  (?>2\d)(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))? .)?.(?>\d+\t(?>\S+) ...  (?>2\d)(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))? .)?.(?>\d+\t(?>\S+) ...  (?>2\d)(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))? .)?.(?>\d+\t(?>\S+) ...  (?>2\d)(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))? .)?.(?>\d+\t(?>\S+) ...  (?>2\d)(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))?(?> (\S{2}))? .)?", RegexOptions.Singleline);
            while (m1.Success)
            {
                fill_data(m1.Groups);
                inclement_msg_counter();

                //for (int i = 0; i < 20; i++) {
                //        Debug.WriteLine(i.ToString()+": " + m1.Groups[i].ToString()); }
                //Debug.WriteLine("Match: --"+ m.Value + "--");
                str = str.Replace(m1.Groups[0].Value, "");
                //Debug.WriteLine(str);

                m1 = m1.NextMatch();
            }
            return str;
        }

        private void inclement_msg_counter()
        {
            msgcounter++;
            lab_msg_counter.Invoke((MethodInvoker)delegate
            {
                lab_msg_counter.Text = msgcounter.ToString(nfi);
            });
        }

        private void fill_data(GroupCollection g)
        {
            const int b_count = 24;
            TextBox [] tb = new TextBox[b_count] { tb_byte0, tb_byte1, tb_byte2, tb_byte3, tb_byte4, tb_byte5, tb_byte6, tb_byte7, tb_byte8, tb_byte9, tb_byte10, tb_byte11, tb_byte12, tb_byte13, tb_byte14, tb_byte15, tb_byte16, tb_byte17, tb_byte18, tb_byte19, tb_byte20, tb_byte21, tb_byte22, tb_byte23 };
            
            
            set_text_box_string(tb_id, g[1].Value);
            set_text_box_string(tb_br0, g[4].Value);
            set_text_box_string(tb_br1, g[5].Value);
            int pos = 5;
            int offset = 6;

            int t = 0;
            do {
                t = check_fillvalue(g, pos);
                pos += t;
                if(pos - offset < b_count)
                {
                    set_text_box_string(tb[pos - offset], g[pos].Value);
                }
                
            } while (t > 0);
            for ( int i = pos - offset+1; i< b_count; i++)
            {
                set_text_box_string(tb[i], "");
            }
            
            calc_value();
        }

        private int check_fillvalue(GroupCollection g, int pos)
        {
            for (int i = pos+1; i < g.Count; i++)
            {
                if (g[i].Value != "") {
                    //Debug.WriteLine(i - pos);
                    return i-pos; }
            }
            return 0;
        }


        void set_text_box_string(TextBox tb, string str)
        {
            tb.Invoke((MethodInvoker)delegate
            {
                    tb.Text = str;
            });
        }

        void set_lab_string(Label lb, string str)
        {
            lb.Invoke((MethodInvoker)delegate
            {
                lb.Text = str;
            });
        }

        private void calc_value()
        {
            string[] hex = new string[8];
            int num_checked = 0;
            ulong val = 0;
            double final_val = 0;
            double act_val = 0;
            bool[] byte_checked = new bool[24];
            int startbit = 0;


            if (cb_byte0.Checked) { hex[num_checked] = tb_byte0.Text; num_checked++; byte_checked[0] = true; }
            if (cb_byte1.Checked) { hex[num_checked] = tb_byte1.Text; num_checked++; byte_checked[1] = true; }
            if (cb_byte2.Checked) { hex[num_checked] = tb_byte2.Text; num_checked++; byte_checked[2] = true; }
            if (cb_byte3.Checked) { hex[num_checked] = tb_byte3.Text; num_checked++; byte_checked[3] = true; }
            if (cb_byte4.Checked) { hex[num_checked] = tb_byte4.Text; num_checked++; byte_checked[4] = true; }
            if (cb_byte5.Checked) { hex[num_checked] = tb_byte5.Text; num_checked++; byte_checked[5] = true; }
            if (cb_byte6.Checked) { hex[num_checked] = tb_byte6.Text; num_checked++; byte_checked[6] = true; }
            if (cb_byte7.Checked) { hex[num_checked] = tb_byte7.Text; num_checked++; byte_checked[7] = true; }
            if (cb_byte8.Checked) { hex[num_checked] = tb_byte8.Text; num_checked++; byte_checked[8] = true; }
            if (cb_byte9.Checked) { hex[num_checked] = tb_byte9.Text; num_checked++; byte_checked[9] = true; }
            if (cb_byte10.Checked) { hex[num_checked] = tb_byte10.Text; num_checked++; byte_checked[10] = true; }
            if (cb_byte11.Checked) { hex[num_checked] = tb_byte11.Text; num_checked++; byte_checked[11] = true; }
            if (cb_byte12.Checked) { hex[num_checked] = tb_byte12.Text; num_checked++; byte_checked[12] = true; }
            if (cb_byte13.Checked) { hex[num_checked] = tb_byte13.Text; num_checked++; byte_checked[13] = true; }
            if (cb_byte14.Checked) { hex[num_checked] = tb_byte14.Text; num_checked++; byte_checked[14] = true; }
            if (cb_byte15.Checked) { hex[num_checked] = tb_byte15.Text; num_checked++; byte_checked[15] = true; }
            if (cb_byte16.Checked) { hex[num_checked] = tb_byte16.Text; num_checked++; byte_checked[16] = true; }
            if (cb_byte17.Checked) { hex[num_checked] = tb_byte17.Text; num_checked++; byte_checked[17] = true; }
            if (cb_byte18.Checked) { hex[num_checked] = tb_byte18.Text; num_checked++; byte_checked[18] = true; }
            if (cb_byte19.Checked) { hex[num_checked] = tb_byte19.Text; num_checked++; byte_checked[19] = true; }
            if (cb_byte20.Checked) { hex[num_checked] = tb_byte20.Text; num_checked++; byte_checked[20] = true; }
            if (cb_byte21.Checked) { hex[num_checked] = tb_byte21.Text; num_checked++; byte_checked[21] = true; }
            if (cb_byte22.Checked) { hex[num_checked] = tb_byte22.Text; num_checked++; byte_checked[22] = true; }
            if (cb_byte23.Checked) { hex[num_checked] = tb_byte23.Text; num_checked++; byte_checked[23] = true; }

            // set bitmask if changed bytes
            if (update_bitmask)
            {
                update_bitmask = false;
                ulong bitmask = 0xFFFFFFFFFFFFFFFF >> (64 - num_checked * 8);
                if (num_checked == 0) { bitmask = 0; }
                set_text_box_string(tb_bitmask, string.Format("0x{0:X}", bitmask));
            }

            // read back bitmask from field
            ulong bitm = 0;
            try
            {
                bitm = ulong.Parse(tb_bitmask.Text.Substring(2), NumberStyles.HexNumber);
            }
            catch { }
            //Debug.WriteLine(string.Format("0x{0:X}", bitm));
            int offset = 0;
            int bitlength = 0;

            for (int i = 0; i < num_checked * 8 + 1; i++)
            {
                if (bitm >> i == 0) {
                    offset = (num_checked * 8) - i;
                    break;
                }
            }

            for (int i = offset; i < num_checked * 8 + 1; i++)

            {
                if (((bitm << i) & (0xFFFFFFFFFFFFFFFF >> (64 - (num_checked * 8)))) == (ulong)0)
                {
                    bitlength = i - offset;
                    break;
                }
            }
            //Debug.WriteLine(offset);
            //Debug.WriteLine(bitlength);
            try
            {
                int min_checked = 0;
                for (int i = 0; i < 24; i++)
                {
                    if (byte_checked[i]) { min_checked = i; break; }
                }

                startbit = (min_checked) * 8 + offset + 24;
                //bitlength = (num_checked * 8);
                if (num_checked == 0) { startbit = 0; }
                set_lab_string(lab_length, "Length: " + bitlength.ToString());
                set_lab_string(lab_startbit, "Startbit: " + startbit.ToString());

                if (num_checked == 0)
                {
                    val = 0;
                }

                //int bytes = (bitlength + startbit) / 8 + 1 * ((((bitlength + startbit) % 8) > 0)?1:0);
                int bytes = (bitlength) / 8 + 1 * ((((bitlength + startbit) % 8) > 0) ? 1 : 0);
                int startbyte = min_checked; // (startbit- offset) / 8;
                Debug.WriteLine(startbyte.ToString());

                for (int i = bytes - 1; i > -1; i--)
                {
                    val += (ulong)(long.Parse(hex[i], NumberStyles.HexNumber)) << (((bytes - 1) - i) * 8);
                }

                if (cb_isFloat.Checked) {
                    final_val = BitConverter.ToSingle(BitConverter.GetBytes(val), 0);
                }
                else
                {
                    if (cb_signed.Checked)
                    {
                        if (((val) & (ulong)1 << (bitlength - 1)) == (ulong)1 << (bitlength - 1)) // sign bit is set
                        {
                            final_val = ((double)(((double)val - (double)(bitm)) * double.Parse(tb_mult.Text, nsi, nfi)) / double.Parse(tb_div.Text, nsi, nfi)) + double.Parse(tb_add.Text, nsi, nfi);
                        }
                        else
                        {
                            final_val = ((double)(val * double.Parse(tb_mult.Text, nsi, nfi)) / double.Parse(tb_div.Text, nsi, nfi)) + double.Parse(tb_add.Text, nsi, nfi);
                        }
                    }
                    else
                    {
                        final_val = ((double)(val * double.Parse(tb_mult.Text, nsi, nfi)) / double.Parse(tb_div.Text, nsi, nfi)) + double.Parse(tb_add.Text, nsi, nfi);
                    }
                }



                act_val = double.Parse(tb_act_value.Text) / final_val;
                set_text_box_string(tb_factor, act_val.ToString(nfi));
                set_text_box_string(tb_factor2, (final_val / double.Parse(tb_act_value.Text)).ToString(nfi));


            }
            catch
            {
                final_val = 0;
            }

            double m;
            double t;
            try
            {
                m = (double.Parse(tb_ax.Text, nsi, nfi) - double.Parse(tb_bx.Text, nsi, nfi)) / (double.Parse(tb_ay.Text, nsi, nfi) - double.Parse(tb_by.Text, nsi, nfi));
                t = -double.Parse(tb_ax.Text) * m;
            }
            catch
            {
                m = 0;
                t = 0;
            }

            set_text_box_string(tb_ssr_m, m.ToString(nfi));
            set_text_box_string(tb_ssr_t, t.ToString(nfi));
            set_text_box_string(tb_val, final_val.ToString(nfi));
            set_lab_string(lab_value_big, final_val.ToString(nfi));
            string sign = cb_signed.Checked ? "-" : "+";
            if (cb_isFloat.Checked)
            {
                sign = "f";
            }

            long rqid = 0;
            if (tb_id.Text.Length > 0) { rqid = Convert.ToInt32(tb_id.Text, 16); } //Convert.ToInt64(tb_id.Text); // Fix request vs Response
            //Debug.WriteLine(rqid);
            if (rqid > 0)
            {
                if (rqid >= 0x7E8 && rqid <= 0x7EF) { rqid -= 0x08; } // OBD specific functional adressing : 0x7E0 + (rqid-0x7E8)
                else if (rqid < 0xFFF) { rqid -= 0x6A; }
                else { rqid -= 0x20000; }
            }

            string sst = "[CCAN=UDS,ReqID,0x"+ rqid.ToString("X") + ",GroupID,Freq,REG={0x22,0x"+tb_br0.Text+",0x" + tb_br1.Text + "}" +
                ",TYPE={"+sign+"," + startbit.ToString(nfi) + ","+ (num_checked * 8) + ",MSB},CONV={"+tb_add.Text+","+tb_mult.Text+","+tb_div.Text+"},EXT]";
            set_text_box_string(tb_settingsstring, sst);

        }

        private void watch_serial()
        {
            byte[] buffer = new byte[5000];
            int size = 0;
            string text = "";
            while (true)
            {
                while (uart_connected && _serialPort.IsOpen)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        size = _serialPort.Read(buffer, 0, 4999);
                        text += System.Text.Encoding.UTF8.GetString(buffer, 0, size);
                        text = filter_serial(text);
                    }
                }
                Thread.Sleep(500);
            }

        }

        private void get_com_ports()
        {
            string[] ports = SerialPort.GetPortNames();
            selector_com_port.Items.Clear();
            selector_com_port.Items.AddRange(ports);
            selector_com_port.SelectedIndex = selector_com_port.Items.Count - 1;
        }

        private void connect(bool dis)
        {
            if (dis) // disconnect
            {
                _serialPort.Close();
                btn_connect.Text = "Connect";
                uart_connected = false;
                selector_com_port.Enabled = true;
                btn_com_port_refresh.Enabled = true;
                form.Text = "UDS Decoder";
                sthread.Suspend();

            }
            else // connect
            {
                _serialPort.PortName = get_selected_com_port();
                try
                {
                    _serialPort.Open();
                    form.Text = "UDS Decoder -- Connected";
                }
                catch (UnauthorizedAccessException ex)
                {
                    form.Text = "UDS Decoder -- " +get_selected_com_port() + " already used by another Application";
                }
                catch (System.IO.IOException)
                {
                    form.Text = "UDS Decoder -- " + get_selected_com_port() + " not found";
                }
                if (_serialPort.IsOpen)
                {
                    btn_connect.Text = "Disconnect";
                    uart_connected = true;
                    selector_com_port.Enabled = false;
                    btn_com_port_refresh.Enabled = false;
                    sthread.Resume();
                }
            }

        }

        private string get_selected_com_port()
        {
            string port = "";
            form.selector_com_port.Invoke((MethodInvoker)delegate {
                port = selector_com_port.SelectedItem.ToString();
            });
            return port;
        }

        private void set_bitsmask()
        {
            update_bitmask = true;
        }

        private void cb_byte2_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            connect(uart_connected);
        }

        private void btn_com_port_refresh_Click(object sender, EventArgs e)
        {
            get_com_ports();
            form.Text = "UDS Decoder";
            calc_value();
        }

        private void btn_set_ax_Click(object sender, EventArgs e)
        {
            set_text_box_string(tb_ax, tb_val.Text);
        }

        private void btn_set_ay_Click(object sender, EventArgs e)
        {
            set_text_box_string(tb_ay, tb_val.Text);
        }

        private void btn_set_bx_Click(object sender, EventArgs e)
        {
            set_text_box_string(tb_bx, tb_val.Text);
        }

        private void btn_set_by_Click(object sender, EventArgs e)
        {
            set_text_box_string(tb_by, tb_val.Text);
        }

        private void cb_byte0_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte1_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte3_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte4_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte5_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte6_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte7_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte8_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte9_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte10_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte11_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte12_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte13_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte14_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte15_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte16_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte17_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte18_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte19_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte20_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte21_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte22_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void cb_byte23_CheckedChanged(object sender, EventArgs e)
        {
            set_bitsmask();
        }

        private void tb_abc_in_TextChanged(object sender, EventArgs e)
        {
            int output = 0;
            try
            {
                int len = tb_abc_in.Text.Length;
                if(len > 0)
                {
                    output += char.ToUpper(tb_abc_in.Text[0]) - 64; //index == 1
                }
                if (len == 2)
                {
                    output *= 26;
                    output += char.ToUpper(tb_abc_in.Text[1]) - 64; //index == 1
                }

                output += 2; // offset of 2 byte?



            }
            catch
            {

            }
            tb_abc_int.Text = output.ToString();
            tb_abc_bit.Text = (output*8).ToString();

        }


    }
}
