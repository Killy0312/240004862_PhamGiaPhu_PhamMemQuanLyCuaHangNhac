namespace QLCuaHangBangDiaThietBi
{
    partial class ucTrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuSo = new System.Windows.Forms.Label();
            this.lblDoanhThuText = new System.Windows.Forms.Label();
            this.pnlHoaDon = new System.Windows.Forms.Panel();
            this.lblHoaDonSo = new System.Windows.Forms.Label();
            this.lblHoaDonText = new System.Windows.Forms.Label();
            this.pnlTonKho = new System.Windows.Forms.Panel();
            this.lblTonKhoSo = new System.Windows.Forms.Label();
            this.lblTonKhoText = new System.Windows.Forms.Label();
            this.pnlKhachHang = new System.Windows.Forms.Panel();
            this.lblKhachHangSo = new System.Windows.Forms.Label();
            this.lblKhachHangText = new System.Windows.Forms.Label();
            this.chartTopSP = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTyTrong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTop.SuspendLayout();
            this.pnlDoanhThu.SuspendLayout();
            this.pnlHoaDon.SuspendLayout();
            this.pnlTonKho.SuspendLayout();
            this.pnlKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTyTrong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Teal;
            this.pnlTop.Controls.Add(this.lblTime);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(950, 45);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.Gold;
            this.lblTime.Location = new System.Drawing.Point(740, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Text = "Hôm nay";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG BĂNG ĐĨA AUDIOPHILE";
            // 
            // pnlDoanhThu
            // 
            this.pnlDoanhThu.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuSo);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuText);
            this.pnlDoanhThu.Location = new System.Drawing.Point(20, 65);
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(210, 100);
            // 
            // lblDoanhThuSo
            // 
            this.lblDoanhThuSo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuSo.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuSo.Location = new System.Drawing.Point(10, 45);
            this.lblDoanhThuSo.Name = "lblDoanhThuSo";
            this.lblDoanhThuSo.Text = "0 VNĐ";
            // 
            // lblDoanhThuText
            // 
            this.lblDoanhThuText.AutoSize = true;
            this.lblDoanhThuText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThuText.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuText.Location = new System.Drawing.Point(10, 15);
            this.lblDoanhThuText.Name = "lblDoanhThuText";
            this.lblDoanhThuText.Text = "DOANH THU HÔM NAY";
            // 
            // pnlHoaDon
            // 
            this.pnlHoaDon.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlHoaDon.Controls.Add(this.lblHoaDonSo);
            this.pnlHoaDon.Controls.Add(this.lblHoaDonText);
            this.pnlHoaDon.Location = new System.Drawing.Point(250, 65);
            this.pnlHoaDon.Name = "pnlHoaDon";
            this.pnlHoaDon.Size = new System.Drawing.Size(210, 100);
            // 
            // lblHoaDonSo
            // 
            this.lblHoaDonSo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHoaDonSo.ForeColor = System.Drawing.Color.White;
            this.lblHoaDonSo.Location = new System.Drawing.Point(10, 45);
            this.lblHoaDonSo.Name = "lblHoaDonSo";
            this.lblHoaDonSo.Text = "0 Đơn";
            // 
            // lblHoaDonText
            // 
            this.lblHoaDonText.AutoSize = true;
            this.lblHoaDonText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoaDonText.ForeColor = System.Drawing.Color.White;
            this.lblHoaDonText.Location = new System.Drawing.Point(10, 15);
            this.lblHoaDonText.Name = "lblHoaDonText";
            this.lblHoaDonText.Text = "HÓA ĐƠN TRONG NGÀY";
            // 
            // pnlTonKho
            // 
            this.pnlTonKho.BackColor = System.Drawing.Color.DarkOrange;
            this.pnlTonKho.Controls.Add(this.lblTonKhoSo);
            this.pnlTonKho.Controls.Add(this.lblTonKhoText);
            this.pnlTonKho.Location = new System.Drawing.Point(480, 65);
            this.pnlTonKho.Name = "pnlTonKho";
            this.pnlTonKho.Size = new System.Drawing.Size(210, 100);
            // 
            // lblTonKhoSo
            // 
            this.lblTonKhoSo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTonKhoSo.ForeColor = System.Drawing.Color.White;
            this.lblTonKhoSo.Location = new System.Drawing.Point(10, 45);
            this.lblTonKhoSo.Name = "lblTonKhoSo";
            this.lblTonKhoSo.Text = "0 Sản phẩm";
            // 
            // lblTonKhoText
            // 
            this.lblTonKhoText.AutoSize = true;
            this.lblTonKhoText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTonKhoText.ForeColor = System.Drawing.Color.White;
            this.lblTonKhoText.Location = new System.Drawing.Point(10, 15);
            this.lblTonKhoText.Name = "lblTonKhoText";
            this.lblTonKhoText.Text = "TỔNG HÀNG TỒN KHO";
            // 
            // pnlKhachHang
            // 
            this.pnlKhachHang.BackColor = System.Drawing.Color.IndianRed;
            this.pnlKhachHang.Controls.Add(this.lblKhachHangSo);
            this.pnlKhachHang.Controls.Add(this.lblKhachHangText);
            this.pnlKhachHang.Location = new System.Drawing.Point(710, 65);
            this.pnlKhachHang.Name = "pnlKhachHang";
            this.pnlKhachHang.Size = new System.Drawing.Size(210, 100);
            // 
            // lblKhachHangSo
            // 
            this.lblKhachHangSo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangSo.ForeColor = System.Drawing.Color.White;
            this.lblKhachHangSo.Location = new System.Drawing.Point(10, 45);
            this.lblKhachHangSo.Name = "lblKhachHangSo";
            this.lblKhachHangSo.Text = "0 Khách";
            // 
            // lblKhachHangText
            // 
            this.lblKhachHangText.AutoSize = true;
            this.lblKhachHangText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHangText.ForeColor = System.Drawing.Color.White;
            this.lblKhachHangText.Location = new System.Drawing.Point(10, 15);
            this.lblKhachHangText.Name = "lblKhachHangText";
            this.lblKhachHangText.Text = "TỔNG KHÁCH HÀNG";
            // 
            // chartTopSP
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTopSP.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTopSP.Legends.Add(legend1);
            this.chartTopSP.Location = new System.Drawing.Point(20, 190);
            this.chartTopSP.Name = "chartTopSP";
            this.chartTopSP.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Số lượng bán";
            this.chartTopSP.Series.Add(series1);
            this.chartTopSP.Size = new System.Drawing.Size(560, 390);
            this.chartTopSP.TabIndex = 4;
            this.chartTopSP.Text = "Top 5 Sản Phẩm";
            // 
            // chartTyTrong
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTyTrong.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTyTrong.Legends.Add(legend2);
            this.chartTyTrong.Location = new System.Drawing.Point(600, 190);
            this.chartTyTrong.Name = "chartTyTrong";
            this.chartTyTrong.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "DoanhThu";
            this.chartTyTrong.Series.Add(series2);
            this.chartTyTrong.Size = new System.Drawing.Size(320, 390);
            this.chartTyTrong.TabIndex = 5;
            this.chartTyTrong.Text = "Tỉ trọng Doanh Thu";
            // 
            // ucTrangChu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.chartTyTrong);
            this.Controls.Add(this.chartTopSP);
            this.Controls.Add(this.pnlKhachHang);
            this.Controls.Add(this.pnlTonKho);
            this.Controls.Add(this.pnlHoaDon);
            this.Controls.Add(this.pnlDoanhThu);
            this.Controls.Add(this.pnlTop);
            this.Name = "ucTrangChu";
            this.Size = new System.Drawing.Size(950, 610);
            this.Load += new System.EventHandler(this.ucTrangChu_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlDoanhThu.ResumeLayout(false);
            this.pnlDoanhThu.PerformLayout();
            this.pnlHoaDon.ResumeLayout(false);
            this.pnlHoaDon.PerformLayout();
            this.pnlTonKho.ResumeLayout(false);
            this.pnlTonKho.PerformLayout();
            this.pnlKhachHang.ResumeLayout(false);
            this.pnlKhachHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTyTrong)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuSo;
        private System.Windows.Forms.Label lblDoanhThuText;
        private System.Windows.Forms.Panel pnlHoaDon;
        private System.Windows.Forms.Label lblHoaDonSo;
        private System.Windows.Forms.Label lblHoaDonText;
        private System.Windows.Forms.Panel pnlTonKho;
        private System.Windows.Forms.Label lblTonKhoSo;
        private System.Windows.Forms.Label lblTonKhoText;
        private System.Windows.Forms.Panel pnlKhachHang;
        private System.Windows.Forms.Label lblKhachHangSo;
        private System.Windows.Forms.Label lblKhachHangText;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSP;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTyTrong;
    }
}