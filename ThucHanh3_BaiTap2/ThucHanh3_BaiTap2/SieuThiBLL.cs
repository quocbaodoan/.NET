using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3_BaiTap2
{
    class SieuThiBLL
    {
        SieuThiDAL dalST;
        public SieuThiBLL()
        {
            dalST = new SieuThiDAL();
        }
        public DataTable getAllSieuThi()
        {
            return dalST.getAllSieuThi();
        }
        public bool InsertSieuThi(tblSieuThi st)
        {
            return dalST.InsertSieuThi(st);
        }
        public bool UpdateSieuThi(tblSieuThi st)
        {
            return dalST.UpdateSieuThi(st);
        }
        public bool DeleteSieuThi(tblSieuThi st)
        {
            return dalST.DeleteSieuThi(st);
        }
        public DataTable FindSieuThi(string st)
        {
            return dalST.FindSieuThi(st);
        }
    }
}
