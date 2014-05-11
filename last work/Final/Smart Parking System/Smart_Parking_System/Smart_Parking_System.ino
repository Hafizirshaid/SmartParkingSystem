/*
 Smart Parking system 
 
 status character meanings 
 
 O ----> open the door
 
 L ----> car wants to leave the garage 
 
 D ----> do not open the door because of some errors 
 
 R ---> resend RFID 
 
 S ----> shutdown the system 
 
 G ---> if the car wants to leave and it is really leaved the garage 
 
 */


//this is for the press button to send RFID to computer when this button is pressed 
int button = 0;

//this is flag i will toggle it when the button is pressed 
int button_state = 0;

//
const int buttonPin0 = A0;

//this is used for DEBUGING
#include <SoftwareSerial.h>

SoftwareSerial Debug(5, 6); // RX, TX

//////////////////////////////
SoftwareSerial mySerial(2, 3); // RX, TX
int i=0;
int a_card=1;
 int m_card=1; 
byte data1[16];
byte aya[16]= {2,48,49,48,51,69,53,70,49,53,70,52,57,13,10,3};
byte mais[16]={2,48,49,48,51,66,69,67,52,57,49,69,57,13,10,3};

///////////////////////////////////


//this to indicate if the car is leaving the garage or not 
#define CARLEAVE 1
#define CARNOTLEAVE 0

//this function to check the sensors that tell us the car do really leaved 
int check_car_leave()
{

   
  delay(2000);
  return CARLEAVE;
  //this function is going to check if the car really leave the garage  
}

//this code is going to open the door
void open_door()
{
  //this is also must close when the car pass the door sensors 
  //Serial.print("Car is Leaving");
  //write the code to open the door 
}


void chek_Identity()
{
  //Serial.print("hhhhhhhhhhhhhh");
  
  //Serial.print(a_card);
  
  if(a_card==1 )
  {
    if(i!=0)
    {
      //Serial.println("Hello, aya? all gate open to you");
      open_gate();
    }
  }
  /*if(m_card==1 )
    if(i!=0)*/
      //Serial.println("sory, mais? no permission to entrance");
  i=0;
  a_card=1;
  m_card=1; 

}
void open_gate(){
  digitalWrite(buttonPin0,HIGH);
  delay (1500);
  digitalWrite(buttonPin0,LOW);
  delay (1500);
}


//this function is going to read RFID number from the reader 
String read_RFID()
{
  //replace this code with read RFID from RFID sensor 
  return "001100110011";
}

void setup()
{
  Serial.begin(9600);
  Debug.begin(9600);
  mySerial.begin(9600);
  pinMode(buttonPin0, OUTPUT);
  //attachInterrupt(button,change_button_state , LOW);

}

//this function will execute when button is pressed 
void change_button_state()
{
  //button_state
  /*
  if(button_state == 0)
   {
   button_state = 1; 
   }
   else if(button_state == 1)
   {
   button_state = 0; 
   }*/
  Debug.println("RFID Reading...");
  Serial.print("001100110011");
}
//flag to know the state of the program 
// 0 means wait until the PC connect 
//1 means the program is running 
int Program_State = 0;


//main MCU loop 
void loop()
{
  Debug.println("*********************************************************************");
  //check program state, if 0 then wait computer to connect 
  if(Program_State == 0)
  {
    Debug.println("Program Start...");
    Debug.println("Wait Computer To connect...");

    //wait until computer connect and send char 'A' 
    while(!Serial.available());
    
    //read the command from the compter 
    char start_command = (char) Serial.read();

    //if computer send A then all things is right 
    if(start_command == 'A')
    {
      Debug.println("PC is Ready...");
      Serial.print("A");

      //set program state 1 that means the computer send A 
      Program_State = 1;
    }
    else
    {
      Debug.println("Problem in Starting the program...");
    }
  }
  else
  {


    Serial.flush();
    Debug.println("****************************");
    Debug.println("Start of loop ");
  //Serial.print("****************");
    //this is for simulation issues
    //read RFID 
    //String RFID = read_RFID();


  chek_Identity();
while(!mySerial.available());

  for(int x=0;x<16;x++)
  //while(mySerial.available())
  {

   data1[i]=mySerial.read();
    delay(10);
     Serial.write(data1[i]);
     if (data1[i] != aya[i]) a_card = 0;
     if (data1[i] != mais[i]) m_card = 0;
    
     i++;
   
    }
  
  //Serial.print("*************");
  
    //send RFID to the computer 
    //Serial.print("001100110011");

    /*
    if(button_state == 1)
     {
     Serial.print("001100110011");
     }*/

    Debug.println("Start Debugging...");
    Debug.println("Waiting for a command...");
    //wait until computer send the command 
    while(!Serial.available());

    //read the command from the compter 
    char command = (char) Serial.read();

    Debug.print("I have a command : ");
    Debug.println(command);

    //check the command and execute the operation 
    if(command == 'O')
    {
      //open the door 
      Debug.println("Open the Door");
      open_door();
    }
    else if(command == 'D')
    {
      //don't open the door 
      Debug.println("Don't Open the door");
      //Serial.println("don't open the door");
    }
    else if(command == 'L')
    {
      Debug.println("wait car to leave");

      //wait until the car leaving 
      //must check leaving sensor if the car really leave the garage 
      int car_state = check_car_leave();
      if(car_state == CARLEAVE)
      {
        //send ack to the computer to do his works 
        Serial.write("G");
        Debug.println("leaved");
      }
      else
      {
        //send negative ack to pc to tell him that this kid is kidding 
        // Serial.print("Not OK");
        Debug.println("Car didn't leave");
      }
    }
    else if(command == 'R')
    {
      Debug.println("error in sending RFID to PC");
      //this means that the RFID is less than 12 char so resend RFID 
    }
    else if(command == 'S')
    {
      //shut down the program and wait until PC connect again 
      Debug.println("Stop the Program..."); 

      //stop the program 
      Program_State = 0;
    }
    /*else if(command == 'H')
     {
     //this for the program to send RFID 
     Serial.write("001100110011");
     Debug.println("Send RFID to Computer to process it ");
     }*/
    else 
    {
      //unknown error 
      //Serial.print(command);
      //Serial.println("UNKNOWN ERROR!");
      Debug.println("Unknown Eroor");
    }
    Debug.println("End of Loop ");
    Debug.println("****************************");
    Serial.flush();
    //delay(1000);
  }
}


