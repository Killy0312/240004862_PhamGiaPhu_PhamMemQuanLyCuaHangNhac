using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucKhachHang : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        public ucKhachHang()
        {
            InitializeComponent();
            this.Load += ucKhachHang_Load;
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            TaoMaKhachHangMoi();
            LoadDataToGridView();
        }

        private void TaoMaKhachHangMoi()
        {
            txtMaKH.Text = "KH" + DateTime.Now.ToString("ddHHmmss");
            txtMaKH.SelectionStart = 0;
        }

        // CÂU TRUY VẤN TÍNH TỔNG SỐ LẦN MUA & TỔNG TIỀN ĐÃ CHI TRẢ
        private void LoadDataToGridView(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            KH.MaKh AS [Mã Khách Hàng],
                            KH.HotenKh AS [Tên Khách Hàng],
                            KH.SoDtKh AS [Số Điện Thoại],
                            COUNT(DISTINCT HD.SoHdBan) AS [Tổng Số Lần Mua],
                            ISNULL(SUM(CT.ThanhTien), 0) AS [Tổng Tiền Đã Mua]
                        FROM KhachHang KH
                        LEFT JOIN HoaDonBan HD ON KH.MaKh = HD.MaKh
                        LEFT JOIN (
                            SELECT SoHdBan, (Soluong * Dongia) AS ThanhTien FROM ChiTietHoaDonBangDia
                            UNION ALL
                            SELECT SoHdBan, (Soluong * Dongia) AS ThanhTien FROM ChiTietHoaDonThietBi
                        ) CT ON HD.SoHdBan = CT.SoHdBan
                        WHERE KH.HotenKh LIKE @kw OR KH.SoDtKh LIKE @kw OR KH.MaKh LIKE @kw
                        GROUP BY KH.MaKh, KH.HotenKh, KH.SoDtKh
                        ORDER BY [Tổng Tiền Đã Mua] DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvKhachHang.DataSource = dt;

                    // ĐỊNH DẠNG ĐẸP MẮT CHO CÁC CỘT TRÊN DATA GRID VIEW
                    if (dgvKhachHang.Columns["Tổng Tiền Đã Mua"] != null)
                    {
                        dgvKhachHang.Columns["Tổng Tiền Đã Mua"].DefaultCellStyle.Format = "N0";
                        dgvKhachHang.Columns["Tổng Tiền Đã Mua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    if (dgvKhachHang.Columns["Tổng Số Lần Mua"] != null)
                    {
                        dgvKhachHang.Columns["Tổng Số Lần Mua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGridView(txtTimKiem.Text.Trim());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataToGridView(txtTimKiem.Text.Trim());
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDataToGridView(txtTimKiem.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKhachHang.Rows[e.RowIndex].Cells["Mã Khách Hàng"].Value != null)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["Mã Khách Hàng"].Value.ToString();
                txtTenKH.Text = row.Cells["Tên Khách Hàng"].Value.ToString();
                txtSDT.Text = row.Cells["Số Điện Thoại"].Value.ToString();

                txtMaKH.SelectionStart = 0;
                txtTenKH.SelectionStart = 0;
                txtSDT.SelectionStart = 0;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên và Số điện thoại khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO KhachHang (MaKh, HotenKh, SoDtKh) VALUES (@Ma, @Ten, @SDT)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMaKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ten", txtTenKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGridView();
                    btnLamMoi_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrEmpty(maKH)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE KhachHang SET HotenKh = @Ten, SoDtKh = @SDT WHERE MaKh = @Ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ten", txtTenKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ma", maKH);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrEmpty(maKH)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM KhachHang WHERE MaKh = @Ma";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@Ma", maKH);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataToGridView();
                        btnLamMoi_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa khách hàng đã có lịch sử mua hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaoMaKhachHangMoi();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtTimKiem.Clear();
            LoadDataToGridView();
        }

        // MỞ FORM LỊCH SỬ MUA HÀNG CHI TIẾT
        private void btnLichSu_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrEmpty(maKH))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để xem lịch sử!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi Form frmLichSuMuaHang
            GUI.frmLichSuMuaHang frm = new GUI.frmLichSuMuaHang(maKH, txtTenKH.Text.Trim(), txtSDT.Text.Trim());
            frm.ShowDialog();
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            btnLichSu_Click(sender, e);
        }
    }
}