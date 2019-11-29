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
    public partial class Form1 : Form
    {
        SinhVienBLL bllSV;
        public Form1()
        {
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }
        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridViewSinhVien.DataSource = dt;
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
        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridViewSinhVien.DataSource = dt;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        int index;
        private void DataGridViewSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txtMaSV.Text = dataGridViewSinhVien.Rows[index].Cells["MaSV"].Value.ToString();
                txtTenSV.Text = dataGridViewSinhVien.Rows[index].Cells["TenSV"].Value.ToString();
                dateTimePickerNgaySinh.Text = dataGridViewSinhVien.Rows[index].Cells["NgaySinh"].Value.ToString();
                comboBoxQueQuan.Text = dataGridViewSinhVien.Rows[index].Cells["QueQuan"].Value.ToString();
                txtHoKhau.Text = dataGridViewSinhVien.Rows[index].Cells["HoKhau"].Value.ToString();
                txtDiemTB.Text = dataGridViewSinhVien.Rows[index].Cells["DiemTB"].Value.ToString();
                comboBoxKhoa.Text = dataGridViewSinhVien.Rows[index].Cells["TenKhoa"].Value.ToString();
                if (dataGridViewSinhVien.Rows[index].Cells["GioiTinh"].Value.ToString() == "Nam") radioButtonMale.Checked = true; 
                else radioButtonFemale.Checked = true;
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSinhVien sv = new tblSinhVien();
                sv.MaSV = dataGridViewSinhVien.Rows[index].Cells["MaSV"].Value.ToString();
                if (bllSV.DeleteSinhVien(sv) == true)
                {
                    ShowAllSinhVien();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
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
                if (bllSV.UpdateSinhVien(sv) == true)
                {
                    ShowAllSinhVien();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string value = txtSearch.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = bllSV.FindSinhVien(value);
                dataGridViewSinhVien.DataSource = dt;
            }
            else
            {
                ShowAllSinhVien();
            }
        }
    }
}
