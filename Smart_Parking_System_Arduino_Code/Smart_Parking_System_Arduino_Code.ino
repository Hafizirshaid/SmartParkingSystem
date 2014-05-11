/*
 Smart Parking system 
 
 status character meanings 
 
 O ----> open the door
 
 L ----> car wants t o leave the garage 
 
 D ----> do not open the door because of some errors 
 
 R ---> resend RFID 
 
 S ----> shutdown the system 
 
 G ---> if the car wants to leave and it is really leaved the garage 
 
 */
//this is used for DEBUGING
#include <SoftwareSerial.h>
#include <Servo.h> 

Servo myservo;  // create servo object to control a servo 
// a maximum of eight servo objects can be created 

int pos = 0;    // variable to store the servo position 

//////////////////////////////
SoftwareSerial mySerial(2, 3); // RX, TX

//this code is going to open the door
void open_door()
{

  for(pos = 90; pos < 170; pos += 1)  // goes from 0 degrees to 180 degrees 
  {                                  // in steps of 1 degree 
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  }
  delay(2000);
  for(pos = 170; pos>=90; pos-=1)     // goes from 180 degrees to 0 degrees 
  {                                
    myservo.write(pos);              // tell servo to go to position in variable 'pos' 
    delay(15);                       // waits 15ms for the servo to reach the position 
  }  
}

void setup()
{
  Serial.begin(9600);
   myservo.attach(9);  // attaches the servo on pin 9 to the servo object 
  mySerial.begin(9600);
}
//flag to know the state of the program 
// 0 means wait until the PC connect 
//1 means the program is running 
int Program_State = 0;
byte data[16];

void print_RFID()
{
  int ii = 0;
  //while(!mySerial.available());
  while(mySerial.available())
  {
    char b = mySerial.read();
    // Serial.print(b);
    data[ii] = b;
    ii++;
    delay(10);
   // while(!mySerial.available());
  }

  for(int i = 1; i < 11; i++)
  {
    Serial.print((char)data[i]); 
  }
  //Serial.println("");
  //Serial.println("i is ");
  //Serial.println(ii);
}
int first_time = 0;

//main MCU loop 
void loop()
{
  if(first_time == 0)
  {
    myservo.write(90);            
    first_time = 1;
  }
  
  //check program state, if 0 then wait computer to connect 
  if(Program_State == 0)
  {
    //wait until computer connect and send char 'A' 
    while(!Serial.available());

    //read the command from the compter 
    char start_command = (char) Serial.read();

    //if computer send A then all things is right 
    if(start_command == 'A')
    {
      // Debug.println("PC is Ready...");
      Serial.print("A");

      //set program state 1 that means the computer send A 
      Program_State = 1;
    }
  }
  else
  {
    //  Serial.flush();
    //Serial.println("Waitingvvv RFID ");
    while(!mySerial.available());
    print_RFID();
    
   // Serial.println("Finished ");

    while(!Serial.available());

    //read the command from the compter 
    char command = (char) Serial.read();

    //check the command and execute the operation 
    if(command == 'O')
    {
      //open the door 
      //   Debug.println("Open the Door");
      open_door();
    }
    else if(command == 'D')
    {
      //don't open the door 
      // Debug.println("Don't Open the door");
      //Serial.println("don't open the door");
    }
    else if(command == 'L')
    {
      //send ack to the computer to do his works 
      Serial.write("G");
      //    Debug.println("leaved");
    }
    else if(command == 'R')
    {
      // Debug.println("error in sending RFID to PC");
      //this means that the RFID is less than 12 char so resend RFID 
    }
    else if(command == 'S')
    {
      //shut down the program and wait until PC connect again 
      //   Debug.println("Stop the Program..."); 

      //stop the program 
      Program_State = 0;
    }
  }
}


