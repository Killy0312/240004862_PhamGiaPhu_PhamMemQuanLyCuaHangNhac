using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BUS; // Kết nối tầng xử lý nghiệp vụ để kiểm tra tài khoản

namespace GUI
{
    public partial class frmAuth : Form
    {
        private TaiKhoanBUS tkBUS = new TaiKhoanBUS();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public frmAuth()
        {
            InitializeComponent();

            SendMessage(txtLoginUser.Handle, EM_SETCUEBANNER, 1, "Nhập tài khoản...");
            SendMessage(txtLoginPass.Handle, EM_SETCUEBANNER, 1, "Nhập mật khẩu...");

            txtLoginPass.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUser.Text.Trim();
            string password = txtLoginPass.Text.Trim();

            string ketQua = tkBUS.KiemTraDangNhap(username, password);

            if (ketQua == "OK")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(ketQua, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtLoginPass.Clear();
                txtLoginPass.Focus();
            }
        }
    }
}