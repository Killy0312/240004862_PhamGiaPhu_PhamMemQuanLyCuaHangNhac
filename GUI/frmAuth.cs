using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmAuth : Form
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";

        public static string MaNhanVien = "";
        public static string TenNhanVien = "";
        public static string ChucVu = "";

        // Biến quản lý nút ẩn/hiện mật khẩu
        private bool isHienMatKhau = false;
        private Button btnToggleMatKhau;

        public frmAuth()
        {
            InitializeComponent();
            LoadBanner();
            KhoiTaoNutAnHienMatKhau(); // Tự động tạo nút con mắt bên trong ô mật khẩu
        }

        // ================= KHỞI TẠO NÚT CON MẮT ĐÓNG / MỞ =================
        private void KhoiTaoNutAnHienMatKhau()
        {
            // Mặc định ẩn mật khẩu
            txtMatKhau.UseSystemPasswordChar = true;

            // Tạo nút bấm con mắt
            btnToggleMatKhau = new Button();
            btnToggleMatKhau.Name = "btnToggleMatKhau";
            btnToggleMatKhau.Text = "👁";
            btnToggleMatKhau.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Regular);
            btnToggleMatKhau.ForeColor = Color.Gray;
            btnToggleMatKhau.BackColor = Color.White;
            btnToggleMatKhau.FlatStyle = FlatStyle.Flat;
            btnToggleMatKhau.FlatAppearance.BorderSize = 0;
            btnToggleMatKhau.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnToggleMatKhau.Cursor = Cursors.Hand;

            // Đặt kích thước và vị trí nằm góc phải bên trong ô Password
            btnToggleMatKhau.Size = new Size(30, txtMatKhau.Height - 4);
            btnToggleMatKhau.Location = new Point(txtMatKhau.Right - 32, txtMatKhau.Top + 2);

            // Gán sự kiện click
            btnToggleMatKhau.Click += BtnToggleMatKhau_Click;

            // Gắn nút vào cùng khung chứa với ô mật khẩu
            Control parent = txtMatKhau.Parent ?? this;
            parent.Controls.Add(btnToggleMatKhau);
            btnToggleMatKhau.BringToFront();
        }

        private void BtnToggleMatKhau_Click(object sender, EventArgs e)
        {
            isHienMatKhau = !isHienMatKhau;

            if (isHienMatKhau)
            {
                // Hiện mật khẩu
                txtMatKhau.UseSystemPasswordChar = false;
                txtMatKhau.PasswordChar = '\0';
                btnToggleMatKhau.Text = "🙈";
                btnToggleMatKhau.ForeColor = Color.Teal;
            }
            else
            {
                // Ẩn mật khẩu
                txtMatKhau.UseSystemPasswordChar = true;
                txtMatKhau.PasswordChar = '●';
                btnToggleMatKhau.Text = "👁";
                btnToggleMatKhau.ForeColor = Color.Gray;
            }

            txtMatKhau.Focus();
            txtMatKhau.SelectionStart = txtMatKhau.Text.Length;
        }

        private void LoadBanner()
        {
            if (picBanner.Image != null) return;

            string bannerPath = Path.Combine(Application.StartupPath, "Images", "login_banner.jpg");
            if (File.Exists(bannerPath))
            {
                picBanner.ImageLocation = bannerPath;
            }
            else
            {
                pnlLeft.BackColor = Color.Teal;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTaiKhoan.Text.Trim();
            string mk = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT MsNv, Hoten, ChucVu FROM NhanVien WHERE TenDangNhap = @User AND MatKhau = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@User", tk);
                    cmd.Parameters.AddWithValue("@Pass", mk);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MaNhanVien = dr["MsNv"].ToString();
                        TenNhanVien = dr["Hoten"].ToString();
                        ChucVu = dr["ChucVu"].ToString();

                        MessageBox.Show($"Đăng nhập thành công!\nXin chào {ChucVu}: {TenNhanVien}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMatKhau.Clear();
                        this.Hide();

                        frmMain main = new frmMain();
                        main.ShowDialog();

                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Clear();
                        txtMatKhau.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtInputs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(null, null);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}