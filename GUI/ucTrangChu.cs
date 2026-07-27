using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucTrangChu : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        public ucTrangChu()
        {
            InitializeComponent();
            LoadThongKeQuick();
            LoadTopSanPham();
        }

        // Đồng hồ đếm giờ thời gian thực
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        // 1. Thống kê nhanh số liệu cho 4 Card
        private void LoadThongKeQuick()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Card 1: Doanh thu bán hàng hôm nay
                    string queryCard1 = @"SELECT ISNULL(SUM(CT.Soluong * CT.Dongia), 0)
                                          FROM HoaDonBan HD
                                          JOIN ChiTietHoaDonBangDia CT ON HD.SoHdBan = CT.SoHdBan
                                          WHERE CONVERT(date, HD.NgayBan) = CONVERT(date, GETDATE())";
                    SqlCommand cmd1 = new SqlCommand(queryCard1, conn);
                    decimal doanhThu = Convert.ToDecimal(cmd1.ExecuteScalar());
                    lblCard1Val.Text = string.Format("{0:#,##0} VNĐ", doanhThu);

                    // Card 2: Số hóa đơn bán hôm nay
                    string queryCard2 = "SELECT COUNT(*) FROM HoaDonBan WHERE CONVERT(date, NgayBan) = CONVERT(date, GETDATE())";
                    SqlCommand cmd2 = new SqlCommand(queryCard2, conn);
                    int soHD = Convert.ToInt32(cmd2.ExecuteScalar());
                    lblCard2Val.Text = soHD.ToString() + " Đơn";

                    // Card 3: Số phiếu thuê chưa trả
                    string queryCard3 = "SELECT COUNT(*) FROM PhieuThue WHERE NgayTraThucTe IS NULL";
                    SqlCommand cmd3 = new SqlCommand(queryCard3, conn);
                    int soThuThue = Convert.ToInt32(cmd3.ExecuteScalar());
                    lblCard3Val.Text = soThuThue.ToString() + " Phiếu";

                    // Card 4: Tổng số khách hàng
                    string queryCard4 = "SELECT COUNT(*) FROM KhachHang";
                    SqlCommand cmd4 = new SqlCommand(queryCard4, conn);
                    int soKH = Convert.ToInt32(cmd4.ExecuteScalar());
                    lblCard4Val.Text = soKH.ToString() + " Khách";
                }
                catch (Exception ex)
                {
                    // Lỗi nhẹ không làm đứng app
                    lblCard1Val.Text = "0 VNĐ";
                }
            }
        }

        // 2. Nạp bảng danh sách đĩa/thiết bị bán chạy nhất
        private void LoadTopSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 5 BD.MsBangDia AS [Mã SP], BD.TenBangDia AS [Tên Băng Đĩa / Thiết Bị], 
                               BD.TheLoai AS [Loại Danh Mục], ISNULL(SUM(CT.Soluong), 0) AS [Tổng Đã Bán]
                        FROM BangDia BD
                        JOIN ChiTietHoaDonBangDia CT ON BD.MsBangDia = CT.MsBangDia
                        GROUP BY BD.MsBangDia, BD.TenBangDia, BD.TheLoai
                        ORDER BY [Tổng Đã Bán] DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTopSelling.DataSource = dt;
                }
                catch (Exception ex)
                {
                    // Nếu chưa có giao dịch sẽ hiện bảng trống sạch đẹp
                }
            }
        }
    }
}