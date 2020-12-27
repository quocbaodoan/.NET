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
    public partial class Form1 : Form
    {
        CodeSQL csql = new CodeSQL();
        public Form1()
        {
            InitializeComponent();
        }
        public void ShowAll()
        {
            DataTable dt = csql.Show();
            dataGridViewSinhVien.DataSource = dt;
        }
        private void BtnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = csql.Show();
            dataGridViewSinhVien.DataSource = dt;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            ShowAll();
        }


        private void BtnSua_Click(object sender, EventArgs e)
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
            if (radioButtonNam.Checked) sv.GioiTinh = "Nam";
            else sv.GioiTinh = "Nữ";
            if (csql.Update(sv, hp) == true)
            {
                ShowAll();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int index;
        private void DataGridViewSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index >= 0)
            {
                txtMaSV.Text = dataGridViewSinhVien.Rows[index].Cells["MaSV"].Value.ToString();
                txtTenSV.Text = dataGridViewSinhVien.Rows[index].Cells["TenSV"].Value.ToString();
                if (dataGridViewSinhVien.Rows[index].Cells["GioiTinh"].Value.ToString() == "Nam") radioButtonNam.Checked = true;
                else radioButtonNu.Checked = true;
                comboBoxNamSinh.Text = dataGridViewSinhVien.Rows[index].Cells["NamSinh"].Value.ToString();
                txtQueQuan.Text = dataGridViewSinhVien.Rows[index].Cells["QueQuan"].Value.ToString();
                txtNoiCuTru.Text = dataGridViewSinhVien.Rows[index].Cells["NoiCuTru"].Value.ToString();
                txtMaHocPhan.Text = dataGridViewSinhVien.Rows[index].Cells["MaHocPhan"].Value.ToString();
                txtTenHocPhan.Text = dataGridViewSinhVien.Rows[index].Cells["TenHocPhan"].Value.ToString();
                txtDiemSo.Text = dataGridViewSinhVien.Rows[index].Cells["DiemSo"].Value.ToString();
                txtDiemChu.Text = dataGridViewSinhVien.Rows[index].Cells["DiemChu"].Value.ToString();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa hay không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = int.Parse(dataGridViewSinhVien.Rows[index].Cells["MaSV"].Value.ToString());
                if (csql.Delete(sv) == true)
                {
                    ShowAll();
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
            string value2 = comboBoxSearch.Text;
            if (!string.IsNullOrEmpty(value))
            {
                DataTable dt = csql.Search(value, value2);
                dataGridViewSinhVien.DataSource = dt;
            }
            else
            {
                ShowAll();
            }
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
             string value = comboBoxSort.Text;
             DataTable dt = csql.Sort(value);
             dataGridViewSinhVien.DataSource = dt;
        }

    }
}
