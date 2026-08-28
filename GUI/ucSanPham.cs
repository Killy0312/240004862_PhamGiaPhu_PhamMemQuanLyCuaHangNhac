using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace QLCuaHangBangDiaThietBi
{
    public partial class ucSanPham : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private string selectedImagePath = "";
        private string imageFolder = Path.Combine(Application.StartupPath, "Images");

        public ucSanPham()
        {
            InitializeComponent();

            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            this.Load += ucSanPham_Load;
        }

        private void ucSanPham_Load(object sender, EventArgs e)
        {
            // Tắt dòng trống (*) ở cuối lưới để chống click nhầm gây lỗi DBNull
            dgvSanPham.AllowUserToAddRows = false;

            LoadComboBoxData();
            LoadDataToGridView();
            PhanQuyenNguoiDung();
        }

        private void PhanQuyenNguoiDung()
        {
            string chucVu = GUI.frmAuth.ChucVu;
            bool isNhanVien = string.IsNullOrEmpty(chucVu) ||
                              chucVu.Equals("NhanVien", StringComparison.OrdinalIgnoreCase) ||
                              chucVu.Equals("Nhân viên bán hàng", StringComparison.OrdinalIgnoreCase) ||
                              chucVu.Contains("Nhân viên");

            if (isNhanVien)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnChonAnh.Enabled = false;

                btnThem.BackColor = Color.Gray;
                btnSua.BackColor = Color.Gray;
                btnXoa.BackColor = Color.Gray;
                btnChonAnh.BackColor = Color.Gray;

                txtMaSP.ReadOnly = true;
                txtTenSP.ReadOnly = true;
                txtNgheSi.ReadOnly = true;
                txtSoTon.ReadOnly = true;
                txtGiaBan.ReadOnly = true;
                cboHang.Enabled = false;
                cboLoaiSP.Enabled = false;

                txtTimKiem.ReadOnly = false;
                txtTimKiem.Enabled = true;
                dgvSanPham.Enabled = true;
            }
        }

        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT Hang_Id, TenHang FROM Hang", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboHang.DataSource = dt;
                    cboHang.DisplayMember = "TenHang";
                    cboHang.ValueMember = "Hang_Id";

                    cboLoaiSP.Items.Clear();
                    cboLoaiSP.Items.Add("Đĩa CD");
                    cboLoaiSP.Items.Add("Đĩa than Vinyl");
                    cboLoaiSP.Items.Add("Băng Cassette");
                    cboLoaiSP.Items.Add("Thiết bị nghe nhạc");
                    cboLoaiSP.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // HÀM TẢI VÀ TÌM KIẾM CHI TIẾT SẢN PHẨM TOÀN DIỆN
        public void LoadDataToGridView(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            BD.MsBangDia AS [Mã SP], 
                            BD.TenBangDia AS [Tên Sản Phẩm], 
                            ISNULL(BD.NgheSi, N'N/A') AS [Nghệ Sĩ / Ca Sĩ], 
                            ISNULL(H.TenHang, N'Khác') AS [Hãng SX / Nhà PH], 
                            ISNULL(BD.TheLoai, N'Đĩa CD') AS [Loại SP], 
                            ISNULL(BD.SoLuongTon, 0) AS [Số Tồn], 
                            ISNULL(BG.DonGiaBan, 0) AS [Giá Bán]
                        FROM BangDia BD 
                        LEFT JOIN Hang H ON BD.Hang_Id = H.Hang_Id
                        LEFT JOIN BangGiaBangDia BG ON BD.MsBangDia = BG.MsBangDia
                        WHERE (
                            BD.TenBangDia LIKE @kw 
                            OR BD.NgheSi LIKE @kw 
                            OR H.TenHang LIKE @kw 
                            OR BD.MsBangDia LIKE @kw 
                            OR BD.TheLoai LIKE @kw
                        )
                        
                        UNION ALL
                        
                        SELECT 
                            TB.MsThietBi AS [Mã SP], 
                            TB.TenThietBi AS [Tên Sản Phẩm], 
                            N'Thiết Bị Audio' AS [Nghệ Sĩ / Ca Sĩ], 
                            ISNULL(H.TenHang, N'Khác') AS [Hãng SX / Nhà PH], 
                            ISNULL(NULLIF(TB.LoaiThietBi, ''), N'Thiết bị nghe nhạc') AS [Loại SP], 
                            ISNULL(TB.SoLuongTon, 0) AS [Số Tồn], 
                            ISNULL(BG.DonGiaBan, 0) AS [Giá Bán]
                        FROM ThietBi TB 
                        LEFT JOIN Hang H ON TB.Hang_Id = H.Hang_Id
                        LEFT JOIN BangGiaThietBi BG ON TB.MsThietBi = BG.MsThietBi
                        WHERE (
                            TB.TenThietBi LIKE @kw 
                            OR H.TenHang LIKE @kw 
                            OR TB.MsThietBi LIKE @kw 
                            OR ISNULL(TB.LoaiThietBi, N'Thiết bị nghe nhạc') LIKE @kw
                            OR N'Thiết Bị Audio' LIKE @kw
                        )
                        
                        ORDER BY [Mã SP] ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvSanPham.DataSource = dt;

                        // Định dạng cột
                        if (dgvSanPham.Columns["Giá Bán"] != null)
                        {
                            dgvSanPham.Columns["Giá Bán"].DefaultCellStyle.Format = "N0";
                            dgvSanPham.Columns["Giá Bán"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        if (dgvSanPham.Columns["Số Tồn"] != null)
                        {
                            dgvSanPham.Columns["Số Tồn"].DefaultCellStyle.Format = "N0";
                            dgvSanPham.Columns["Số Tồn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView(txtTimKiem.Text.Trim());
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Chặn click tiêu đề hoặc dòng mới
            if (e.RowIndex < 0 || e.RowIndex >= dgvSanPham.Rows.Count || dgvSanPham.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

            // 2. Chặn ô rỗng
            if (row.Cells["Mã SP"].Value == null || row.Cells["Mã SP"].Value == DBNull.Value)
            {
                return;
            }

            try
            {
                string maSP = row.Cells["Mã SP"].Value.ToString();

                txtMaSP.Text = maSP;
                txtTenSP.Text = row.Cells["Tên Sản Phẩm"].Value?.ToString() ?? "";
                txtNgheSi.Text = row.Cells["Nghệ Sĩ / Ca Sĩ"].Value?.ToString() ?? "";
                cboHang.Text = row.Cells["Hãng SX / Nhà PH"].Value?.ToString() ?? "";

                string loaiSP = row.Cells["Loại SP"].Value?.ToString() ?? "Đĩa CD";
                if (loaiSP.Contains("CD")) cboLoaiSP.SelectedItem = "Đĩa CD";
                else if (loaiSP.Contains("Vinyl")) cboLoaiSP.SelectedItem = "Đĩa than Vinyl";
                else if (loaiSP.Contains("Cassette")) cboLoaiSP.SelectedItem = "Băng Cassette";
                else cboLoaiSP.SelectedItem = "Thiết bị nghe nhạc";

                txtSoTon.Text = (row.Cells["Số Tồn"].Value != null && row.Cells["Số Tồn"].Value != DBNull.Value)
                                ? row.Cells["Số Tồn"].Value.ToString() : "0";

                if (row.Cells["Giá Bán"].Value != null && row.Cells["Giá Bán"].Value != DBNull.Value &&
                    decimal.TryParse(row.Cells["Giá Bán"].Value.ToString(), out decimal giaBanVal))
                {
                    txtGiaBan.Text = giaBanVal.ToString("0.##");
                }
                else
                {
                    txtGiaBan.Text = "0";
                }

                txtMaSP.SelectionStart = 0;
                txtTenSP.SelectionStart = 0;
                txtNgheSi.SelectionStart = 0;
                cboHang.SelectionStart = 0;
                cboLoaiSP.SelectionStart = 0;
                txtSoTon.SelectionStart = 0;
                txtGiaBan.SelectionStart = 0;

                // Nạp ảnh sản phẩm
                picHinhAnh.ImageLocation = null;
                picHinhAnh.Image = null;
                selectedImagePath = "";

                string imgJpg = Path.Combine(imageFolder, maSP + ".jpg");
                string imgPng = Path.Combine(imageFolder, maSP + ".png");

                if (File.Exists(imgJpg))
                {
                    picHinhAnh.ImageLocation = imgJpg;
                }
                else if (File.Exists(imgPng))
                {
                    picHinhAnh.ImageLocation = imgPng;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp dữ liệu dòng: " + ex.Message);
            }
        }

        private void LuuAnhVaoHeThong(string maSP)
        {
            if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
            {
                string extension = Path.GetExtension(selectedImagePath);
                string destinationPath = Path.Combine(imageFolder, maSP + extension);

                if (selectedImagePath != destinationPath)
                {
                    try
                    {
                        File.Copy(selectedImagePath, destinationPath, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi copy ảnh: " + ex.Message);
                    }
                }
            }
        }

        private decimal ParseGiaBanAnToan(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return 0;
            string clean = input.Trim().Replace(" ", "");

            if (clean.Contains(",") && clean.Contains("."))
            {
                clean = clean.Replace(".", "").Replace(",", ".");
            }
            else if (clean.Contains(","))
            {
                clean = clean.Replace(",", ".");
            }

            if (decimal.TryParse(clean, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            return 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSP = txtMaSP.Text.Trim();
            string loaiChon = cboLoaiSP.Text;
            int soTon = int.TryParse(txtSoTon.Text, out int st) ? st : 0;
            decimal giaBan = ParseGiaBanAnToan(txtGiaBan.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (loaiChon == "Thiết bị nghe nhạc")
                    {
                        string queryTB = "INSERT INTO ThietBi (MsThietBi, TenThietBi, LoaiThietBi, Hang_Id, SoLuongTon) VALUES (@Ma, @Ten, @Loai, @Hang, @SoTon)";
                        SqlCommand cmdTB = new SqlCommand(queryTB, conn);
                        cmdTB.Parameters.AddWithValue("@Ma", maSP);
                        cmdTB.Parameters.AddWithValue("@Ten", txtTenSP.Text.Trim());
                        cmdTB.Parameters.AddWithValue("@Loai", loaiChon);
                        cmdTB.Parameters.AddWithValue("@Hang", cboHang.SelectedValue ?? DBNull.Value);
                        cmdTB.Parameters.AddWithValue("@SoTon", soTon);
                        cmdTB.ExecuteNonQuery();

                        string queryGiaTB = @"
                            IF EXISTS (SELECT 1 FROM BangGiaThietBi WHERE MsThietBi = @Ma)
                                UPDATE BangGiaThietBi SET DonGiaBan = @GiaBan, NgayAd = GETDATE() WHERE MsThietBi = @Ma;
                            ELSE
                                INSERT INTO BangGiaThietBi (MsThietBi, NgayAd, DonGiaBan) VALUES (@Ma, GETDATE(), @GiaBan);";
                        SqlCommand cmdGiaTB = new SqlCommand(queryGiaTB, conn);
                        cmdGiaTB.Parameters.AddWithValue("@Ma", maSP);
                        cmdGiaTB.Parameters.AddWithValue("@GiaBan", giaBan);
                        cmdGiaTB.ExecuteNonQuery();
                    }
                    else
                    {
                        string queryBD = "INSERT INTO BangDia (MsBangDia, TenBangDia, NgheSi, TheLoai, Hang_Id, SoLuongTon) VALUES (@Ma, @Ten, @NgheSi, @Loai, @Hang, @SoTon)";
                        SqlCommand cmdBD = new SqlCommand(queryBD, conn);
                        cmdBD.Parameters.AddWithValue("@Ma", maSP);
                        cmdBD.Parameters.AddWithValue("@Ten", txtTenSP.Text.Trim());
                        cmdBD.Parameters.AddWithValue("@NgheSi", txtNgheSi.Text.Trim());
                        cmdBD.Parameters.AddWithValue("@Loai", loaiChon);
                        cmdBD.Parameters.AddWithValue("@Hang", cboHang.SelectedValue ?? DBNull.Value);
                        cmdBD.Parameters.AddWithValue("@SoTon", soTon);
                        cmdBD.ExecuteNonQuery();

                        string queryGiaBD = @"
                            IF EXISTS (SELECT 1 FROM BangGiaBangDia WHERE MsBangDia = @Ma)
                                UPDATE BangGiaBangDia SET DonGiaBan = @GiaBan, NgayAd = GETDATE() WHERE MsBangDia = @Ma;
                            ELSE
                                INSERT INTO BangGiaBangDia (MsBangDia, NgayAd, DonGiaBan) VALUES (@Ma, GETDATE(), @GiaBan);";
                        SqlCommand cmdGiaBD = new SqlCommand(queryGiaBD, conn);
                        cmdGiaBD.Parameters.AddWithValue("@Ma", maSP);
                        cmdGiaBD.Parameters.AddWithValue("@GiaBan", giaBan);
                        cmdGiaBD.ExecuteNonQuery();
                    }

                    LuuAnhVaoHeThong(maSP);

                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGridView();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soTon = int.TryParse(txtSoTon.Text, out int st) ? st : 0;
            decimal giaBan = ParseGiaBanAnToan(txtGiaBan.Text);
            string loaiChon = cboLoaiSP.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    if (loaiChon == "Thiết bị nghe nhạc")
                    {
                        string q1 = "UPDATE ThietBi SET TenThietBi=@Ten, LoaiThietBi=@Loai, Hang_Id=@Hang, SoLuongTon=@SoTon WHERE MsThietBi=@Ma";
                        SqlCommand c1 = new SqlCommand(q1, conn);
                        c1.Parameters.AddWithValue("@Ten", txtTenSP.Text.Trim());
                        c1.Parameters.AddWithValue("@Loai", loaiChon);
                        c1.Parameters.AddWithValue("@Hang", cboHang.SelectedValue ?? DBNull.Value);
                        c1.Parameters.AddWithValue("@SoTon", soTon);
                        c1.Parameters.AddWithValue("@Ma", maSP);
                        c1.ExecuteNonQuery();

                        string q2 = @"
                            IF EXISTS (SELECT 1 FROM BangGiaThietBi WHERE MsThietBi = @Ma)
                                UPDATE BangGiaThietBi SET DonGiaBan = @GiaBan, NgayAd = GETDATE() WHERE MsThietBi = @Ma;
                            ELSE
                                INSERT INTO BangGiaThietBi (MsThietBi, NgayAd, DonGiaBan) VALUES (@Ma, GETDATE(), @GiaBan);";
                        SqlCommand c2 = new SqlCommand(q2, conn);
                        c2.Parameters.AddWithValue("@GiaBan", giaBan);
                        c2.Parameters.AddWithValue("@Ma", maSP);
                        c2.ExecuteNonQuery();
                    }
                    else
                    {
                        string q1 = "UPDATE BangDia SET TenBangDia=@Ten, NgheSi=@NgheSi, TheLoai=@Loai, Hang_Id=@Hang, SoLuongTon=@SoTon WHERE MsBangDia=@Ma";
                        SqlCommand c1 = new SqlCommand(q1, conn);
                        c1.Parameters.AddWithValue("@Ten", txtTenSP.Text.Trim());
                        c1.Parameters.AddWithValue("@NgheSi", txtNgheSi.Text.Trim());
                        c1.Parameters.AddWithValue("@Loai", loaiChon);
                        c1.Parameters.AddWithValue("@Hang", cboHang.SelectedValue ?? DBNull.Value);
                        c1.Parameters.AddWithValue("@SoTon", soTon);
                        c1.Parameters.AddWithValue("@Ma", maSP);
                        c1.ExecuteNonQuery();

                        string q2 = @"
                            IF EXISTS (SELECT 1 FROM BangGiaBangDia WHERE MsBangDia = @Ma)
                                UPDATE BangGiaBangDia SET DonGiaBan = @GiaBan, NgayAd = GETDATE() WHERE MsBangDia = @Ma;
                            ELSE
                                INSERT INTO BangGiaBangDia (MsBangDia, NgayAd, DonGiaBan) VALUES (@Ma, GETDATE(), @GiaBan);";
                        SqlCommand c2 = new SqlCommand(q2, conn);
                        c2.Parameters.AddWithValue("@GiaBan", giaBan);
                        c2.Parameters.AddWithValue("@Ma", maSP);
                        c2.ExecuteNonQuery();
                    }

                    LuuAnhVaoHeThong(maSP);

                    MessageBox.Show("Cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text.Trim();
            if (string.IsNullOrEmpty(maSP)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand c1 = new SqlCommand("DELETE FROM BangGiaBangDia WHERE MsBangDia=@Ma; DELETE FROM BangDia WHERE MsBangDia=@Ma;", conn);
                        c1.Parameters.AddWithValue("@Ma", maSP);
                        c1.ExecuteNonQuery();

                        SqlCommand c2 = new SqlCommand("DELETE FROM BangGiaThietBi WHERE MsThietBi=@Ma; DELETE FROM ThietBi WHERE MsThietBi=@Ma;", conn);
                        c2.Parameters.AddWithValue("@Ma", maSP);
                        c2.ExecuteNonQuery();

                        string imgJpg = Path.Combine(imageFolder, maSP + ".jpg");
                        string imgPng = Path.Combine(imageFolder, maSP + ".png");
                        if (File.Exists(imgJpg)) File.Delete(imgJpg);
                        if (File.Exists(imgPng)) File.Delete(imgPng);

                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGridView();
                        btnLamMoi_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtNgheSi.Clear();
            txtSoTon.Clear();
            txtGiaBan.Clear();
            txtTimKiem.Clear();
            if (cboHang.Items.Count > 0) cboHang.SelectedIndex = 0;
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;

            picHinhAnh.ImageLocation = null;
            picHinhAnh.Image = null;
            selectedImagePath = "";

            LoadDataToGridView();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.avif;*.webp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                picHinhAnh.ImageLocation = selectedImagePath;
            }
        }
    }
}