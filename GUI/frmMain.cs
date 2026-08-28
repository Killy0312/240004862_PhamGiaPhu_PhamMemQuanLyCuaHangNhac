using QLCuaHangBangDiaThietBi;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMain : Form
    {
        private string vaiTroNguoiDung = "";

        // KHAI BÁO CÁC ĐỐI TƯỢNG USERCONTROL ĐỂ LƯU GIỮ TRẠNG THÁI TRONG BỘ NHỚ
        private ucTrangChu ucHome;
        private ucSanPham ucSP;
        private ucLapHoaDon ucHD;
        private ucKhachHang ucKH;
        private ucThongKe ucTK;
        private ucNhanVien ucNV;
        private ucXuatNhapHang ucXNH;

        public frmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if (!string.IsNullOrEmpty(frmAuth.ChucVu))
            {
                this.vaiTroNguoiDung = frmAuth.ChucVu;
            }

            this.Load -= frmMain_Load;
            this.Load += frmMain_Load;
        }

        public frmMain(string quyenHeThong) : this()
        {
            if (!string.IsNullOrEmpty(quyenHeThong))
            {
                this.vaiTroNguoiDung = quyenHeThong;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            TuDongDinhDangGiaoDienFlat();
            ThucHienPhanLuongGiaoDien();

            // Mặc định nạp và hiển thị Trang Chủ
            btnTrangChu_Click(btnTrangChu, e);
        }

        private void TuDongDinhDangGiaoDienFlat()
        {
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 210;
            pnlSidebar.BackColor = Color.FromArgb(26, 30, 40);

            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.BackColor = Color.FromArgb(240, 244, 247);

            int viTriY = 20;
            Button[] menuButtons = { btnTrangChu, btnSanPham, btnHoaDon, btnKhachHang, btnThongKe, btnNhanVien, btnXuatNhapHang };

            foreach (Button btn in menuButtons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(180, 188, 200);
                btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(20, 0, 0, 0);
                btn.Cursor = Cursors.Hand;
                btn.Width = pnlSidebar.Width;
                btn.Height = 48;
                btn.Location = new Point(0, viTriY);

                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 46, 60);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 128, 128);

                viTriY += 50;
            }

            // Nút Đăng xuất
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.Height = 50;
            btnDangXuat.BackColor = Color.FromArgb(18, 21, 28);
            btnDangXuat.ForeColor = Color.FromArgb(235, 87, 87);
            btnDangXuat.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnDangXuat.TextAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.Padding = new Padding(20, 0, 0, 0);
            btnDangXuat.Cursor = Cursors.Hand;
        }

        private void HighlightNutDuocChon(Button btnActive)
        {
            if (btnActive == null) return;

            Button[] menuButtons = { btnTrangChu, btnSanPham, btnHoaDon, btnKhachHang, btnThongKe, btnNhanVien, btnXuatNhapHang };
            foreach (Button btn in menuButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(180, 188, 200);
                btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            }

            btnActive.BackColor = Color.Teal;
            btnActive.ForeColor = Color.White;
            btnActive.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        }

        private void ThucHienPhanLuongGiaoDien()
        {
            bool isNhanVien = vaiTroNguoiDung.Equals("NhanVien", StringComparison.OrdinalIgnoreCase) ||
                              vaiTroNguoiDung.Equals("Nhân viên bán hàng", StringComparison.OrdinalIgnoreCase) ||
                              vaiTroNguoiDung.Contains("Nhân viên");

            if (isNhanVien)
            {
                btnNhanVien.Visible = false;
                btnXuatNhapHang.Visible = false;
                this.Text = "HỆ THỐNG BÁN HÀNG - PHÂN HỆ NHÂN VIÊN THU NGÂN";
            }
            else
            {
                btnNhanVien.Visible = true;
                btnXuatNhapHang.Visible = true;
                this.Text = "HỆ THỐNG QUẢN TRỊ TRUNG TÂM - VAI TRÒ: CHỦ CỬA HÀNG (ADMIN)";
            }
        }

        // ================= CƠ CHẾ CHUYỂN TRANG KHÔNG MẤT DỮ LIỆU =================

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button ?? btnTrangChu);
            if (ucHome == null)
            {
                ucHome = new ucTrangChu();
                ucHome.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucHome);
            }
            ucHome.BringToFront();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button);
            if (ucSP == null)
            {
                ucSP = new ucSanPham();
                ucSP.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucSP);
            }
            ucSP.BringToFront();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button);
            if (ucHD == null)
            {
                ucHD = new ucLapHoaDon();
                ucHD.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucHD);
            }
            ucHD.BringToFront(); // Giữ nguyên giỏ hàng, thông tin khách đang nhập
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button);
            if (ucKH == null)
            {
                ucKH = new ucKhachHang();
                ucKH.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucKH);
            }
            ucKH.BringToFront();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button);
            if (ucTK == null)
            {
                ucTK = new ucThongKe();
                ucTK.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucTK);
            }
            ucTK.BringToFront();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button);
            if (ucNV == null)
            {
                ucNV = new ucNhanVien();
                ucNV.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucNV);
            }
            ucNV.BringToFront();
        }

        private void btnXuatNhapHang_Click(object sender, EventArgs e)
        {
            HighlightNutDuocChon(sender as Button);
            if (ucXNH == null)
            {
                ucXNH = new ucXuatNhapHang();
                ucXNH.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(ucXNH);
            }
            ucXNH.BringToFront();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pnlSidebar_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}