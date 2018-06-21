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
    public partial class Change_password : Form
    {
        public Change_password()
        {
            InitializeComponent();
        }

        private void Change_button_Click(object sender, EventArgs e)
        {
            if (Account_textBox.Text == "" || Password_textBox.Text == "" || New_textBox.Text == "" || Again_textBox.Text == "")
            {
                MessageBox.Show("Account, Old password, New password and Confirm the password can not be empty!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (((New_textBox.Text).Length) > 16)
            {
                MessageBox.Show("The new password can't exceed 16 bits!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (New_textBox.Text != Again_textBox.Text)
            {
                MessageBox.Show("The new password is not consistent with confirm the password!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DBHelper db = new DBHelper();
            string SqlText = "select * from Admin where Account='" + Account_textBox.Text + "';";
            SqlParameter Account = new SqlParameter("@Account", Account_textBox.Text.Trim());
            SqlParameter Password = new SqlParameter("@Password", Password_textBox.Text.Trim());
            DataSet data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count > 0)
            {
                db = new DBHelper();
                SqlText = "select * from Admin where Account = @Account and Password = @Password";
                data = db.DBselect(SqlText, Account, Password);
                //label1.Text = (data.Tables[0].Rows.Count).ToString();
                if (data.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("The old password is incorrect.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    SqlText = "update Admin set Password = N'" + New_textBox.Text + "' where Account = N'" + Account_textBox.Text + "'";
                    data = db.DBselect(SqlText);
                    MessageBox.Show("Complete.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            //DBHelper db = new DBHelper();
            SqlText = "select * from Users where Account = @Account and Password = @Password";
            //SqlParameter Account = new SqlParameter("@Account", Account_textBox.Text.Trim());
            //SqlParameter Password = new SqlParameter("@Password", Password_textBox.Text.Trim());
            data = db.DBselect(SqlText, Account, Password);
            //label1.Text = (data.Tables[0].Rows.Count).ToString();
            if (data.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("The account does not exist or the old password is incorrect.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlText = "update Users set Password = N'" + New_textBox.Text + "' where Account = N'"+ Account_textBox.Text + "'";
                data = db.DBselect(SqlText);
                MessageBox.Show("Complete.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
