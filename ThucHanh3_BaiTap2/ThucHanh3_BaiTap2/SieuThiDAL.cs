using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh3_BaiTap2
{
    class SieuThiDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SieuThiDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllSieuThi()
        {
            string sql = "SELECT MaSanPham, TenSanPham, NgayNhap, NhaSanXuat, TinhTrang, TenMatHang FROM tblSanPham LEFT JOIN tblMatHang ON tblSanPham.MaMatHang = tblMatHang.MaMatHang";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSieuThi(tblSieuThi st)
        {
            string sql = "INSERT INTO tblSanPham(MaSanPham, TenSanPham, NgayNhap, NhaSanXuat, TinhTrang, MaMatHang) VALUES(@MaSanPham, @TenSanPham, @NgayNhap, @NhaSanXuat, @TinhTrang, (SELECT MaMatHang FROM tblMatHang WHERE TenMatHang = @TenMatHang))";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSanPham", SqlDbType.NVarChar).Value = st.MaSanPham;
                cmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = st.TenSanPham;
                cmd.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = st.NgayNhap;
                cmd.Parameters.Add("@NhaSanXuat", SqlDbType.NVarChar).Value = st.NhaSanXuat;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = st.TinhTrang;
                cmd.Parameters.Add("@TenMatHang", SqlDbType.NVarChar).Value = st.TenMatHang;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSieuThi(tblSieuThi st)
        {
            string sql = "UPDATE tblSanPham SET TenSanPham = @TenSanPham, NgayNhap = @NgayNhap, NhaSanXuat = @NhaSanXuat, TinhTrang = @TinhTrang, MaMatHang = (SELECT MaMatHang FROM tblMatHang WHERE TenMatHang = @TenMatHang) WHERE MaSanPham = @MaSanPham";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSanPham", SqlDbType.NVarChar).Value = st.MaSanPham;
                cmd.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = st.TenSanPham;
                cmd.Parameters.Add("@NgayNhap", SqlDbType.DateTime).Value = st.NgayNhap;
                cmd.Parameters.Add("@NhaSanXuat", SqlDbType.NVarChar).Value = st.NhaSanXuat;
                cmd.Parameters.Add("@TinhTrang", SqlDbType.NVarChar).Value = st.TinhTrang;
                cmd.Parameters.Add("@TenMatHang", SqlDbType.NVarChar).Value = st.TenMatHang;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSieuThi(tblSieuThi st)
        {
            string sql = "DELETE tblSanPham WHERE MaSanPham = @MaSanPham";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSanPham", SqlDbType.NVarChar).Value = st.MaSanPham;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public DataTable FindSieuThi(string st)
        {
            string sql = "SELECT * FROM tblSanPham WHERE TenSanPham like N'%" + st + "%'";
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
