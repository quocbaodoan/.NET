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
    public partial class Form1 : Form
    {
        public ArrayList StudentList = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }
        private void RadiobtnDaiHoc_CheckedChanged(object sender, EventArgs e)
        {
            txtBang1.ReadOnly = true;
            txtCongTac.ReadOnly = true;
            comboBoxChuyenNganh.Enabled = true;
        }
        private void RadiobtnBangHai_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxChuyenNganh.Enabled = false;
            txtBang1.ReadOnly = false;
            txtCongTac.ReadOnly = false;
        }
        private void RadiobtnCaoDang_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxChuyenNganh.Enabled = false;
            txtBang1.ReadOnly = true;
            txtCongTac.ReadOnly = true;
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.check == true)
            {
                StudentList.Add(form2.sv);
                UpdateList();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedList;
            SelectedList = listViewSinhVien.SelectedItems;
            foreach (ListViewItem item in SelectedList)
            {
                string masv = item.Text;
                foreach (SinhVien sv in StudentList)
                {
                    if (sv.MASV == masv)
                    {
                        StudentList.Remove(sv);
                        break;
                    }
                }
            }
            UpdateList();
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedList;
            SelectedList = listViewSinhVien.SelectedItems;
            foreach (ListViewItem item in SelectedList)
            {
                string ms = item.Text;
                foreach (SinhVien sv in StudentList)
                {
                    if (sv.MASV == ms)
                    {
                        StudentList.Remove(sv);
                        SinhVien sv1 = null;
                        string masv = this.txtMaSV.Text;
                        string tensv = this.txtTenSV.Text;
                        string ngaysinh = this.dateSV.Text;
                        string diachi = this.txtDiaChi.Text;
                        string dienthoai = this.txtDienThoai.Text;
                        int nienkhoa = int.Parse(this.txtNienKhoa.Text);
                        if (radiobtnDaiHoc.Checked)
                        {
                            string chuyennganh = this.comboBoxChuyenNganh.Text;
                            sv1 = new SinhVienDaiHoc(masv, tensv, ngaysinh, diachi, dienthoai, nienkhoa, chuyennganh);
                        }
                        else if (radiobtnBangHai.Checked)
                        {
                            string bang1 = this.txtBang1.Text;
                            string congtac = this.txtCongTac.Text;
                            sv1 = new SinhVienBangHai(masv, tensv, ngaysinh, diachi, dienthoai, nienkhoa, bang1, congtac);
                        }
                        else if (radiobtnCaoDang.Checked)
                        {
                            sv1 = new SinhVienCaoDang(masv, tensv, ngaysinh, diachi, dienthoai, nienkhoa);
                        }

                        this.StudentList.Add(sv1);
                        break;
                        
                    }
                }
            }
            UpdateList();
        }
        private void ListViewSinhVien_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection SelectedList;
            SelectedList = listViewSinhVien.SelectedItems;
            foreach (ListViewItem item in SelectedList)
            {
                string masv = item.Text;
                foreach (SinhVien sv in StudentList)
                {
                    if (sv.MASV == masv)
                    {
                        txtMaSV.Text = sv.MASV;
                        txtTenSV.Text = sv.TENSV;
                        dateSV.Text = sv.NgaySinh;
                        txtDiaChi.Text = sv.DIACHI;
                        txtDienThoai.Text = sv.DIENTHOAI;
                        txtNienKhoa.Text = sv.NIENKHOA.ToString();
                        if (sv.LoaiHinh() == "Đại học")
                        {
                            radiobtnDaiHoc.Checked = true;
                            RadiobtnDaiHoc_CheckedChanged(sender, e);
                        }
                        else if (sv.LoaiHinh() == "Bằng hai")
                        {
                            radiobtnBangHai.Checked = true;
                            RadiobtnBangHai_CheckedChanged(sender, e);
                        }
                        else if(sv.LoaiHinh() == "Cao đẳng")
                        {
                            radiobtnCaoDang.Checked = true;
                            RadiobtnCaoDang_CheckedChanged(sender, e);
                        }
                    }
                }
            }
        }

        public void UpdateList()
        {
            listViewSinhVien.Items.Clear();
            int i = 0;
            foreach(SinhVien sv in StudentList) 
            {
                ListViewItem item = new ListViewItem(sv.MASV, i++);
                item.SubItems.Add(sv.TENSV);
                item.SubItems.Add(sv.NGAYSINH.ToString());
                item.SubItems.Add(sv.DIACHI);
                item.SubItems.Add(sv.DienThoai);
                item.SubItems.Add(sv.NIENKHOA.ToString());
                item.SubItems.Add(sv.LoaiHinh());
                listViewSinhVien.Items.Add(item);
            }
        }
    }
}
