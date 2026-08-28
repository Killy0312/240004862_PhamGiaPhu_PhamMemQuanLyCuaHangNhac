using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucNhanVien : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        public ucNhanVien()
        {
            InitializeComponent();
            LoadData();
            TaoMaMoi();
        }

        private void LoadData(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Load đủ cả dữ liệu mới cấy vào DB
                    string sql = @"SELECT MsNv AS [Mã NV], Hoten AS [Họ Tên], NgaySinh AS [Ngày Sinh], 
                                          SoDienThoai AS [SĐT], DiaChi AS [Địa Chỉ], ChucVu AS [Chức Vụ], 
                                          TenDangNhap AS [Tài Khoản], MatKhau AS [Mật Khẩu] 
                                   FROM NhanVien 
                                   WHERE Hoten LIKE @kw OR MsNv LIKE @kw OR TenDangNhap LIKE @kw";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvNhanVien.DataSource = dt;

                    // Format ngày sinh cho đẹp
                    if (dt.Rows.Count > 0)
                        dgvNhanVien.Columns["Ngày Sinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TaoMaMoi()
        {
            txtMaNV.Text = "NV" + DateTime.Now.ToString("ddHHmmss");
            txtMaNV.SelectionStart = 0;
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            if (cboChucVu.Items.Count > 0) cboChucVu.SelectedIndex = 1; // Mặc định là Nhân viên bán hàng
            txtHoTen.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaoMaMoi();
            txtTimKiem.Clear();
            LoadData();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["Mã NV"].Value.ToString();
                txtHoTen.Text = row.Cells["Họ Tên"].Value.ToString();

                if (row.Cells["Ngày Sinh"].Value != DBNull.Value)
                    dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                else
                    dtpNgaySinh.Value = DateTime.Now;

                txtSDT.Text = row.Cells["SĐT"].Value.ToString();
                txtDiaChi.Text = row.Cells["Địa Chỉ"].Value.ToString();
                cboChucVu.Text = row.Cells["Chức Vụ"].Value.ToString();
                txtTaiKhoan.Text = row.Cells["Tài Khoản"].Value.ToString();
                txtMatKhau.Text = row.Cells["Mật Khẩu"].Value.ToString(); // Chủ cửa hàng được xem/sửa mật khẩu

                // Chống trôi chữ kinh điển
                txtMaNV.SelectionStart = 0;
                txtHoTen.SelectionStart = 0;
                txtSDT.SelectionStart = 0;
                txtDiaChi.SelectionStart = 0;
                txtTaiKhoan.SelectionStart = 0;
                txtMatKhau.SelectionStart = 0;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Họ Tên, Tài Khoản và Mật Khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Kiểm tra trùng Tên Đăng Nhập
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = @User", conn);
                    cmdCheck.Parameters.AddWithValue("@User", txtTaiKhoan.Text.Trim());
                    if ((int)cmdCheck.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tài khoản này đã có người sử dụng. Hãy chọn tên khác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = @"INSERT INTO NhanVien (MsNv, Hoten, NgaySinh, SoDienThoai, DiaChi, ChucVu, TenDangNhap, MatKhau) 
                                   VALUES (@Ma, @Ten, @NS, @SDT, @DC, @CV, @User, @Pass)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@NS", dtpNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@DC", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@CV", cboChucVu.Text);
                    cmd.Parameters.AddWithValue("@User", txtTaiKhoan.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txtMatKhau.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tạo tài khoản nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    TaoMaMoi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Nếu sửa tài khoản phải check xem có bị trùng với người khác không
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = @User AND MsNv != @Ma", conn);
                    cmdCheck.Parameters.AddWithValue("@User", txtTaiKhoan.Text.Trim());
                    cmdCheck.Parameters.AddWithValue("@Ma", txtMaNV.Text);
                    if ((int)cmdCheck.ExecuteScalar() > 0)
                    {
                        MessageBox.Show("Tên tài khoản này bị trùng với nhân viên khác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = @"UPDATE NhanVien SET Hoten=@Ten, NgaySinh=@NS, SoDienThoai=@SDT, DiaChi=@DC, 
                                   ChucVu=@CV, TenDangNhap=@User, MatKhau=@Pass WHERE MsNv=@Ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ma", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@Ten", txtHoTen.Text.Trim());
                    cmd.Parameters.AddWithValue("@NS", dtpNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@DC", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@CV", cboChucVu.Text);
                    cmd.Parameters.AddWithValue("@User", txtTaiKhoan.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txtMatKhau.Text.Trim());

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công! (Nhân viên cần dùng Mật khẩu mới để đăng nhập)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(txtTimKiem.Text.Trim());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text)) return;
            if (txtTaiKhoan.Text.ToLower() == "admin")
            {
                MessageBox.Show("Không thể xóa tài khoản Quản trị viên tối cao!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa nhân sự {txtHoTen.Text}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM NhanVien WHERE MsNv = @Ma", conn);
                        cmd.Parameters.AddWithValue("@Ma", txtMaNV.Text);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(null, null);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547) // Bắt lỗi khóa ngoại nếu nhân viên đã từng lập bill
                        {
                            MessageBox.Show("Không thể xóa nhân viên này vì họ đã từng lập Hóa đơn giao dịch trên hệ thống!", "Từ chối xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}