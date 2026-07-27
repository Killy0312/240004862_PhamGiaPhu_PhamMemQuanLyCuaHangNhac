using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QLCuaHangBangDiaThietBi
{
    public partial class ucSanPham : UserControl
    {
        // Chuỗi kết nối SQL Server
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private string selectedImagePath = "";

        public ucSanPham()
        {
            InitializeComponent();
            LoadComboBoxData();
            LoadDataToGridView();
        }

        // 1. Nạp danh sách Hãng từ SQL vào ComboBox
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

                    // NẠP 4 LOẠI SẢN PHẨM MỚI THEO YÊU CẦU
                    cboLoaiSP.Items.Clear();
                    cboLoaiSP.Items.Add("Đĩa CD");
                    cboLoaiSP.Items.Add("Đĩa than Vinyl");
                    cboLoaiSP.Items.Add("Băng Cassette");
                    cboLoaiSP.Items.Add("Thiết bị nghe nhạc");
                    cboLoaiSP.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp danh mục: " + ex.Message);
                }
            }
        }

        // 2. Nạp dữ liệu Sản phẩm vào DataGridView
        private void LoadDataToGridView(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Gộp danh sách cả Băng Đĩa (CD, Vinyl, Cassette) lẫn Thiết Bị Nghe Nhạc
                    string query = @"
                SELECT BD.MsBangDia AS MaSP, BD.TenBangDia AS TenSP, H.TenHang, 
                       BD.TheLoai AS Loai, BG.DonGiaBan, BG.DonGiaThue
                FROM BangDia BD 
                LEFT JOIN Hang H ON BD.Hang_Id = H.Hang_Id
                LEFT JOIN BangGiaBangDia BG ON BD.MsBangDia = BG.MsBangDia
                WHERE BD.TenBangDia LIKE @kw OR BD.MsBangDia LIKE @kw
                
                UNION ALL
                
                SELECT TB.MsThietBi AS MaSP, TB.TenThietBi AS TenSP, H.TenHang, 
                       TB.LoaiThietBi AS Loai, BG.DonGiaBan, BG.DonGiaThue
                FROM ThietBi TB 
                LEFT JOIN Hang H ON TB.Hang_Id = H.Hang_Id
                LEFT JOIN BangGiaThietBi BG ON TB.MsThietBi = BG.MsThietBi
                WHERE TB.TenThietBi LIKE @kw OR TB.MsThietBi LIKE @kw";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSanPham.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        // 3. Chọn ảnh cho sản phẩm
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = open.FileName;
                picHinhAnh.Image = Image.FromFile(open.FileName);
            }
        }

        // 4. Thêm sản phẩm mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiChon = cboLoaiSP.Text;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Nếu chọn "Thiết bị nghe nhạc" -> Lưu vào bảng ThietBi
                    if (loaiChon == "Thiết bị nghe nhạc")
                    {
                        string queryTB = "INSERT INTO ThietBi (MsThietBi, TenThietBi, LoaiThietBi, Hang_Id) VALUES (@Ma, @Ten, @Loai, @Hang)";
                        SqlCommand cmdTB = new SqlCommand(queryTB, conn);
                        cmdTB.Parameters.AddWithValue("@Ma", txtMaSP.Text.Trim());
                        cmdTB.Parameters.AddWithValue("@Ten", txtTenSP.Text.Trim());
                        cmdTB.Parameters.AddWithValue("@Loai", loaiChon);
                        cmdTB.Parameters.AddWithValue("@Hang", cboHang.SelectedValue);
                        cmdTB.ExecuteNonQuery();

                        string queryGiaTB = "INSERT INTO BangGiaThietBi (MsThietBi, NgayAd, DonGiaBan, DonGiaThue) VALUES (@Ma, GETDATE(), @GiaBan, @GiaThue)";
                        SqlCommand cmdGiaTB = new SqlCommand(queryGiaTB, conn);
                        cmdGiaTB.Parameters.AddWithValue("@Ma", txtMaSP.Text.Trim());
                        cmdGiaTB.Parameters.AddWithValue("@GiaBan", decimal.TryParse(txtGiaBan.Text, out decimal gb) ? gb : 0);
                        cmdGiaTB.Parameters.AddWithValue("@GiaThue", decimal.TryParse(txtGiaThue.Text, out decimal gt) ? gt : 0);
                        cmdGiaTB.ExecuteNonQuery();
                    }
                    // Nếu chọn CD, Vinyl, Cassette -> Lưu vào bảng BangDia
                    else
                    {
                        string queryBD = "INSERT INTO BangDia (MsBangDia, TenBangDia, TheLoai, Hang_Id) VALUES (@Ma, @Ten, @Loai, @Hang)";
                        SqlCommand cmdBD = new SqlCommand(queryBD, conn);
                        cmdBD.Parameters.AddWithValue("@Ma", txtMaSP.Text.Trim());
                        cmdBD.Parameters.AddWithValue("@Ten", txtTenSP.Text.Trim());
                        cmdBD.Parameters.AddWithValue("@Loai", loaiChon);
                        cmdBD.Parameters.AddWithValue("@Hang", cboHang.SelectedValue);
                        cmdBD.ExecuteNonQuery();

                        string queryGiaBD = "INSERT INTO BangGiaBangDia (MsBangDia, NgayAd, DonGiaBan, DonGiaThue) VALUES (@Ma, GETDATE(), @GiaBan, @GiaThue)";
                        SqlCommand cmdGiaBD = new SqlCommand(queryGiaBD, conn);
                        cmdGiaBD.Parameters.AddWithValue("@Ma", txtMaSP.Text.Trim());
                        cmdGiaBD.Parameters.AddWithValue("@GiaBan", decimal.TryParse(txtGiaBan.Text, out decimal gb) ? gb : 0);
                        cmdGiaBD.Parameters.AddWithValue("@GiaThue", decimal.TryParse(txtGiaThue.Text, out decimal gt) ? gt : 0);
                        cmdGiaBD.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm sản phẩm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGridView();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message);
                }
            }
        }

        // 5. Click vào dòng trong DataGridView để đổ dữ liệu lên ô nhập
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSP"].Value?.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString();
                cboHang.Text = row.Cells["TenHang"].Value?.ToString();
                cboLoaiSP.Text = row.Cells["Loai"].Value?.ToString();
                txtGiaBan.Text = row.Cells["DonGiaBan"].Value?.ToString();
                txtGiaThue.Text = row.Cells["DonGiaThue"].Value?.ToString();
            }
        }

        // 6. Xóa sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text)) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd1 = new SqlCommand("DELETE FROM BangGiaBangDia WHERE MsBangDia = @Ma", conn);
                        cmd1.Parameters.AddWithValue("@Ma", txtMaSP.Text);
                        cmd1.ExecuteNonQuery();

                        SqlCommand cmd2 = new SqlCommand("DELETE FROM BangDia WHERE MsBangDia = @Ma", conn);
                        cmd2.Parameters.AddWithValue("@Ma", txtMaSP.Text);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Xóa thành công!");
                        LoadDataToGridView();
                        btnLamMoi_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa: " + ex.Message);
                    }
                }
            }
        }

        // 7. Tải lại / Làm mới form
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtGiaThue.Clear();
            txtTimKiem.Clear();
            picHinhAnh.Image = null;
            LoadDataToGridView();
        }

        // 8. Tìm kiếm thời gian thực
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView(txtTimKiem.Text.Trim());
        }
    }
}