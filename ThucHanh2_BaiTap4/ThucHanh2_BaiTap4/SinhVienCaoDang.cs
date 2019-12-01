using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_BaiTap4
{
    class SinhVienCaoDang : SinhVien
    {
        public SinhVienCaoDang(string msv, string tsv, string ns, string dc, string dt, int nk) : base(msv, tsv, ns, dc, dt, nk)
        {
        }
        public override string LoaiHinh()
        {
            return "Cao đẳng";
        }
    }
}
