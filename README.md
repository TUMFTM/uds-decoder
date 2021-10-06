# UDS Decoder Tool
To work with Rosstech VCDS

## Instructions
- Start UDS decoder, Select Teensys COM port and connect
- Start VCDS, select the ECU, go to advanced measurements, select ONE! value.
- Some data should be visible in UDS decoder. 


Try to find the conversion formula by selecting some bytes and modifing Add, Mult and Div values in order to match the actual value displayed in VCDS. The setting for ESP32OBDII Logger is automatically generated (already with calculated request address from response)

## Hardware

Use a Teensy 3.2 based USB-CAN sniffer flashed with the Arduino code provided     
![Teensy 3.2 sniffer wiring](TeensyCanSniffer/wiring.png?raw=true "Teensy wiring")
