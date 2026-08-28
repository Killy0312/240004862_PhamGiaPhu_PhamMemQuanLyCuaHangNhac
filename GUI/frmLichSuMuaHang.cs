using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLichSuMuaHang : Form
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private string maKH;
        private string tenKH;
        private string sdtKH;

        private TreeView tvLichSu;
        private Label lblTongTien;

        public frmLichSuMuaHang(string maKH, string tenKH, string sdtKH)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.sdtKH = sdtKH;

            InitializeComponentCustom();
            LoadLichSuDangCay();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "LỊCH SỬ GIAO DỊCH KHÁCH HÀNG - CỬA HÀNG AUDIOPHILE";
            this.Size = new Size(950, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 244, 247);

            // 1. Header trên cùng
            Label lblHeader = new Label();
            lblHeader.Text = $"LỊCH SỬ MUA HÀNG - KHÁCH HÀNG: {tenKH.ToUpper()} (SĐT: {sdtKH})";
            lblHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblHeader.ForeColor = Color.Teal;
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Height = 45;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            // 2. Control TreeView dạng Cây Xổ Xuống (Full Width 1 Cột)
            tvLichSu = new TreeView();
            tvLichSu.Dock = DockStyle.Fill;
            tvLichSu.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            tvLichSu.ItemHeight = 32; // Độ cao mỗi dòng thoáng mắt
            tvLichSu.ShowLines = true;
            tvLichSu.ShowPlusMinus = true;
            tvLichSu.ShowRootLines = true;
            tvLichSu.BorderStyle = BorderStyle.None;
            tvLichSu.BackColor = Color.White;
            tvLichSu.Indent = 25;

            Panel pnlTreeContainer = new Panel();
            pnlTreeContainer.Dock = DockStyle.Fill;
            pnlTreeContainer.Padding = new Padding(15, 10, 15, 10);
            pnlTreeContainer.Controls.Add(tvLichSu);

            // 3. Thanh Tổng Tiền & Nút Đóng ở đáy
            Panel pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 55;
            pnlBottom.BackColor = Color.White;

            lblTongTien = new Label();
            lblTongTien.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTongTien.ForeColor = Color.DarkRed;
            lblTongTien.Location = new Point(20, 16);
            lblTongTien.AutoSize = true;

            Button btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Font = new Font("Segoe UI", 10);
            btnClose.Size = new Size(110, 36);
            btnClose.Location = new Point(800, 10);
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => { this.Close(); };

            pnlBottom.Controls.Add(lblTongTien);
            pnlBottom.Controls.Add(btnClose);

            this.Controls.Add(pnlTreeContainer);
            this.Controls.Add(pnlBottom);
            this.Controls.Add(lblHeader);
        }

        // CẤU TRÚC NẠP DỮ LIỆU DẠNG CÂY (PARENT: HÓA ĐƠN -> CHILD: MÓN HÀNG)
        private void LoadLichSuDangCay()
        {
            tvLichSu.Nodes.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query 1: Lấy danh sách Hóa Đơn của Khách hàng
                    string sqlHD = @"
                        SELECT 
                            HD.SoHdBan AS [SoHD],
                            CONVERT(VARCHAR, HD.NgayBan, 103) + ' ' + CONVERT(VARCHAR, HD.NgayBan, 108) AS [NgayBan],
                            ISNULL(SUM(CT.ThanhTien), 0) AS [TongTien],
                            ISNULL(NV.Hoten, N'Thu ngân') AS [TenNV]
                        FROM HoaDonBan HD
                        LEFT JOIN (
                            SELECT SoHdBan, (Soluong * Dongia) AS ThanhTien FROM ChiTietHoaDonBangDia
                            UNION ALL
                            SELECT SoHdBan, (Soluong * Dongia) AS ThanhTien FROM ChiTietHoaDonThietBi
                        ) CT ON HD.SoHdBan = CT.SoHdBan
                        LEFT JOIN NhanVien NV ON HD.MsNv = NV.MsNv
                        WHERE HD.MaKh = @MaKH
                        GROUP BY HD.SoHdBan, HD.NgayBan, NV.Hoten
                        ORDER BY HD.NgayBan DESC";

                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn);
                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);

                    SqlDataAdapter daHD = new SqlDataAdapter(cmdHD);
                    DataTable dtHD = new DataTable();
                    daHD.Fill(dtHD);

                    if (dtHD.Rows.Count == 0)
                    {
                        TreeNode emptyNode = new TreeNode("Khách hàng này chưa có lịch sử mua hàng nào!");
                        tvLichSu.Nodes.Add(emptyNode);
                        lblTongTien.Text = "TỔNG TÍCH LŨY CHI TIÊU: 0 VNĐ (0 Hóa Đơn)";
                        return;
                    }

                    decimal tongTichLuy = 0;

                    // Duyệt từng Hóa Đơn
                    foreach (DataRow rowHD in dtHD.Rows)
                    {
                        string soHD = rowHD["SoHD"].ToString();
                        string ngayBan = rowHD["NgayBan"].ToString();
                        decimal tongTienHD = Convert.ToDecimal(rowHD["TongTien"]);
                        string tenNV = rowHD["TenNV"].ToString();

                        tongTichLuy += tongTienHD;

                        // Tạo Node Cha (Dòng Hóa Đơn)
                        string textParent = $"🧾 Mã HĐ: {soHD}   │   📅 Ngày: {ngayBan}   │   💰 Tổng tiền đơn: {tongTienHD:N0} VNĐ   │   👤 Thu ngân: {tenNV}";
                        TreeNode parentNode = new TreeNode(textParent);
                        parentNode.NodeFont = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                        parentNode.ForeColor = Color.FromArgb(20, 80, 100);

                        // Query 2: Lấy các món hàng thuộc Hóa Đơn này
                        string sqlCT = @"
                            SELECT 
                                CT.TenSP, CT.LoaiSP, CT.Soluong, CT.Dongia, (CT.Soluong * CT.Dongia) AS ThanhTien
                            FROM (
                                SELECT CTBD.SoHdBan, BD.TenBangDia AS TenSP, N'Băng Đĩa' AS LoaiSP, CTBD.Soluong, CTBD.Dongia
                                FROM ChiTietHoaDonBangDia CTBD JOIN BangDia BD ON CTBD.MsBangDia = BD.MsBangDia
                                UNION ALL
                                SELECT CTTB.SoHdBan, TB.TenThietBi AS TenSP, N'Thiết Bị' AS LoaiSP, CTTB.Soluong, CTTB.Dongia
                                FROM ChiTietHoaDonThietBi CTTB JOIN ThietBi TB ON CTTB.MsThietBi = TB.MsThietBi
                            ) CT
                            WHERE CT.SoHdBan = @SoHD";

                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn);
                        cmdCT.Parameters.AddWithValue("@SoHD", soHD);

                        SqlDataAdapter daCT = new SqlDataAdapter(cmdCT);
                        DataTable dtCT = new DataTable();
                        daCT.Fill(dtCT);

                        // Duyệt từng món hàng tạo Node Con (Xổ xuống khi bấm [+])
                        foreach (DataRow rowCT in dtCT.Rows)
                        {
                            string tenSP = rowCT["TenSP"].ToString();
                            string loaiSP = rowCT["LoaiSP"].ToString();
                            int sl = Convert.ToInt32(rowCT["Soluong"]);
                            decimal gia = Convert.ToDecimal(rowCT["Dongia"]);
                            decimal thanhTien = Convert.ToDecimal(rowCT["ThanhTien"]);

                            string textChild = $"{tenSP} ({loaiSP})   ─   Số lượng: {sl}   │   Đơn giá: {gia:N0} VNĐ   │   Thành tiền: {thanhTien:N0} VNĐ";
                            TreeNode childNode = new TreeNode(textChild);
                            childNode.NodeFont = new Font("Segoe UI", 10F, FontStyle.Regular);
                            childNode.ForeColor = Color.FromArgb(50, 50, 50);

                            parentNode.Nodes.Add(childNode);
                        }

                        tvLichSu.Nodes.Add(parentNode);
                    }

                    // Tự động xổ mở sẵn Hóa Đơn Mới Nhất đầu tiên
                    if (tvLichSu.Nodes.Count > 0)
                    {
                        tvLichSu.Nodes[0].Expand();
                    }

                    lblTongTien.Text = $"TỔNG TÍCH LŨY CHI TIÊU: {tongTichLuy:N0} VNĐ ({dtHD.Rows.Count} Hóa Đơn)";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp lịch sử mua hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}