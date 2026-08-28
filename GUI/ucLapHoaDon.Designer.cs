namespace GUI
{
    partial class ucLapHoaDon
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeftInfo = new System.Windows.Forms.Panel();
            this.lblSoHD = new System.Windows.Forms.Label();
            this.txtSoHD = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtNgayLap = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.pnlRightTotal = new System.Windows.Forms.Panel();
            this.lblTongTienTitle = new System.Windows.Forms.Label();
            this.lblTongTienVal = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnHuyGio = new System.Windows.Forms.Button();
            this.btnHuyDonVuaLap = new System.Windows.Forms.Button();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlLeftInfo.SuspendLayout();
            this.pnlRightTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 45);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(384, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LẬP HÓA ĐƠN BÁN HÀNG & THU NGÂN";
            // 
            // pnlLeftInfo
            // 
            this.pnlLeftInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInfo.Controls.Add(this.lblSoHD);
            this.pnlLeftInfo.Controls.Add(this.txtSoHD);
            this.pnlLeftInfo.Controls.Add(this.lblNgayLap);
            this.pnlLeftInfo.Controls.Add(this.txtNgayLap);
            this.pnlLeftInfo.Controls.Add(this.lblSDT);
            this.pnlLeftInfo.Controls.Add(this.txtSDT);
            this.pnlLeftInfo.Controls.Add(this.lblTenKH);
            this.pnlLeftInfo.Controls.Add(this.txtTenKH);
            this.pnlLeftInfo.Controls.Add(this.lblBarcode);
            this.pnlLeftInfo.Controls.Add(this.txtBarcode);
            this.pnlLeftInfo.Controls.Add(this.lblHuongDan);
            this.pnlLeftInfo.Location = new System.Drawing.Point(20, 55);
            this.pnlLeftInfo.Name = "pnlLeftInfo";
            this.pnlLeftInfo.Size = new System.Drawing.Size(630, 175);
            this.pnlLeftInfo.TabIndex = 1;
            // 
            // lblSoHD
            // 
            this.lblSoHD.Location = new System.Drawing.Point(15, 15);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(100, 23);
            this.lblSoHD.TabIndex = 0;
            this.lblSoHD.Text = "Mã Hóa Đơn:";
            // 
            // txtSoHD
            // 
            this.txtSoHD.Location = new System.Drawing.Point(121, 12);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.ReadOnly = true;
            this.txtSoHD.Size = new System.Drawing.Size(189, 22);
            this.txtSoHD.TabIndex = 1;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.Location = new System.Drawing.Point(330, 15);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(100, 23);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Thời Gian:";
            // 
            // txtNgayLap
            // 
            this.txtNgayLap.Location = new System.Drawing.Point(428, 12);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.Size = new System.Drawing.Size(172, 22);
            this.txtNgayLap.TabIndex = 3;
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(15, 52);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(100, 23);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SĐT Khách:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(121, 49);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(189, 22);
            this.txtSDT.TabIndex = 5;
            this.txtSDT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSDT_KeyDown);
            // 
            // lblTenKH
            // 
            this.lblTenKH.Location = new System.Drawing.Point(330, 52);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(100, 23);
            this.lblTenKH.TabIndex = 6;
            this.lblTenKH.Text = "Tên Khách:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(428, 49);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(172, 22);
            this.txtTenKH.TabIndex = 7;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.ForeColor = System.Drawing.Color.Teal;
            this.lblBarcode.Location = new System.Drawing.Point(15, 95);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(200, 21);
            this.lblBarcode.TabIndex = 8;
            this.lblBarcode.Text = "QUÉT MÃ / NHẬP MÃ SP:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.Location = new System.Drawing.Point(210, 90);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(400, 32);
            this.txtBarcode.TabIndex = 9;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            // 
            // lblHuongDan
            // 
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHuongDan.ForeColor = System.Drawing.Color.Gray;
            this.lblHuongDan.Location = new System.Drawing.Point(210, 130);
            this.lblHuongDan.Name = "lblHuongDan";
            this.lblHuongDan.Size = new System.Drawing.Size(460, 19);
            this.lblHuongDan.TabIndex = 10;
            this.lblHuongDan.Text = "* Gõ SĐT rồi bấm Enter để tìm khách. Cột \'Số lượng\' có thể sửa trực tiếp.";
            // 
            // pnlRightTotal
            // 
            this.pnlRightTotal.BackColor = System.Drawing.Color.LightCyan;
            this.pnlRightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightTotal.Controls.Add(this.lblTongTienTitle);
            this.pnlRightTotal.Controls.Add(this.lblTongTienVal);
            this.pnlRightTotal.Controls.Add(this.btnThanhToan);
            this.pnlRightTotal.Controls.Add(this.btnXoaSP);
            this.pnlRightTotal.Controls.Add(this.btnHuyGio);
            this.pnlRightTotal.Controls.Add(this.btnHuyDonVuaLap);
            this.pnlRightTotal.Location = new System.Drawing.Point(670, 55);
            this.pnlRightTotal.Name = "pnlRightTotal";
            this.pnlRightTotal.Size = new System.Drawing.Size(250, 175);
            this.pnlRightTotal.TabIndex = 2;
            // 
            // lblTongTienTitle
            // 
            this.lblTongTienTitle.AutoSize = true;
            this.lblTongTienTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTienTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTongTienTitle.Name = "lblTongTienTitle";
            this.lblTongTienTitle.Size = new System.Drawing.Size(212, 21);
            this.lblTongTienTitle.TabIndex = 0;
            this.lblTongTienTitle.Text = "TỔNG TIỀN THANH TOÁN:";
            // 
            // lblTongTienVal
            // 
            this.lblTongTienVal.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTongTienVal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTienVal.Location = new System.Drawing.Point(12, 28);
            this.lblTongTienVal.Name = "lblTongTienVal";
            this.lblTongTienVal.Size = new System.Drawing.Size(225, 32);
            this.lblTongTienVal.TabIndex = 1;
            this.lblTongTienVal.Text = "0 VNĐ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.Teal;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(15, 65);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(220, 35);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Location = new System.Drawing.Point(15, 105);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(105, 28);
            this.btnXoaSP.TabIndex = 3;
            this.btnXoaSP.Text = "Xóa Dòng";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnHuyGio
            // 
            this.btnHuyGio.Location = new System.Drawing.Point(130, 105);
            this.btnHuyGio.Name = "btnHuyGio";
            this.btnHuyGio.Size = new System.Drawing.Size(105, 28);
            this.btnHuyGio.TabIndex = 4;
            this.btnHuyGio.Text = "Hủy Giỏ";
            this.btnHuyGio.Click += new System.EventHandler(this.btnHuyGio_Click);
            // 
            // btnHuyDonVuaLap
            // 
            this.btnHuyDonVuaLap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.btnHuyDonVuaLap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDonVuaLap.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnHuyDonVuaLap.ForeColor = System.Drawing.Color.White;
            this.btnHuyDonVuaLap.Location = new System.Drawing.Point(15, 138);
            this.btnHuyDonVuaLap.Name = "btnHuyDonVuaLap";
            this.btnHuyDonVuaLap.Size = new System.Drawing.Size(220, 28);
            this.btnHuyDonVuaLap.TabIndex = 5;
            this.btnHuyDonVuaLap.Text = "HỦY ĐƠN VỪA LẬP (TRẢ HÀNG)";
            this.btnHuyDonVuaLap.UseVisualStyleBackColor = false;
            this.btnHuyDonVuaLap.Click += new System.EventHandler(this.btnHuyDonVuaLap_Click);
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeight = 29;
            this.dgvGioHang.Location = new System.Drawing.Point(20, 240);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersWidth = 51;
            this.dgvGioHang.Size = new System.Drawing.Size(900, 345);
            this.dgvGioHang.TabIndex = 3;
            this.dgvGioHang.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGioHang_CellEndEdit);
            // 
            // ucLapHoaDon
            // 
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlLeftInfo);
            this.Controls.Add(this.pnlRightTotal);
            this.Controls.Add(this.dgvGioHang);
            this.Name = "ucLapHoaDon";
            this.Size = new System.Drawing.Size(950, 610);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeftInfo.ResumeLayout(false);
            this.pnlLeftInfo.PerformLayout();
            this.pnlRightTotal.ResumeLayout(false);
            this.pnlRightTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeftInfo;
        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.TextBox txtNgayLap;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Panel pnlRightTotal;
        private System.Windows.Forms.Label lblTongTienTitle;
        private System.Windows.Forms.Label lblTongTienVal;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnHuyGio;
        private System.Windows.Forms.Button btnHuyDonVuaLap;
        private System.Windows.Forms.DataGridView dgvGioHang;
    }
}