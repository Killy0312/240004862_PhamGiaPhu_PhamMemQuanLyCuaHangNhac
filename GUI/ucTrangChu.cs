using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLCuaHangBangDiaThietBi
{
    public partial class ucTrangChu : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        public ucTrangChu()
        {
            InitializeComponent();
        }

        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");

            LoadDashboardMetrics();
            LoadChartTopSanPham();
            LoadChartTyTrongDoanhThu();
        }

        public void LoadDashboardMetrics()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Tính Tổng doanh thu hôm nay
                    string sqlDoanhThu = @"
                        SELECT ISNULL(SUM(ThanhTien), 0) FROM (
                            SELECT (CT.Soluong * CT.Dongia) as ThanhTien 
                            FROM ChiTietHoaDonBangDia CT JOIN HoaDonBan HD ON CT.SoHdBan = HD.SoHdBan 
                            WHERE CONVERT(date, HD.NgayBan) = CONVERT(date, GETDATE())
                            UNION ALL
                            SELECT (CT.Soluong * CT.Dongia) as ThanhTien 
                            FROM ChiTietHoaDonThietBi CT JOIN HoaDonBan HD ON CT.SoHdBan = HD.SoHdBan 
                            WHERE CONVERT(date, HD.NgayBan) = CONVERT(date, GETDATE())
                        ) AS T";
                    SqlCommand cmd1 = new SqlCommand(sqlDoanhThu, conn);
                    decimal doanhThu = Convert.ToDecimal(cmd1.ExecuteScalar());

                    // TỰ ĐỘNG HẠ CỠ CHỮ ĐỂ KHÔNG BỊ TRÀN VIỀN / MẤT SỐ
                    lblDoanhThuSo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                    lblDoanhThuSo.Text = doanhThu.ToString("#,##0") + " đ";

                    // 2. Tính số lượng Hóa đơn hôm nay
                    string sqlHoaDon = "SELECT COUNT(*) FROM HoaDonBan WHERE CONVERT(date, NgayBan) = CONVERT(date, GETDATE())";
                    SqlCommand cmd2 = new SqlCommand(sqlHoaDon, conn);
                    lblHoaDonSo.Text = cmd2.ExecuteScalar().ToString() + " Đơn";

                    // 3. Tính Tổng Hàng Tồn Kho
                    string sqlTonKho = "SELECT (SELECT ISNULL(SUM(SoLuongTon),0) FROM BangDia) + (SELECT ISNULL(SUM(SoLuongTon),0) FROM ThietBi)";
                    SqlCommand cmd3 = new SqlCommand(sqlTonKho, conn);
                    lblTonKhoSo.Text = cmd3.ExecuteScalar().ToString();

                    // 4. Tính Tổng Khách Hàng
                    string sqlKhachHang = "SELECT COUNT(*) FROM KhachHang";
                    SqlCommand cmd4 = new SqlCommand(sqlKhachHang, conn);
                    lblKhachHangSo.Text = cmd4.ExecuteScalar().ToString() + " Khách";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi Load Metrics: " + ex.Message);
                }
            }
        }

        private void LoadChartTopSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT TOP 5 TenSP, SUM(SoLuong) AS TongBan
                        FROM (
                            SELECT BD.TenBangDia AS TenSP, CT.Soluong
                            FROM ChiTietHoaDonBangDia CT JOIN BangDia BD ON CT.MsBangDia = BD.MsBangDia
                            UNION ALL
                            SELECT TB.TenThietBi AS TenSP, CT.Soluong
                            FROM ChiTietHoaDonThietBi CT JOIN ThietBi TB ON CT.MsThietBi = TB.MsThietBi
                        ) AS BangGop
                        GROUP BY TenSP
                        ORDER BY TongBan DESC";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    chartTopSP.Series["Số lượng bán"].Points.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        chartTopSP.Series["Số lượng bán"].Points.AddXY(row["TenSP"].ToString(), Convert.ToInt32(row["TongBan"]));
                    }

                    chartTopSP.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                    chartTopSP.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
                    chartTopSP.ChartAreas[0].AxisX.Interval = 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi Load Chart 1: " + ex.Message);
                }
            }
        }

        private void LoadChartTyTrongDoanhThu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // THÊM KÝ TỰ N'...' ĐỂ HIỂN THỊ ĐÚNG CHỮ "THIẾT BỊ" KHÔNG BỊ LỖI THI?T B?
                    string sql = @"
                        SELECT N'Băng Đĩa' AS NhomHangg, ISNULL(SUM(Soluong * Dongia), 0) AS TongTien FROM ChiTietHoaDonBangDia
                        UNION ALL
                        SELECT N'Thiết Bị' AS NhomHangg, ISNULL(SUM(Soluong * Dongia), 0) FROM ChiTietHoaDonThietBi";

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    chartTyTrong.Series["DoanhThu"].Points.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        decimal tien = Convert.ToDecimal(row["TongTien"]);
                        if (tien > 0)
                        {
                            int pt = chartTyTrong.Series["DoanhThu"].Points.AddXY(row["NhomHangg"].ToString(), tien);
                            chartTyTrong.Series["DoanhThu"].Points[pt].Label = "#PERCENT{P0}";
                            chartTyTrong.Series["DoanhThu"].Points[pt].LegendText = row["NhomHangg"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi Load Chart 2: " + ex.Message);
                }
            }
        }
    }
}