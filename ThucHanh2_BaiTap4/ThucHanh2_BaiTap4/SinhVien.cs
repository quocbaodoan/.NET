using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh2_BaiTap4
{
    public class SinhVien
    {
        public string MaSV;
        public string TenSV;
        public string NgaySinh;
        public string DiaChi;
        public string DienThoai;
        public int NienKhoa;
        public SinhVien(string msv, string tsv, string ns, string dc, string dt, int nk)
        {
            this.MaSV = msv;
            this.TenSV = tsv;
            this.NgaySinh = ns;
            this.DiaChi = dc;
            this.DienThoai = dt;
            this.NienKhoa = nk;
        }
        public string MASV
        {
            get
            {
                return MaSV;
            }
            set
            {
                this.MaSV = value;
            }
        }
        public string TENSV
        {
            get
            {
                return TenSV;
            }
            set
            {
                this.TenSV = value;
            }
        }
        public string NGAYSINH
        {
            get
            {
                return NgaySinh;
            }
            set
            {
                this.NgaySinh = value;
            }
        }
        public string DIACHI
        {
            get
            {
                return DiaChi;
            }
            set
            {
                this.DiaChi = value;
            }
        }
        public string DIENTHOAI
        {
            get
            {
                return DienThoai;
            }
            set
            {
                this.DienThoai = value;
            }
        }
        public int NIENKHOA
        {
            get
            {
                return NienKhoa;
            }
            set
            {
                this.NienKhoa = value;
            }
        }
        public virtual string LoaiHinh()
        {
            return "Sinh vien";
        }
    }
}
