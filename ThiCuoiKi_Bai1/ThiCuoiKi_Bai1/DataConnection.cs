using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiKi_Bai1
{
    class DataConnection
    {
        public string con;
        public DataConnection()
        {
            con = "Data Source=DESKTOP-E8OHC92;Initial Catalog=ThiCuoiKi;UID=sa; PWD=123456";
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(con);
        }
    }
}
