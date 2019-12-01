using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_BaiTap4
{
    class SinhVienDaiHoc : SinhVien
    {

        public string ChuyenNganh;
        public SinhVienDaiHoc(string msv, string tsv, string ns, string dc, string dt, int nk, string cn) : base(msv, tsv, ns, dc, dt, nk)
        {
            this.ChuyenNganh = cn;
        }
        public string CHUYENNGANH   
        {
            get
            {
                return ChuyenNganh;
            }
            set
            {
                this.ChuyenNganh = value;
            }
        }
        public override string LoaiHinh()
        {
            return "Đại học";
        }
    }
}
