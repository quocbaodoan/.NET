using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanh3_BaiTap1
{
    public partial class Form2 : Form
    {
        SinhVienBLL bllSV;
        Form1 form1 =  new Form1();
        public Form2()
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(comboBoxQueQuan.Text))
            {
                MessageBox.Show("Bạn chưa chọn quê quán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtHoKhau.Text))
            {
                MessageBox.Show("Bạn chưa nhập hộ khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoKhau.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiemTB.Text))
            {
                MessageBox.Show("Bạn chưa nhập điểm trung bình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiemTB.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(comboBoxKhoa.Text))
            {
                MessageBox.Show("Bạn chưa nhập khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (radioButtonMale.Checked == false && radioButtonFemale.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblSinhVien sv = new tblSinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.TenSV = txtTenSV.Text;
                sv.NgaySinh = dateTimePickerNgaySinh.Value;
                sv.QueQuan = comboBoxQueQuan.Text;
                sv.HoKhau = txtHoKhau.Text;
                sv.DiemTB = double.Parse(txtDiemTB.Text);
                sv.Khoa = comboBoxKhoa.Text;
                if (radioButtonMale.Checked) sv.GioiTinh = "Nam";
                else sv.GioiTinh = "Nữ";
                if (bllSV.InsertSinhVien(sv) == true)
                {
                    form1.ShowAllSinhVien();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
