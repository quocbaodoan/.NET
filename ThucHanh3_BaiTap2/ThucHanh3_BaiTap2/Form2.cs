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
    public partial class Form2 : Form
    {
        SieuThiBLL bllST;
        Form1 form1 = new Form1();
        public Form2()
        {
            InitializeComponent();
            bllST = new SieuThiBLL();
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
            if(radioButtonConHang.Checked == false && radioButtonHetHang.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        private void BtnOK_Click(object sender, EventArgs e)
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
                if (bllST.InsertSieuThi(st) == true)
                {
                    form1.ShowAllSieuThi();
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
