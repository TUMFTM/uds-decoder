#include <FlexCAN.h>

FlexCAN CANbus(500000, 0);
static CAN_message_t msg,rxmsg;
static uint8_t hex[17] = "0123456789abcdef";

int txCount,rxCount;
unsigned int txTimer,rxTimer;


static void hexDump(uint8_t dumpLen, uint8_t *bytePtr){
  uint8_t working;
  while( dumpLen-- ) {
    working = *bytePtr++;
    Serial.write( hex[ working>>4 ] );
    Serial.write( hex[ working&15 ] );
  }
  Serial.write('\r');
  Serial.write('\n');
}

// -------------------------------------------------------------
void setup(void){
  CANbus.begin();
  delay(1000);
  Serial.println(F("Teensy CAN Sniffer. Running at 500 kBits"));
}

// -------------------------------------------------------------
void loop(void){
  while ( CANbus.read(rxmsg) ) {
    //hexDump( sizeof(rxmsg), (uint8_t *)&rxmsg );
    Serial.print(millis());
    Serial.print("\t");
    Serial.print(rxmsg.id,HEX);
    Serial.print(" [");
    Serial.print(rxmsg.len);
    Serial.print("]  ");
    for (int i=0; i<8;i++){
      Serial.printf("%02x ",rxmsg.buf[i]);
    }
    Serial.print("\n");
  }
}

