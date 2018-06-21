using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.Collections;

namespace Device_Management_System_V1._0
{
    public partial class Device_Management_System : Form
    {
        string Account_n = Login.Account_n; //获取登录的用户名
        public static string Refresh_SqlText = "";
        public static string[] TableArr;
        public Device_Management_System()
        {
            InitializeComponent();
            label1.Text = Account_n;
            DBHelper db = new DBHelper();
            string SqlText = "select * from Admin where Account='"+Account_n +"';";
            DataSet data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count == 0)
            {
                db = new DBHelper();
                SqlText = "select * from Users where Account='" + Account_n + "';";
                data = db.DBselect(SqlText, null);
                char Scope = Convert.ToChar(data.Tables[0].Rows[0][2]);
                switch (Scope)
                {
                    case 'A':
                        Refresh_SqlText = "select * from Borrow_Device_Input_List where Return_data is NUll union all select * from Borrow_Device_CellPhoneTablet_List where Return_data is NUll";
                        TableArr =  new string []{ "Borrow_Device_Input_List", "Borrow_Device_CellPhoneTablet_List" };
                        break;
                    case 'B':
                        Refresh_SqlText = "select * from Borrow_Device_FlashStorage_List where Return_data is NUll union all select * from Borrow_Device_ODD_List where Return_data is NUll union all select * from Device_Others_List where Return_data is NUll";
                        TableArr = new string[] { "Borrow_Device_FlashStorage_List", "Borrow_Device_ODD_List", "Device_Others_List" };
                        break;
                    case 'C':
                        Refresh_SqlText = "select * from Borrow_Device_CardReader_List where Return_data is NUll union all select * from Borrow_Device_HUB_List where Return_data is NUll union all select * from Borrow_Device_Adapter_List where Return_data is NUll union all select * from Borrow_Device_MediaCard_List where Return_data is NUll  union all select * from Borrow_Device_DongleCable_List where Return_data is NUll";
                        TableArr = new string[] { "Borrow_Device_CardReader_List", "Borrow_Device_HUB_List", "Borrow_Device_Adapter_List", "Borrow_Device_MediaCard_List", "Borrow_Device_DongleCable_List" };
                        break;
                    case 'D':
                        Refresh_SqlText = "select * from Borrow_Device_DisplayTV_List where Return_data is NUll";
                        TableArr = new string[] { "Borrow_Device_DisplayTV_List" };
                        break;
                    case 'E':
                        Refresh_SqlText = "select * from Borrow_Device_Audio_List where Return_data is NUll";
                        TableArr = new string[] { "Borrow_Device_Audio_List" };
                        break;
                    case 'F':
                        Refresh_SqlText = "select * from Borrow_Device_PrinterScanner_List where Return_data is NUll union all select * from Borrow_Device_AccessPointStation_List where Return_data is NUll union all select * from Borrow_Device_Switch_List where Return_data is NUll";
                        TableArr = new string[] { "Borrow_Device_PrinterScanner_List", "Borrow_Device_AccessPointStation_List", "Borrow_Device_Switch_List" };
                        break;
                }
                DGVset.Refresh(this);
                DGVset.Set(this);
            } 
            else
            {
                Borrow_button.Enabled = false;
                Return_button.Enabled = false;
                Not_Returned_button.Enabled = false;
                Returned_log_button.Enabled = false;
                Add_User_linkLabel.Visible = true;
            }
        }

