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

using System.Security.Cryptography;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
       /* private void button1_Click(object sender, EventArgs e)
        {
            
            //connection string builder helps me to build the connection string to connect to MySQL database server
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "";
            conn_string.Database = "communications";
            
            //put the connection string in the label 
            label1.Text = conn_string.ToString();

            //MySQL connection referecnce 
            MySqlConnection myConnection = new MySqlConnection(conn_string.ToString());

            //open connection
            myConnection.Open();

            //query string to insert the value to the table in the database 
            string query = "insert into hafiz values(0,'10dgbag')";

            //exectue SQL
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.ExecuteNonQuery();
         
            //close connection
            myConnection.Close();
        }
        */
        private void button2_Click(object sender, EventArgs e)
        {
            string user_name = username.Text;
            string pass_word = password.Text;
            
            string PasswordMD5 = ModelClass.MD5_Function(pass_word);

            //MessageBox.Show(user_name + "  " + pass_word + "  " + PasswordMD5);
            //check login state 
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "";
            conn_string.Database = "communications";

            //put the connection string in the label 
            //label1.Text = conn_string.ToString();

            //MySQL connection referecnce 
            MySqlConnection myConnection = new MySqlConnection(conn_string.ToString());

            //open connection
            myConnection.Open();

            //query string to insert the value to the table in the database 
            string query = "select * from users where name='" + user_name + "'";
            //string query = "select * from users";
            //exectue SQL
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);

            MySqlDataReader myReader;
            myReader = myCommand.ExecuteReader();
            // Always call Read before accessing data.
            if (myReader.Read())
            {
                string PasswordStoredInDatabase = myReader.GetString(8);

                if (PasswordStoredInDatabase == PasswordMD5)
                {
                    //this is good
 
                    //hide this form 
                    this.Hide();

                    //show garage manager form 
                    GarageManager g = new GarageManager();
                    g.Show();
                    //hide this form and show the pther form 
                }
                else
                {
                    MessageBox.Show("Password Error");
                }
            }
            else
            {
                MessageBox.Show("Username Error");
            }

            // always call Close when done reading.
            myReader.Close();

            //if true hide this form and show other form 
            myConnection.Close();
            //else 
            //error alert 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewUserInputForm ff = new NewUserInputForm();

             MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "127.0.0.1";
            conn_string.UserID = "root";
            conn_string.Password = "";
            conn_string.Database = "communications";

            //put the connection string in the label 
            //label1.Text = conn_string.ToString();

            //MySQL connection referecnce 
            MySqlConnection myConnection = new MySqlConnection(conn_string.ToString());

            //open connection
            myConnection.Open();


           // ff.DatabaseConnection = myConnection;
            ff.ShowDialog();

           // MessageBox.Show("skfoisfugihgv");
        }

     
    }
}
