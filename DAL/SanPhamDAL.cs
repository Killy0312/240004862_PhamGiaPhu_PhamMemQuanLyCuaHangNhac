using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SanPhamDAL : DBConnect
    {
        // Hàm lấy toàn bộ danh sách sản phẩm
        public DataTable GetListSanPham()
        {
            DataTable dtSanPham = new DataTable();

            // Khởi tạo câu lệnh SQL
            string query = "SELECT * FROM SanPham";

            // Sử dụng SqlDataAdapter để lấy dữ liệu đổ vào DataTable
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dtSanPham);

            return dtSanPham;
        }
    }
}