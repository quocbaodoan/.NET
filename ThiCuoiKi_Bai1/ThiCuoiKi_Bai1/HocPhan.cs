using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiKi_Bai1
{
    class HocPhan:SinhVien
    {
        SinhVien sv = new SinhVien();
        public int MaSV { get { return sv.MaSV; } }
        public int MaHocPhan { set; get; }
        public string TenHocPhan { set; get; }
        public string DiemSo { set; get; }
        public string DiemChu { set; get; }
    }
}
