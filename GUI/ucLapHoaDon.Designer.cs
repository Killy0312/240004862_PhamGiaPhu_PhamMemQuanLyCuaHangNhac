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
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblHuongDan = new System.Windows.Forms.Label();
            this.pnlRightTotal = new System.Windows.Forms.Panel();
            this.lblTongTienTitle = new System.Windows.Forms.Label();
            this.lblTongTienVal = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnXoaSP = new System.Windows.Forms.Button();
            this.btnHuyGio = new System.Windows.Forms.Button();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlLeftInfo.SuspendLayout();
            this.pnlRightTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 45);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 21);
            this.lblTitle.Text = "LẬP HÓA ĐƠN BÁN HÀNG & THU NGÂN";

            // pnlLeftInfo
            this.pnlLeftInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInfo.Controls.Add(this.lblSoHD);
            this.pnlLeftInfo.Controls.Add(this.txtSoHD);
            this.pnlLeftInfo.Controls.Add(this.lblNgayLap);
            this.pnlLeftInfo.Controls.Add(this.txtNgayLap);
            this.pnlLeftInfo.Controls.Add(this.lblKhachHang);
            this.pnlLeftInfo.Controls.Add(this.cboKhachHang);
            this.pnlLeftInfo.Controls.Add(this.lblBarcode);
            this.pnlLeftInfo.Controls.Add(this.txtBarcode);
            this.pnlLeftInfo.Controls.Add(this.lblHuongDan);
            this.pnlLeftInfo.Location = new System.Drawing.Point(20, 60);
            this.pnlLeftInfo.Name = "pnlLeftInfo";
            this.pnlLeftInfo.Size = new System.Drawing.Size(580, 160);

            // lblSoHD & txtSoHD
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.Location = new System.Drawing.Point(15, 15);
            this.lblSoHD.Text = "Mã Hóa Đơn:";
            this.txtSoHD.Location = new System.Drawing.Point(110, 12);
            this.txtSoHD.Name = "txtSoHD";
            this.txtSoHD.ReadOnly = true;
            this.txtSoHD.Size = new System.Drawing.Size(160, 22);

            // lblNgayLap & txtNgayLap
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Location = new System.Drawing.Point(290, 15);
            this.lblNgayLap.Text = "Thời Gian:";
            this.txtNgayLap.Location = new System.Drawing.Point(360, 12);
            this.txtNgayLap.Name = "txtNgayLap";
            this.txtNgayLap.ReadOnly = true;
            this.txtNgayLap.Size = new System.Drawing.Size(200, 22);

            // lblKhachHang & cboKhachHang
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(15, 52);
            this.lblKhachHang.Text = "Khách Hàng:";
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.Location = new System.Drawing.Point(110, 49);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(450, 22);

            // lblBarcode & txtBarcode
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.ForeColor = System.Drawing.Color.Teal;
            this.lblBarcode.Location = new System.Drawing.Point(15, 95);
            this.lblBarcode.Text = "QUÉT MÃ MÁY / NHẬP MÃ SP:";
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.Location = new System.Drawing.Point(220, 90);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(340, 27);
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // lblHuongDan
            this.lblHuongDan.AutoSize = true;
            this.lblHuongDan.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHuongDan.ForeColor = System.Drawing.Color.Gray;
            this.lblHuongDan.Location = new System.Drawing.Point(220, 125);
            this.lblHuongDan.Text = "* Bấm phím Enter sau khi quét/nhập mã để thêm vào giỏ";

            // pnlRightTotal
            this.pnlRightTotal.BackColor = System.Drawing.Color.LightCyan;
            this.pnlRightTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightTotal.Controls.Add(this.lblTongTienTitle);
            this.pnlRightTotal.Controls.Add(this.lblTongTienVal);
            this.pnlRightTotal.Controls.Add(this.btnThanhToan);
            this.pnlRightTotal.Controls.Add(this.btnXoaSP);
            this.pnlRightTotal.Controls.Add(this.btnHuyGio);
            this.pnlRightTotal.Location = new System.Drawing.Point(620, 60);
            this.pnlRightTotal.Name = "pnlRightTotal";
            this.pnlRightTotal.Size = new System.Drawing.Size(300, 160);

            // lblTongTienTitle
            this.lblTongTienTitle.AutoSize = true;
            this.lblTongTienTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTienTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTongTienTitle.Text = "TỔNG TIỀN THANH TOÁN:";

            // lblTongTienVal
            this.lblTongTienVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongTienVal.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTienVal.Location = new System.Drawing.Point(15, 35);
            this.lblTongTienVal.Size = new System.Drawing.Size(270, 35);
            this.lblTongTienVal.Text = "0 VNĐ";

            // btnThanhToan
            this.btnThanhToan.BackColor = System.Drawing.Color.Teal;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(15, 80);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(270, 40);
            this.btnThanhToan.Text = "THANH TOÁN & IN HÓA ĐƠN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            // btnXoaSP
            this.btnXoaSP.Location = new System.Drawing.Point(15, 125);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(130, 25);
            this.btnXoaSP.Text = "Xóa Dòng Chọn";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);

            // btnHuyGio
            this.btnHuyGio.Location = new System.Drawing.Point(155, 125);
            this.btnHuyGio.Name = "btnHuyGio";
            this.btnHuyGio.Size = new System.Drawing.Size(130, 25);
            this.btnHuyGio.Text = "Hủy Giỏ Hàng";
            this.btnHuyGio.Click += new System.EventHandler(this.btnHuyGio_Click);

            // dgvGioHang
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioHang.Location = new System.Drawing.Point(20, 235);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(900, 350);

            // ucLapHoaDon
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
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblHuongDan;
        private System.Windows.Forms.Panel pnlRightTotal;
        private System.Windows.Forms.Label lblTongTienTitle;
        private System.Windows.Forms.Label lblTongTienVal;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnHuyGio;
        private System.Windows.Forms.DataGridView dgvGioHang;
    }
}