using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThiCuoiKi_Bai1
{
    public partial class Form2 : Form
    {
        CodeSQL csql = new CodeSQL();
        public Form2()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            HocPhan hp = new HocPhan();
            sv.MaSV = int.Parse(txtMaSV.Text);
            sv.TenSV = txtTenSV.Text;
            sv.NamSinh = comboBoxNamSinh.Text;
            sv.QueQuan = txtQueQuan.Text;
            sv.NoiCuTru = txtNoiCuTru.Text;
            hp.MaHocPhan = int.Parse(txtMaHocPhan.Text);
            hp.TenHocPhan = txtTenHocPhan.Text;
            hp.DiemSo = txtDiemSo.Text;
            hp.DiemChu = txtDiemChu.Text;
            if(radioButtonNam.Checked) sv.GioiTinh = "Nam";
                else sv.GioiTinh = "Nữ";
            if (csql.Add(sv, hp) == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
