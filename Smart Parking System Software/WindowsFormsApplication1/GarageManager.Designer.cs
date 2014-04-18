namespace WindowsFormsApplication1
{
    partial class GarageManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.disconnect_serial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.baudrate = new System.Windows.Forms.TextBox();
            this.connect_arduino = new System.Windows.Forms.Button();
            this.Available_ports = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CurrentUserInformation = new System.Windows.Forms.GroupBox();
            this.UserMoney = new System.Windows.Forms.TextBox();
            this.UserEmail = new System.Windows.Forms.TextBox();
            this.UserPhoneNum = new System.Windows.Forms.TextBox();
            this.UserRFID = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ProgState = new System.Windows.Forms.RichTextBox();
            this.status_line = new System.Windows.Forms.StatusStrip();
            this.State = new System.Windows.Forms.ToolStripStatusLabel();
            this.Logo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.CurrentUserInformation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.status_line.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.disconnect_serial);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.baudrate);
            this.panel1.Controls.Add(this.connect_arduino);
            this.panel1.Controls.Add(this.Available_ports);
            this.panel1.Location = new System.Drawing.Point(501, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 157);
            this.panel1.TabIndex = 0;
            // 
            // disconnect_serial
            // 
            this.disconnect_serial.Enabled = false;
            this.disconnect_serial.Location = new System.Drawing.Point(42, 94);
            this.disconnect_serial.Name = "disconnect_serial";
            this.disconnect_serial.Size = new System.Drawing.Size(121, 23);
            this.disconnect_serial.TabIndex = 2;
            this.disconnect_serial.Text = "Disconnect";
            this.disconnect_serial.UseVisualStyleBackColor = true;
            this.disconnect_serial.Click += new System.EventHandler(this.disconnect_serial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available Ports";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "BaudRate";
            // 
            // baudrate
            // 
            this.baudrate.Location = new System.Drawing.Point(94, 12);
            this.baudrate.Name = "baudrate";
            this.baudrate.Size = new System.Drawing.Size(100, 20);
            this.baudrate.TabIndex = 2;
            this.baudrate.Text = "9600";
            // 
            // connect_arduino
            // 
            this.connect_arduino.Location = new System.Drawing.Point(42, 65);
            this.connect_arduino.Name = "connect_arduino";
            this.connect_arduino.Size = new System.Drawing.Size(121, 23);
            this.connect_arduino.TabIndex = 1;
            this.connect_arduino.Text = "Connect to Arduino";
            this.connect_arduino.UseVisualStyleBackColor = true;
            this.connect_arduino.Click += new System.EventHandler(this.connect_arduino_Click);
            // 
            // Available_ports
            // 
            this.Available_ports.FormattingEnabled = true;
            this.Available_ports.Location = new System.Drawing.Point(94, 38);
            this.Available_ports.Name = "Available_ports";
            this.Available_ports.Size = new System.Drawing.Size(100, 21);
            this.Available_ports.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.CurrentUserInformation);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(12, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(483, 395);
            this.panel2.TabIndex = 1;
            // 
            // CurrentUserInformation
            // 
            this.CurrentUserInformation.Controls.Add(this.UserMoney);
            this.CurrentUserInformation.Controls.Add(this.UserEmail);
            this.CurrentUserInformation.Controls.Add(this.UserPhoneNum);
            this.CurrentUserInformation.Controls.Add(this.UserRFID);
            this.CurrentUserInformation.Controls.Add(this.UserName);
            this.CurrentUserInformation.Controls.Add(this.label7);
            this.CurrentUserInformation.Controls.Add(this.label6);
            this.CurrentUserInformation.Controls.Add(this.label5);
            this.CurrentUserInformation.Controls.Add(this.label4);
            this.CurrentUserInformation.Controls.Add(this.label3);
            this.CurrentUserInformation.Location = new System.Drawing.Point(9, 242);
            this.CurrentUserInformation.Name = "CurrentUserInformation";
            this.CurrentUserInformation.Size = new System.Drawing.Size(248, 139);
            this.CurrentUserInformation.TabIndex = 6;
            this.CurrentUserInformation.TabStop = false;
            this.CurrentUserInformation.Text = "Current User Information";
            // 
            // UserMoney
            // 
            this.UserMoney.Location = new System.Drawing.Point(90, 111);
            this.UserMoney.Name = "UserMoney";
            this.UserMoney.Size = new System.Drawing.Size(152, 20);
            this.UserMoney.TabIndex = 9;
            // 
            // UserEmail
            // 
            this.UserEmail.Location = new System.Drawing.Point(90, 88);
            this.UserEmail.Name = "UserEmail";
            this.UserEmail.Size = new System.Drawing.Size(152, 20);
            this.UserEmail.TabIndex = 8;
            // 
            // UserPhoneNum
            // 
            this.UserPhoneNum.Location = new System.Drawing.Point(90, 65);
            this.UserPhoneNum.Name = "UserPhoneNum";
            this.UserPhoneNum.Size = new System.Drawing.Size(152, 20);
            this.UserPhoneNum.TabIndex = 7;
            // 
            // UserRFID
            // 
            this.UserRFID.Location = new System.Drawing.Point(90, 42);
            this.UserRFID.Name = "UserRFID";
            this.UserRFID.Size = new System.Drawing.Size(152, 20);
            this.UserRFID.TabIndex = 6;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(90, 20);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(152, 20);
            this.UserName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Credit Money";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "RFID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ProgState);
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 174);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Porgram Status";
            // 
            // ProgState
            // 
            this.ProgState.Location = new System.Drawing.Point(6, 19);
            this.ProgState.Name = "ProgState";
            this.ProgState.Size = new System.Drawing.Size(457, 149);
            this.ProgState.TabIndex = 0;
            this.ProgState.Text = "";
            // 
            // status_line
            // 
            this.status_line.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.State});
            this.status_line.Location = new System.Drawing.Point(0, 497);
            this.status_line.Name = "status_line";
            this.status_line.Size = new System.Drawing.Size(709, 22);
            this.status_line.TabIndex = 2;
            this.status_line.Text = "statusStrip1";
            // 
            // State
            // 
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(118, 17);
            this.State.Text = "toolStripStatusLabel1";
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.Location = new System.Drawing.Point(103, 24);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(469, 54);
            this.Logo.TabIndex = 3;
            this.Logo.Text = "Smart Parking System";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(709, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // AddNewUser
            // 
            this.AddNewUser.Location = new System.Drawing.Point(544, 272);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(121, 23);
            this.AddNewUser.TabIndex = 5;
            this.AddNewUser.Text = "Add New User";
            this.AddNewUser.UseVisualStyleBackColor = true;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // GarageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 519);
            this.Controls.Add(this.AddNewUser);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.status_line);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GarageManager";
            this.Text = "GarageManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GarageManager_FormClosed);
            this.Load += new System.EventHandler(this.GarageManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.CurrentUserInformation.ResumeLayout(false);
            this.CurrentUserInformation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.status_line.ResumeLayout(false);
            this.status_line.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button connect_arduino;
        private System.Windows.Forms.ComboBox Available_ports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox baudrate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button disconnect_serial;
        private System.Windows.Forms.StatusStrip status_line;
        private System.Windows.Forms.ToolStripStatusLabel State;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox ProgState;
        private System.Windows.Forms.GroupBox CurrentUserInformation;
        private System.Windows.Forms.TextBox UserMoney;
        private System.Windows.Forms.TextBox UserEmail;
        private System.Windows.Forms.TextBox UserPhoneNum;
        private System.Windows.Forms.TextBox UserRFID;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button AddNewUser;
    }
}