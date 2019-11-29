using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanh3_BaiTap2
{
    public partial class Form1 : Form
    {
        SieuThiBLL bllST;
        public Form1()
        {
            InitializeComponent();
            bllST = new SieuThiBLL();
        }
        public void ShowAllSieuThi()
        {
            DataTable dt = bllST.getAllSieuThi();
            dataGridViewSieuThi.DataSource = dt;
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSanPham.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSanPham.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dateTimePickerNgayNhap.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerNgayNhap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(comboBoxNhaSanXuat.Text))
            {
                MessageBox.Show("Bạn chưa chọn nhà sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxNhaSanXuat.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(comboBoxTenMatHang.Text))
            {
                MessageBox.Show("Bạn chưa chọn tên mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBoxTenMatHang.Focus();
                return false;
            }
            if (radioButtonConHang.Checked == false && radioButtonHetHang.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = bllST.getAllSieuThi();
            dataGridViewSieuThi.DataSource = dt;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        int index;
        private void DataGridViewSieuThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txtMaSanPham.Text = dataGridViewSieuThi.Rows[index].Cells["MaSanPham"].Value.ToString();
                txtTenSanPham.Text = dataGridViewSieuThi.Rows[index].Cells["TenSanPham"].Value.ToString();
                dateTimePickerNgayNhap.Text = dataGridViewSieuThi.Rows[index].Cells["NgayNhap"].Value.ToString();
                comboBoxNhaSanXuat.Text = dataGridViewSieuThi.Rows[index].Cells["NhaSanXuat"].Value.ToString();
                if (dataGridViewSieuThi.Rows[index].Cells["TinhTrang"].Value.ToString() == "Còn hàng") radioButtonConHang.Checked = true;
                else radioButtonHetHang.Checked = true;
                comboBoxTenMatHang.Text = dataGridViewSieuThi.Rows[index].Cells["TenMatHang"].Value.ToString();
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                tblSieuThi st = new tblSieuThi();
                st.MaSanPham = txtMaSanPham.Text;
                st.TenSanPham = txtTenSanPham.Text;
                st.NgayNhap = dateTimePickerNgayNhap.Value;
                st.TenMatHang = comboBoxTenMatHang.Text;
                st.NhaSanXuat = comboBoxNhaSanXuat.Text;
                if (radioButtonConHang.Checked) st.TinhTrang = "Còn hàng";
                else st.TinhTrang = "Hết hàng";
                if (bllST.UpdateSieuThi(st) == true)
                {
                    ShowAllSieuThi();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra, xin thử lại sau!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tblSieuThi st = new tblSieuThi();
                st.MaSanPham = dataGridViewSieuThi.Rows[index].Cells["MaSanPham"].Value.ToString();
                if (bllST.DeleteSieuThi(st) == true)
                {
                    ShowAllSieuThi();
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
                DataTable dt = bllST.FindSieuThi(value);
                dataGridViewSieuThi.DataSource = dt;
            }
            else
            {
                ShowAllSieuThi();
            }
        }
    }
}
