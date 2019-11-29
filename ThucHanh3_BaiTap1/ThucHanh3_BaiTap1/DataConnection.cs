using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3_BaiTap1
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = "Data Source = DESKTOP-E8OHC92; Initial Catalog=ThucHanh3_BaiTap1; UID=sa; PWD=123456;";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
