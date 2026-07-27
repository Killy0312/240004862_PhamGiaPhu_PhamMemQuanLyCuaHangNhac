namespace GUI
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);

            // Cards
            this.pnlCard1 = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.lblCard1Val = new System.Windows.Forms.Label();
            this.pnlCard2 = new System.Windows.Forms.Panel();
            this.lblCard2Title = new System.Windows.Forms.Label();
            this.lblCard2Val = new System.Windows.Forms.Label();
            this.pnlCard3 = new System.Windows.Forms.Panel();
            this.lblCard3Title = new System.Windows.Forms.Label();
            this.lblCard3Val = new System.Windows.Forms.Label();
            this.pnlCard4 = new System.Windows.Forms.Panel();
            this.lblCard4Title = new System.Windows.Forms.Label();
            this.lblCard4Val = new System.Windows.Forms.Label();

            // Quick Actions & Grid
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.dgvTopSelling = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlCard1.SuspendLayout();
            this.pnlCard2.SuspendLayout();
            this.pnlCard3.SuspendLayout();
            this.pnlCard4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.Teal;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblClock);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 50);

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(15, 15);
            this.lblWelcome.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG BĂNG ĐĨA AUDIOPHILE";

            // lblClock
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClock.ForeColor = System.Drawing.Color.Yellow;
            this.lblClock.Location = new System.Drawing.Point(680, 16);
            this.lblClock.Text = "27/07/2026 09:00:00";

            // timerClock
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);

            // Card 1 - Doanh thu
            this.pnlCard1.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlCard1.Controls.Add(this.lblCard1Title);
            this.pnlCard1.Controls.Add(this.lblCard1Val);
            this.pnlCard1.Location = new System.Drawing.Point(20, 70);
            this.pnlCard1.Size = new System.Drawing.Size(210, 90);

            this.lblCard1Title.AutoSize = true;
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard1Title.ForeColor = System.Drawing.Color.White;
            this.lblCard1Title.Location = new System.Drawing.Point(10, 12);
            this.lblCard1Title.Text = "DOANH THU HÔM NAY";

            this.lblCard1Val.AutoSize = true;
            this.lblCard1Val.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCard1Val.ForeColor = System.Drawing.Color.White;
            this.lblCard1Val.Location = new System.Drawing.Point(10, 42);
            this.lblCard1Val.Text = "0 VNĐ";

            // Card 2 - Hóa đơn
            this.pnlCard2.BackColor = System.Drawing.Color.SteelBlue;
            this.pnlCard2.Controls.Add(this.lblCard2Title);
            this.pnlCard2.Controls.Add(this.lblCard2Val);
            this.pnlCard2.Location = new System.Drawing.Point(250, 70);
            this.pnlCard2.Size = new System.Drawing.Size(210, 90);

            this.lblCard2Title.AutoSize = true;
            this.lblCard2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard2Title.ForeColor = System.Drawing.Color.White;
            this.lblCard2Title.Location = new System.Drawing.Point(10, 12);
            this.lblCard2Title.Text = "HÓA ĐƠN BÁN TRONG NGÀY";

            this.lblCard2Val.AutoSize = true;
            this.lblCard2Val.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCard2Val.ForeColor = System.Drawing.Color.White;
            this.lblCard2Val.Location = new System.Drawing.Point(10, 42);
            this.lblCard2Val.Text = "0 Đơn";

            // Card 3 - Phiếu thuê
            this.pnlCard3.BackColor = System.Drawing.Color.DarkOrange;
            this.pnlCard3.Controls.Add(this.lblCard3Title);
            this.pnlCard3.Controls.Add(this.lblCard3Val);
            this.pnlCard3.Location = new System.Drawing.Point(480, 70);
            this.pnlCard3.Size = new System.Drawing.Size(210, 90);

            this.lblCard3Title.AutoSize = true;
            this.lblCard3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard3Title.ForeColor = System.Drawing.Color.White;
            this.lblCard3Title.Location = new System.Drawing.Point(10, 12);
            this.lblCard3Title.Text = "Đang Cho Thuê (Chưa Trả)";

            this.lblCard3Val.AutoSize = true;
            this.lblCard3Val.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCard3Val.ForeColor = System.Drawing.Color.White;
            this.lblCard3Val.Location = new System.Drawing.Point(10, 42);
            this.lblCard3Val.Text = "0 Phiếu";

            // Card 4 - Khách hàng
            this.pnlCard4.BackColor = System.Drawing.Color.IndianRed;
            this.pnlCard4.Controls.Add(this.lblCard4Title);
            this.pnlCard4.Controls.Add(this.lblCard4Val);
            this.pnlCard4.Location = new System.Drawing.Point(710, 70);
            this.pnlCard4.Size = new System.Drawing.Size(210, 90);

            this.lblCard4Title.AutoSize = true;
            this.lblCard4Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCard4Title.ForeColor = System.Drawing.Color.White;
            this.lblCard4Title.Location = new System.Drawing.Point(10, 12);
            this.lblCard4Title.Text = "TỔNG KHÁCH HÀNG";

            this.lblCard4Val.AutoSize = true;
            this.lblCard4Val.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCard4Val.ForeColor = System.Drawing.Color.White;
            this.lblCard4Val.Location = new System.Drawing.Point(10, 42);
            this.lblCard4Val.Text = "0 Khách";

            // Title Table
            this.lblTopTitle.AutoSize = true;
            this.lblTopTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTopTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTopTitle.Location = new System.Drawing.Point(20, 185);
            this.lblTopTitle.Text = "TOP SẢN PHẨM (BĂNG ĐĨA / THIẾT BỊ) BÁN CHẠY NHẤT";

            // dgvTopSelling
            this.dgvTopSelling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopSelling.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopSelling.Location = new System.Drawing.Point(20, 215);
            this.dgvTopSelling.Name = "dgvTopSelling";
            this.dgvTopSelling.ReadOnly = true;
            this.dgvTopSelling.Size = new System.Drawing.Size(900, 370);

            // ucTrangChu
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlCard1);
            this.Controls.Add(this.pnlCard2);
            this.Controls.Add(this.pnlCard3);
            this.Controls.Add(this.pnlCard4);
            this.Controls.Add(this.lblTopTitle);
            this.Controls.Add(this.dgvTopSelling);
            this.Name = "ucTrangChu";
            this.Size = new System.Drawing.Size(950, 610);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard1.ResumeLayout(false);
            this.pnlCard1.PerformLayout();
            this.pnlCard2.ResumeLayout(false);
            this.pnlCard2.PerformLayout();
            this.pnlCard3.ResumeLayout(false);
            this.pnlCard3.PerformLayout();
            this.pnlCard4.ResumeLayout(false);
            this.pnlCard4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Label lblCard1Val;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Title;
        private System.Windows.Forms.Label lblCard2Val;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Title;
        private System.Windows.Forms.Label lblCard3Val;
        private System.Windows.Forms.Panel pnlCard4;
        private System.Windows.Forms.Label lblCard4Title;
        private System.Windows.Forms.Label lblCard4Val;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.DataGridView dgvTopSelling;
    }
}