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
    public partial class Device_list : Form
    {
        public Device_list()
        {
            InitializeComponent();
        }
        public class DGVset
        {
            public static void Set(Device_list form)
            {
                form.dataGridView1.RowHeadersVisible = false;    //
                                                                 //form.dataGridView1.Columns[0].Visible = false;   //隐藏列
                                                                 //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                                                 //dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);    //自动行高
                form.dataGridView1.Columns[0].Width = 80;    //指定列宽
                form.dataGridView1.Columns[1].Width = 100;
                form.dataGridView1.Columns[2].Width = 80;
                form.dataGridView1.Columns[3].Width = 60;
                form.dataGridView1.Columns[4].Width = 400;
                form.dataGridView1.Columns[5].Width = 90;
                form.dataGridView1.Columns[6].Width = 90;
                form.dataGridView1.Columns[7].Width = 220;
                //form.dataGridView1.Columns[8].Width = 200;
                //form.dataGridView1.Columns[9].Width = 200;
                form.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;    //设置显示所有字段
                form.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;    //自动调节行高
                                                                                                             //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    //设置标题栏剧中，但由于
                                                                                                             //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold); //设置标题文字
                                                                                                             //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //所有字段剧中显示
                                                                                                             //dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    //设置居中对齐
                                                                                                             //dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //设置左对齐
                                                                                                             //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //设置右对齐
                                                                                                             //设置字段的对齐方式
                for (int i = 1; i <= 6; i++)
                {
                    if (i == 4 || i == 6)
                    {
                        continue;
                    }
                    form.dataGridView1.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                //设置标题剧中
                foreach (DataGridViewColumn col in form.dataGridView1.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                form.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                GC.Collect();
            }
        }

        private void Input_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_Input_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void FlashStorage_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_FlashStorage_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void Optical_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_ODD_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void CardReader_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_CardReader_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void PrinterScanner_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_PrinterScanner_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void HUB_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_HUB_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void Audio_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_Audio_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void AccessPointStation_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_AccessPointStation_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void Adapter_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_Adapter_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void CellPhoneTable_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_CellPhoneTablet_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void MediaCard_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_MediaCard_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void DongleCable_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_DongleCable_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void DisplayTV_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_DisplayTV_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void Switch_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_Switch_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }

        private void Others_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Status,Qty_Inventory,Remake from Device_Others_List";
            DataSet data = db.DBselect(SqlText, null);
            dataGridView1.DataSource = data.Tables[0];
            DGVset.Set(this);
        }
    }
}
