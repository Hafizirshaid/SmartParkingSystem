/**
 * 
 * this form has to add new user into database 
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class NewUserInputForm : Form
    {

        /// <summary>
        /// database connection regerence 
        /// </summary>
        private MySqlConnection DatabaseConnection;
        MySqlConnectionStringBuilder ConnectionString;

        private void InitDatabase()
        {
            ConnectionString = new MySqlConnectionStringBuilder();
            ConnectionString.Server = "127.0.0.1";
            ConnectionString.UserID = "root";
            ConnectionString.Password = "";
            ConnectionString.Database = "communications";
            DatabaseConnection = new MySqlConnection(ConnectionString.ToString());
            DatabaseConnection = new MySqlConnection(ConnectionString.ToString());
            DatabaseConnection.Open();
        }


        /// <summary>
        /// this var to hold if the user enter his information or press cancel, in order to open or close the door 
        /// </summary>
        public int state;
        public NewUserInputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// if the caller give an RFID as a parameter 
        /// </summary>
        /// <param name="RFID">the RFID </param>
        public NewUserInputForm(string RFID)
        {
            InitializeComponent();
            UserRFID.Enabled = false;
            UserRFID.Text = RFID;
        }
        /// <summary>
        /// this function must add the user into the database 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="RFID"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <param name="CreditMoney"></param>
        /// <param name="PaidOrNot"></param>
        private int AddNewUser(string Name, string RFID, string PhoneNumber, string Email, string CreditMoney, string PaidOrNot)
        {
            this.InitDatabase();
            //to store the registration date 
            DateTime RegistrationDate = DateTime.Now;

            //convert the date into MySQL format 
            string RegistrationDateString = RegistrationDate.ToString("yyyy-MM-dd hh:mm:ss");

            //password shoud be encrepted 
            string Password =  ModelClass.MD5_Function("123456");
           // DatabaseConnection.Open();
            //the query to insert the new user into the database 
            string InsetNewUserSQL =
                String.Format("insert into users values(0,'{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','no')",
                Name, PhoneNumber, RegistrationDate, RFID, Email, CreditMoney, PaidOrNot, Password);

            //execute the command 
            MySqlCommand InsertNewUserCommand = new MySqlCommand(InsetNewUserSQL, DatabaseConnection);
            int ERRORCODE = InsertNewUserCommand.ExecuteNonQuery();

            return ERRORCODE;
        }

        /// <summary>
        /// save, insert this user in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            //execute the function add new user 
            int ERROR_CODE = 
                AddNewUser(UserName.Text, UserRFID.Text, UserPhoneNum.Text, UserEmail.Text, UserMoney.Text, PaidOrNot.Text);

            //print the message 
            MessageBox.Show("Inserted in to database , " + ERROR_CODE);

            state = 1;
            //hide the form 
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            state = 0;
            this.Hide();
        }

        private void NewUserInputForm_Load(object sender, EventArgs e)
        {

        }
    }
}
