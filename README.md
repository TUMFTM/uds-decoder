# UDS Decoder Tool
To work with Rosstechs VCDS.    
As a fair deal please publicly provide conversions you have sourced with this tool.

## Instructions
- Start UDS decoder (bin folder), Select Teensys COM port and click connect
- Start VCDS, select the ECU, go to advanced measurements, select ONE! value you want to observe
- Some data should be visible in UDS decoder. 

Try to find the conversion formula by selecting some bytes and modifing Add, Mult and Div values in order to match the actual value displayed in VCDS. The setting for ESP32OBDII Logger is automatically generated (already with calculated request address from response)    
Common conversions can be found in the ids.txt file.

Other functions of this tool are not documented at the moment, feel free to try out and contribute

![KL30 example](examples/2022_rework.png?raw=true "KL30 example")    
See more in examples folder


## Hardware

Use a Teensy 3.2 based USB-CAN sniffer flashed with the Arduino code provided in `TeensyCanSniffer`     
Required Hardware:
- Teensy 3.1/3.2 (or other with [FlexCan](https://github.com/pawelsky/FlexCAN_Library) support)
- SN65HVD230
- OBDII Socket or creative wiring

![Teensy 3.2 sniffer wiring](TeensyCanSniffer/wiring.png?raw=true "Teensy wiring")

# python_can_recorder
A python based ISO-TP decoder to read UDS 0x22 diagnostic data answers of requests from ESP32OBDII Logger directly on your PC.     
Requires a SocketCan compatible USB adapter (e.g. Vector VN1610) and an ESP32OBDII Logger provided by me.

## Instructions
- Install all requirements. Update pandas if you have problems reading the `labels.p` pickle file
- (Install Vector USB drivers, if not present)
- Connect VN16XX to OBD in paralell/Y-splitter to ESP32OBDII Logger
- Run main.py, values will be listed in terminal if received
- End with Ctrl+C (once), recorded data will be resampled to given period (100 ms by default)
- matlab file will be saved in `data` folder, a pickle file and raw pickle will be saved in `data/other'

To convert matlab workspace (.mat) to table use
```
VarNames = cellstr(columns);
Vars = array2table(data , 'VariableNames', VarNames);
```

Only requests listed in ids.txt will be recorded. Labels for the request_ids are normally requested directly from our database.
I provide a pickle snapshot and id list for VW ID.3 within this repo.    

# I want to try it out
If you are seriously interested in this stuff, feel free to contact me for documentation.     
Maybe I'll provide you an ESP32OBDII Logger (within Germany only, not public yet)     
This is mainly used to source battery and powertrain data of VAG MEB vehicles (ID.3, ID.4...) but is compatible with most VAG vehicles starting from ~2009 (UDS protocol)


Liked some of my stuff? Buy me a coffee (or more likely a beer)    
[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://buymeacoffee.com/thezenox)
