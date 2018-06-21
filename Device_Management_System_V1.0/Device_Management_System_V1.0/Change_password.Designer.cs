namespace Device_Management_System_V1._0
{
    partial class Change_password
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
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Account_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.New_textBox = new System.Windows.Forms.TextBox();
            this.Again_textBox = new System.Windows.Forms.TextBox();
            this.Change_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(179, 88);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(203, 21);
            this.Password_textBox.TabIndex = 12;
            // 
            // Account_textBox
            // 
            this.Account_textBox.Location = new System.Drawing.Point(179, 43);
            this.Account_textBox.Name = "Account_textBox";
            this.Account_textBox.Size = new System.Drawing.Size(203, 21);
            this.Account_textBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Old password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Account:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "New password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "Confirm the password:";
            // 
            // New_textBox
            // 
            this.New_textBox.Location = new System.Drawing.Point(179, 134);
            this.New_textBox.Name = "New_textBox";
            this.New_textBox.PasswordChar = '*';
            this.New_textBox.Size = new System.Drawing.Size(203, 21);
            this.New_textBox.TabIndex = 15;
            // 
            // Again_textBox
            // 
            this.Again_textBox.Location = new System.Drawing.Point(179, 178);
            this.Again_textBox.Name = "Again_textBox";
            this.Again_textBox.PasswordChar = '*';
            this.Again_textBox.Size = new System.Drawing.Size(203, 21);
            this.Again_textBox.TabIndex = 16;
            // 
            // Change_button
            // 
            this.Change_button.Location = new System.Drawing.Point(213, 236);
            this.Change_button.Name = "Change_button";
            this.Change_button.Size = new System.Drawing.Size(75, 23);
            this.Change_button.TabIndex = 17;
            this.Change_button.Text = "Change";
            this.Change_button.UseVisualStyleBackColor = true;
            this.Change_button.Click += new System.EventHandler(this.Change_button_Click);
            // 
            // Change_password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 288);
            this.Controls.Add(this.Change_button);
            this.Controls.Add(this.Again_textBox);
            this.Controls.Add(this.New_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Account_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Change_password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.TextBox Account_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox New_textBox;
        private System.Windows.Forms.TextBox Again_textBox;
        private System.Windows.Forms.Button Change_button;
    }
}