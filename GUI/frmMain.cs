using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        private string vaiTroNguoiDung = "";

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(string quyenHeThong)
        {
            InitializeComponent();
            this.vaiTroNguoiDung = quyenHeThong;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += frmMain_Load;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            TuDongDinhDangGiaoDienFlat();
            ThucHienPhanLuongGiaoDien();
        }

        private void TuDongDinhDangGiaoDienFlat()
        {
            this.BackColor = Color.FromArgb(240, 244, 247);

            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 220;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.BackColor = Color.FromArgb(30, 34, 43);

            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.BackColor = Color.White;

            int viTriY = 20;
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(220, 225, 230);
                    btn.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(15, 0, 0, 0);
                    btn.Cursor = Cursors.Hand;

                    btn.Width = pnlSidebar.Width;
                    btn.Height = 45;

                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 52, 66);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 70, 90);
                }
            }

            btnTrangChu.Location = new Point(0, viTriY);
            btnSanPham.Location = new Point(0, viTriY + 50);
            btnHoaDon.Location = new Point(0, viTriY + 100);
            btnKhachHang.Location = new Point(0, viTriY + 150);
            btnThongKe.Location = new Point(0, viTriY + 200);
            btnNhanVien.Location = new Point(0, viTriY + 250);
            btnXuatNhapHang.Location = new Point(0, viTriY + 300);

            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.Height = 50;
            btnDangXuat.BackColor = Color.FromArgb(25, 28, 36);
        }

        private void ThucHienPhanLuongGiaoDien()
        {
            if (vaiTroNguoiDung.Equals("NhanVien", StringComparison.OrdinalIgnoreCase))
            {
                btnNhanVien.Visible = false;
                btnXuatNhapHang.Visible = false;
                this.Text = "HỆ THỐNG BÁN HÀNG - PHÂN HỆ NHÂN VIÊN THU NGÂN";

                btnDangXuat.Location = new Point(0, pnlSidebar.Height - btnDangXuat.Height);
            }
            else if (vaiTroNguoiDung.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                btnNhanVien.Visible = true;
                btnXuatNhapHang.Visible = true;
                this.Text = "HỆ THỐNG QUẢN TRỊ TRUNG TÂM - VAI TRÒ: CHỦ CỬA HÀNG (ADMIN)";
            }
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmAuth)
                    {
                        f.Show();
                        break;
                    }
                }
                this.Dispose();
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e) { }
        private void btnSanPham_Click(object sender, EventArgs e) { }
        private void btnHoaDon_Click(object sender, EventArgs e) { }
        private void btnKhachHang_Click(object sender, EventArgs e) { }
        private void btnThongKe_Click(object sender, EventArgs e) { }
        private void btnNhanVien_Click(object sender, EventArgs e) { }
        private void btnXuatNhapHang_Click(object sender, EventArgs e) { }
    }
}