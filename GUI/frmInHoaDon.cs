using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmInHoaDon : Form
    {
        private string maHD;
        private string ngayLap;
        private string tenKhach;
        private string sdtKhach;
        private string tenThuNgan;
        private DataTable dtChiTiet;
        private decimal tongTien;

        private PrintDocument printDoc = new PrintDocument();

        public frmInHoaDon(string maHD, string ngayLap, string tenKhach, string sdtKhach, string tenThuNgan, DataTable dtChiTiet, decimal tongTien)
        {
            this.maHD = maHD;
            this.ngayLap = ngayLap;
            this.tenKhach = string.IsNullOrEmpty(tenKhach) ? "Khách vãng lai" : tenKhach;
            this.sdtKhach = string.IsNullOrEmpty(sdtKhach) ? "N/A" : sdtKhach;
            this.tenThuNgan = string.IsNullOrEmpty(tenThuNgan) ? "Thu ngân" : tenThuNgan;
            this.dtChiTiet = dtChiTiet;
            this.tongTien = tongTien;

            InitializeComponentCustom();

            printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void InitializeComponentCustom()
        {
            this.Text = "XEM TRƯỚC HÓA ĐƠN BÁN LẺ - MUSIC STORE";
            this.Size = new Size(520, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(240, 242, 245);

            // Panel chứa nội dung hóa đơn (Mô phỏng tờ giấy in k80)
            Panel pnlReceipt = new Panel();
            pnlReceipt.Size = new Size(440, 580);
            pnlReceipt.Location = new Point(32, 20);
            pnlReceipt.BackColor = Color.White;
            pnlReceipt.BorderStyle = BorderStyle.FixedSingle;

            // Nút bấm In hóa đơn
            Button btnPrint = new Button();
            btnPrint.Text = "🖨️ IN HÓA ĐƠN";
            btnPrint.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.BackColor = Color.Teal;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Size = new Size(160, 42);
            btnPrint.Location = new Point(100, 615);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Click += (s, e) => {
                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = printDoc;
                preview.Width = 800;
                preview.Height = 600;
                preview.ShowDialog();
            };

            // Nút bấm Đóng
            Button btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Font = new Font("Segoe UI", 10);
            btnClose.Size = new Size(110, 42);
            btnClose.Location = new Point(275, 615);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => { this.Close(); };

            // Vẽ giao diện hóa đơn bằng Paint
            pnlReceipt.Paint += (s, e) => {
                VeHoaDonChuyenNghiep(e.Graphics);
            };

            this.Controls.Add(pnlReceipt);
            this.Controls.Add(btnPrint);
            this.Controls.Add(btnClose);
        }

        // HÀM VẼ GIAO DIỆN HÓA ĐƠN CHUẨN ĐẸP (SỬ DỤNG GRAPHICS)
        private void VeHoaDonChuyenNghiep(Graphics g)
        {
            Font fontHeaderTitle = new Font("Segoe UI", 13, FontStyle.Bold);
            Font fontSubTitle = new Font("Segoe UI", 9, FontStyle.Italic);
            Font fontDocTitle = new Font("Segoe UI", 14, FontStyle.Bold);
            Font fontRegular = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            Font fontBold = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Font fontLargeBold = new Font("Segoe UI", 12, FontStyle.Bold);

            Brush brushBlack = Brushes.Black;
            Brush brushTeal = Brushes.Teal;
            Pen penDash = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
            Pen penSolid = new Pen(Color.Black, 1.5F);

            int y = 15;
            int width = 430;

            // 1. HEADER CỬA HÀNG
            StringFormat sfCenter = new StringFormat() { Alignment = StringAlignment.Center };
            g.DrawString("CỬA HÀNG BĂNG ĐĨA AUDIOPHILE", fontHeaderTitle, brushTeal, new RectangleF(0, y, width, 25), sfCenter);
            y += 25;
            g.DrawString("Đ/c: 123 Nguyễn Tất Thành, Q.4, TP. Hồ Chí Minh", fontSubTitle, brushBlack, new RectangleF(0, y, width, 18), sfCenter);
            y += 18;
            g.DrawString("Hotline: 0909.123.456 - Website: audiophilestore.vn", fontSubTitle, brushBlack, new RectangleF(0, y, width, 18), sfCenter);
            y += 25;

            g.DrawLine(penDash, 20, y, width - 20, y);
            y += 10;

            // 2. TIÊU ĐỀ HÓA ĐƠN
            g.DrawString("HÓA ĐƠN BÁN LẺ", fontDocTitle, brushBlack, new RectangleF(0, y, width, 28), sfCenter);
            y += 30;

            // 3. THÔNG TIN GIAO DỊCH
            g.DrawString($"Mã hóa đơn: {maHD}", fontBold, brushBlack, 25, y);
            g.DrawString($"Ngày: {ngayLap}", fontRegular, brushBlack, 230, y);
            y += 20;
            g.DrawString($"Khách hàng: {tenKhach}", fontRegular, brushBlack, 25, y);
            y += 20;
            g.DrawString($"Số ĐT: {sdtKhach}", fontRegular, brushBlack, 25, y);
            g.DrawString($"Thu ngân: {tenThuNgan}", fontRegular, brushBlack, 230, y);
            y += 25;

            g.DrawLine(penSolid, 20, y, width - 20, y);
            y += 8;

            // 4. BẢNG DANH SÁCH SẢN PHẨM
            g.DrawString("Tên SP / Album", fontBold, brushBlack, 25, y);
            g.DrawString("SL", fontBold, brushBlack, 230, y);
            g.DrawString("Đơn Giá", fontBold, brushBlack, 270, y);
            g.DrawString("Thành Tiền", fontBold, brushBlack, 340, y);
            y += 20;

            g.DrawLine(penDash, 20, y, width - 20, y);
            y += 8;

            foreach (DataRow row in dtChiTiet.Rows)
            {
                string tenSP = row["Tên Sản Phẩm"].ToString();
                if (tenSP.Length > 24) tenSP = tenSP.Substring(0, 22) + "..";

                int sl = Convert.ToInt32(row["Số Lượng"]);
                decimal donGia = Convert.ToDecimal(row["Đơn Giá"]);
                decimal thanhTien = Convert.ToDecimal(row["Thành Tiền"]);

                g.DrawString(tenSP, fontRegular, brushBlack, 25, y);
                g.DrawString(sl.ToString(), fontRegular, brushBlack, 235, y);
                g.DrawString(donGia.ToString("N0"), fontRegular, brushBlack, 265, y);
                g.DrawString(thanhTien.ToString("N0"), fontRegular, brushBlack, 340, y);
                y += 22;
            }

            y += 5;
            g.DrawLine(penSolid, 20, y, width - 20, y);
            y += 12;

            // 5. TỔNG TIỀN THANH TOÁN
            g.DrawString("TỔNG CỘNG TIỀN HÀNG:", fontBold, brushBlack, 25, y);
            g.DrawString($"{tongTien:N0} VNĐ", fontLargeBold, brushTeal, 240, y - 2);
            y += 30;

            g.DrawLine(penDash, 20, y, width - 20, y);
            y += 15;

            // 6. CHÚ THÍCH VÀ LỜI CẢM ƠN
            g.DrawString("Cảm ơn Quý khách & Hẹn gặp lại!", fontBold, brushBlack, new RectangleF(0, y, width, 20), sfCenter);
            y += 20;
            g.DrawString("Chúc Quý khách có những phút giây thưởng thức âm nhạc tuyệt vời!", fontSubTitle, brushBlack, new RectangleF(0, y, width, 20), sfCenter);
        }

        // SỰ KIỆN IN HÓA ĐƠN RA MÁY IN THỰC
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            VeHoaDonChuyenNghiep(e.Graphics);
        }
    }
}