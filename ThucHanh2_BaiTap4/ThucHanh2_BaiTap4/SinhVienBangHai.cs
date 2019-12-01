using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_BaiTap4
{
    class SinhVienBangHai : SinhVien
    {
        public string Bang1, CongTac;
        public SinhVienBangHai(string msv, string tsv, string ns, string dc, string dt, int nk, string b1, string ct) : base(msv, tsv, ns, dc, dt, nk)
        {
            this.Bang1 = b1;
            this.CongTac = ct;
        }
        public string BANG1
        {
            get
            {
                return Bang1;
            }
            set
            {
                this.Bang1 = value;
            }
        }
        public string CONGTAC
        {
            get
            {
                return CongTac;
            }
            set
            {
                this.CongTac = value;
            }
        }
        public override string LoaiHinh()
        {
            return "Bằng hai";
        }
    }
}