        public class DGVset //用来设置dataGridView1的显示格式
        {
            public static void Set(Device_Management_System form)  //参数获取窗体对象
            {
                form.dataGridView1.RowHeadersVisible = false;    //
                                                                 //form.dataGridView1.Columns[0].Visible = false;   //隐藏列
                                                                 //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                                                                 //dataGridView1.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);    //自动行高
                form.dataGridView1.Columns[0].Width = 80;    //指定列宽
                form.dataGridView1.Columns[1].Width = 120;
                form.dataGridView1.Columns[2].Width = 80;
                form.dataGridView1.Columns[3].Width = 120;
                form.dataGridView1.Columns[4].Width = 120;
                form.dataGridView1.Columns[5].Width = 180;
                //form.dataGridView1.Columns[6].Width = 200;
                form.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;    //设置显示所有字段
                form.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;    //自动调节行高
                                                                                                             //dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    //设置标题栏剧中，但由于
                                                                                                             //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold); //设置标题文字
                                                                                                             //dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //所有字段剧中显示
                                                                                                             //dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;    //设置居中对齐
                                                                                                             //dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //设置左对齐
                                                                                                             //dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  //设置右对齐
                                                                                                             //设置字段的对齐方式
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 5)
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
            public static void Refresh(Device_Management_System form)
            {
                DBHelper db = new DBHelper();
                //string SqlText = "select * from Borrow_Device_Input_List";
                //string SqlText = "select * from Borrow_Device_Input_List union all select * from Borrow_Device_FlashStorage_List";
                string SqlText = Refresh_SqlText;
                DataSet data = db.DBselect(SqlText, null);
                form.dataGridView1.DataSource = data.Tables[0];
            }
            public static void Dis_btn(Device_Management_System form)
            {
                form.Not_Returned_button.Enabled = false;
                form.Returned_log_button.Enabled = false;
                form.Borrow_button.Enabled = false;
                form.Return_button.Enabled = false;
            }
            public static void En_btn(Device_Management_System form)
            {
                form.Not_Returned_button.Enabled = true;
                form.Returned_log_button.Enabled = true;
                form.Borrow_button.Enabled = true;
                form.Return_button.Enabled = true;
            }
        }

        private void Device_List_button_Click(object sender, EventArgs e)
        {
            Device_list forms = new Device_list();
            forms.Show();
        }

        private void Device_Management_button_Click(object sender, EventArgs e)
        {
            Device_management forms = new Device_management();
            forms.Show();
        }

        private void Export_List_button_Click(object sender, EventArgs e)
        {
            Export_list forms = new Export_list();
            forms.Show();
        }

        private void Returned_log_button_Click(object sender, EventArgs e)
        {
            DGVset.Dis_btn(this);
            string message = "";
            try
            {
                Object Nothing = System.Reflection.Missing.Value;
                //Directory.CreateDirectory("C:/CNSI");  //创建文件所在目录
                string D_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //获取桌面的路径
                string name = Account_n+"_Controller_device_borrowing_record" + DateTime.Now.ToString("yyyyMMddhh") + ".doc";
                object filename = D_path + "/" + name;  //文件保存路径
                                                        //创建Word文档

                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

                WordApp.Selection.ParagraphFormat.LineSpacing = 20f;//设置文档的行间距

                //设置页边距
                Microsoft.Office.Interop.Word.Document wordDoc;
                Microsoft.Office.Interop.Word.Application wordApp;
                wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                wordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式为A4纸
                wordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientPortrait;//排列方式为垂直方向
                WordDoc.PageSetup.LeftMargin = 40.0f;
                WordDoc.PageSetup.RightMargin = 40.0f;
                WordDoc.PageSetup.TopMargin = 40.0f;
                WordDoc.PageSetup.BottomMargin = 40.0f;

                DBHelper db = new DBHelper();
                string SqlText = "select * from log_Borrow_"+Account_n;
                DataSet data = db.DBselect(SqlText, null);

                int test = 0;
                if (data.Tables[0].Rows.Count % 27 != 0)
                    test = 1;
                int numb = 0;
                if (data.Tables[0].Rows.Count <= 27)
                    numb = 28;
                else
                {

                    numb = data.Tables[0].Rows.Count + data.Tables[0].Rows.Count / 27 + test;
                }

                //文档中创建表格
                Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, numb, 7, ref Nothing, ref Nothing);

                //设置表格样式
                newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
                newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                newTable.Columns[1].Width = 30f;
                newTable.Columns[2].Width = 55f;
                newTable.Columns[3].Width = 70f;
                newTable.Columns[4].Width = 70f;
                newTable.Columns[5].Width = 70f;
                newTable.Columns[6].Width = 70f;
                newTable.Columns[7].Width = 150f;

                //填充表格内容
                for (int i = 1; i <= numb; i = i + 28)
                {
                    newTable.Cell(i, 1).Range.Text = "ID";
                    newTable.Cell(i, 2).Range.Text = "Identifier";
                    newTable.Cell(i, 3).Range.Text = "Borrower";
                    newTable.Cell(i, 4).Range.Text = "Extension";
                    newTable.Cell(i, 5).Range.Text = "Borrow data";
                    newTable.Cell(i, 6).Range.Text = "Return data";
                    newTable.Cell(i, 7).Range.Text = "Remake";
                    for (int j = 1; j <= 7; j++)
                    {
                        newTable.Cell(i, j).Range.Bold = 2;
                    }
                }

                int cellstr1 = 2;
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    //string ll = data.Tables[0].Rows[i][0].ToString();
                    //newTable.Cell(i, 1).Range.Text = ll;
                    //这种语句,可根据Rows[][]取到任一行任一列的值.
                    if (i % 27 == 0)
                    {
                        if (i == 0)
                        {
                            goto Test;
                        }
                        cellstr1 = cellstr1 + 1;
                    }
                    Test:
                    for (int j = 0; j < data.Tables[0].Columns.Count; j++)
                    {
                        string gg = data.Tables[0].Rows[i][j].ToString();
                        newTable.Cell(i + cellstr1, j + 1).Range.Text = gg;
                    }

                }

