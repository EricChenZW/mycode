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
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Device_Management_System_V1._0
{
    public partial class Login : Form
    {
        [DllImport("wininet")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);
        public Login()
        {
            InitializeComponent();
            //int ip = 0;
            //if (InternetGetConnectedState(out int ip, 0))   //检测是否连接网络
            //{
            //    Ping pingSender = new Ping();
            //    PingReply reply = pingSender.Send("10.0.0.1", 120);//第一个参数为ip地址，第二个参数为ping的时间
            //    if (reply.Status != IPStatus.Success)
            //    {
            //        MessageBox.Show("Please check the network and unable to find the server. The program will be introduced.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Environment.Exit(0);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Not connected to the network, please connect. The program will be introduced.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Environment.Exit(0);
            //}
        }
        public static string Account_n;   //将用户名传递到其他窗体
        private void Login_Load(object sender, EventArgs e)
        {

        }
        int count = 0;
        private void Login_button_Click(object sender, EventArgs e)
        {
            Account_n = Account_textBox.Text;
            if (Account_textBox.Text == "" || Password_textBox.Text == "")
            {
                MessageBox.Show("Account and password can not be empty!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DBHelper db = new DBHelper();
            string SqlText = "select * from Admin where Account = @username and Password = @password";
            SqlParameter Acount = new SqlParameter("@username", Account_textBox.Text.Trim());
            SqlParameter Password = new SqlParameter("@password", Password_textBox.Text.Trim());
            if (count < 3)
            {
                count++;

                DataSet data = db.DBselect(SqlText, Acount, Password);
                if (data.Tables[0].Rows.Count == 0)
                {
                    SqlText = "select * from Users where Account = @username and Password = @password";
                    Acount = new SqlParameter("@username", Account_textBox.Text.Trim());
                    Password = new SqlParameter("@password", Password_textBox.Text.Trim());
                    data = db.DBselect(SqlText, Acount, Password);
                    if (data.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("The account does not exist or the password is incorrect.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Device_Management_System forms = new Device_Management_System();
                        forms.Show();
                        this.Hide();
                    }
                    //MessageBox.Show("The account does not exist or the password is incorrect.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Device_Management_System forms = new Device_Management_System();
                    forms.Show();
                    this.Hide();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        //private void Register_button_Click(object sender, EventArgs e)
        //{
        //    Register form = new Register();
        //    form.Show();
        //}

        private void Change_password_button_Click(object sender, EventArgs e)
        {
            Change_password form = new Change_password();
            form.Show();
        }
    }
}
