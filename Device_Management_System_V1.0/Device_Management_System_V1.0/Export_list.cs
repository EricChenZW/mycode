using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Device_Management_System_V1._0
{
    public partial class Export_list : Form
    {
        public Export_list()
        {
            InitializeComponent();
            Path_textBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        }

        private void Path_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            Path_textBox.Text = path.SelectedPath;
        }

        private void Export_All_button_Click(object sender, EventArgs e)
        {
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Others_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Switch_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_DisplayTV_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_DongleCable_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_MediaCard_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_CellPhoneTablet_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Adapter_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_AccessPointStation_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Audio_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_HUB_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_PrinterScanner_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_CardReader_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_ODD_List;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_FlashStorage_List; select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Input_List";
            DataSet data = db.DBselect(SqlText);
            int DT_num = data.Tables.Count;

            string P_str_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //获取桌面路径
            //创建Excel对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //添加新工作簿
            Microsoft.Office.Interop.Excel.Workbook newWorkBook = excel.Application.Workbooks.Add(true);
            object missing = System.Reflection.Missing.Value;   //获取缺少的object类型值
            //string Sheet_Name = "teat";
            string[] Sheet_Name = { "Device_Others_List", "Device_Switch_List", "Device_DisplayTV_List", "Device_DongleCable_List", "Device_MediaCard_List", "Device_CellPhoneTablet_List", "Device_Adapter_List", "Device_AccessPointStation_List", "Device_Audio_List", "Device_HUB_List", "Device_PrinterScanner_List", "Device_CardReader_List", "Device_ODD_List", "Device_FlashStorage_List", "Device_Input_List" };
            for (int m = 0; m < data.Tables.Count; m++)
            {
                newWorkBook.Worksheets.Add(missing, missing, missing, missing); //向Excel文件中添加工作表
                Worksheet ws = (Worksheet)excel.Sheets[1];
                ws.Name = Sheet_Name[m];
                System.Data.DataTable dt = data.Tables[m];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    excel.Cells[1, i + 1] = dt.Columns[i].Caption;//输出DataGridView列头名  
                }
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)//控制Excel中行，上下的距离，就是可以到Excel最下的行数，比数据长了报错，比数据短了会显示不完
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)//控制Excel中列，左右的距离，就是可以到Excel最右的列数，比数据长了报错，比数据短了会显示不完
                        {
                            string str = dt.Rows[i][j].ToString();
                            excel.Cells[i + 2, j + 1] = "" + str;//i控制行，从Excel中第2行开始输出第一行数据，j控制列，从Excel中第1列输出第1列数据，"'" +是以string形式保存，所以遇到数字不会转成16进制
                        }
                    }
                }
                ws.Rows.RowHeight = 25;
                ws.Columns.ColumnWidth = 15;

                ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 7]).Font.Bold = 5; //设置第一行A-G为粗体
                //ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 7]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;  //设置第一行A-G居中
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 1]).ColumnWidth = 8.38;
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 2]).ColumnWidth = 20.63;
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 3]).ColumnWidth = 20.63;
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 4]).ColumnWidth = 10.63;
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 5]).ColumnWidth = 40.63;
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 6]).ColumnWidth = 13.00;
                ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 7]).ColumnWidth = 38.75;
                ws.get_Range(ws.Cells[1, 1], ws.Cells[data.Tables.Count + 1, 8]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                //((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify; //设置单元格（1，1）右对齐
                ws.get_Range(ws.Cells[2, 5], ws.Cells[data.Tables.Count + 1, 5]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;  //设置第五列右对齐（除标题）
                ws.get_Range(ws.Cells[2, 7], ws.Cells[data.Tables.Count + 1, 7]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;  //设置第五列右对齐（除标题）
            }

            if (Path_textBox.Text.EndsWith("\\"))
            {//保存Excel文件
                newWorkBook.SaveCopyAs(Path_textBox.Text + "Nexstgo Device purchase milestone for Compatibility_" + DateTime.Now.ToString("yyyyMMddhh") + ".xlsx");
            }
            else
            {//保存Excel文件
                newWorkBook.SaveCopyAs(Path_textBox.Text + "\\" + "Nexstgo Device purchase milestone for Compatibility_" + DateTime.Now.ToString("yyyyMMddhh") + ".xlsx");
            }
            //弹出提示信息
            if(Path_textBox.Text == P_str_path)
                MessageBox.Show("The Excel file is created successfully and stored on the desktop.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("The Excel file is created successfully and stored on "+ Path_textBox.Text, "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //创建进程对象
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();
        }

        private void Status_button_Click(object sender, EventArgs e)
        {
            if (Status_comboBox.Text == "")
            {
                MessageBox.Show("Status can not be empty!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string Status = Status_comboBox.Text;
            DBHelper db = new DBHelper();
            string SqlText = "select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Others_List where Status = '" + Status + "';select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Switch_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_DisplayTV_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_DongleCable_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_MediaCard_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_CellPhoneTablet_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Adapter_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_AccessPointStation_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Audio_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_HUB_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_PrinterScanner_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_CardReader_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_ODD_List where Status = '" + Status + "' ;select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_FlashStorage_List where Status = '" + Status + "' ; select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Input_List where Status = '" + Status+"'";
            DataSet data = db.DBselect(SqlText);
            int DT_num = data.Tables.Count;

            string P_str_path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //获取桌面路径
            //创建Excel对象
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //添加新工作簿
            Microsoft.Office.Interop.Excel.Workbook newWorkBook = excel.Application.Workbooks.Add(true);
            object missing = System.Reflection.Missing.Value;   //获取缺少的object类型值
            string Sheet_Name = Status_comboBox.Text;
            newWorkBook.Worksheets.Add(missing, missing, missing, missing); //向Excel文件中添加工作表
            Worksheet ws = (Worksheet)excel.Sheets[1];
            ws.Name = Sheet_Name;
            int Excel_rows = 2;
            for (int m = 0; m < DT_num; m++)
            {
                System.Data.DataTable dt = data.Tables[m];
                if (m == 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        excel.Cells[1, i + 1] = dt.Columns[i].Caption;//输出DataGridView列头名  
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    
                    
                    for (int i = 0; i < dt.Rows.Count; i++)//控制Excel中行，上下的距离，就是可以到Excel最下的行数，比数据长了报错，比数据短了会显示不完
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)//控制Excel中列，左右的距离，就是可以到Excel最右的列数，比数据长了报错，比数据短了会显示不完
                        {
                            string str = dt.Rows[i][j].ToString();
                            excel.Cells[Excel_rows + i, j + 1] = "" + str;//i控制行，从Excel中第2行开始输出第一行数据，j控制列，从Excel中第1列输出第1列数据，"'" +是以string形式保存，所以遇到数字不会转成16进制
                        }
                    }
                    Excel_rows += data.Tables[m].Rows.Count;
                }
            }
            ws.Rows.RowHeight = 25;
            ws.Columns.ColumnWidth = 15;

            ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 7]).Font.Bold = 5; //设置第一行A-G为粗体
                                                                        //ws.get_Range(ws.Cells[1, 1], ws.Cells[1, 7]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;  //设置第一行A-G居中
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 1]).ColumnWidth = 8.38;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 2]).ColumnWidth = 20.63;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 3]).ColumnWidth = 20.63;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 4]).ColumnWidth = 10.63;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 5]).ColumnWidth = 40.63;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 6]).ColumnWidth = 13.00;
            ((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 7]).ColumnWidth = 38.75;
            ws.get_Range(ws.Cells[1, 1], ws.Cells[data.Tables.Count + 1, 7]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            //((Microsoft.Office.Interop.Excel.Range)ws.Cells[1, 1]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify; //设置单元格（1，1）右对齐
            ws.get_Range(ws.Cells[2, 5], ws.Cells[data.Tables.Count + 1, 5]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;  //设置第五列右对齐（除标题）
            ws.get_Range(ws.Cells[2, 7], ws.Cells[data.Tables.Count + 1, 7]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;  //设置第五列右对齐（除标题）

            if (Path_textBox.Text.EndsWith("\\"))
            {//保存Excel文件
                newWorkBook.SaveCopyAs(Path_textBox.Text + Status_comboBox + "_Nexstgo Device purchase milestone for Compatibility_" + DateTime.Now.ToString("yyyyMMddhh") + ".xlsx");
            }
            else
            {//保存Excel文件
                newWorkBook.SaveCopyAs(Path_textBox.Text + "\\" + Status_comboBox.Text + "_Nexstgo Device purchase milestone for Compatibility_" + DateTime.Now.ToString("yyyyMMddhh") + ".xlsx");
            }
            //弹出提示信息
            if (Path_textBox.Text == P_str_path)
                MessageBox.Show("The Excel file is created successfully and stored on the desktop.", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("The Excel file is created successfully and stored on " + Path_textBox.Text, "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //创建进程对象
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProcess)
                p.Kill();
        }
    }
}
