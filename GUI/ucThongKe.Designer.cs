namespace GUI
{
    partial class ucThongKe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnThangNay = new System.Windows.Forms.Button();
            this.btnHomNay = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlKPI = new System.Windows.Forms.Panel();
            this.pnlKPI4 = new System.Windows.Forms.Panel();
            this.lblBanChamNhat = new System.Windows.Forms.Label();
            this.lblTitleKPI4 = new System.Windows.Forms.Label();
            this.pnlKPI3 = new System.Windows.Forms.Panel();
            this.lblBanChayNhat = new System.Windows.Forms.Label();
            this.lblTitleKPI3 = new System.Windows.Forms.Label();
            this.pnlKPI2 = new System.Windows.Forms.Panel();
            this.lblTongHoaDon = new System.Windows.Forms.Label();
            this.lblTitleKPI2 = new System.Windows.Forms.Label();
            this.pnlKPI1 = new System.Windows.Forms.Panel();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.lblTitleKPI1 = new System.Windows.Forms.Label();
            this.pnlCharts = new System.Windows.Forms.Panel();
            this.chartTyTrong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvThongKeSanPham = new System.Windows.Forms.DataGridView();
            this.pnlFilter.SuspendLayout();
            this.pnlKPI.SuspendLayout();
            this.pnlKPI4.SuspendLayout();
            this.pnlKPI3.SuspendLayout();
            this.pnlKPI2.SuspendLayout();
            this.pnlKPI1.SuspendLayout();
            this.pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTyTrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnThangNay);
            this.pnlFilter.Controls.Add(this.btnHomNay);
            this.pnlFilter.Controls.Add(this.btnThongKe);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Controls.Add(this.lblTieuDe);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(10, 10);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1080, 60);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnThangNay
            // 
            this.btnThangNay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnThangNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThangNay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThangNay.ForeColor = System.Drawing.Color.White;
            this.btnThangNay.Location = new System.Drawing.Point(950, 15);
            this.btnThangNay.Name = "btnThangNay";
            this.btnThangNay.Size = new System.Drawing.Size(90, 30);
            this.btnThangNay.TabIndex = 7;
            this.btnThangNay.Text = "Tháng này";
            this.btnThangNay.UseVisualStyleBackColor = false;
            this.btnThangNay.Click += new System.EventHandler(this.btnThangNay_Click);
            // 
            // btnHomNay
            // 
            this.btnHomNay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnHomNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomNay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHomNay.ForeColor = System.Drawing.Color.White;
            this.btnHomNay.Location = new System.Drawing.Point(850, 15);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(90, 30);
            this.btnHomNay.TabIndex = 6;
            this.btnHomNay.Text = "Hôm nay";
            this.btnHomNay.UseVisualStyleBackColor = false;
            this.btnHomNay.Click += new System.EventHandler(this.btnHomNay_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(740, 15);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(100, 30);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Lọc Dữ Liệu";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpDenNgay.Location = new System.Drawing.Point(600, 17);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(120, 25);
            this.dtpDenNgay.TabIndex = 4;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDenNgay.Location = new System.Drawing.Point(525, 21);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(69, 17);
            this.lblDenNgay.TabIndex = 3;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpTuNgay.Location = new System.Drawing.Point(390, 17);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(120, 25);
            this.dtpTuNgay.TabIndex = 2;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTuNgay.Location = new System.Drawing.Point(320, 21);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(62, 17);
            this.lblTuNgay.TabIndex = 1;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTieuDe.Location = new System.Drawing.Point(15, 17);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(209, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THỐNG KÊ DOANH THU";
            // 
            // pnlKPI
            // 
            this.pnlKPI.Controls.Add(this.pnlKPI4);
            this.pnlKPI.Controls.Add(this.pnlKPI3);
            this.pnlKPI.Controls.Add(this.pnlKPI2);
            this.pnlKPI.Controls.Add(this.pnlKPI1);
            this.pnlKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKPI.Location = new System.Drawing.Point(10, 70);
            this.pnlKPI.Name = "pnlKPI";
            this.pnlKPI.Size = new System.Drawing.Size(1080, 80);
            this.pnlKPI.TabIndex = 1;
            // 
            // pnlKPI4
            // 
            this.pnlKPI4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlKPI4.Controls.Add(this.lblBanChamNhat);
            this.pnlKPI4.Controls.Add(this.lblTitleKPI4);
            this.pnlKPI4.Location = new System.Drawing.Point(810, 10);
            this.pnlKPI4.Name = "pnlKPI4";
            this.pnlKPI4.Size = new System.Drawing.Size(260, 60);
            this.pnlKPI4.TabIndex = 3;
            // 
            // lblBanChamNhat
            // 
            this.lblBanChamNhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBanChamNhat.ForeColor = System.Drawing.Color.White;
            this.lblBanChamNhat.Location = new System.Drawing.Point(10, 28);
            this.lblBanChamNhat.Name = "lblBanChamNhat";
            this.lblBanChamNhat.Size = new System.Drawing.Size(240, 25);
            this.lblBanChamNhat.TabIndex = 1;
            this.lblBanChamNhat.Text = "Chưa có dữ liệu";
            // 
            // lblTitleKPI4
            // 
            this.lblTitleKPI4.AutoSize = true;
            this.lblTitleKPI4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitleKPI4.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI4.Location = new System.Drawing.Point(10, 8);
            this.lblTitleKPI4.Name = "lblTitleKPI4";
            this.lblTitleKPI4.Size = new System.Drawing.Size(104, 15);
            this.lblTitleKPI4.TabIndex = 0;
            this.lblTitleKPI4.Text = "Mặt hàng bán chậm";
            // 
            // pnlKPI3
            // 
            this.pnlKPI3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.pnlKPI3.Controls.Add(this.lblBanChayNhat);
            this.pnlKPI3.Controls.Add(this.lblTitleKPI3);
            this.pnlKPI3.Location = new System.Drawing.Point(540, 10);
            this.pnlKPI3.Name = "pnlKPI3";
            this.pnlKPI3.Size = new System.Drawing.Size(260, 60);
            this.pnlKPI3.TabIndex = 2;
            // 
            // lblBanChayNhat
            // 
            this.lblBanChayNhat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBanChayNhat.ForeColor = System.Drawing.Color.White;
            this.lblBanChayNhat.Location = new System.Drawing.Point(10, 28);
            this.lblBanChayNhat.Name = "lblBanChayNhat";
            this.lblBanChayNhat.Size = new System.Drawing.Size(240, 25);
            this.lblBanChayNhat.TabIndex = 1;
            this.lblBanChayNhat.Text = "Chưa có dữ liệu";
            // 
            // lblTitleKPI3
            // 
            this.lblTitleKPI3.AutoSize = true;
            this.lblTitleKPI3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitleKPI3.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI3.Location = new System.Drawing.Point(10, 8);
            this.lblTitleKPI3.Name = "lblTitleKPI3";
            this.lblTitleKPI3.Size = new System.Drawing.Size(108, 15);
            this.lblTitleKPI3.TabIndex = 0;
            this.lblTitleKPI3.Text = "Mặt hàng bán chạy";
            // 
            // pnlKPI2
            // 
            this.pnlKPI2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlKPI2.Controls.Add(this.lblTongHoaDon);
            this.pnlKPI2.Controls.Add(this.lblTitleKPI2);
            this.pnlKPI2.Location = new System.Drawing.Point(270, 10);
            this.pnlKPI2.Name = "pnlKPI2";
            this.pnlKPI2.Size = new System.Drawing.Size(250, 60);
            this.pnlKPI2.TabIndex = 1;
            // 
            // lblTongHoaDon
            // 
            this.lblTongHoaDon.AutoSize = true;
            this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongHoaDon.ForeColor = System.Drawing.Color.White;
            this.lblTongHoaDon.Location = new System.Drawing.Point(10, 28);
            this.lblTongHoaDon.Name = "lblTongHoaDon";
            this.lblTongHoaDon.Size = new System.Drawing.Size(87, 21);
            this.lblTongHoaDon.TabIndex = 1;
            this.lblTongHoaDon.Text = "0 Hóa đơn";
            // 
            // lblTitleKPI2
            // 
            this.lblTitleKPI2.AutoSize = true;
            this.lblTitleKPI2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitleKPI2.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI2.Location = new System.Drawing.Point(10, 8);
            this.lblTitleKPI2.Name = "lblTitleKPI2";
            this.lblTitleKPI2.Size = new System.Drawing.Size(104, 15);
            this.lblTitleKPI2.TabIndex = 0;
            this.lblTitleKPI2.Text = "Tổng Số Hóa Đơn";
            // 
            // pnlKPI1
            // 
            this.pnlKPI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlKPI1.Controls.Add(this.lblTongDoanhThu);
            this.pnlKPI1.Controls.Add(this.lblTitleKPI1);
            this.pnlKPI1.Location = new System.Drawing.Point(10, 10);
            this.pnlKPI1.Name = "pnlKPI1";
            this.pnlKPI1.Size = new System.Drawing.Size(250, 60);
            this.pnlKPI1.TabIndex = 0;
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(10, 28);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(61, 21);
            this.lblTongDoanhThu.TabIndex = 1;
            this.lblTongDoanhThu.Text = "0 VNĐ";
            // 
            // lblTitleKPI1
            // 
            this.lblTitleKPI1.AutoSize = true;
            this.lblTitleKPI1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTitleKPI1.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI1.Location = new System.Drawing.Point(10, 8);
            this.lblTitleKPI1.Name = "lblTitleKPI1";
            this.lblTitleKPI1.Size = new System.Drawing.Size(95, 15);
            this.lblTitleKPI1.TabIndex = 0;
            this.lblTitleKPI1.Text = "Tổng Doanh Thu";
            // 
            // pnlCharts
            // 
            this.pnlCharts.Controls.Add(this.chartTyTrong);
            this.pnlCharts.Controls.Add(this.chartDoanhThu);
            this.pnlCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCharts.Location = new System.Drawing.Point(10, 150);
            this.pnlCharts.Name = "pnlCharts";
            this.pnlCharts.Size = new System.Drawing.Size(1080, 280);
            this.pnlCharts.TabIndex = 2;
            // 
            // chartTyTrong
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTyTrong.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTyTrong.Legends.Add(legend1);
            this.chartTyTrong.Location = new System.Drawing.Point(620, 10);
            this.chartTyTrong.Name = "chartTyTrong";
            this.chartTyTrong.Size = new System.Drawing.Size(450, 260);
            this.chartTyTrong.TabIndex = 1;
            // 
            // chartDoanhThu
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend2);
            this.chartDoanhThu.Location = new System.Drawing.Point(10, 10);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(590, 260);
            this.chartDoanhThu.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvThongKeSanPham);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(10, 430);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(1080, 260);
            this.pnlGrid.TabIndex = 3;
            // 
            // dgvThongKeSanPham
            // 
            this.dgvThongKeSanPham.AllowUserToAddRows = false;
            this.dgvThongKeSanPham.AllowUserToDeleteRows = false;
            this.dgvThongKeSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKeSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKeSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeSanPham.Location = new System.Drawing.Point(10, 10);
            this.dgvThongKeSanPham.Name = "dgvThongKeSanPham";
            this.dgvThongKeSanPham.ReadOnly = true;
            this.dgvThongKeSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKeSanPham.Size = new System.Drawing.Size(1060, 240);
            this.dgvThongKeSanPham.TabIndex = 0;
            // 
            // ucThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlCharts);
            this.Controls.Add(this.pnlKPI);
            this.Controls.Add(this.pnlFilter);
            this.Name = "ucThongKe";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.ucThongKe_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlKPI.ResumeLayout(false);
            this.pnlKPI4.ResumeLayout(false);
            this.pnlKPI4.PerformLayout();
            this.pnlKPI3.ResumeLayout(false);
            this.pnlKPI3.PerformLayout();
            this.pnlKPI2.ResumeLayout(false);
            this.pnlKPI2.PerformLayout();
            this.pnlKPI1.ResumeLayout(false);
            this.pnlKPI1.PerformLayout();
            this.pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTyTrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnHomNay;
        private System.Windows.Forms.Button btnThangNay;

        private System.Windows.Forms.Panel pnlKPI;
        private System.Windows.Forms.Panel pnlKPI1;
        private System.Windows.Forms.Label lblTitleKPI1;
        private System.Windows.Forms.Label lblTongDoanhThu;

        private System.Windows.Forms.Panel pnlKPI2;
        private System.Windows.Forms.Label lblTitleKPI2;
        private System.Windows.Forms.Label lblTongHoaDon;

        private System.Windows.Forms.Panel pnlKPI3;
        private System.Windows.Forms.Label lblTitleKPI3;
        private System.Windows.Forms.Label lblBanChayNhat;

        private System.Windows.Forms.Panel pnlKPI4;
        private System.Windows.Forms.Label lblTitleKPI4;
        private System.Windows.Forms.Label lblBanChamNhat;

        private System.Windows.Forms.Panel pnlCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTyTrong;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvThongKeSanPham;
    }
}