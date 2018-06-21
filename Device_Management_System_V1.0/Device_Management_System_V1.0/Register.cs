using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Device_Management_System_V1._0
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            MessageBox.Show("Scope options:\n\rA: Input Device, Cell Phone&Tablet\n\rB: Flash&Storage, Optical Drive, Others\n\rC: CardReader, Adapter Charger, Hub, Media Card, Dongle&Cable\n\rD: Display&TV\r\nE: Audio Device\r\nF: Access Point&Station, Prineter& Scanner, Switch", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            if (Account_textBox.Text == "" || Password_textBox.Text == "" || Password_again_textBox.Text == "" || Scope_comboBox.Text == "")
            {
                MessageBox.Show("Account, Password, Confirm the password and Scope can not be empty!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (((Password_textBox.Text).Length) > 16)
            {
                MessageBox.Show("The password can't exceed 16 bits!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Password_textBox.Text != Password_again_textBox.Text)
            {
                MessageBox.Show("The password is not consistent with confirm the password!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DBHelper db = new DBHelper();
            string SqlText = "select * from Users where Account = @Account";
            SqlParameter Account = new SqlParameter("@Account", Account_textBox.Text.Trim());
            SqlParameter Password = new SqlParameter("@Password", Password_textBox.Text.Trim());
            DataSet data = db.DBselect(SqlText, Account);
            //label1.Text = (data.Tables[0].Rows.Count).ToString();
            if (data.Tables[0].Rows.Count == 1)
            {

                MessageBox.Show("Account already exists.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlText = "insert into Users values(N'" + Account_textBox.Text + "',N'" + Password_textBox.Text + "',N'" + Scope_comboBox.Text + "')";
                data = db.DBselect(SqlText);
                string Account_n = Account_textBox.Text;
                SqlText = @"create table Log_Borrow_" + Account_n + @"(ID int primary key identity(1,1),Identifier nvarchar(6),Borrower nvarchar(16) not null,Extension nvarchar(11) null,Date_of_borrowing nvarchar(12) null,Return_data nvarchar(12) null,Remake ntext null)";
                data = db.DBselect(SqlText);
                MessageBox.Show("Complete.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Scope_description_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Scope options:\n\rA: Input Device, Cell Phone&Tablet\n\rB: Flash&Storage, Optical Drive, Others\n\rC: CardReader, Adapter Charger, Hub, Media Card, Dongle&Cable\n\rD: Display&TV\r\nE: Audio Device\r\nF: Access Point&Station, Prineter& Scanner, Switch", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
