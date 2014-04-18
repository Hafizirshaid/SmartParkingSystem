/*
 * 
 * Najah National University
 * Communication Engineering Department
 * Smart Parking System 
 * status character Description:
 
        O ----> open the door
 
        L ----> car wants to leave the garage 
 
        D ----> do not open the door because of some errors 
 
        S ---> shutdown the program 
 
        A -----> this is the char must received and sent by the PC to run the program on the arduino otherwise the arduino shoud not work 
 * 
 * 
 * 
 * TODO:
 *      1- update in the database the value of the money if the user is paid  ---> OK(does Not tested yet)
 *      2- send that user an email 
 *      3- open the door if the user enter the garage and the RFID does not exist in the database after the
 *          admin enter the data
 *      4- check in the login form if the user admin or not, if not, do not open this window 
 *      5- complete Email send function
 *      
 * 6- test the program 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GarageManager : Form
    {
        /// <summary>
        /// serial port object 
        /// </summary>
        private SerialPort serial_port;

        /// <summary>
        /// available serial ports on this PC 
        /// </summary>
        string[] AvailablePorts;

        /// <summary>
        /// database connection string builder 
        /// </summary>
        MySqlConnectionStringBuilder ConnectionString;

        /// <summary>
        /// database connection 
        /// </summary>
        MySqlConnection DatabaseConnection;

        /// <summary>
        /// this function is to init database connection
        /// </summary>
        private void InitDatabase()
        {
            ConnectionString = new MySqlConnectionStringBuilder();
            ConnectionString.Server = "127.0.0.1";
            ConnectionString.UserID = "root";
            ConnectionString.Password = "";
            ConnectionString.Database = "communications";
            DatabaseConnection = new MySqlConnection(ConnectionString.ToString());
        }

        /// <summary>
        /// constructor
        /// </summary>
        public GarageManager()
        {
            InitializeComponent();

            //init database connection here 
            InitDatabase();

            //statusStrip1.Text = "Arduino Disconnected!";
            AvailablePorts = SerialPort.GetPortNames();

            //store all available ports in AvailablePorts array 
            for (int i = 0; i < AvailablePorts.Length; i++)
            {
                Available_ports.Items.Add(AvailablePorts[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GarageManager_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// event handler of the start process button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // serial_port.DataReceived += serial_port_DataReceived;
            //serial_port.Write("H");
            State.Text = "Process is Running!";
        }

        /// <summary>
        /// event to handle serial port data recive 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void serial_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ProgState.AppendText("*************** New User ***************\n");

            //read the RFID

            // string RFID = serial_port.ReadExisting();
            string RFID = "";
            for (int i = 0; i < 15; i++)
            {
                RFID += (char)serial_port.ReadChar();
            }

            MessageBox.Show(RFID);
            string RF = "";
            for (int i = 0; i < 12; i++)
            {
                RF += RFID[i];

            }

            //MessageBox.Show(RF + " " + RF.Length);
            ProgState.AppendText("RFID is " + RFID);
            // richTextBox1.AppendText(RFID + "\n");
            if (RF.Length == 12)
            {
                //check this RFID 
                CheckRFIDInDatabase(RF);
            }
            else
            {
                //send to microcontroller to resend the RFID because it has some error 
                State.Text = "R";
                serial_port.Write("R");
            }

        }

        /// <summary>
        /// connect to arduino button event listener 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connect_arduino_Click(object sender, EventArgs e)
        {
            //get selected port and baud rate and connect to arduino
            string PortName = (string)Available_ports.SelectedItem;
            int Baudrate = Int32.Parse(baudrate.Text);
            serial_port = new SerialPort(PortName, Baudrate, Parity.None, 8, StopBits.One);
            serial_port.ReadTimeout = 100000;
            serial_port.Open();

            serial_port.DataReceived += serial_port_DataReceived;
            State.Text = "Connecting to arduino!";

            //this char A for acknolagemnt to check if the MCU is alive or not 
            //send this char to the 
            serial_port.Write("A");

            //wait until the ack is comming from arduino
            char ack;
            try
            {
                ack = (char)serial_port.ReadChar();
                if (ack == 'A')
                {
                    //then, all things ia fine
                    connect_arduino.Enabled = false;
                    disconnect_serial.Enabled = true;
                    State.Text = "Connected to arduino!";
                }
                else
                {
                    //maybe there are a problem
                    MessageBox.Show("A problem with arduino, check USB connection! ");
                    serial_port.Close();
                }
            }
            catch (Exception ex)
            {
                //time out execption 
                serial_port.Close();
                MessageBox.Show("A problem with arduino, check USB connection! \n" + ex.Message);
            }
        }

        /// <summary>
        /// disconnect from serial port, also you have to tell the MCU that i don't wanna send any thing, stop please 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnect_serial_Click(object sender, EventArgs e)
        {
            //this code means stop waiting command 
            serial_port.Write("S");

            ProgState.AppendText("Disconnect form arduino\n");
            State.Text = "Disconnect";

            //close the serial port 
            serial_port.Close();
            connect_arduino.Enabled = true;
            disconnect_serial.Enabled = false;
        }

        /// <summary>
        /// this code must execute if the RFID doesn't exist on the LOGIN table 
        /// </summary>
        /// <param name="RFID"></param>
        public void CheckRFIDInDatabase(string RFID)
        {
            //State.Text = "Checking RF in DB";

            //string ProgStateString = "";
            
            //open db connection
            DatabaseConnection.Open();

            //query string to insert the value to the table in the database 
            string QueryUSER = "select * from users where RFID='" + RFID + "'";

            //exectue SQL
            MySqlCommand UserQueryCommand = new MySqlCommand(QueryUSER, DatabaseConnection);

            MySqlDataReader UserReader = UserQueryCommand.ExecuteReader();

            //if reader has got a value and if RFID exists
            if (UserReader.Read())
            {
                //update current user state here ***

                UpdateUserInformation(UserReader.GetString(1), UserReader.GetString(4), UserReader.GetString(2), 
                    UserReader.GetString(5), UserReader.GetString(6));

                //check if this RFID is in login table 
                UserReader.Close();

                //check if the RFID is in the garage or not, 
                //this is done by checking the RFID in login table, if it exists there, that means the cas is already in the 
                //garage, otherwise it want to enter the garage 
                string SQLQueryLogin = String.Format("select * from login where RFID='{0}'", RFID);
                
                MySqlCommand check_login_table = new MySqlCommand(SQLQueryLogin, DatabaseConnection);

                MySqlDataReader loginReader = check_login_table.ExecuteReader();

                //check the car is in the garage or not 
                if (loginReader.Read())
                {
                    //the car is in the garage
                    //so send to the MCU command 'l' means wait until the car leave the garage and then 
                    //insert to the table garage entries its values 
                   loginReader.Close();
                   ProgState.AppendText("the car is in the garage and wanna leave \n");

                    //send to MCU leave command 
					
					/////TODO change this to O 
                    serial_port.Write("L");

                    //wait until good is received 

					///////TODO make state equals to G
                    char state = (char)serial_port.ReadChar();
                    ProgState.AppendText("I Have got a char " + state);
                    //check the state, if the car leave the garage 
                    if (state == 'G')
                    {

                        //this flag will still zero if the Date Does not Exist 
                        bool FoundDateInLoginTable = false;

                        DateTime LoginDate = DateTime.Now;
                        DateTime LeaveDate = DateTime.Now;

                          ProgState.AppendText("Calculating Money \n");
                        //car leaved the garage
                        //get enter date from login table 
                        string GetEnterDateQuery = string.Format("select enter_time_date from login where RFID='{0}'", 
                                                                RFID);
                        MySqlCommand GetEnterDateCommand = new MySqlCommand(GetEnterDateQuery, DatabaseConnection);

                        MySqlDataReader GetEnterDateReader = GetEnterDateCommand.ExecuteReader();

                        //to get the car enter date 
                        if (GetEnterDateReader.Read())
                        {
                            LoginDate = GetEnterDateReader.GetDateTime(0);
                            //LoginDate = ConvertStringToDate(LoginDateString);
                            // LoginDate = DateTime.
                            ProgState.AppendText("Login Date is " + LoginDate.ToString() + "  \n");
                            FoundDateInLoginTable = true;

                        }
                        else
                        {
                            ProgState.AppendText("Problem In Database \n");
                        }

                        //close the GetEnterDateReader 
                        GetEnterDateReader.Close();

                        if (FoundDateInLoginTable == true)
                        {
                            //delete the RFID from the login table and calclate the money
                            string DeleteCarFromLoginTableSQL = String.Format("delete from login where RFID='{0}'",
                                RFID);

                            MySqlCommand DeleteCarCommand = new MySqlCommand(DeleteCarFromLoginTableSQL, 
                                                        DatabaseConnection);

                            DeleteCarCommand.ExecuteNonQuery();

                            string LoginDateString = LoginDate.ToString("yyyy-MM-dd hh:mm:ss");
                            string LeaveDateString = LeaveDate.ToString("yyyy-MM-dd hh:mm:ss");

                            // int duration = (LeaveDate - LoginDate).Minutes;

                            ///////// here you must check if the user paid or not 

                            string CheckPaidQuery = String.Format("select paid_or_not from users where RFID='{0}'", 
                                                        RFID);

                            MySqlCommand CheckPaidQueryCommand = new MySqlCommand(CheckPaidQuery, DatabaseConnection);
                            MySqlDataReader CheckPaidReader = CheckPaidQueryCommand.ExecuteReader();

                            CheckPaidReader.Read();

                            string PaidOrNot = CheckPaidReader.GetString(0);

                            //must colse the connection 
                            CheckPaidReader.Close();
                            double discount = 0;
                            if (PaidOrNot.ToLower() == "no")
                            {

                                //calculate the discount
                                discount = CalculateMoney(LoginDate, LeaveDate);
                 
                                //get the old credit money value for this user 
                                var GetOldCreditSQL = String.Format("select credit_money from users where RFID='{0}'", 
                                                                    RFID);

                                MySqlCommand GetOldCreditCommad = new MySqlCommand(GetOldCreditSQL, 
                                                    DatabaseConnection);

                                MySqlDataReader GetOldCreditReader = GetOldCreditCommad.ExecuteReader();

                                //execute reader 
                                GetOldCreditReader.Read();

                                double OldCredit = Double.Parse(GetOldCreditReader.GetString(0));

                                GetOldCreditReader.Close();
                                
                                ProgState.AppendText("old cridit \n" + OldCredit + "\n");

                                double NewCreditMoneyValue = OldCredit - discount;
                                ProgState.AppendText("discount \n" + NewCreditMoneyValue + "\n");
                                
                                if (NewCreditMoneyValue >= 0)
                                {
                                    //Update here 
                                    var UpdateNewCreditSQL = 
                                        String.Format("update users set credit_money={0} where RFID='{1}'", 
                                                        NewCreditMoneyValue, RFID);
                                    MySqlCommand UpdateNewCreditCommand = new MySqlCommand(UpdateNewCreditSQL,
                                                    DatabaseConnection);

                                    UpdateNewCreditCommand.ExecuteNonQuery();

                                   

                                    MessageBox.Show("Updated " + discount);
                                }
                                else
                                {
                                    //the user has no money 

                                    MessageBox.Show("this user does not have enought money!");
                                }

                            }

                            ProgState.AppendText("Leave Date is " + LeaveDate + "  Duration " + discount + "\n");
                            ProgState.AppendText("Duration is " + TakeDateTimeDifference(LeaveDate, LoginDate) + "\n");
                         
                           
                            //insert into garage_entries the leave 
                            string InsertIntoGarageEntriesQuery =
                                String.Format("insert into garage_entries values(0,'{0}','{1}','{2}',{3})", 
                                                LoginDateString, LeaveDateString, RFID, discount);

                            MySqlCommand InsertIntoGarageCommand = new MySqlCommand(InsertIntoGarageEntriesQuery, 
                                                DatabaseConnection);

                            InsertIntoGarageCommand.ExecuteNonQuery();

                            //you have to calclate the duration and discount the money form the account 


                            /******** send a user an email to tell him the staff ************/
                        }
                    }
                    //problem in car leaving 
                    else
                    {
                        //the car didn't want to leave the garage, it still in the door, door sensor 
                        //problem
                        ProgState.AppendText("We Got a problem in Ack  \n");
                        MessageBox.Show("Please Leave the garage as soon as posible ");
                    }

                }
                //the car wants to enter the garage 
                else
                {
                    
                    loginReader.Close();

                    ProgState.AppendText("the car wanna enter the garage , open the door \n");
                    //here open the door 
                    OpenTheDoor();

                    //DateTime EnterDate = DateTime.Now;
                    //insert to the login table some data 

                    //string CurrentDateTime = ReturnMySQLDateFormat(EnterDate);
                    DateTime date_today = DateTime.Now;

                    string CurrentDate = date_today.ToString("yyyy-MM-dd hh:mm:ss");

                    ProgState.AppendText(String.Format("Current Date is {0} \n", CurrentDate));
                    string InsertQuery = String.Format("insert into login values(0,'{0}','{1}')", RFID, CurrentDate);
                    MySqlCommand InsertIntoLoginTable = new MySqlCommand(InsertQuery, DatabaseConnection);

                    //execute the query 
                    InsertIntoLoginTable.ExecuteNonQuery();

                    
                   ProgState.AppendText("finishing database insertion to login table \n");
                }

            }
            //here the reader does not have any value, that means the RFID does not existing 
            else
            {

                NewUserInputForm NewUserForm = new NewUserInputForm(RFID);
                NewUserForm.ShowDialog();

                if (NewUserForm.state == 0)
                {
                    serial_port.Write("D");
                }
                else if (NewUserForm.state == 1)
                {
                    serial_port.Write("O");
                }
                //if the RFID doesn't exist in db then send to serial port 'D'
                //this char means do not open the door 
                
                ProgState.AppendText(String.Format("this RFID {0} does not exist in the db, do not open the door \n", RFID));
                // status_line.Text = String.Format("this {0} does not exist in the db, do not open the door ", RFID);
            }
            DatabaseConnection.Close();
        }


        /// <summary>
        /// this function is going to send O char to serial to tell MCU that open the door 
        /// </summary>
        public void OpenTheDoor()
        {
            //send to MCU command 'O'means open the door 

            serial_port.Write("O");
        }

        /// <summary>
        /// this function used to return a string contain the date as MySQL Type wants.
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        static string ReturnMySQLDateFormat(DateTime d)
        {
            return String.Format("{0} {1}", d.ToString().Split(' ')[0], d.ToString().Split(' ')[1]);
        }

        /// <summary>
        /// this function is going to convert a string into datetime format inorder to compare it and other things 
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        private DateTime ConvertStringToDate(String Date)
        {
            int year, month, day, hour, minit, second;
            year = int.Parse(Date.Split(' ')[0].Split('-')[0]);
            month = int.Parse(Date.Split(' ')[0].Split('-')[1]);
            day = int.Parse(Date.Split(' ')[0].Split('-')[2]);
            hour = int.Parse(Date.Split(' ')[1].Split(':')[0]);
            minit = int.Parse(Date.Split(' ')[1].Split(':')[1]);
            second = int.Parse(Date.Split(' ')[1].Split(':')[2]);
            DateTime d = new DateTime(year, month, day, hour, minit, second);
            return d;
        }

        /// <summary>
        /// this function convert the date type into string 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        static string ConvertDateToString(DateTime date)
        {
            string ret = String.Format("{0}-{1}-{2} {3}:{4}:{5}", date.Year,
                date.Month, date.Day, date.Hour, date.Minute, date.Second);
            return ret;
        }

        /// <summary>
        /// stop process of receiving RFIDs from serial port 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopProcess_Click(object sender, EventArgs e)
        {
            //send S to MCU to tell him stop man, take a break 
            serial_port.Write("S");
            serial_port.DataReceived -= serial_port_DataReceived;
            State.Text = "Process is stopped!";
        }

        /// <summary>
        /// exit from the program 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GarageManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// this function have to take the differece between two dates and return the
        /// difference in minits 
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public double TakeDateTimeDifference(DateTime t1, DateTime t2)
        {
            TimeSpan t = t1.Subtract(t2);

            //return the difference 
            return Math.Abs(t.TotalMinutes);
        }

        /// <summary>
        /// this function is going to calculate how much this staying in garage does costs 
        /// </summary>
        /// <param name="EnterDate">garage enter date time</param>
        /// <param name="LeaveDate">garage leave date time </param>
        /// <returns>how much this cost </returns>
        private double CalculateMoney(DateTime EnterDate, DateTime LeaveDate)
        {

            int DollarPerMinuit = 5;
            double Duration = TakeDateTimeDifference(LeaveDate, EnterDate);
            return Math.Abs(Duration * DollarPerMinuit);
        }

        /// <summary>
        /// this is the handler of the button test Button
        /// this is just for test, i wanna test the function CheckRFIDInDatabase 
        /// and pass some value to it to test it 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestButton_Click(object sender, EventArgs e)
        {
            string RFID = "001100110011";

            CheckRFIDInDatabase(RFID);

        }

        /// <summary>
        /// this function shoud send an email to the carage user to tell him about the duration and login date and leave date 
        /// and how much does the system discount from him(money)
        /// </summary>
        /// <param name="To"> Receiver address</param>
        /// <param name="Discount">Discointed money</param>
        /// <param name="Duration">Duration</param>
        /// <param name="LoginDate"></param>
        /// <param name="LeaveDate"></param>
        private void SendUserEmail(string To, double Discount, double Duration, DateTime LoginDate, DateTime LeaveDate)
        {

            string Subject = "";
            string Body = "";

            //using smtp client 
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Timeout = 100000;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            //change here, you have to have valid email address and password 
            client.Credentials = new NetworkCredential("yourid@gmail.com", "yourgmailpassword");

            MailMessage msg = new MailMessage();

            msg.To.Add(To);
            msg.From = new MailAddress("yourid@gmail.com");
            msg.Subject = Subject;

            msg.Body = Body;
            client.Send(msg);

            MessageBox.Show("Successfully Sent Message.");
        }

        /// <summary>
        /// this function have to update the labels in the current user information 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="userRFID"></param>
        /// <param name="userPhoneNumber"></param>
        /// <param name="userEmail"></param>
        /// <param name="UserCeditMoney"></param>
        private void UpdateUserInformation(string Username, string userRFID, string userPhoneNumber, string userEmail, 
                                            string UserCeditMoney)
        {
            UserName.Text = Username;
            UserRFID.Text = userRFID;
            UserPhoneNum.Text = userPhoneNumber;
            UserEmail.Text = userEmail;
            UserMoney.Text = UserCeditMoney;
        }

        /// <summary>
        /// this event is oing to show a new dialog to enter new user data 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewUser_Click(object sender, EventArgs e)
        {
            //create object 
            NewUserInputForm NewUser = new NewUserInputForm();

            //pass database connection reference to the form 
            //NewUser.DatabaseConnection = DatabaseConnection;

            //show the dialog 
            NewUser.ShowDialog();
        }
    }
}
