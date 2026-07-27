using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAuth : Form
    {
        // Chuỗi kết nối SQL Server
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        // Khởi tạo Win32 API để làm chữ gợi ý ẩn hệ thống (Placeholder)
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmAuth()
        {
            InitializeComponent();

            // Cấu hình chữ gợi ý tự mất khi gõ và che mật khẩu dấu chấm tròn
            SendMessage(txtLoginUser.Handle, EM_SETCUEBANNER, 1, "Nhập tài khoản...");
            SendMessage(txtLoginPass.Handle, EM_SETCUEBANNER, 1, "Nhập mật khẩu...");
            txtLoginPass.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUser.Text.Trim();
            string password = txtLoginPass.Text.Trim();

            // KIỂM TRA BẮT BUỘC: Không được để trống dữ liệu nhập
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // XÁC THỰC TÀI KHOẢN TRỰC TIẾP TỪ BẢNG NhanVien TRONG SQL SERVER
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT MsNv, Hoten, ChucVu FROM NhanVien WHERE TenDangNhap = @User AND MatKhau = @Pass";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@User", username);
                    cmd.Parameters.AddWithValue("@Pass", password);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string hoTen = dr["Hoten"].ToString();
                        string chucVu = dr["ChucVu"].ToString();

                        // Tự động nhận diện quyền để truyền sang frmMain
                        string quyenTaiKhoan = "NhanVien";
                        if (chucVu.ToLower().Contains("quản lý") || chucVu.ToLower().Contains("admin"))
                        {
                            quyenTaiKhoan = "Admin";
                        }

                        MessageBox.Show($"Đăng nhập thành công!\nXin chào: {hoTen} ({chucVu})", "Xác thực thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở trang chủ và truyền quyền vào constructor
                        frmMain mainForm = new frmMain(quyenTaiKhoan);
                        mainForm.Show();

                        this.Hide(); // Ẩn form đăng nhập này đi
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}