                //移动焦点并换行
                object count = numb;
                object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                WordApp.Selection.TypeParagraph();//插入段落

                //WordDoc.Paragraphs.Last.Range.Text = "文档创建时间：" + DateTime.Now.ToString();//“落款”
                //WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

                //文件保存
                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                message = name + "\nExport the records of borrowed. \nPath: " + D_path + "(Desktop)";
                MessageBox.Show(message, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                message = "文件导出异常！";
            }
            //return message;
            DGVset.En_btn(this);
        }

        private void Not_Returned_button_Click(object sender, EventArgs e)
        {
            DGVset.Dis_btn(this);
            string message = "";
            try
            {
                Object Nothing = System.Reflection.Missing.Value;
                //Directory.CreateDirectory("C:/CNSI");  //创建文件所在目录
                string D_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //获取桌面的路径
                string name = Account_n+"_Controller_device_borrowing_NR_record" + DateTime.Now.ToString("yyyyMMddhh") + ".doc";
                object filename = D_path + "/" + name;  //文件保存路径
                                                        //创建Word文档

                Microsoft.Office.Interop.Word.Application WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                Microsoft.Office.Interop.Word.Document WordDoc = WordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

                WordApp.Selection.ParagraphFormat.LineSpacing = 20f;//设置文档的行间距

                //设置页边距
                Microsoft.Office.Interop.Word.Document wordDoc;
                Microsoft.Office.Interop.Word.Application wordApp;
                wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                wordDoc.PageSetup.PaperSize = Microsoft.Office.Interop.Word.WdPaperSize.wdPaperA4;//设置纸张样式为A4纸
                wordDoc.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientPortrait;//排列方式为垂直方向
                WordDoc.PageSetup.LeftMargin = 40.0f;
                WordDoc.PageSetup.RightMargin = 40.0f;
                WordDoc.PageSetup.TopMargin = 40.0f;
                WordDoc.PageSetup.BottomMargin = 40.0f;

                DBHelper db = new DBHelper();
                string SqlText = Refresh_SqlText+" order by Borrower";
                DataSet data = db.DBselect(SqlText, null);

                int test = 0;
                if (data.Tables[0].Rows.Count % 27 != 0)
                    test = 1;
                int numb = 0;
                if (data.Tables[0].Rows.Count <= 27)
                    numb = 28;
                else
                {

                    numb = data.Tables[0].Rows.Count + data.Tables[0].Rows.Count / 27 + test;
                }

                //文档中创建表格
                Microsoft.Office.Interop.Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, numb, 7, ref Nothing, ref Nothing);

                //设置表格样式
                newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleThickThinLargeGap;
                newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                newTable.Columns[1].Width = 30f;
                newTable.Columns[2].Width = 55f;
                newTable.Columns[3].Width = 70f;
                newTable.Columns[4].Width = 70f;
                newTable.Columns[5].Width = 70f;
                newTable.Columns[6].Width = 70f;
                newTable.Columns[7].Width = 150f;

                //填充表格内容
                for (int i = 1; i <= numb; i = i + 28)
                {
                    newTable.Cell(i, 1).Range.Text = "ID";
                    newTable.Cell(i, 2).Range.Text = "Identifier";
                    newTable.Cell(i, 3).Range.Text = "Borrower";
                    newTable.Cell(i, 4).Range.Text = "Extension";
                    newTable.Cell(i, 5).Range.Text = "Borrow data";
                    newTable.Cell(i, 6).Range.Text = "Return data";
                    newTable.Cell(i, 7).Range.Text = "Remake";
                    for (int j = 1; j <= 7; j++)
                    {
                        newTable.Cell(i, j).Range.Bold = 2;
                    }
                }

                //DBHelper db = new DBHelper();
                //string SqlText = "select * from log_Borrow_Sundy";
                //DataSet data = db.DBselect(SqlText, null);
                int cellstr1 = 2;
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    //string ll = data.Tables[0].Rows[i][0].ToString();
                    //newTable.Cell(i, 1).Range.Text = ll;
                    //这种语句,可根据Rows[][]取到任一行任一列的值.
                    if (i % 27 == 0)
                    {
                        if (i == 0)
                        {
                            goto Test;
                        }
                        cellstr1 = cellstr1 + 1;
                    }
                    Test:
                    for (int j = 0; j < data.Tables[0].Columns.Count; j++)
                    {
                        newTable.Cell(i + cellstr1, 1).Range.Text = i.ToString();
                        string gg = data.Tables[0].Rows[i][j].ToString();
                        newTable.Cell(i + cellstr1, j + 2).Range.Text = gg;
                    }

                }

                //移动焦点并换行
                object count = numb;
                object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                WordApp.Selection.MoveDown(ref WdLine, ref count, ref Nothing);//移动焦点
                WordApp.Selection.TypeParagraph();//插入段落

                //WordDoc.Paragraphs.Last.Range.Text = "文档创建时间：" + DateTime.Now.ToString();//“落款”
                //WordDoc.Paragraphs.Last.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;

                //文件保存
                WordDoc.SaveAs(ref filename, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                WordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
                WordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
                message = name + "\nExport the record that is not returned. \nPath: " + D_path + "(Desktop)";
                MessageBox.Show(message, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                message = "文件导出异常！";
            }
            //return message;
            DGVset.En_btn(this);
        }

        private void Borrow_button_Click(object sender, EventArgs e)
        {
            string Identifier = Identifier_textBox.Text;
            string Borrower = Borrower_textBox.Text;
            string Extension = Extension_textBox.Text;
            string Date_of_borrowing = Date_of_borrowing_textBox.Text;
            string Remake = Remake_textBox.Text;
            if (Identifier == "" || Borrower == "" || Date_of_borrowing == "")
            {
                MessageBox.Show("Identifier, Borrower, Date_of_borrowing and Return_data can not be empty!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Id_f = Identifier.Substring(0, 1);
            char Id_need = Convert.ToChar(Id_f);
            string Table = "";
            if (Identifier.Substring(0, 2) == "SP")
            {
                Table = "Borrow_Device_Audio_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "IP")
            {
                Table = "Borrow_Device_CellPhoneTablet_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "MC")
            {
                Table = "Borrow_Device_MediaCard_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CA")
            {
                Table = "Borrow_Device_DongleCable_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "TV")
            {
                Table = "Borrow_Device_DisplayTV_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "SW")
            {
                Table = "Borrow_Device_Switch_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CD")
            {
                Table = "Borrow_Device_Others_List";
                goto Testc;
            }
            switch (Id_need)
            {
                case 'K':
                    Table = "Borrow_Device_Input_List";
                    break;
                case 'M':
                    Table = "Borrow_Device_Input_List";
                    break;
                case 'G':
                    Table = "Borrow_Device_Input_List";
                    break;
                case 'F':
                    Table = "Borrow_Device_FlashStorage_List";
                    break;
                case 'S':
                    Table = "Borrow_Device_FlashStorage_List";
                    break;
                case 'O':
                    Table = "Borrow_Device_ODD_List";
                    break;
                case 'C':
                    Table = "Borrow_Device_CardReader_List";
                    break;
                case 'P':
                    Table = "Borrow_Device_PrinterScanner_List";
                    break;
                case 'H':
                    Table = "Borrow_Device_HUB_List";
                    break;
                case 'W':
                    Table = "Borrow_Device_AccessPointStation_List";
                    break;
                case 'A':
                    Table = "Borrow_Device_Adapter_List";
                    break;
                default:
                    Table = "Borrow_Device_Others_List";
                    break;
            }
            Testc:
            DBHelper db = new DBHelper();
            string SqlText = "select * from "+Table + " where Identifier = '"+ Identifier +"'";
            DataSet data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count>0)
            {
                MessageBox.Show("The device has been borrowed.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool exists = ((IList)TableArr).Contains(Table);
            if (!exists)
            {
                MessageBox.Show("This device does not belong to "+Account_n+" management.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            db = new DBHelper();
            string Test_Table = Table.Remove(0,7);
            SqlText = "select * from " + Test_Table + " where Identifier = '" + Identifier + "'";
            data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("This device does not exist.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //label1.Text = Table;
            db = new DBHelper();
            SqlText = "insert into " + Table + " values(N\'" + Identifier + "\',N\'" + Borrower + "',N\'" + Extension + "\',N\'" + Date_of_borrowing + "\',null,N\'" + Remake + "')";
            data = db.DBselect(SqlText, null);
            DGVset.Refresh(this);
            DGVset.Set(this);
        }

        private void Return_button_Click(object sender, EventArgs e)
        {
            string Identifier = Identifier_r_textBox.Text;
            string Return_data = Returen_datatextBox.Text;
            string Into_table_Name = "Log_Borrow_" + Account_n;
            if (Identifier == "" || Return_data == "")
            {
                MessageBox.Show("Identifier and Return_data can not be empty!");
                return;
            }
            string Id_f = Identifier.Substring(0, 1);
            char Id_need = Convert.ToChar(Id_f);
            string Table = "";
            if (Identifier.Substring(0, 2) == "SP")
            {
                Table = "Borrow_Device_Audio_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "IP")
            {
                Table = "Borrow_Device_CellPhoneTablet_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "MC")
            {
                Table = "Borrow_Device_MediaCard_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CA")
            {
                Table = "Borrow_Device_DongleCable_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "TV")
            {
                Table = "Borrow_Device_DisplayTV_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "SW")
            {
                Table = "Borrow_Device_Switch_List";
                goto Testc;
            }
            if (Identifier.Substring(0, 2) == "CD")
            {
                Table = "Borrow_Device_Others_List";
                goto Testc;
            }
            switch (Id_need)
            {
                case 'K':
                    Table = "Borrow_Device_Input_List";
                    break;
                case 'M':
                    Table = "Borrow_Device_Input_List";
                    break;
                case 'G':
                    Table = "Borrow_Device_Input_List";
                    break;
                case 'F':
                    Table = "Borrow_Device_FlashStorage_List";
                    break;
                case 'S':
                    Table = "Borrow_Device_FlashStorage_List";
                    break;
                case 'O':
                    Table = "Borrow_Device_ODD_List";
                    break;
                case 'C':
                    Table = "Borrow_Device_CardReader_List";
                    break;
                case 'P':
                    Table = "Borrow_Device_PrinterScanner_List";
                    break;
                case 'H':
                    Table = "Borrow_Device_HUB_List";
                    break;
                case 'W':
                    Table = "Borrow_Device_AccessPointStation_List";
                    break;
                case 'A':
                    Table = "Borrow_Device_Adapter_List";
                    break;
                default:
                    Table = "Borrow_Device_Others_List";
                    break;
            }
            Testc:
            DBHelper db = new DBHelper();
            string Test_Table = Table.Remove(0, 7);
            string SqlText = "select * from " + Test_Table + " where Identifier = '" + Identifier + "'";
            DataSet  data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("This device does not exist.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            db = new DBHelper();
            SqlText = "select * from " + Table + " where Identifier = '" + Identifier + "'";
            data = db.DBselect(SqlText, null);
            if (data.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("The device has returned or does not exist.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            db = new DBHelper();
            SqlText = "update " + Table + " set Return_data=N'" + Return_data + "' where Identifier = N'" + Identifier + "'";
            data = db.DBselect(SqlText, null);
            SqlText = "insert into "+ Into_table_Name +"(Identifier,Borrower,Extension,Date_of_borrowing,Return_data,Remake) select * from " + Table + " where Identifier = '" + Identifier + "'";
            db.DBselect(SqlText, null);
            SqlText = "Delete from " + Table + " where Identifier='" + Identifier + "'";
            db.DBselect(SqlText, null);
            DGVset.Refresh(this);
            DGVset.Set(this);
        }

        private void Device_Management_System_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Add_User_linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register forms = new Register();
            forms.Show();
        }
    }
}
