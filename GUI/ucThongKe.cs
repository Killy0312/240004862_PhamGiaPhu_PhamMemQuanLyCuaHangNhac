using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class ucThongKe : UserControl
    {
        // Chuỗi kết nối CSDL SQL Server
        private string strConnectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        public ucThongKe()
        {
            InitializeComponent();
        }

        private void ucThongKe_Load(object sender, EventArgs e)
        {
            // Mặc định khoảng thời gian: Từ ngày 1 đầu tháng hiện tại -> Hôm nay
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            // Cấu hình giao diện biểu đồ
            CauHinhBieuDo();

            // Tải dữ liệu thống kê
            TaiDuLieuThongKe();
        }

        #region CẤU HÌNH GIAO DIỆN BIỂU ĐỒ (CHART CONFIG)
        private void CauHinhBieuDo()
        {
            // 1. Biểu đồ Cột (Top Sản phẩm doanh thu cao)
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add("TOP SẢN PHẨM CÓ DOANH THU CAO NHẤT");
            chartDoanhThu.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartDoanhThu.Titles[0].ForeColor = Color.DarkBlue;

            Series seriesCol = new Series("DoanhThu");
            seriesCol.ChartType = SeriesChartType.Column;
            seriesCol.XValueType = ChartValueType.String;
            seriesCol.YValueType = ChartValueType.Double;
            seriesCol.IsValueShownAsLabel = true;
            seriesCol.LabelFormat = "{0:N0}đ";
            seriesCol.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            seriesCol.Color = Color.FromArgb(41, 128, 185);
            chartDoanhThu.Series.Add(seriesCol);

            chartDoanhThu.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5F);
            chartDoanhThu.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8.5F);
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;

            // 2. Biểu đồ Tròn/Doughnut (Tỷ trọng theo Nhóm hàng)
            chartTyTrong.Series.Clear();
            chartTyTrong.Titles.Clear();
            chartTyTrong.Titles.Add("TỶ TRỌNG DOANH THU THEO NHÓM HÀNG");
            chartTyTrong.Titles[0].Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chartTyTrong.Titles[0].ForeColor = Color.DarkRed;

            Series seriesPie = new Series("TyTrong");
            seriesPie.ChartType = SeriesChartType.Doughnut;
            seriesPie.IsValueShownAsLabel = true;
            seriesPie.Label = "#PERCENT{P1}";
            seriesPie.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            seriesPie.LegendText = "#VALX (#VALY{N0}đ)";
            chartTyTrong.Series.Add(seriesPie);
            chartTyTrong.Legends[0].Docking = Docking.Bottom;
            chartTyTrong.Legends[0].Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }
        #endregion

        #region XỬ LÝ TẢI VÀ TÍNH TOÁN DỮ LIỆU THỐNG KÊ
        public void TaiDuLieuThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();

                    // 1. TẢI CÁC CHỈ SỐ KPI TỔNG QUAN
                    TaiKpiTongQuan(conn, tuNgay, denNgay);

                    // 2. TẢI DỮ LIỆU BẢNG CHI TIẾT SẢN PHẨM (BÁN CHẠY & BÁN CHẬM)
                    DataTable dtSanPham = TaiBangThongKeSanPham(conn, tuNgay, denNgay);
                    dgvThongKeSanPham.DataSource = dtSanPham;
                    DinhDangGridSanPham();

                    // 3. VẼ BIỂU ĐỒ CỘT (TOP 5 SẢN PHẨM)
                    VeBieuDoCotTopSanPham(dtSanPham);

                    // 4. VẼ BIỂU ĐỒ TRÒN (TỶ TRỌNG CÁC NHÓM HÀNG)
                    VeBieuDoTronTyTrong(conn, tuNgay, denNgay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình tải dữ liệu thống kê: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 1. Hàm tính các số liệu KPI
        private void TaiKpiTongQuan(SqlConnection conn, DateTime tuNgay, DateTime denNgay)
        {
            string sqlKpi = @"
                SELECT 
                    COUNT(DISTINCT hd.SoHdBan) AS TongHoaDon,
                    (
                        ISNULL((SELECT SUM(ct1.Soluong * ct1.Dongia) 
                                FROM ChiTietHoaDonBangDia ct1 
                                INNER JOIN HoaDonBan h1 ON ct1.SoHdBan = h1.SoHdBan 
                                WHERE h1.NgayBan BETWEEN @TuNgay AND @DenNgay), 0) 
                        +
                        ISNULL((SELECT SUM(ct2.Soluong * ct2.Dongia) 
                                FROM ChiTietHoaDonThietBi ct2 
                                INNER JOIN HoaDonBan h2 ON ct2.SoHdBan = h2.SoHdBan 
                                WHERE h2.NgayBan BETWEEN @TuNgay AND @DenNgay), 0)
                    ) AS TongDoanhThu
                FROM HoaDonBan hd
                WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay";

            using (SqlCommand cmd = new SqlCommand(sqlKpi, conn))
            {
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        decimal tongDoanhThu = dr["TongDoanhThu"] != DBNull.Value ? Convert.ToDecimal(dr["TongDoanhThu"]) : 0;
                        int tongHoaDon = dr["TongHoaDon"] != DBNull.Value ? Convert.ToInt32(dr["TongHoaDon"]) : 0;

                        lblTongDoanhThu.Text = string.Format("{0:N0} VNĐ", tongDoanhThu);
                        lblTongHoaDon.Text = string.Format("{0:N0} Hóa đơn", tongHoaDon);
                    }
                    else
                    {
                        lblTongDoanhThu.Text = "0 VNĐ";
                        lblTongHoaDon.Text = "0 Hóa đơn";
                    }
                }
            }
        }

        // 2. Hàm lấy danh sách thống kê sản phẩm
        private DataTable TaiBangThongKeSanPham(SqlConnection conn, DateTime tuNgay, DateTime denNgay)
        {
            string sqlQuery = @"
                WITH ChiTietBan AS (
                    -- Doanh thu Băng Đĩa
                    SELECT 
                        ct.MsBangDia AS MaSP,
                        bd.TenBangDia AS TenSP,
                        N'Băng đĩa' AS LoaiSP,
                        SUM(ct.Soluong) AS TongSoLuong,
                        SUM(ct.Soluong * ct.Dongia) AS TongDoanhThu
                    FROM ChiTietHoaDonBangDia ct
                    INNER JOIN HoaDonBan hd ON ct.SoHdBan = hd.SoHdBan
                    INNER JOIN BangDia bd ON ct.MsBangDia = bd.MsBangDia
                    WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay
                    GROUP BY ct.MsBangDia, bd.TenBangDia

                    UNION ALL

                    -- Doanh thu Thiết Bị
                    SELECT 
                        ct.MsThietBi AS MaSP,
                        tb.TenThietBi AS TenSP,
                        N'Thiết bị' AS LoaiSP,
                        SUM(ct.Soluong) AS TongSoLuong,
                        SUM(ct.Soluong * ct.Dongia) AS TongDoanhThu
                    FROM ChiTietHoaDonThietBi ct
                    INNER JOIN HoaDonBan hd ON ct.SoHdBan = hd.SoHdBan
                    INNER JOIN ThietBi tb ON ct.MsThietBi = tb.MsThietBi
                    WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay
                    GROUP BY ct.MsThietBi, tb.TenThietBi
                )
                SELECT 
                    MaSP, 
                    TenSP, 
                    LoaiSP, 
                    TongSoLuong, 
                    TongDoanhThu,
                    CASE 
                        WHEN TongSoLuong >= 10 THEN N'Bán chạy'
                        WHEN TongSoLuong BETWEEN 1 AND 9 THEN N'Bán bình thường'
                        ELSE N'Bán chậm'
                    END AS TrangThai
                FROM ChiTietBan
                ORDER BY TongDoanhThu DESC";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblBanChayNhat.Text = string.Format("{0} ({1} cái)", dt.Rows[0]["TenSP"], dt.Rows[0]["TongSoLuong"]);
                    lblBanChamNhat.Text = string.Format("{0} ({1} cái)", dt.Rows[dt.Rows.Count - 1]["TenSP"], dt.Rows[dt.Rows.Count - 1]["TongSoLuong"]);
                }
                else
                {
                    lblBanChayNhat.Text = "Chưa có dữ liệu";
                    lblBanChamNhat.Text = "Chưa có dữ liệu";
                }

                return dt;
            }
        }

        // 3. Hàm vẽ Biểu đồ cột Top 5 Sản phẩm
        private void VeBieuDoCotTopSanPham(DataTable dtSanPham)
        {
            chartDoanhThu.Series["DoanhThu"].Points.Clear();

            int count = 0;
            foreach (DataRow row in dtSanPham.Rows)
            {
                if (count >= 5) break;

                string tenSP = row["TenSP"].ToString();
                if (tenSP.Length > 15) tenSP = tenSP.Substring(0, 12) + "...";

                double doanhThu = Convert.ToDouble(row["TongDoanhThu"]);

                int pointIdx = chartDoanhThu.Series["DoanhThu"].Points.AddXY(tenSP, doanhThu);
                chartDoanhThu.Series["DoanhThu"].Points[pointIdx].ToolTip = string.Format("{0}: {1:N0} VNĐ", row["TenSP"], doanhThu);

                count++;
            }
        }

        // 4. Hàm vẽ Biểu đồ tròn tỷ trọng (ĐÃ THÊM TIỀN TỐ N'...' CHUẨN UNICODE)
        private void VeBieuDoTronTyTrong(SqlConnection conn, DateTime tuNgay, DateTime denNgay)
        {
            chartTyTrong.Series["TyTrong"].Points.Clear();

            string sqlTyTrong = @"
                SELECT N'Băng đĩa' AS NhomHang, ISNULL(SUM(ct.Soluong * ct.Dongia), 0) AS DoanhThu
                FROM ChiTietHoaDonBangDia ct
                INNER JOIN HoaDonBan hd ON ct.SoHdBan = hd.SoHdBan
                WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay
                
                UNION ALL
                
                SELECT N'Thiết bị Audio' AS NhomHang, ISNULL(SUM(ct.Soluong * ct.Dongia), 0) AS DoanhThu
                FROM ChiTietHoaDonThietBi ct
                INNER JOIN HoaDonBan hd ON ct.SoHdBan = hd.SoHdBan
                WHERE hd.NgayBan BETWEEN @TuNgay AND @DenNgay";

            using (SqlCommand cmd = new SqlCommand(sqlTyTrong, conn))
            {
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string nhomHang = dr["NhomHang"].ToString();
                        double doanhThu = Convert.ToDouble(dr["DoanhThu"]);

                        if (doanhThu > 0)
                        {
                            int pIdx = chartTyTrong.Series["TyTrong"].Points.AddXY(nhomHang, doanhThu);
                            chartTyTrong.Series["TyTrong"].Points[pIdx].ToolTip = string.Format("{0}: {1:N0} VNĐ", nhomHang, doanhThu);
                        }
                    }
                }
            }
        }

        private void DinhDangGridSanPham()
        {
            if (dgvThongKeSanPham.Columns.Count > 0)
            {
                dgvThongKeSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                dgvThongKeSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgvThongKeSanPham.Columns["LoaiSP"].HeaderText = "Phân Loại";
                dgvThongKeSanPham.Columns["TongSoLuong"].HeaderText = "Số Lượng Bán";
                dgvThongKeSanPham.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu (VNĐ)";
                dgvThongKeSanPham.Columns["TrangThai"].HeaderText = "Đánh Giá";

                dgvThongKeSanPham.Columns["TongDoanhThu"].DefaultCellStyle.Format = "N0";
                dgvThongKeSanPham.Columns["TongSoLuong"].DefaultCellStyle.Format = "N0";
                dgvThongKeSanPham.Columns["TongDoanhThu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvThongKeSanPham.Columns["TongSoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThongKeSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        #endregion

        #region EVENT HANDLERS
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TaiDuLieuThongKe();
        }

        private void btnHomNay_Click(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Now;
            dtpDenNgay.Value = DateTime.Now;
            TaiDuLieuThongKe();
        }

        private void btnThangNay_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            TaiDuLieuThongKe();
        }
        #endregion
    }
}