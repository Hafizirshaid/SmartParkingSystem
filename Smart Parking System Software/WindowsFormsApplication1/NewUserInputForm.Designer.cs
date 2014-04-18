namespace WindowsFormsApplication1
{
    partial class NewUserInputForm
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
            this.Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CurrentUserInformation = new System.Windows.Forms.GroupBox();
            this.PaidOrNot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentUserInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(100, 253);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(103, 23);
            this.Save.TabIndex = 0;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CurrentUserInformation
            // 
            this.CurrentUserInformation.Controls.Add(this.PaidOrNot);
            this.CurrentUserInformation.Controls.Add(this.label2);
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
            this.CurrentUserInformation.Location = new System.Drawing.Point(100, 75);
            this.CurrentUserInformation.Name = "CurrentUserInformation";
            this.CurrentUserInformation.Size = new System.Drawing.Size(248, 172);
            this.CurrentUserInformation.TabIndex = 7;
            this.CurrentUserInformation.TabStop = false;
            this.CurrentUserInformation.Text = "Current User Information";
            // 
            // PaidOrNot
            // 
            this.PaidOrNot.DisplayMember = "Yes";
            this.PaidOrNot.FormattingEnabled = true;
            this.PaidOrNot.Location = new System.Drawing.Point(90, 135);
            this.PaidOrNot.Name = "PaidOrNot";
            this.PaidOrNot.Size = new System.Drawing.Size(152, 21);
            this.PaidOrNot.TabIndex = 11;
            this.PaidOrNot.ValueMember = "Yes";
            this.PaidOrNot.Items.Add("Yes");
            this.PaidOrNot.Items.Add("No");
            this.PaidOrNot.SelectedIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Paid or not";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "New User Information";
            // 
            // NewUserInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 330);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentUserInformation);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Save);
            this.Name = "NewUserInputForm";
            this.Text = "NewUserInputForm";
            this.Load += new System.EventHandler(this.NewUserInputForm_Load);
            this.CurrentUserInformation.ResumeLayout(false);
            this.CurrentUserInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button button2;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox PaidOrNot;
        private System.Windows.Forms.Label label2;
    }
}