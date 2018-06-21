namespace Device_Management_System_V1._0
{
    partial class Export_list
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.Path_textBox = new System.Windows.Forms.TextBox();
            this.Path_button = new System.Windows.Forms.Button();
            this.Export_All_button = new System.Windows.Forms.Button();
            this.Status_comboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Status_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // Path_textBox
            // 
            this.Path_textBox.Location = new System.Drawing.Point(87, 48);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(531, 21);
            this.Path_textBox.TabIndex = 1;
            // 
            // Path_button
            // 
            this.Path_button.Location = new System.Drawing.Point(617, 47);
            this.Path_button.Name = "Path_button";
            this.Path_button.Size = new System.Drawing.Size(34, 23);
            this.Path_button.TabIndex = 2;
            this.Path_button.Text = "...";
            this.Path_button.UseVisualStyleBackColor = true;
            this.Path_button.Click += new System.EventHandler(this.Path_button_Click);
            // 
            // Export_All_button
            // 
            this.Export_All_button.Location = new System.Drawing.Point(520, 99);
            this.Export_All_button.Name = "Export_All_button";
            this.Export_All_button.Size = new System.Drawing.Size(131, 23);
            this.Export_All_button.TabIndex = 3;
            this.Export_All_button.Text = "Export all list";
            this.Export_All_button.UseVisualStyleBackColor = true;
            this.Export_All_button.Click += new System.EventHandler(this.Export_All_button_Click);
            // 
            // Status_comboBox
            // 
            this.Status_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Status_comboBox.FormattingEnabled = true;
            this.Status_comboBox.Items.AddRange(new object[] {
            "Normal",
            "Damaged",
            "To be added"});
            this.Status_comboBox.Location = new System.Drawing.Point(87, 152);
            this.Status_comboBox.Name = "Status_comboBox";
            this.Status_comboBox.Size = new System.Drawing.Size(257, 20);
            this.Status_comboBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "Status:";
            // 
            // Status_button
            // 
            this.Status_button.Location = new System.Drawing.Point(520, 149);
            this.Status_button.Name = "Status_button";
            this.Status_button.Size = new System.Drawing.Size(131, 23);
            this.Status_button.TabIndex = 18;
            this.Status_button.Text = "Export Status list";
            this.Status_button.UseVisualStyleBackColor = true;
            this.Status_button.Click += new System.EventHandler(this.Status_button_Click);
            // 
            // Export_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 226);
            this.Controls.Add(this.Status_button);
            this.Controls.Add(this.Status_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Export_All_button);
            this.Controls.Add(this.Path_button);
            this.Controls.Add(this.Path_textBox);
            this.Controls.Add(this.label1);
            this.Name = "Export_list";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export list";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Path_textBox;
        private System.Windows.Forms.Button Path_button;
        private System.Windows.Forms.Button Export_All_button;
        private System.Windows.Forms.ComboBox Status_comboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Status_button;
    }
}