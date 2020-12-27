using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ThiCuoiKi_Bai1
{
    class CodeSQL
    {
        DataConnection dc = new DataConnection();
        SqlDataAdapter da;
        SqlCommand cmd;
        public DataTable Show()
        {
            string sql = "SELECT SINHVIEN.MaSV, TenSV, GioiTinh, NamSinh, QueQuan, NoiCuTru, MaHocPhan, TenHocPhan, DiemSo, DiemChu FROM SINHVIEN LEFT JOIN HOCPHAN ON SINHVIEN.MaSV = HOCPHAN.MaSV";
            SqlConnection con = dc.getConnect();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(sql, con);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
            }
            return dt;
        }
        public bool Add(SinhVien sv, HocPhan hp)
        {
            string sql = "INSERT INTO SINHVIEN(MaSV, TenSV, GioiTinh, NamSinh, QueQuan, NoiCuTru) VALUES (@MaSV, @TenSV, @GioiTinh, @NamSinh, @QueQuan, @NoiCuTru); INSERT INTO HOCPHAN(MaHocPhan, TenHocPhan, DiemSo, DiemChu, MaSV) VALUES(@MaHocPhan, @TenHocPhan, @DiemSo, @DiemChu, @MaSV);";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.Int).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                cmd.Parameters.Add("@NamSinh", SqlDbType.NVarChar).Value = sv.NamSinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = sv.QueQuan;
                cmd.Parameters.Add("@NoiCuTru", SqlDbType.NVarChar).Value = sv.NoiCuTru;
                cmd.Parameters.Add("@MaHocPhan", SqlDbType.Int).Value = hp.MaHocPhan;
                cmd.Parameters.Add("@TenHocPhan", SqlDbType.NVarChar).Value = hp.TenHocPhan;
                cmd.Parameters.Add("@DiemSo", SqlDbType.NVarChar).Value = hp.DiemSo;
                cmd.Parameters.Add("@DiemChu", SqlDbType.NVarChar).Value = hp.DiemChu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool Update(SinhVien sv, HocPhan hp)
        {
            string sql = "UPDATE SINHVIEN SET TenSV = @TenSV, GioiTinh = @GioiTinh, NamSinh = @NamSinh, QueQuan = @QueQuan, NoiCuTru = @NoiCuTru WHERE MaSV = @MaSV; UPDATE HOCPHAN SET MaHocPhan = @MaHocPhan, TenHocPhan = @TenHocPhan, DiemSo = @DiemSo, DiemChu = @DiemChu WHERE MaSV = @MaSV;";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.Int).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                cmd.Parameters.Add("@NamSinh", SqlDbType.NVarChar).Value = sv.NamSinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = sv.QueQuan;
                cmd.Parameters.Add("@NoiCuTru", SqlDbType.NVarChar).Value = sv.NoiCuTru;
                cmd.Parameters.Add("@MaHocPhan", SqlDbType.Int).Value = hp.MaHocPhan;
                cmd.Parameters.Add("@TenHocPhan", SqlDbType.NVarChar).Value = hp.TenHocPhan;
                cmd.Parameters.Add("@DiemSo", SqlDbType.NVarChar).Value = hp.DiemSo;
                cmd.Parameters.Add("@DiemChu", SqlDbType.NVarChar).Value = hp.DiemChu;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool Delete(SinhVien sv)
        {
            string sql = "DELETE HOCPHAN WHERE MaSV = @MaSV; DELETE SINHVIEN WHERE MaSV = @MaSV;";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.Int).Value = sv.MaSV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable Search(string value, string value2)
        {
            string sql = "SELECT SINHVIEN.MaSV, TenSV, GioiTinh, NamSinh, QueQuan, NoiCuTru, MaHocPhan, TenHocPhan, DiemSo, DiemChu FROM SINHVIEN LEFT JOIN HOCPHAN ON SINHVIEN.MaSV = HOCPHAN.MaSV WHERE " +value2+ " like N'%" + value + "%'"; 
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable Sort(String value)
        {
            string sql = "SELECT SINHVIEN.MaSV, TenSV, GioiTinh, NamSinh, QueQuan, NoiCuTru, MaHocPhan, TenHocPhan, DiemSo, DiemChu FROM SINHVIEN LEFT JOIN HOCPHAN ON SINHVIEN.MaSV = HOCPHAN.MaSV ORDER BY " +value+ " ASC";
            SqlConnection con = dc.getConnect();
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter(sql, con);
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            catch (Exception e)
            {
            }
            return dt;
        }
    }
}
