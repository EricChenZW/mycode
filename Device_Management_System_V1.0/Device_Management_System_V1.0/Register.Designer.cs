namespace Device_Management_System_V1._0
{
    partial class Register
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
            this.Password_again_textBox = new System.Windows.Forms.TextBox();
            this.Register_button = new System.Windows.Forms.Button();
            this.Scope_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Scope_description_linkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(191, 76);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(203, 21);
            this.Password_textBox.TabIndex = 8;
            // 
            // Account_textBox
            // 
            this.Account_textBox.Location = new System.Drawing.Point(191, 31);
            this.Account_textBox.Name = "Account_textBox";
            this.Account_textBox.Size = new System.Drawing.Size(203, 21);
            this.Account_textBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Account:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Confirm the password:";
            // 
            // Password_again_textBox
            // 
            this.Password_again_textBox.Location = new System.Drawing.Point(191, 123);
            this.Password_again_textBox.Name = "Password_again_textBox";
            this.Password_again_textBox.PasswordChar = '*';
            this.Password_again_textBox.Size = new System.Drawing.Size(203, 21);
            this.Password_again_textBox.TabIndex = 9;
            // 
            // Register_button
            // 
            this.Register_button.Location = new System.Drawing.Point(211, 206);
            this.Register_button.Name = "Register_button";
            this.Register_button.Size = new System.Drawing.Size(75, 23);
            this.Register_button.TabIndex = 11;
            this.Register_button.Text = "Register";
            this.Register_button.UseVisualStyleBackColor = true;
            this.Register_button.Click += new System.EventHandler(this.Register_button_Click);
            // 
            // Scope_comboBox
            // 
            this.Scope_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Scope_comboBox.FormattingEnabled = true;
            this.Scope_comboBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.Scope_comboBox.Location = new System.Drawing.Point(191, 167);
            this.Scope_comboBox.Name = "Scope_comboBox";
            this.Scope_comboBox.Size = new System.Drawing.Size(203, 20);
            this.Scope_comboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Scope:";
            // 
            // Scope_description_linkLabel
            // 
            this.Scope_description_linkLabel.AutoSize = true;
            this.Scope_description_linkLabel.Location = new System.Drawing.Point(380, 234);
            this.Scope_description_linkLabel.Name = "Scope_description_linkLabel";
            this.Scope_description_linkLabel.Size = new System.Drawing.Size(107, 12);
            this.Scope_description_linkLabel.TabIndex = 14;
            this.Scope_description_linkLabel.TabStop = true;
            this.Scope_description_linkLabel.Text = "Scope description";
            this.Scope_description_linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Scope_description_linkLabel_LinkClicked);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 255);
            this.Controls.Add(this.Scope_description_linkLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Scope_comboBox);
            this.Controls.Add(this.Register_button);
            this.Controls.Add(this.Password_again_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Account_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.TextBox Account_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Password_again_textBox;
        private System.Windows.Forms.Button Register_button;
        private System.Windows.Forms.ComboBox Scope_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel Scope_description_linkLabel;
    }
}