using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_Management_System_V1._0
{
    public partial class Device_management : Form
    {
        public Device_management()
        {
            InitializeComponent();
        }

        private void Query_button_Click(object sender, EventArgs e)
        {
            string Identifier = Identifier_textBox.Text;
            if (Identifier == "")
            {
                MessageBox.Show("Identifier can not be empty!");
                return;
            }
            string Id_f = Identifier.Substring(0, 1);
            char Id_need = Convert.ToChar(Id_f);
            string Table = "";
            if (Identifier.Substring(0, 2) == "SP")
            {
                Table = "Device_Audio_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "IP")
            {
                Table = "Device_CellPhoneTablet_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "MC")
            {
                Table = "Device_MediaCard_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CA")
            {
                Table = "Device_DongleCable_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "TV")
            {
                Table = "Device_DisplayTV_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "SW")
            {
                Table = "Device_Switch_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CD")
            {
                Table = "Device_Others_List";
                goto Testc;
            }
            switch (Id_need)
            {
                case 'K':
                    Table = "Device_Input_List";
                    break;
                case 'M':
                    Table = "Device_Input_List";
                    break;
                case 'G':
                    Table = "Device_Input_List";
                    break;
                case 'F':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'S':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'O':
                    Table = "Device_ODD_List";
                    break;
                case 'C':
                    Table = "Device_CardReader_List";
                    break;
                case 'P':
                    Table = "Device_PrinterScanner_List";
                    break;
                case 'H':
                    Table = "Device_HUB_List";
                    break;
                case 'W':
                    Table = "Device_AccessPointStation_List";
                    break;
                case 'A':
                    Table = "Device_Adapter_List";
                    break;
                default:
                    Table = "Device_Others_List";
                    break;
            }
            Testc:
            DBHelper db = new DBHelper();
            string SqlText = "select * from " + Table + " where Identifier=\'" + Identifier + "\'";
            DataSet data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("This device does not exist.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GC.Collect();
                return;
            }
            Identifier_textBox.Text = (data.Tables[0].Rows[0][0]).ToString();
            Category_textBox.Text = (data.Tables[0].Rows[0][1]).ToString();
            Type_textBox.Text = (data.Tables[0].Rows[0][2]).ToString();
            Size_textBox.Text = (data.Tables[0].Rows[0][3]).ToString();
            DET_info_textBox.Text = (data.Tables[0].Rows[0][4]).ToString();
            Status_comboBox.Text = (data.Tables[0].Rows[0][5]).ToString();
            Qty_Inventory_textBox.Text = (data.Tables[0].Rows[0][6]).ToString();
            Qty_Storage_textBox.Text = (data.Tables[0].Rows[0][7]).ToString();
            Remake_textBox.Text = (data.Tables[0].Rows[0][8]).ToString();
            Other_info_textBox.Text = (data.Tables[0].Rows[0][9]).ToString();
            MessageBox.Show("Complete query.");
            GC.Collect();
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            string Identifier = Identifier_textBox.Text;
            if (Identifier == "")
            {
                MessageBox.Show("Identifier can not be empty!");
                return;
            }
            string Id_f = Identifier.Substring(0, 1);
            char Id_need = Convert.ToChar(Id_f);
            string Table = "";
            if (Identifier.Substring(0, 2) == "SP")
            {
                Table = "Device_Audio_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "IP")
            {
                Table = "Device_CellPhoneTablet_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "MC")
            {
                Table = "Device_MediaCard_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CA")
            {
                Table = "Device_DongleCable_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "TV")
            {
                Table = "Device_DisplayTV_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "SW")
            {
                Table = "Device_Switch_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CD")
            {
                Table = "Device_Others_List";
                goto Testc;
            }
            switch (Id_need)
            {
                case 'K':
                    Table = "Device_Input_List";
                    break;
                case 'M':
                    Table = "Device_Input_List";
                    break;
                case 'G':
                    Table = "Device_Input_List";
                    break;
                case 'F':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'S':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'O':
                    Table = "Device_ODD_List";
                    break;
                case 'C':
                    Table = "Device_CardReader_List";
                    break;
                case 'P':
                    Table = "Device_PrinterScanner_List";
                    break;
                case 'H':
                    Table = "Device_HUB_List";
                    break;
                case 'W':
                    Table = "Device_AccessPointStation_List";
                    break;
                case 'A':
                    Table = "Device_Adapter_List";
                    break;
                default:
                    Table = "Device_Others_List";
                    break;
            }
            Testc:
            DBHelper db = new DBHelper();
            string SqlText = "Delete from " + Table + " where Identifier=\'" + Identifier + "\'";
            DataSet data = db.DBselect(SqlText, null);
            MessageBox.Show("Complete deleting.");
            GC.Collect();
        }

        private void Alter_button_Click(object sender, EventArgs e)
        {
            string Identifier = Identifier_textBox.Text;
            string Category = Category_textBox.Text;
            string Type = Type_textBox.Text;
            string Size = Size_textBox.Text;
            string DET_info = DET_info_textBox.Text;
            string Status = Status_comboBox.Text;
            string Qty_Inventory = Qty_Inventory_textBox.Text;
            string Qty_Storage = Qty_Storage_textBox.Text;
            string Remake = Remake_textBox.Text;
            string Other_info = Other_info_textBox.Text;
            if (Identifier == "" || Category == "" || Qty_Inventory == "" || Status == "" || Qty_Storage == "")
            {
                MessageBox.Show("Please execute the query first!");
                return;
            }
            string Id_f = Identifier.Substring(0, 1);
            char Id_need = Convert.ToChar(Id_f);
            string Table = "";
            if (Identifier.Substring(0, 2) == "SP")
            {
                Table = "Device_Audio_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "IP")
            {
                Table = "Device_CellPhoneTablet_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "MC")
            {
                Table = "Device_MediaCard_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CA")
            {
                Table = "Device_DongleCable_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "TV")
            {
                Table = "Device_DisplayTV_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "SW")
            {
                Table = "Device_Switch_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CD")
            {
                Table = "Device_Others_List";
                goto Testc;
            }
            switch (Id_need)
            {
                case 'K':
                    Table = "Device_Input_List";
                    break;
                case 'M':
                    Table = "Device_Input_List";
                    break;
                case 'G':
                    Table = "Device_Input_List";
                    break;
                case 'F':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'S':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'O':
                    Table = "Device_ODD_List";
                    break;
                case 'C':
                    Table = "Device_CardReader_List";
                    break;
                case 'P':
                    Table = "Device_PrinterScanner_List";
                    break;
                case 'H':
                    Table = "Device_HUB_List";
                    break;
                case 'W':
                    Table = "Device_AccessPointStation_List";
                    break;
                case 'A':
                    Table = "Device_Adapter_List";
                    break;
                default:
                    Table = "Device_Others_List";
                    break;
            }
            Testc:
            DBHelper db = new DBHelper();
            string SqlText = "update "+Table+" set Category = N'"+ Category + "',Type = N'" + Type + "', Size = N'" + Size + "',DET_info = N'" + DET_info + "', Status = N'" + Status + "',Qty_Inventory = N'" + Qty_Inventory + "', Qty_Storage= N'" + Qty_Storage + "',Remake = N'" + Remake + "', Other_info = N'" + Other_info + "' where Identifier = '" + Identifier + "';";
            DataSet data = db.DBselect(SqlText, null);
            MessageBox.Show("Finish alter.");
            GC.Collect();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            string Identifier = Identifier_textBox.Text;
            string Category = Category_textBox.Text;
            string Type = Type_textBox.Text;
            string Size = Size_textBox.Text;
            string DET_info = DET_info_textBox.Text;
            string Status = Status_comboBox.Text;
            string Qty_Inventory = Qty_Inventory_textBox.Text;
            string Qty_Storage = Qty_Storage_textBox.Text;
            string Remake = Remake_textBox.Text;
            string Other_info = Other_info_textBox.Text;
            if (Identifier == "" || Category == "" || Qty_Inventory == "" || Status == "" || Qty_Storage =="")
            {
                MessageBox.Show("Identifier, Category, Status, Qty_Inventory and Qty_Storage can not be empty!");
                return;
            }
            string Id_f = Identifier.Substring(0, 1);
            char Id_need = Convert.ToChar(Id_f);
            string Table = "";
            if (Identifier.Substring(0, 2) == "SP")
            {
                Table = "Device_Audio_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "IP")
            {
                Table = "Device_CellPhoneTablet_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "MC")
            {
                Table = "Device_MediaCard_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CA")
            {
                Table = "Device_DongleCable_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "TV")
            {
                Table = "Device_DisplayTV_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "SW")
            {
                Table = "Device_Switch_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CD")
            {
                Table = "Device_Others_List";
                goto Testc;
            }
            switch (Id_need)
            {
                case 'K':
                    Table = "Device_Input_List";
                    break;
                case 'M':
                    Table = "Device_Input_List";
                    break;
                case 'G':
                    Table = "Device_Input_List";
                    break;
                case 'F':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'S':
                    Table = "Device_FlashStorage_List";
                    break;
                case 'O':
                    Table = "Device_ODD_List";
                    break;
                case 'C':
                    Table = "Device_CardReader_List";
                    break;
                case 'P':
                    Table = "Device_PrinterScanner_List";
                    break;
                case 'H':
                    Table = "Device_HUB_List";
                    break;
                case 'W':
                    Table = "Device_AccessPointStation_List";
                    break;
                case 'A':
                    Table = "Device_Adapter_List";
                    break;
                default:
                    Table = "Device_Others_List";
                    break;
            }
            Testc:
            DBHelper db = new DBHelper();
            string SqlText = "select * from "+ Table;
            DataSet data = db.DBselect(SqlText, null);
            if(data.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("The device has already existed.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GC.Collect();
                return;
            }
            db = new DBHelper();
            SqlText = "insert into " + Table + " values(N\'" + Identifier + "\',N\'" + Category + "\',N\'" + Type + "\',N\'" + Size + "\',N\'" + DET_info + "\',N\'" + Status + "\',\'" + Qty_Inventory + "\',\'" + Qty_Storage + "\',N\'" + Remake + "\',N\'" + Other_info + "\')";
            data = db.DBselect(SqlText, null);
            MessageBox.Show("Finish adding.");
            GC.Collect();
        }
    }
}
