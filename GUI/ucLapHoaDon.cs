using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucLapHoaDon : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private DataTable dtGioHang;
        private string maHoaDonVuaThanhToan = "";

        public ucLapHoaDon()
        {
            InitializeComponent();
            KhoiTaoGioHang();
            TaoMaHoaDonMoi();
            TaoNutHuyDonTuDong();
        }

        private void TaoNutHuyDonTuDong()
        {
            pnlRightTotal.Height = 180;

            if (!pnlRightTotal.Controls.ContainsKey("btnHuyDonVuaLap"))
            {
                Button btnHuy = new Button();
                btnHuy.Name = "btnHuyDonVuaLap";
                btnHuy.Text = "HỦY ĐƠN VỪA LẬP (TRẢ HÀNG)";
                btnHuy.BackColor = Color.FromArgb(235, 87, 87);
                btnHuy.ForeColor = Color.White;
                btnHuy.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                btnHuy.FlatStyle = FlatStyle.Flat;
                btnHuy.FlatAppearance.BorderSize = 0;
                btnHuy.Size = new Size(220, 28);
                btnHuy.Location = new Point(15, 140);
                btnHuy.Cursor = Cursors.Hand;
                btnHuy.Click += new EventHandler(this.btnHuyDonVuaLap_Click);

                pnlRightTotal.Controls.Add(btnHuy);
                btnHuy.BringToFront();
            }
        }

        private void KhoiTaoGioHang()
        {
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("MaSP", typeof(string));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("LoaiSP", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));

            dgvGioHang.DataSource = dtGioHang;

            dgvGioHang.Columns["MaSP"].HeaderText = "Mã SP";
            dgvGioHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvGioHang.Columns["LoaiSP"].HeaderText = "Loại";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số Lượng (Sửa được)";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            foreach (DataGridViewColumn col in dgvGioHang.Columns)
            {
                if (col.Name != "SoLuong")
                {
                    col.ReadOnly = true;
                }
            }
        }

        private void TaoMaHoaDonMoi()
        {
            txtSoHD.Text = "HD" + DateTime.Now.ToString("ddHHmmss");
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            txtSoHD.SelectionStart = 0;
            txtNgayLap.SelectionStart = 0;
        }

        private int LaySoLuongTonKho(string maSP, string loaiSP)
        {
            int tonKho = 0;
            string tableName = (loaiSP == "BangDia") ? "BangDia" : "ThietBi";
            string colName = (loaiSP == "BangDia") ? "MsBangDia" : "MsThietBi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = $"SELECT SoLuongTon FROM {tableName} WHERE {colName} = @MaSP";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSP", maSP);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            tonKho = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi lấy tồn kho: " + ex.Message);
                }
            }
            return tonKho;
        }

        // 1. NGHIỆP VỤ TÌM KHÁCH HÀNG KHI GÕ SĐT VÀ BẤM ENTER
        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string sdt = txtSDT.Text.Trim();
                if (string.IsNullOrEmpty(sdt))
                {
                    txtTenKH.Text = "Khách vãng lai";
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "SELECT HotenKh FROM KhachHang WHERE SoDtKh = @SDT";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@SDT", sdt);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            txtTenKH.Text = result.ToString();
                        }
                        else
                        {
                            txtTenKH.Text = "Khách Hàng Mới";
                            txtTenKH.Focus();
                            txtTenKH.SelectAll();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi tìm khách hàng: " + ex.Message);
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // 2. NGHIỆP VỤ QUÉT MÃ VẠCH SẢN PHẨM
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string maSP = txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(maSP)) return;

                TimVaThemVaoGioHang(maSP);
                txtBarcode.Clear();
                txtBarcode.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TimVaThemVaoGioHang(string maSP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Tìm đĩa
                    string sqlBD = @"SELECT BD.TenBangDia AS TenSP, 'BangDia' AS LoaiSP, ISNULL(BG.DonGiaBan, 0) AS DonGia, ISNULL(BD.SoLuongTon, 0) AS TonKho
                                     FROM BangDia BD LEFT JOIN BangGiaBangDia BG ON BD.MsBangDia = BG.MsBangDia WHERE BD.MsBangDia = @Ma";
                    SqlCommand cmdBD = new SqlCommand(sqlBD, conn);
                    cmdBD.Parameters.AddWithValue("@Ma", maSP);
                    SqlDataReader dr = cmdBD.ExecuteReader();

                    string tenSP = "", loaiSP = "";
                    decimal donGia = 0;
                    int tonKho = 0;
                    bool timThay = false;

                    if (dr.Read())
                    {
                        tenSP = dr["TenSP"].ToString();
                        loaiSP = dr["LoaiSP"].ToString();
                        donGia = Convert.ToDecimal(dr["DonGia"]);
                        tonKho = Convert.ToInt32(dr["TonKho"]);
                        timThay = true;
                    }
                    dr.Close();

                    // Tìm thiết bị
                    if (!timThay)
                    {
                        string sqlTB = @"SELECT TB.TenThietBi AS TenSP, 'ThietBi' AS LoaiSP, ISNULL(BG.DonGiaBan, 0) AS DonGia, ISNULL(TB.SoLuongTon, 0) AS TonKho
                                         FROM ThietBi TB LEFT JOIN BangGiaThietBi BG ON TB.MsThietBi = BG.MsThietBi WHERE TB.MsThietBi = @Ma";
                        SqlCommand cmdTB = new SqlCommand(sqlTB, conn);
                        cmdTB.Parameters.AddWithValue("@Ma", maSP);
                        dr = cmdTB.ExecuteReader();

                        if (dr.Read())
                        {
                            tenSP = dr["TenSP"].ToString();
                            loaiSP = dr["LoaiSP"].ToString();
                            donGia = Convert.ToDecimal(dr["DonGia"]);
                            tonKho = Convert.ToInt32(dr["TonKho"]);
                            timThay = true;
                        }
                        dr.Close();
                    }

                    if (!timThay)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm mã: " + maSP, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (tonKho <= 0)
                    {
                        MessageBox.Show($"Sản phẩm '{tenSP}' đã HẾT HÀNG trong kho!", "Hết hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thêm vào giỏ
                    DataRow[] existingRows = dtGioHang.Select("MaSP = '" + maSP + "'");
                    if (existingRows.Length > 0)
                    {
                        int currentQty = Convert.ToInt32(existingRows[0]["SoLuong"]);
                        if (currentQty + 1 > tonKho)
                        {
                            MessageBox.Show($"Sản phẩm '{tenSP}' chỉ còn {tonKho} cái trong kho!", "Vượt quá tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        existingRows[0]["SoLuong"] = currentQty + 1;
                        existingRows[0]["ThanhTien"] = (currentQty + 1) * donGia;
                    }
                    else
                    {
                        DataRow newRow = dtGioHang.NewRow();
                        newRow["MaSP"] = maSP;
                        newRow["TenSP"] = tenSP;
                        newRow["LoaiSP"] = loaiSP;
                        newRow["DonGia"] = donGia;
                        newRow["SoLuong"] = 1;
                        newRow["ThanhTien"] = donGia;
                        dtGioHang.Rows.Add(newRow);
                    }
                    TinhTongTien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 3. SỰ KIỆN KHI NGƯỜI DÙNG SỬA TRỰC TIẾP SỐ LƯỢNG TRÊN LƯỚI
        private void dgvGioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGioHang.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                DataGridViewRow row = dgvGioHang.Rows[e.RowIndex];
                string maSP = row.Cells["MaSP"].Value?.ToString();
                string loaiSP = row.Cells["LoaiSP"].Value?.ToString();
                string tenSP = row.Cells["TenSP"].Value?.ToString();
                decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                if (int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int sl) && sl > 0)
                {
                    int tonKho = LaySoLuongTonKho(maSP, loaiSP);

                    if (sl > tonKho)
                    {
                        MessageBox.Show(
                            $"Sản phẩm '{tenSP}' hiện chỉ còn tồn kho {tonKho} cái!\nKhông đủ số lượng để lập đơn {sl} cái.",
                            "Cảnh báo vượt tồn kho",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        sl = (tonKho > 0) ? tonKho : 1;
                        row.Cells["SoLuong"].Value = sl;
                    }

                    row.Cells["ThanhTien"].Value = sl * donGia;
                }
                else
                {
                    MessageBox.Show("Số lượng mua phải là số nguyên lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["SoLuong"].Value = 1;
                    row.Cells["ThanhTien"].Value = donGia;
                }

                TinhTongTien();
            }
        }

        private decimal TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTienVal.Text = string.Format("{0:#,##0} VNĐ", tongTien);
            return tongTien;
        }

        // 4. NGHIỆP VỤ THANH TOÁN (TỰ ĐỘNG GÁN KHÁCH VÃNG LAI NẾU BỎ TRỐNG)
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống! Vui lòng quét mã sản phẩm trước.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sdt = txtSDT.Text.Trim();
            string tenKH = txtTenKH.Text.Trim();

            // TỰ ĐỘNG GÁN KHÁCH VÃNG LAI NẾU THU NGÂN ĐỂ TRỐNG Ô NHẬP LIỆU
            bool isKhachVangLai = false;
            if (string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(tenKH))
            {
                isKhachVangLai = true;
                tenKH = "Khách vãng lai";
                sdt = "0000000000";
            }
            else if (string.IsNullOrEmpty(tenKH))
            {
                tenKH = "Khách Hàng Mới";
            }

            // KIỂM TRA LẠI TỒN KHO TOÀN BỘ GIỎ HÀNG TRƯỚC KHI THỰC HIỆN GIAO DỊCH
            foreach (DataRow row in dtGioHang.Rows)
            {
                string maSP = row["MaSP"].ToString();
                string loaiSP = row["LoaiSP"].ToString();
                string tenSP = row["TenSP"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                int tonKho = LaySoLuongTonKho(maSP, loaiSP);

                if (soLuong > tonKho)
                {
                    MessageBox.Show($"Sản phẩm '{tenSP}' hiện chỉ còn tồn {tonKho} cái trong kho, không đủ để xuất {soLuong} cái!",
                                    "Không đủ hàng tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string maKH = "";

                    // A. XỬ LÝ MÃ KHÁCH HÀNG
                    if (isKhachVangLai)
                    {
                        // Kiểm tra mã KVL00 đã có trong CSDL chưa
                        SqlCommand cmdCheckKVL = new SqlCommand("SELECT MaKh FROM KhachHang WHERE MaKh = 'KVL00' OR SoDtKh = '0000000000'", conn, transaction);
                        object objKVL = cmdCheckKVL.ExecuteScalar();
                        if (objKVL != null)
                        {
                            maKH = objKVL.ToString();
                        }
                        else
                        {
                            maKH = "KVL00";
                            SqlCommand cmdInsertKVL = new SqlCommand("INSERT INTO KhachHang (MaKh, HotenKh, SoDtKh) VALUES ('KVL00', N'Khách vãng lai', '0000000000')", conn, transaction);
                            cmdInsertKVL.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Tìm khách hàng theo SĐT
                        SqlCommand cmdCheck = new SqlCommand("SELECT MaKh FROM KhachHang WHERE SoDtKh = @SDT", conn, transaction);
                        cmdCheck.Parameters.AddWithValue("@SDT", sdt);
                        object objMaKH = cmdCheck.ExecuteScalar();

                        if (objMaKH != null)
                        {
                            maKH = objMaKH.ToString();
                        }
                        else
                        {
                            maKH = "KH" + DateTime.Now.ToString("ddHHmmss");
                            SqlCommand cmdKH = new SqlCommand("INSERT INTO KhachHang (MaKh, HotenKh, SoDtKh) VALUES (@Ma, @Ten, @SDT)", conn, transaction);
                            cmdKH.Parameters.AddWithValue("@Ma", maKH);
                            cmdKH.Parameters.AddWithValue("@Ten", tenKH);
                            cmdKH.Parameters.AddWithValue("@SDT", sdt);
                            cmdKH.ExecuteNonQuery();
                        }
                    }

                    // B. LƯU HÓA ĐƠN CHÍNH
                    string soHD = txtSoHD.Text;
                    string maNVHienTai = string.IsNullOrEmpty(frmAuth.MaNhanVien) ? "NV01" : frmAuth.MaNhanVien;

                    string sqlHD = "INSERT INTO HoaDonBan (SoHdBan, NgayBan, MaKh, MsNv) VALUES (@SoHD, GETDATE(), @MaKH, @MsNv)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@SoHD", soHD);
                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);
                    cmdHD.Parameters.AddWithValue("@MsNv", maNVHienTai);
                    cmdHD.ExecuteNonQuery();

                    // C. LƯU CHI TIẾT & TRỪ TỒN KHO
                    foreach (DataRow row in dtGioHang.Rows)
                    {
                        string maSP = row["MaSP"].ToString();
                        string loaiSP = row["LoaiSP"].ToString();
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);

                        if (loaiSP == "BangDia")
                        {
                            // Lưu chi tiết đĩa
                            SqlCommand cmdCT = new SqlCommand("INSERT INTO ChiTietHoaDonBangDia (SoHdBan, MsBangDia, Soluong, Dongia) VALUES (@SoHD, @MaSP, @SL, @Gia)", conn, transaction);
                            cmdCT.Parameters.AddWithValue("@SoHD", soHD);
                            cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                            cmdCT.Parameters.AddWithValue("@SL", soLuong);
                            cmdCT.Parameters.AddWithValue("@Gia", donGia);
                            cmdCT.ExecuteNonQuery();

                            // Trừ tồn kho đĩa
                            SqlCommand cmdTon = new SqlCommand("UPDATE BangDia SET SoLuongTon = SoLuongTon - @SL WHERE MsBangDia = @MaSP", conn, transaction);
                            cmdTon.Parameters.AddWithValue("@SL", soLuong);
                            cmdTon.Parameters.AddWithValue("@MaSP", maSP);
                            cmdTon.ExecuteNonQuery();
                        }
                        else
                        {
                            // Lưu chi tiết thiết bị
                            SqlCommand cmdCT = new SqlCommand("INSERT INTO ChiTietHoaDonThietBi (SoHdBan, MsThietBi, Soluong, Dongia) VALUES (@SoHD, @MaSP, @SL, @Gia)", conn, transaction);
                            cmdCT.Parameters.AddWithValue("@SoHD", soHD);
                            cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                            cmdCT.Parameters.AddWithValue("@SL", soLuong);
                            cmdCT.Parameters.AddWithValue("@Gia", donGia);
                            cmdCT.ExecuteNonQuery();

                            // Trừ tồn kho thiết bị
                            SqlCommand cmdTon = new SqlCommand("UPDATE ThietBi SET SoLuongTon = SoLuongTon - @SL WHERE MsThietBi = @MaSP", conn, transaction);
                            cmdTon.Parameters.AddWithValue("@SL", soLuong);
                            cmdTon.Parameters.AddWithValue("@MaSP", maSP);
                            cmdTon.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    maHoaDonVuaThanhToan = soHD;

                    // D. XUẤT HÓA ĐƠN ĐẸP MẮT RA CỬA SỔ IN
                    InXuatHoaDonChuyenNghiep(tenKH, sdt);

                    // Reset trang sau khi thanh toán thành công
                    dtGioHang.Clear();
                    TaoMaHoaDonMoi();
                    txtSDT.Clear();
                    txtTenKH.Clear();
                    TinhTongTien();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // GỌI FORM IN HÓA ĐƠN
        private void InXuatHoaDonChuyenNghiep(string ten, string sdt)
        {
            DataTable dtChiTietIn = new DataTable();
            dtChiTietIn.Columns.Add("Tên Sản Phẩm", typeof(string));
            dtChiTietIn.Columns.Add("Số Lượng", typeof(int));
            dtChiTietIn.Columns.Add("Đơn Giá", typeof(decimal));
            dtChiTietIn.Columns.Add("Thành Tiền", typeof(decimal));

            foreach (DataRow row in dtGioHang.Rows)
            {
                dtChiTietIn.Rows.Add(
                    row["TenSP"].ToString(),
                    Convert.ToInt32(row["SoLuong"]),
                    Convert.ToDecimal(row["DonGia"]),
                    Convert.ToDecimal(row["ThanhTien"])
                );
            }

            string tenThuNganHienTai = string.IsNullOrEmpty(frmAuth.TenNhanVien) ? "Thu ngân" : frmAuth.TenNhanVien;
            decimal tongTien = TinhTongTien();

            frmInHoaDon frmIn = new frmInHoaDon(
                txtSoHD.Text,
                DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                ten,
                sdt,
                tenThuNganHienTai,
                dtChiTietIn,
                tongTien
            );

            frmIn.ShowDialog();
        }

        // 5. NGHIỆP VỤ HỦY HÓA ĐƠN TRẢ HÀNG
        private void btnHuyDonVuaLap_Click(object sender, EventArgs e)
        {
            frmTraHang formTraHang = new frmTraHang();
            formTraHang.ShowDialog();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                {
                    if (!row.IsNewRow) dgvGioHang.Rows.Remove(row);
                }
                TinhTongTien();
            }
        }

        private void btnHuyGio_Click(object sender, EventArgs e)
        {
            dtGioHang.Clear();
            TinhTongTien();
        }
    }
}