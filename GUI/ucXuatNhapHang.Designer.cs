namespace GUI
{
    partial class ucXuatNhapHang
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlKPI = new System.Windows.Forms.Panel();
            this.pnlKPI3 = new System.Windows.Forms.Panel();
            this.lblSapHetHang = new System.Windows.Forms.Label();
            this.lblTitleKPI3 = new System.Windows.Forms.Label();
            this.pnlKPI2 = new System.Windows.Forms.Panel();
            this.lblTongSoLuongTon = new System.Windows.Forms.Label();
            this.lblTitleKPI2 = new System.Windows.Forms.Label();
            this.pnlKPI1 = new System.Windows.Forms.Panel();
            this.lblTongMatHang = new System.Windows.Forms.Label();
            this.lblTitleKPI1 = new System.Windows.Forms.Label();
            this.tabControlXuatNhap = new System.Windows.Forms.TabControl();
            this.tabQuanLyKho = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeftGrid = new System.Windows.Forms.Panel();
            this.dgvKhoHang = new System.Windows.Forms.DataGridView();
            this.pnlToolGrid = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cmbLoaiHang = new System.Windows.Forms.ComboBox();
            this.lblLocLoai = new System.Windows.Forms.Label();
            this.pnlRightInput = new System.Windows.Forms.Panel();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.cmbNhaCungCap = new System.Windows.Forms.ComboBox();
            this.lblNhaCungCap = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXacNhanNhap = new System.Windows.Forms.Button();
            this.nudSoLuongNhap = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongNhap = new System.Windows.Forms.Label();
            this.txtTonHienTai = new System.Windows.Forms.TextBox();
            this.lblTonHienTai = new System.Windows.Forms.Label();
            this.cmbPhanLoaiInput = new System.Windows.Forms.ComboBox();
            this.lblLoaiSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.lblTitleNhapKho = new System.Windows.Forms.Label();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlKPI.SuspendLayout();
            this.pnlKPI3.SuspendLayout();
            this.pnlKPI2.SuspendLayout();
            this.pnlKPI1.SuspendLayout();
            this.tabControlXuatNhap.SuspendLayout();
            this.tabQuanLyKho.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeftGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).BeginInit();
            this.pnlToolGrid.SuspendLayout();
            this.pnlRightInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).BeginInit();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(10, 10);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1080, 45);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTieuDe.Location = new System.Drawing.Point(15, 10);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(325, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ XUẤT NHẬP HÀNG TỒN KHO";
            // 
            // pnlKPI
            // 
            this.pnlKPI.Controls.Add(this.pnlKPI3);
            this.pnlKPI.Controls.Add(this.pnlKPI2);
            this.pnlKPI.Controls.Add(this.pnlKPI1);
            this.pnlKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKPI.Location = new System.Drawing.Point(10, 55);
            this.pnlKPI.Name = "pnlKPI";
            this.pnlKPI.Size = new System.Drawing.Size(1080, 65);
            this.pnlKPI.TabIndex = 1;
            // 
            // pnlKPI3
            // 
            this.pnlKPI3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlKPI3.Controls.Add(this.lblSapHetHang);
            this.pnlKPI3.Controls.Add(this.lblTitleKPI3);
            this.pnlKPI3.Location = new System.Drawing.Point(540, 8);
            this.pnlKPI3.Name = "pnlKPI3";
            this.pnlKPI3.Size = new System.Drawing.Size(250, 50);
            this.pnlKPI3.TabIndex = 2;
            // 
            // lblSapHetHang
            // 
            this.lblSapHetHang.AutoSize = true;
            this.lblSapHetHang.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSapHetHang.ForeColor = System.Drawing.Color.White;
            this.lblSapHetHang.Location = new System.Drawing.Point(10, 24);
            this.lblSapHetHang.Name = "lblSapHetHang";
            this.lblSapHetHang.Size = new System.Drawing.Size(83, 20);
            this.lblSapHetHang.TabIndex = 1;
            this.lblSapHetHang.Text = "0 Cảnh báo";
            // 
            // lblTitleKPI3
            // 
            this.lblTitleKPI3.AutoSize = true;
            this.lblTitleKPI3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTitleKPI3.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI3.Location = new System.Drawing.Point(10, 6);
            this.lblTitleKPI3.Name = "lblTitleKPI3";
            this.lblTitleKPI3.Size = new System.Drawing.Size(130, 13);
            this.lblTitleKPI3.TabIndex = 0;
            this.lblTitleKPI3.Text = "Cảnh Báo Sắp Hết (< 5)";
            // 
            // pnlKPI2
            // 
            this.pnlKPI2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlKPI2.Controls.Add(this.lblTongSoLuongTon);
            this.pnlKPI2.Controls.Add(this.lblTitleKPI2);
            this.pnlKPI2.Location = new System.Drawing.Point(270, 8);
            this.pnlKPI2.Name = "pnlKPI2";
            this.pnlKPI2.Size = new System.Drawing.Size(250, 50);
            this.pnlKPI2.TabIndex = 1;
            // 
            // lblTongSoLuongTon
            // 
            this.lblTongSoLuongTon.AutoSize = true;
            this.lblTongSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTongSoLuongTon.ForeColor = System.Drawing.Color.White;
            this.lblTongSoLuongTon.Location = new System.Drawing.Point(10, 24);
            this.lblTongSoLuongTon.Name = "lblTongSoLuongTon";
            this.lblTongSoLuongTon.Size = new System.Drawing.Size(78, 20);
            this.lblTongSoLuongTon.TabIndex = 1;
            this.lblTongSoLuongTon.Text = "0 Cái/Bộ";
            // 
            // lblTitleKPI2
            // 
            this.lblTitleKPI2.AutoSize = true;
            this.lblTitleKPI2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTitleKPI2.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI2.Location = new System.Drawing.Point(10, 6);
            this.lblTitleKPI2.Name = "lblTitleKPI2";
            this.lblTitleKPI2.Size = new System.Drawing.Size(111, 13);
            this.lblTitleKPI2.TabIndex = 0;
            this.lblTitleKPI2.Text = "Tổng Số Lượng Tồn";
            // 
            // pnlKPI1
            // 
            this.pnlKPI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlKPI1.Controls.Add(this.lblTongMatHang);
            this.pnlKPI1.Controls.Add(this.lblTitleKPI1);
            this.pnlKPI1.Location = new System.Drawing.Point(0, 8);
            this.pnlKPI1.Name = "pnlKPI1";
            this.pnlKPI1.Size = new System.Drawing.Size(250, 50);
            this.pnlKPI1.TabIndex = 0;
            // 
            // lblTongMatHang
            // 
            this.lblTongMatHang.AutoSize = true;
            this.lblTongMatHang.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTongMatHang.ForeColor = System.Drawing.Color.White;
            this.lblTongMatHang.Location = new System.Drawing.Point(10, 24);
            this.lblTongMatHang.Name = "lblTongMatHang";
            this.lblTongMatHang.Size = new System.Drawing.Size(91, 20);
            this.lblTongMatHang.TabIndex = 1;
            this.lblTongMatHang.Text = "0 Mặt hàng";
            // 
            // lblTitleKPI1
            // 
            this.lblTitleKPI1.AutoSize = true;
            this.lblTitleKPI1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTitleKPI1.ForeColor = System.Drawing.Color.White;
            this.lblTitleKPI1.Location = new System.Drawing.Point(10, 6);
            this.lblTitleKPI1.Name = "lblTitleKPI1";
            this.lblTitleKPI1.Size = new System.Drawing.Size(109, 13);
            this.lblTitleKPI1.TabIndex = 0;
            this.lblTitleKPI1.Text = "Tổng Số Mặt Hàng";
            // 
            // tabControlXuatNhap
            // 
            this.tabControlXuatNhap.Controls.Add(this.tabQuanLyKho);
            this.tabControlXuatNhap.Controls.Add(this.tabLichSu);
            this.tabControlXuatNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlXuatNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlXuatNhap.Location = new System.Drawing.Point(10, 120);
            this.tabControlXuatNhap.Name = "tabControlXuatNhap";
            this.tabControlXuatNhap.SelectedIndex = 0;
            this.tabControlXuatNhap.Size = new System.Drawing.Size(1080, 570);
            this.tabControlXuatNhap.TabIndex = 2;
            // 
            // tabQuanLyKho
            // 
            this.tabQuanLyKho.Controls.Add(this.pnlMain);
            this.tabQuanLyKho.Location = new System.Drawing.Point(4, 26);
            this.tabQuanLyKho.Name = "tabQuanLyKho";
            this.tabQuanLyKho.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuanLyKho.Size = new System.Drawing.Size(1072, 540);
            this.tabQuanLyKho.TabIndex = 0;
            this.tabQuanLyKho.Text = "📦 TỒN KHO & NHẬP HÀNG";
            this.tabQuanLyKho.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlLeftGrid);
            this.pnlMain.Controls.Add(this.pnlRightInput);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1066, 534);
            this.pnlMain.TabIndex = 3;
            // 
            // pnlLeftGrid
            // 
            this.pnlLeftGrid.Controls.Add(this.dgvKhoHang);
            this.pnlLeftGrid.Controls.Add(this.pnlToolGrid);
            this.pnlLeftGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftGrid.Name = "pnlLeftGrid";
            this.pnlLeftGrid.Size = new System.Drawing.Size(686, 534);
            this.pnlLeftGrid.TabIndex = 0;
            // 
            // dgvKhoHang
            // 
            this.dgvKhoHang.AllowUserToAddRows = false;
            this.dgvKhoHang.AllowUserToDeleteRows = false;
            this.dgvKhoHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvKhoHang.Location = new System.Drawing.Point(0, 45);
            this.dgvKhoHang.Name = "dgvKhoHang";
            this.dgvKhoHang.ReadOnly = true;
            this.dgvKhoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoHang.Size = new System.Drawing.Size(686, 489);
            this.dgvKhoHang.TabIndex = 1;
            this.dgvKhoHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoHang_CellClick);
            // 
            // pnlToolGrid
            // 
            this.pnlToolGrid.BackColor = System.Drawing.Color.White;
            this.pnlToolGrid.Controls.Add(this.btnTimKiem);
            this.pnlToolGrid.Controls.Add(this.txtTimKiem);
            this.pnlToolGrid.Controls.Add(this.cmbLoaiHang);
            this.pnlToolGrid.Controls.Add(this.lblLocLoai);
            this.pnlToolGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlToolGrid.Name = "pnlToolGrid";
            this.pnlToolGrid.Size = new System.Drawing.Size(686, 45);
            this.pnlToolGrid.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(565, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(110, 28);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTimKiem.Location = new System.Drawing.Point(260, 10);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(295, 25);
            this.txtTimKiem.TabIndex = 2;
            // 
            // cmbLoaiHang
            // 
            this.cmbLoaiHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbLoaiHang.FormattingEnabled = true;
            this.cmbLoaiHang.Items.AddRange(new object[] {
            "-- Tất cả mặt hàng --",
            "Đĩa CD",
            "Đĩa Than (Vinyl)",
            "Băng Cassette",
            "Thiết Bị Nghe Nhạc"});
            this.cmbLoaiHang.Location = new System.Drawing.Point(70, 11);
            this.cmbLoaiHang.Name = "cmbLoaiHang";
            this.cmbLoaiHang.Size = new System.Drawing.Size(180, 23);
            this.cmbLoaiHang.TabIndex = 1;
            this.cmbLoaiHang.SelectedIndexChanged += new System.EventHandler(this.cmbLoaiHang_SelectedIndexChanged);
            // 
            // lblLocLoai
            // 
            this.lblLocLoai.AutoSize = true;
            this.lblLocLoai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLocLoai.Location = new System.Drawing.Point(10, 13);
            this.lblLocLoai.Name = "lblLocLoai";
            this.lblLocLoai.Size = new System.Drawing.Size(54, 17);
            this.lblLocLoai.TabIndex = 0;
            this.lblLocLoai.Text = "Bộ lọc:";
            // 
            // pnlRightInput
            // 
            this.pnlRightInput.BackColor = System.Drawing.Color.White;
            this.pnlRightInput.Controls.Add(this.txtGiaBan);
            this.pnlRightInput.Controls.Add(this.lblGiaBan);
            this.pnlRightInput.Controls.Add(this.cmbNhaCungCap);
            this.pnlRightInput.Controls.Add(this.lblNhaCungCap);
            this.pnlRightInput.Controls.Add(this.btnLamMoi);
            this.pnlRightInput.Controls.Add(this.btnXacNhanNhap);
            this.pnlRightInput.Controls.Add(this.nudSoLuongNhap);
            this.pnlRightInput.Controls.Add(this.lblSoLuongNhap);
            this.pnlRightInput.Controls.Add(this.txtTonHienTai);
            this.pnlRightInput.Controls.Add(this.lblTonHienTai);
            this.pnlRightInput.Controls.Add(this.cmbPhanLoaiInput);
            this.pnlRightInput.Controls.Add(this.lblLoaiSP);
            this.pnlRightInput.Controls.Add(this.txtTenSP);
            this.pnlRightInput.Controls.Add(this.lblTenSP);
            this.pnlRightInput.Controls.Add(this.txtMaSP);
            this.pnlRightInput.Controls.Add(this.lblMaSP);
            this.pnlRightInput.Controls.Add(this.lblTitleNhapKho);
            this.pnlRightInput.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightInput.Location = new System.Drawing.Point(686, 0);
            this.pnlRightInput.Name = "pnlRightInput";
            this.pnlRightInput.Size = new System.Drawing.Size(380, 534);
            this.pnlRightInput.TabIndex = 1;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtGiaBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.txtGiaBan.Location = new System.Drawing.Point(135, 255);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(225, 25);
            this.txtGiaBan.TabIndex = 16;
            this.txtGiaBan.Text = "0";
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGiaBan.Location = new System.Drawing.Point(15, 258);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(97, 17);
            this.lblGiaBan.TabIndex = 15;
            this.lblGiaBan.Text = "Giá bán (VNĐ):";
            // 
            // cmbNhaCungCap
            // 
            this.cmbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbNhaCungCap.FormattingEnabled = true;
            this.cmbNhaCungCap.Location = new System.Drawing.Point(135, 210);
            this.cmbNhaCungCap.Name = "cmbNhaCungCap";
            this.cmbNhaCungCap.Size = new System.Drawing.Size(225, 25);
            this.cmbNhaCungCap.TabIndex = 14;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.AutoSize = true;
            this.lblNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNhaCungCap.Location = new System.Drawing.Point(15, 213);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(117, 17);
            this.lblNhaCungCap.TabIndex = 13;
            this.lblNhaCungCap.Text = "Hãng / Nhà cung:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(20, 440);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(340, 40);
            this.btnLamMoi.TabIndex = 12;
            this.btnLamMoi.Text = "LÀM MỚI FORM (NHẬP MỚI)";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXacNhanNhap
            // 
            this.btnXacNhanNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXacNhanNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanNhap.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanNhap.Location = new System.Drawing.Point(20, 385);
            this.btnXacNhanNhap.Name = "btnXacNhanNhap";
            this.btnXacNhanNhap.Size = new System.Drawing.Size(340, 45);
            this.btnXacNhanNhap.TabIndex = 11;
            this.btnXacNhanNhap.Text = "TẠO MỚI & NHẬP KHO";
            this.btnXacNhanNhap.UseVisualStyleBackColor = false;
            this.btnXacNhanNhap.Click += new System.EventHandler(this.btnXacNhanNhap_Click);
            // 
            // nudSoLuongNhap
            // 
            this.nudSoLuongNhap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.nudSoLuongNhap.Location = new System.Drawing.Point(180, 340);
            this.nudSoLuongNhap.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            this.nudSoLuongNhap.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongNhap.Name = "nudSoLuongNhap";
            this.nudSoLuongNhap.Size = new System.Drawing.Size(180, 27);
            this.nudSoLuongNhap.TabIndex = 10;
            this.nudSoLuongNhap.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuongNhap
            // 
            this.lblSoLuongNhap.AutoSize = true;
            this.lblSoLuongNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblSoLuongNhap.Location = new System.Drawing.Point(15, 345);
            this.lblSoLuongNhap.Name = "lblSoLuongNhap";
            this.lblSoLuongNhap.Size = new System.Drawing.Size(130, 17);
            this.lblSoLuongNhap.TabIndex = 9;
            this.lblSoLuongNhap.Text = "+ Số lượng nhập:";
            // 
            // txtTonHienTai
            // 
            this.txtTonHienTai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTonHienTai.Location = new System.Drawing.Point(180, 300);
            this.txtTonHienTai.Name = "txtTonHienTai";
            this.txtTonHienTai.ReadOnly = true;
            this.txtTonHienTai.Size = new System.Drawing.Size(180, 25);
            this.txtTonHienTai.TabIndex = 8;
            // 
            // lblTonHienTai
            // 
            this.lblTonHienTai.AutoSize = true;
            this.lblTonHienTai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTonHienTai.Location = new System.Drawing.Point(15, 303);
            this.lblTonHienTai.Name = "lblTonHienTai";
            this.lblTonHienTai.Size = new System.Drawing.Size(121, 17);
            this.lblTonHienTai.TabIndex = 7;
            this.lblTonHienTai.Text = "Tồn kho hiện tại:";
            // 
            // cmbPhanLoaiInput
            // 
            this.cmbPhanLoaiInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhanLoaiInput.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPhanLoaiInput.FormattingEnabled = true;
            this.cmbPhanLoaiInput.Items.AddRange(new object[] {
            "Đĩa CD",
            "Đĩa Than (Vinyl)",
            "Băng Cassette",
            "Thiết Bị Nghe Nhạc"});
            this.cmbPhanLoaiInput.Location = new System.Drawing.Point(135, 165);
            this.cmbPhanLoaiInput.Name = "cmbPhanLoaiInput";
            this.cmbPhanLoaiInput.Size = new System.Drawing.Size(225, 25);
            this.cmbPhanLoaiInput.TabIndex = 6;
            this.cmbPhanLoaiInput.SelectedIndexChanged += new System.EventHandler(this.cmbPhanLoaiInput_SelectedIndexChanged);
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.AutoSize = true;
            this.lblLoaiSP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLoaiSP.Location = new System.Drawing.Point(15, 168);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(102, 17);
            this.lblLoaiSP.TabIndex = 5;
            this.lblLoaiSP.Text = "Loại sản phẩm:";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTenSP.Location = new System.Drawing.Point(135, 115);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(225, 25);
            this.txtTenSP.TabIndex = 4;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.Location = new System.Drawing.Point(15, 118);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(98, 17);
            this.lblTenSP.TabIndex = 3;
            this.lblTenSP.Text = "Tên sản phẩm:";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtMaSP.Location = new System.Drawing.Point(135, 65);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(225, 25);
            this.txtMaSP.TabIndex = 2;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMaSP.Location = new System.Drawing.Point(15, 68);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(94, 17);
            this.lblMaSP.TabIndex = 1;
            this.lblMaSP.Text = "Mã sản phẩm:";
            // 
            // lblTitleNhapKho
            // 
            this.lblTitleNhapKho.AutoSize = true;
            this.lblTitleNhapKho.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleNhapKho.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitleNhapKho.Location = new System.Drawing.Point(15, 18);
            this.lblTitleNhapKho.Name = "lblTitleNhapKho";
            this.lblTitleNhapKho.Size = new System.Drawing.Size(256, 21);
            this.lblTitleNhapKho.TabIndex = 0;
            this.lblTitleNhapKho.Text = "NHẬP SẢN PHẨM MỚI VÀO KHO";
            // 
            // tabLichSu
            // 
            this.tabLichSu.Controls.Add(this.dgvLichSu);
            this.tabLichSu.Location = new System.Drawing.Point(4, 26);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(10);
            this.tabLichSu.Size = new System.Drawing.Size(1072, 540);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "📜 LỊCH SỬ XUẤT NHẬP KHO";
            this.tabLichSu.UseVisualStyleBackColor = true;
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvLichSu.Location = new System.Drawing.Point(10, 10);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(1052, 520);
            this.dgvLichSu.TabIndex = 0;
            // 
            // ucXuatNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.tabControlXuatNhap);
            this.Controls.Add(this.pnlKPI);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ucXuatNhapHang";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1100, 700);
            this.Load += new System.EventHandler(this.ucXuatNhapHang_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlKPI.ResumeLayout(false);
            this.pnlKPI3.ResumeLayout(false);
            this.pnlKPI3.PerformLayout();
            this.pnlKPI2.ResumeLayout(false);
            this.pnlKPI2.PerformLayout();
            this.pnlKPI1.ResumeLayout(false);
            this.pnlKPI1.PerformLayout();
            this.tabControlXuatNhap.ResumeLayout(false);
            this.tabQuanLyKho.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlLeftGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).EndInit();
            this.pnlToolGrid.ResumeLayout(false);
            this.pnlToolGrid.PerformLayout();
            this.pnlRightInput.ResumeLayout(false);
            this.pnlRightInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongNhap)).EndInit();
            this.tabLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel pnlKPI;
        private System.Windows.Forms.Panel pnlKPI1;
        private System.Windows.Forms.Label lblTitleKPI1;
        private System.Windows.Forms.Label lblTongMatHang;
        private System.Windows.Forms.Panel pnlKPI2;
        private System.Windows.Forms.Label lblTitleKPI2;
        private System.Windows.Forms.Label lblTongSoLuongTon;
        private System.Windows.Forms.Panel pnlKPI3;
        private System.Windows.Forms.Label lblTitleKPI3;
        private System.Windows.Forms.Label lblSapHetHang;
        private System.Windows.Forms.TabControl tabControlXuatNhap;
        private System.Windows.Forms.TabPage tabQuanLyKho;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeftGrid;
        private System.Windows.Forms.DataGridView dgvKhoHang;
        private System.Windows.Forms.Panel pnlToolGrid;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cmbLoaiHang;
        private System.Windows.Forms.Label lblLocLoai;
        private System.Windows.Forms.Panel pnlRightInput;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.ComboBox cmbNhaCungCap;
        private System.Windows.Forms.Label lblNhaCungCap;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXacNhanNhap;
        private System.Windows.Forms.NumericUpDown nudSoLuongNhap;
        private System.Windows.Forms.Label lblSoLuongNhap;
        private System.Windows.Forms.TextBox txtTonHienTai;
        private System.Windows.Forms.Label lblTonHienTai;
        private System.Windows.Forms.ComboBox cmbPhanLoaiInput;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.Label lblTitleNhapKho;
        private System.Windows.Forms.DataGridView dgvLichSu;
    }
}