namespace GUI
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnKhachHang = new System.Windows.Forms.Button();
            this.btnXuatNhapHang = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.pnlSidebar.Controls.Add(this.btnDangXuat);
            this.pnlSidebar.Controls.Add(this.btnKhachHang);
            this.pnlSidebar.Controls.Add(this.btnXuatNhapHang);
            this.pnlSidebar.Controls.Add(this.btnNhanVien);
            this.pnlSidebar.Controls.Add(this.btnThongKe);
            this.pnlSidebar.Controls.Add(this.btnHoaDon);
            this.pnlSidebar.Controls.Add(this.btnSanPham);
            this.pnlSidebar.Controls.Add(this.btnTrangChu);
            this.pnlSidebar.Location = new System.Drawing.Point(13, 13);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(173, 634);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(24, 555);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(122, 48);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click_1);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnKhachHang.Location = new System.Drawing.Point(24, 234);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(135, 53);
            this.btnKhachHang.TabIndex = 0;
            this.btnKhachHang.Text = "Quản lý khách hàng";
            this.btnKhachHang.UseVisualStyleBackColor = true;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnXuatNhapHang
            // 
            this.btnXuatNhapHang.Location = new System.Drawing.Point(24, 475);
            this.btnXuatNhapHang.Name = "btnXuatNhapHang";
            this.btnXuatNhapHang.Size = new System.Drawing.Size(122, 48);
            this.btnXuatNhapHang.TabIndex = 5;
            this.btnXuatNhapHang.Text = "Xuất nhập hàng";
            this.btnXuatNhapHang.UseVisualStyleBackColor = true;
            this.btnXuatNhapHang.Click += new System.EventHandler(this.btnXuatNhapHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Location = new System.Drawing.Point(24, 390);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(122, 48);
            this.btnNhanVien.TabIndex = 4;
            this.btnNhanVien.Text = "Quản lý nhân viên";
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(24, 305);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(122, 45);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Location = new System.Drawing.Point(24, 176);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(122, 40);
            this.btnHoaDon.TabIndex = 2;
            this.btnHoaDon.Text = "Lập hóa đơn";
            this.btnHoaDon.UseVisualStyleBackColor = true;
            this.btnHoaDon.Click += new System.EventHandler(this.btnHoaDon_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Location = new System.Drawing.Point(24, 101);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(122, 40);
            this.btnSanPham.TabIndex = 1;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Location = new System.Drawing.Point(24, 20);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(122, 40);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.label1);
            this.pnlMainContent.Location = new System.Drawing.Point(238, 13);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1012, 621);
            this.pnlMainContent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(105, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(840, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chào mừng đến Phần mềm quản lý cửa hàng băng đĩa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 659);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlMainContent.ResumeLayout(false);
            this.pnlMainContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnXuatNhapHang;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label1;
    }
}