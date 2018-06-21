using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Device_Management_System_V1._0
{
    class DBHelper
    {
        //string SqlText = "Data source = DESKTOP-6K25SP5; Initial Catalog = DB_Device_MS; User =sa; password =123456";
        string SqlText = "Data source = VPRO; Initial Catalog = DB_Device_MS; User =sa; password =P@ssw0rd";

        DataSet Data;

        public DataSet DBselect(string commandText, params SqlParameter[] parameters)
        {
            if (SqlText == null)
                return null;
            SqlConnection con = new SqlConnection(SqlText);
            try
            {
                var cmd = con.CreateCommand();
                cmd.CommandText = commandText;
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                Data = new DataSet();
                adpt.Fill(Data);
            }
            catch (Exception)
            {

            }
            return Data;
        }
    }
}
