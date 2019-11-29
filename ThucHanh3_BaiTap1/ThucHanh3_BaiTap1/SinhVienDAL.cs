using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3_BaiTap1
{
    class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllSinhVien()
        {
            string sql = "SELECT MaSV, TenSV, NgaySinh, QueQuan, HoKhau, DiemTB, TenKhoa, GioiTinh FROM tblSinhVien LEFT JOIN tblKhoa ON tblSinhVien.MaKhoa = tblKhoa.MaKhoa";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSinhVien(tblSinhVien sv)
        {
            string sql = "INSERT INTO tblSinhVien(MaSV, TenSV, NgaySinh, QueQuan, HoKhau, DiemTB, MaKhoa, GioiTinh) VALUES(@MaSV, @TenSV, @NgaySinh, @QueQuan, @HoKhau, @DiemTB, (SELECT MaKhoa FROM tblKhoa WHERE TenKhoa = @TenKhoa), @GioiTinh)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = sv.QueQuan;
                cmd.Parameters.Add("@HoKhau", SqlDbType.NVarChar).Value = sv.HoKhau;
                cmd.Parameters.Add("@DiemTB", SqlDbType.Float).Value = sv.DiemTB;
                cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar).Value = sv.Khoa;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(tblSinhVien sv)
        {
            string sql = "UPDATE tblSinhVien SET TenSV = @TenSV, NgaySinh = @NgaySinh, QueQuan = @QueQuan, HoKhau = @HoKhau, DiemTB = @DiemTB, MaKhoa = (SELECT MaKhoa FROM tblKhoa WHERE TenKhoa = @TenKhoa), GioiTinh = @GioiTinh WHERE MaSV = @MaSV";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = sv.NgaySinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = sv.QueQuan;
                cmd.Parameters.Add("@HoKhau", SqlDbType.NVarChar).Value = sv.HoKhau;
                cmd.Parameters.Add("@DiemTB", SqlDbType.Float).Value = sv.DiemTB;
                cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar).Value = sv.Khoa;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSinhVien(tblSinhVien sv)
        {
            string sql = "DELETE tblSinhVien WHERE MaSV = @MaSV";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable FindSinhVien(string sv)
        {
            string sql = "SELECT * FROM tblSinhVien WHERE TenSV like N'%" + sv + "%'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
