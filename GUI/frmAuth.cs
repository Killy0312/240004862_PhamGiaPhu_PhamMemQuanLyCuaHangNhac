using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAuth : Form
    {
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

            // KỊCH BẢN GIẢ LẬP ĐỂ TEST PHÂN QUYỀN (Không cần SQL Server):
            // 1. Nếu gõ tài khoản là "admin" -> Hệ thống coi là Chủ cửa hàng
            // 2. Nếu gõ tài khoản là bất kỳ chữ nào khác -> Hệ thống coi là Nhân viên bán hàng
            string quyenTaiKhoan = "NhanVien";
            if (username.ToLower() == "admin" && password == "123")
            {
                quyenTaiKhoan = "Admin";
            }
            else if (username.ToLower() != "admin" && password == "123")
            {
                quyenTaiKhoan = "NhanVien";
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng! (Mẹo test: Mật khẩu mặc định là 123)", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ĐĂNG NHẬP THÀNH CÔNG -> Mở trang chủ và truyền quyền sang
            MessageBox.Show($"Đăng nhập thành công với quyền: {quyenTaiKhoan.ToUpper()}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmMain mainForm = new frmMain(quyenTaiKhoan);
            mainForm.Show();

            this.Hide(); // Ẩn form đăng nhập này đi
        }
    }
}