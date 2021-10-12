#include "Keyboard.h"

#include "programmable_air.h"

#define DEBUG 1

int scale = 50;
bool toRun = false;
char size[20];
char grab[20];
int grabThre = 610;

void setup() {
  initializePins();
  Serial.begin(115200);
  
}

void loop() {
  
  int lf = 10;
  int pressure = readPressure();
  int charRead;
  
  while (Serial.available()>0)
  {
      Serial.readBytesUntil(lf,size,4);
      int percentage = atof(size) * scale;
      Serial.print("percentage:");
      Serial.println(percentage);
       if (toRun == false)
      {
         switchOnPump(1, 60);
         suck();
         delay(1000);
         switchOffPump(1);
         
         switchOnPump(2, percentage);
         blow();
         delay(1000);
         
         switchOffPumps();  
         toRun = true;    
      }
      
  }
  toRun = false;
  
  if (pressure > grabThre)
    {
      Serial.write(1);
      Serial.flush();
    }

  
  Serial.println(pressure); //pressure_diff  pressure  mappedData
 }
