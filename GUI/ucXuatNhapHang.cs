using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucXuatNhapHang : UserControl
    {
        private string strConnectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private bool isThemMoiSP = false;
        private DataTable dtLichSuToanBo;

        // Khai báo điều khiển nhập Nghệ sĩ
        private Label lblNgheSi;
        private TextBox txtNgheSi;

        public ucXuatNhapHang()
        {
            InitializeComponent();
            KhoiTaoODieuKhienNgheSi(); // Tự động gắn ô Nghệ sĩ vào đúng khung nhập bên phải
        }

        private void KhoiTaoODieuKhienNgheSi()
        {
            if (txtNgheSi != null || txtTenSP == null) return;

            // Xác định đúng khung chứa của Tên sản phẩm bên phải
            Control parent = txtTenSP.Parent ?? this;

            // Tính khoảng cách chuẩn giữa 2 dòng nhập liệu
            int deltaY = 36;
            if (txtMaSP != null && txtTenSP.Location.Y > txtMaSP.Location.Y)
            {
                deltaY = txtTenSP.Location.Y - txtMaSP.Location.Y;
            }

            // Tìm Label "Tên sản phẩm" để đồng bộ kích thước và tọa độ X
            Control lblTenSP = null;
            foreach (Control c in parent.Controls)
            {
                if (c is Label && (c.Text.Contains("Tên") || (Math.Abs(c.Location.Y - txtTenSP.Location.Y) < 10 && c.Location.X < txtTenSP.Location.X)))
                {
                    lblTenSP = c;
                    break;
                }
            }

            // 1. Tạo Label Nghệ Sĩ
            lblNgheSi = new Label();
            lblNgheSi.Name = "lblNgheSi";
            lblNgheSi.Text = "Nghệ sĩ / Ca sĩ:";
            lblNgheSi.AutoSize = false;

            if (lblTenSP != null)
            {
                lblNgheSi.Font = lblTenSP.Font;
                lblNgheSi.ForeColor = lblTenSP.ForeColor;
                lblNgheSi.Size = lblTenSP.Size;
                lblNgheSi.TextAlign = (lblTenSP as Label)?.TextAlign ?? ContentAlignment.MiddleLeft;
                lblNgheSi.Location = new Point(lblTenSP.Location.X, lblTenSP.Location.Y + deltaY);
            }
            else
            {
                lblNgheSi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lblNgheSi.Size = new Size(110, 22);
                lblNgheSi.TextAlign = ContentAlignment.MiddleLeft;
                lblNgheSi.Location = new Point(Math.Max(0, txtTenSP.Location.X - 115), txtTenSP.Location.Y + deltaY);
            }

            // 2. Tạo TextBox Nghệ Sĩ
            txtNgheSi = new TextBox();
            txtNgheSi.Name = "txtNgheSi";
            txtNgheSi.Font = txtTenSP.Font;
            txtNgheSi.Size = txtTenSP.Size;
            txtNgheSi.Location = new Point(txtTenSP.Location.X, txtTenSP.Location.Y + deltaY);

            // 3. Dịch chuyển duy nhất các ô nằm phía dưới trong cùng khung nhập liệu bên phải
            int baseY = txtTenSP.Location.Y;
            foreach (Control c in parent.Controls)
            {
                if (c != txtTenSP && c != lblTenSP && c.Location.Y > baseY)
                {
                    c.Location = new Point(c.Location.X, c.Location.Y + deltaY);
                }
            }

            // 4. Gắn vào đúng khung bên phải
            parent.Controls.Add(lblNgheSi);
            parent.Controls.Add(txtNgheSi);
            lblNgheSi.BringToFront();
            txtNgheSi.BringToFront();
        }

        private void ucXuatNhapHang_Load(object sender, EventArgs e)
        {
            cmbLoaiHang.SelectedIndex = 0;      // Bộ lọc tất cả
            cmbPhanLoaiInput.SelectedIndex = 0; // Mặc định Đĩa CD

            TuDongTaoBangLichSuNhapKho();
            KhoiTaoBangLichSu();
            TaiDanhSachHangNhaCungCap();
            TaiDanhSachKhoHang();
            TaiLichSuXuatNhapToanBo();
            XoaFormNhapMoi();
        }

        #region TỰ ĐỘNG TẠO BẢNG LƯU TRỮ TRONG SQL SERVER
        private void TuDongTaoBangLichSuNhapKho()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='LichSuNhapKho' AND xtype='U')
                        BEGIN
                            CREATE TABLE LichSuNhapKho (
                                MaGiaoDich VARCHAR(30) PRIMARY KEY,
                                ThoiGian DATETIME DEFAULT GETDATE(),
                                LoaiGiaoDich NVARCHAR(50),
                                TenSP NVARCHAR(250),
                                SoLuong INT,
                                NguoiThucHien NVARCHAR(100),
                                GhiChu NVARCHAR(250)
                            )
                        END";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }
        #endregion

        #region KHỞI TẠO & QUẢN LÝ LỊCH SỬ XUẤT NHẬP KHO
        private void KhoiTaoBangLichSu()
        {
            dtLichSuToanBo = new DataTable();
            dtLichSuToanBo.Columns.Add("MaGiaoDich", typeof(string));
            dtLichSuToanBo.Columns.Add("ThoiGian", typeof(DateTime));
            dtLichSuToanBo.Columns.Add("LoaiGiaoDich", typeof(string));
            dtLichSuToanBo.Columns.Add("TenSP", typeof(string));
            dtLichSuToanBo.Columns.Add("SoLuong", typeof(int));
            dtLichSuToanBo.Columns.Add("NguoiThucHien", typeof(string));
            dtLichSuToanBo.Columns.Add("GhiChu", typeof(string));

            dgvLichSu.DataSource = dtLichSuToanBo;
            DinhDangGridLichSu();
        }

        private void DinhDangGridLichSu()
        {
            if (dgvLichSu.Columns.Count > 0)
            {
                dgvLichSu.Columns["MaGiaoDich"].HeaderText = "Mã Đơn / Mã Phiếu";
                dgvLichSu.Columns["ThoiGian"].HeaderText = "Thời Gian Thao Tác";
                dgvLichSu.Columns["LoaiGiaoDich"].HeaderText = "Loại Giao Dịch";
                dgvLichSu.Columns["TenSP"].HeaderText = "Sản Phẩm";
                dgvLichSu.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvLichSu.Columns["NguoiThucHien"].HeaderText = "Người Thực Hiện";
                dgvLichSu.Columns["GhiChu"].HeaderText = "Chi Tiết / Nhà Cung Cấp";

                dgvLichSu.Columns["ThoiGian"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                dgvLichSu.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
                dgvLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        public void TaiLichSuXuatNhapToanBo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string sql = @"
                        SELECT MaGiaoDich, ThoiGian, LoaiGiaoDich, TenSP, SoLuong, NguoiThucHien, GhiChu 
                        FROM LichSuNhapKho

                        UNION ALL

                        SELECT 
                            hd.SoHdBan AS MaGiaoDich,
                            hd.NgayBan AS ThoiGian,
                            N'Xuất bán' AS LoaiGiaoDich,
                            bd.TenBangDia AS TenSP,
                            ct.Soluong AS SoLuong,
                            ISNULL(nv.Hoten, N'Thu ngân') AS NguoiThucHien,
                            N'Bán lẻ đĩa nhạc' AS GhiChu
                        FROM ChiTietHoaDonBangDia ct
                        INNER JOIN HoaDonBan hd ON ct.SoHdBan = hd.SoHdBan
                        INNER JOIN BangDia bd ON ct.MsBangDia = bd.MsBangDia
                        LEFT JOIN NhanVien nv ON hd.MsNv = nv.MsNv

                        UNION ALL

                        SELECT 
                            hd.SoHdBan AS MaGiaoDich,
                            hd.NgayBan AS ThoiGian,
                            N'Xuất bán' AS LoaiGiaoDich,
                            tb.TenThietBi AS TenSP,
                            ct.Soluong AS SoLuong,
                            ISNULL(nv.Hoten, N'Thu ngân') AS NguoiThucHien,
                            N'Bán lẻ thiết bị audio' AS GhiChu
                        FROM ChiTietHoaDonThietBi ct
                        INNER JOIN HoaDonBan hd ON ct.SoHdBan = hd.SoHdBan
                        INNER JOIN ThietBi tb ON ct.MsThietBi = tb.MsThietBi
                        LEFT JOIN NhanVien nv ON hd.MsNv = nv.MsNv

                        ORDER BY ThoiGian DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dtLichSuToanBo.Clear();
                        da.Fill(dtLichSuToanBo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải lịch sử: " + ex.Message);
            }
        }

        private void GhiNhatKyNhapKhoVaoCSDL(SqlConnection conn, string maSP, string tenSP, int soLuong, string tenNCC, decimal giaBan)
        {
            try
            {
                string maPN = "PN" + DateTime.Now.ToString("ddHHmmss");
                string nguoiThucHien = string.IsNullOrEmpty(frmAuth.TenNhanVien) ? "Chủ cửa hàng (Admin)" : frmAuth.TenNhanVien;
                string ghiChu = string.Format("Nhà cung cấp: {0} | Giá bán: {1:N0} VNĐ", string.IsNullOrEmpty(tenNCC) ? "Mặc định" : tenNCC, giaBan);
                string tenHienThi = string.Format("[{0}] {1}", maSP, tenSP);

                string sql = @"INSERT INTO LichSuNhapKho (MaGiaoDich, ThoiGian, LoaiGiaoDich, TenSP, SoLuong, NguoiThucHien, GhiChu)
                               VALUES (@Ma, GETDATE(), N'Nhập kho', @TenSP, @SL, @Nguoi, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maPN);
                    cmd.Parameters.AddWithValue("@TenSP", tenHienThi);
                    cmd.Parameters.AddWithValue("@SL", soLuong);
                    cmd.Parameters.AddWithValue("@Nguoi", nguoiThucHien);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
        #endregion

        #region TỰ ĐỘNG TẠO MÃ SẢN PHẨM (BDxx HOẶC TBxx)
        private string TaoMaSanPhamTuDong(string phanLoai)
        {
            bool isThietBi = phanLoai.Contains("Thiết bị") || phanLoai.Contains("Thiết Bị");
            string prefix = isThietBi ? "TB" : "BD";
            string tableName = isThietBi ? "ThietBi" : "BangDia";
            string colName = isThietBi ? "MsThietBi" : "MsBangDia";

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string sql = string.Format("SELECT TOP 1 {0} FROM {1} WHERE {0} LIKE '{2}%' ORDER BY LEN({0}) DESC, {0} DESC", colName, tableName, prefix);

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string lastCode = result.ToString().Trim();
                            string numStr = lastCode.Substring(prefix.Length);

                            if (int.TryParse(numStr, out int maxNum))
                            {
                                return prefix + (maxNum + 1).ToString("D2");
                            }
                        }
                    }
                }
            }
            catch { }

            return prefix + "01";
        }

        private void cmbPhanLoaiInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhanLoaiInput.SelectedItem != null)
            {
                string phanLoaiChon = cmbPhanLoaiInput.SelectedItem.ToString();

                if (isThemMoiSP)
                {
                    txtMaSP.Text = TaoMaSanPhamTuDong(phanLoaiChon);
                }

                // Tự động chuyển đổi chế độ nhập nghệ sĩ khi chọn thiết bị âm thanh
                if (phanLoaiChon.Contains("Thiết bị") || phanLoaiChon.Contains("Thiết Bị"))
                {
                    if (txtNgheSi != null)
                    {
                        txtNgheSi.Text = "Thiết Bị Audio";
                        txtNgheSi.ReadOnly = true;
                    }
                }
                else
                {
                    if (txtNgheSi != null)
                    {
                        if (txtNgheSi.Text == "Thiết Bị Audio") txtNgheSi.Clear();
                        txtNgheSi.ReadOnly = !isThemMoiSP;
                    }
                }
            }
        }
        #endregion

        #region TẢI DANH SÁCH NHÀ CUNG CẤP
        private void TaiDanhSachHangNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT Hang_Id, TenHang FROM Hang";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbNhaCungCap.DataSource = dt;
                    cmbNhaCungCap.DisplayMember = "TenHang";
                    cmbNhaCungCap.ValueMember = "Hang_Id";
                    cmbNhaCungCap.SelectedIndex = -1;
                }
            }
            catch { }
        }

        private string GetOrCreateHangId(SqlConnection conn, string tenHang)
        {
            if (string.IsNullOrWhiteSpace(tenHang)) return null;

            string sqlCheck = "SELECT Hang_Id FROM Hang WHERE TenHang = @TenHang";
            using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn))
            {
                cmdCheck.Parameters.AddWithValue("@TenHang", tenHang.Trim());
                object objId = cmdCheck.ExecuteScalar();
                if (objId != null && objId != DBNull.Value) return objId.ToString();
            }

            string newHangId = "H" + DateTime.Now.ToString("ddHHmmss");
            try
            {
                string sqlInsert = "INSERT INTO Hang (Hang_Id, TenHang) VALUES (@HangId, @TenHang)";
                using (SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@HangId", newHangId);
                    cmdInsert.Parameters.AddWithValue("@TenHang", tenHang.Trim());
                    cmdInsert.ExecuteNonQuery();
                }
                return newHangId;
            }
            catch
            {
                string sqlInsertIdentity = "INSERT INTO Hang (TenHang) VALUES (@TenHang); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmdIdentity = new SqlCommand(sqlInsertIdentity, conn))
                {
                    cmdIdentity.Parameters.AddWithValue("@TenHang", tenHang.Trim());
                    object newId = cmdIdentity.ExecuteScalar();
                    return newId?.ToString();
                }
            }
        }
        #endregion

        #region HÀM GIẢI MÃ VÀ CẬP NHẬT GIÁ BÁN
        private decimal LayGiaBanAnToan(SqlConnection conn, string maSP, bool isThietBi)
        {
            string tableGia = isThietBi ? "BangGiaThietBi" : "BangGiaBangDia";
            string colMa = isThietBi ? "MsThietBi" : "MsBangDia";

            try
            {
                string sql = string.Format("SELECT TOP 1 DonGiaBan FROM {0} WHERE {1} = @MaSP ORDER BY NgayAd DESC", tableGia, colMa);
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    object res = cmd.ExecuteScalar();
                    if (res != null && res != DBNull.Value && decimal.TryParse(res.ToString(), out decimal giaVal))
                    {
                        if (giaVal > 0) return giaVal;
                    }
                }
            }
            catch { }

            string[] colsToTry = { "GiaBan", "Dongia", "DonGia", "Gia" };
            foreach (string colGia in colsToTry)
            {
                try
                {
                    string sql = string.Format("SELECT TOP 1 {0} FROM {1} WHERE {2} = @MaSP", colGia, tableGia, colMa);
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        object res = cmd.ExecuteScalar();
                        if (res != null && res != DBNull.Value && decimal.TryParse(res.ToString(), out decimal giaVal))
                        {
                            if (giaVal > 0) return giaVal;
                        }
                    }
                }
                catch { }
            }

            return 0;
        }

        private void CapNhatGiaBanAnToan(SqlConnection conn, string maSP, decimal giaBan, bool isThietBi)
        {
            if (giaBan <= 0) return;

            string tableGia = isThietBi ? "BangGiaThietBi" : "BangGiaBangDia";
            string colMa = isThietBi ? "MsThietBi" : "MsBangDia";

            try
            {
                string sql = string.Format(@"
                    IF EXISTS (SELECT 1 FROM {0} WHERE {1} = @MaSP)
                        UPDATE {0} SET DonGiaBan = @GiaBan, NgayAd = GETDATE() WHERE {1} = @MaSP
                    ELSE
                        INSERT INTO {0} ({1}, NgayAd, DonGiaBan) VALUES (@MaSP, GETDATE(), @GiaBan)", tableGia, colMa);

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@GiaBan", giaBan);
                    cmd.ExecuteNonQuery();
                    return;
                }
            }
            catch { }
        }
        #endregion

        #region XỬ LÝ KHO HÀNG
        public void TaiDanhSachKhoHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();
                    string sqlQuery = "";

                    if (cmbLoaiHang.SelectedIndex == 1) // Đĩa CD
                    {
                        sqlQuery = @"SELECT bd.MsBangDia AS MaSP, bd.TenBangDia AS TenSP, ISNULL(bd.NgheSi, N'N/A') AS NgheSi, N'Đĩa CD' AS LoaiSP, h.TenHang, bd.SoLuongTon 
                                     FROM BangDia bd LEFT JOIN Hang h ON bd.Hang_Id = h.Hang_Id 
                                     WHERE bd.TheLoai LIKE N'%CD%' AND (bd.TenBangDia LIKE @TK OR bd.MsBangDia LIKE @TK OR bd.NgheSi LIKE @TK)";
                    }
                    else if (cmbLoaiHang.SelectedIndex == 2) // Đĩa Than Vinyl
                    {
                        sqlQuery = @"SELECT bd.MsBangDia AS MaSP, bd.TenBangDia AS TenSP, ISNULL(bd.NgheSi, N'N/A') AS NgheSi, N'Đĩa Than (Vinyl)' AS LoaiSP, h.TenHang, bd.SoLuongTon 
                                     FROM BangDia bd LEFT JOIN Hang h ON bd.Hang_Id = h.Hang_Id 
                                     WHERE bd.TheLoai LIKE N'%Vinyl%' AND (bd.TenBangDia LIKE @TK OR bd.MsBangDia LIKE @TK OR bd.NgheSi LIKE @TK)";
                    }
                    else if (cmbLoaiHang.SelectedIndex == 3) // Băng Cassette
                    {
                        sqlQuery = @"SELECT bd.MsBangDia AS MaSP, bd.TenBangDia AS TenSP, ISNULL(bd.NgheSi, N'N/A') AS NgheSi, N'Băng Cassette' AS LoaiSP, h.TenHang, bd.SoLuongTon 
                                     FROM BangDia bd LEFT JOIN Hang h ON bd.Hang_Id = h.Hang_Id 
                                     WHERE bd.TheLoai LIKE N'%Cassette%' AND (bd.TenBangDia LIKE @TK OR bd.MsBangDia LIKE @TK OR bd.NgheSi LIKE @TK)";
                    }
                    else if (cmbLoaiHang.SelectedIndex == 4) // Thiết Bị Nghe Nhạc
                    {
                        sqlQuery = @"SELECT tb.MsThietBi AS MaSP, tb.TenThietBi AS TenSP, N'Thiết Bị Audio' AS NgheSi, N'Thiết bị nghe nhạc' AS LoaiSP, h.TenHang, tb.SoLuongTon 
                                     FROM ThietBi tb LEFT JOIN Hang h ON tb.Hang_Id = h.Hang_Id 
                                     WHERE tb.TenThietBi LIKE @TK OR tb.MsThietBi LIKE @TK";
                    }
                    else // Tất cả
                    {
                        sqlQuery = @"
                            SELECT bd.MsBangDia AS MaSP, bd.TenBangDia AS TenSP, ISNULL(bd.NgheSi, N'N/A') AS NgheSi, ISNULL(bd.TheLoai, N'Băng đĩa') AS LoaiSP, h.TenHang, bd.SoLuongTon 
                            FROM BangDia bd LEFT JOIN Hang h ON bd.Hang_Id = h.Hang_Id WHERE bd.TenBangDia LIKE @TK OR bd.MsBangDia LIKE @TK OR bd.NgheSi LIKE @TK
                            UNION ALL
                            SELECT tb.MsThietBi AS MaSP, tb.TenThietBi AS TenSP, N'Thiết Bị Audio' AS NgheSi, N'Thiết bị nghe nhạc' AS LoaiSP, h.TenHang, tb.SoLuongTon 
                            FROM ThietBi tb LEFT JOIN Hang h ON tb.Hang_Id = h.Hang_Id WHERE tb.TenThietBi LIKE @TK OR tb.MsThietBi LIKE @TK
                            ORDER BY SoLuongTon ASC";
                    }

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TK", "%" + txtTimKiem.Text.Trim() + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (!dt.Columns.Contains("GiaBan"))
                        {
                            dt.Columns.Add("GiaBan", typeof(decimal));
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string maSP = row["MaSP"].ToString();
                            string loaiSP = row["LoaiSP"].ToString();
                            bool isThietBi = loaiSP.Contains("Thiết bị") || loaiSP.Contains("Thiết Bị");

                            row["GiaBan"] = LayGiaBanAnToan(conn, maSP, isThietBi);
                        }

                        dgvKhoHang.DataSource = dt;
                        DinhDangGridKhoHang();
                        ToMauCanhBaoTonKho();
                        CapNhatThongKeKho(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách kho: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DinhDangGridKhoHang()
        {
            if (dgvKhoHang.Columns.Count > 0)
            {
                dgvKhoHang.Columns["MaSP"].HeaderText = "Mã SP";
                dgvKhoHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                if (dgvKhoHang.Columns.Contains("NgheSi"))
                {
                    dgvKhoHang.Columns["NgheSi"].HeaderText = "Nghệ Sĩ / Ca Sĩ";
                }
                dgvKhoHang.Columns["LoaiSP"].HeaderText = "Phân Loại Mặt Hàng";
                dgvKhoHang.Columns["TenHang"].HeaderText = "Hãng / Nhà Cung Cấp";
                dgvKhoHang.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn Kho";
                dgvKhoHang.Columns["GiaBan"].HeaderText = "Giá Bán (VNĐ)";

                dgvKhoHang.Columns["SoLuongTon"].DefaultCellStyle.Format = "N0";
                dgvKhoHang.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                dgvKhoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void ToMauCanhBaoTonKho()
        {
            foreach (DataGridViewRow row in dgvKhoHang.Rows)
            {
                if (row.Cells["SoLuongTon"].Value != null)
                {
                    int tonKho = Convert.ToInt32(row.Cells["SoLuongTon"].Value);
                    if (tonKho <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 205, 210);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (tonKho < 5)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }
        }

        private void CapNhatThongKeKho(DataTable dt)
        {
            int tongMatHang = dt.Rows.Count;
            int sapHetHang = 0;
            int tongSoLuongTon = 0;

            foreach (DataRow dr in dt.Rows)
            {
                int ton = Convert.ToInt32(dr["SoLuongTon"]);
                tongSoLuongTon += ton;
                if (ton < 5) sapHetHang++;
            }

            lblTongMatHang.Text = string.Format("{0} Mặt hàng", tongMatHang);
            lblTongSoLuongTon.Text = string.Format("{0:N0} Cái/Bộ", tongSoLuongTon);
            lblSapHetHang.Text = string.Format("{0} Cảnh báo", sapHetHang);
        }
        #endregion

        #region XỬ LÝ NHẬP HÀNG
        private void dgvKhoHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhoHang.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value.ToString();

                if (txtNgheSi != null && dgvKhoHang.Columns.Contains("NgheSi") && row.Cells["NgheSi"].Value != null)
                {
                    txtNgheSi.Text = row.Cells["NgheSi"].Value.ToString();
                }

                string loai = row.Cells["LoaiSP"].Value.ToString();
                if (loai.Contains("CD")) cmbPhanLoaiInput.SelectedItem = "Đĩa CD";
                else if (loai.Contains("Vinyl")) cmbPhanLoaiInput.SelectedItem = "Đĩa Than (Vinyl)";
                else if (loai.Contains("Cassette")) cmbPhanLoaiInput.SelectedItem = "Băng Cassette";
                else cmbPhanLoaiInput.SelectedItem = "Thiết Bị Nghe Nhạc";

                if (row.Cells["TenHang"].Value != null)
                {
                    cmbNhaCungCap.Text = row.Cells["TenHang"].Value.ToString();
                }

                txtTonHienTai.Text = row.Cells["SoLuongTon"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value != DBNull.Value ? string.Format("{0:N0}", row.Cells["GiaBan"].Value) : "0";
                nudSoLuongNhap.Value = 1;

                ThietLapTrangThaiForm(false);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            XoaFormNhapMoi();
        }

        private void XoaFormNhapMoi()
        {
            txtTenSP.Clear();
            if (txtNgheSi != null) txtNgheSi.Clear();
            cmbPhanLoaiInput.SelectedIndex = 0;
            cmbNhaCungCap.Text = "";
            txtTonHienTai.Text = "0 (Mới)";
            txtGiaBan.Text = "0";
            nudSoLuongNhap.Value = 1;

            txtMaSP.Text = TaoMaSanPhamTuDong(cmbPhanLoaiInput.SelectedItem.ToString());
            ThietLapTrangThaiForm(true);
        }

        private void ThietLapTrangThaiForm(bool choPhepNhapMoi)
        {
            isThemMoiSP = choPhepNhapMoi;

            txtMaSP.ReadOnly = true;
            txtTenSP.ReadOnly = !choPhepNhapMoi;
            if (txtNgheSi != null) txtNgheSi.ReadOnly = !choPhepNhapMoi;
            cmbPhanLoaiInput.Enabled = choPhepNhapMoi;

            if (choPhepNhapMoi)
            {
                lblTitleNhapKho.Text = "NHẬP SẢN PHẨM MỚI VÀO KHO";
                lblTitleNhapKho.ForeColor = Color.DarkGreen;
                btnXacNhanNhap.Text = "TẠO MỚI & NHẬP KHO";
                btnXacNhanNhap.BackColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                lblTitleNhapKho.Text = "CỘNG DỒN TỒN KHO SẢN PHẨM";
                lblTitleNhapKho.ForeColor = Color.FromArgb(44, 62, 80);
                btnXacNhanNhap.Text = "XÁC NHẬN CỘNG TỒN KHO";
                btnXacNhanNhap.BackColor = Color.FromArgb(52, 152, 219);
            }
        }

        private void btnXacNhanNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên sản phẩm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string giaBanStr = txtGiaBan.Text.Replace(",", "").Replace(".", "").Trim();
            decimal.TryParse(giaBanStr, out decimal giaBanNhap);

            string maSP = txtMaSP.Text.Trim();
            string tenSP = txtTenSP.Text.Trim();
            string ngheSi = (txtNgheSi != null && !string.IsNullOrWhiteSpace(txtNgheSi.Text)) ? txtNgheSi.Text.Trim() : "N/A";
            string phanLoai = cmbPhanLoaiInput.SelectedItem.ToString();
            string tenNhaCungCap = cmbNhaCungCap.Text.Trim();
            int soLuongNhap = (int)nudSoLuongNhap.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(strConnectionString))
                {
                    conn.Open();

                    string hangId = GetOrCreateHangId(conn, tenNhaCungCap);
                    bool isThietBi = phanLoai == "Thiết Bị Nghe Nhạc";

                    if (isThietBi)
                    {
                        if (isThemMoiSP)
                        {
                            string sql = "INSERT INTO ThietBi (MsThietBi, TenThietBi, LoaiThietBi, Hang_Id, SoLuongTon) VALUES (@MaSP, @TenSP, @Loai, @HangId, @SoLuong)";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                                cmd.Parameters.AddWithValue("@Loai", phanLoai);
                                cmd.Parameters.AddWithValue("@HangId", (object)hangId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sql = "UPDATE ThietBi SET SoLuongTon = SoLuongTon + @SoLuong, Hang_Id = ISNULL(@HangId, Hang_Id) WHERE MsThietBi = @MaSP";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                                cmd.Parameters.AddWithValue("@HangId", (object)hangId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else // Các loại đĩa (CD, Vinyl, Cassette) -> LƯU CẢ NGHỆ SĨ
                    {
                        if (isThemMoiSP)
                        {
                            string sql = "INSERT INTO BangDia (MsBangDia, TenBangDia, NgheSi, TheLoai, Hang_Id, SoLuongTon) VALUES (@MaSP, @TenSP, @NgheSi, @TheLoai, @HangId, @SoLuong)";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.Parameters.AddWithValue("@TenSP", tenSP);
                                cmd.Parameters.AddWithValue("@NgheSi", string.IsNullOrEmpty(ngheSi) ? "N/A" : ngheSi);
                                cmd.Parameters.AddWithValue("@TheLoai", phanLoai);
                                cmd.Parameters.AddWithValue("@HangId", (object)hangId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sql = "UPDATE BangDia SET SoLuongTon = SoLuongTon + @SoLuong, Hang_Id = ISNULL(@HangId, Hang_Id), NgheSi = ISNULL(@NgheSi, NgheSi) WHERE MsBangDia = @MaSP";
                            using (SqlCommand cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@SoLuong", soLuongNhap);
                                cmd.Parameters.AddWithValue("@HangId", (object)hangId ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@NgheSi", (object)ngheSi ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@MaSP", maSP);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // CẬP NHẬT GIÁ BÁN VÀO CSDL
                    CapNhatGiaBanAnToan(conn, maSP, giaBanNhap, isThietBi);

                    // GHI LỊCH SỬ NHẬP KHO TRỰC TIẾP VÀO CSDL
                    GhiNhatKyNhapKhoVaoCSDL(conn, maSP, tenSP, soLuongNhap, tenNhaCungCap, giaBanNhap);

                    MessageBox.Show(string.Format("Nhập kho thành công {0} sản phẩm [{1}]!\nNghệ sĩ: {2}\nGiá bán: {3:N0} VNĐ",
                                    soLuongNhap, tenSP, ngheSi, giaBanNhap),
                                    "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TaiDanhSachHangNhaCungCap();
                    XoaFormNhapMoi();
                    TaiDanhSachKhoHang();
                    TaiLichSuXuatNhapToanBo();
                    CapNhatTrucTiepGiaGrid(maSP, giaBanNhap);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu kho: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CapNhatTrucTiepGiaGrid(string maSP, decimal giaBan)
        {
            foreach (DataGridViewRow row in dgvKhoHang.Rows)
            {
                if (row.Cells["MaSP"].Value != null && row.Cells["MaSP"].Value.ToString() == maSP)
                {
                    row.Cells["GiaBan"].Value = giaBan;
                    break;
                }
            }
        }
        #endregion

        #region EVENT TRUY VẤN
        private void cmbLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachKhoHang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TaiDanhSachKhoHang();
        }
        #endregion
    }
}