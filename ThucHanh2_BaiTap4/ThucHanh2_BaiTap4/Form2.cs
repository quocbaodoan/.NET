using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanh2_BaiTap4
{
    public partial class Form2 : Form
    {
        public SinhVien sv = null;
        public bool check = false;
        public Form2()
        {
            InitializeComponent();
        }
        public void BtnOK_Click(object sender, EventArgs e)
        {
            
            string masv = this.txtMaSV.Text;
            string tensv = this.txtTenSV.Text;
            string ngaysinh = this.dateSV.Text;
            string diachi = this.txtDiaChi.Text;
            string dienthoai = this.txtDienThoai.Text;
            int nienkhoa = int.Parse(this.txtNienKhoa.Text);
            if (radiobtnDaiHoc.Checked)
            {
                string chuyennganh = this.comboBoxChuyenNganh.Text;
                sv = new SinhVienDaiHoc(masv, tensv, ngaysinh, diachi, dienthoai, nienkhoa, chuyennganh);
            }
            else if (radiobtnBangHai.Checked)
            {
                string bang1 = this.txtBang1.Text;
                string congtac = this.txtCongTac.Text;
                sv = new SinhVienBangHai(masv, tensv, ngaysinh, diachi, dienthoai, nienkhoa, bang1, congtac);
            }
            else
            {
                sv = new SinhVienCaoDang(masv, tensv, ngaysinh, diachi, dienthoai, nienkhoa);
            }
            check = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            check = false;
            this.Close();
        }
    }
}
