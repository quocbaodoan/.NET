using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3_BaiTap1
{
    class SinhVienBLL
    {
        SinhVienDAL dalSV;
        public SinhVienBLL()
        {
            dalSV = new SinhVienDAL();
        }
        public DataTable getAllSinhVien()
        {
            return dalSV.getAllSinhVien();
        }
        public bool InsertSinhVien(tblSinhVien sv)
        {
            return dalSV.InsertSinhVien(sv);
        }
        public bool UpdateSinhVien(tblSinhVien sv)
        {
            return dalSV.UpdateSinhVien(sv);
        }
        public bool DeleteSinhVien(tblSinhVien sv)
        {
            return dalSV.DeleteSinhVien(sv);
        }
        public DataTable FindSinhVien(string sv)
        {
            return dalSV.FindSinhVien(sv);
        }
    }
}
