namespace GUI
{
    partial class frmAuth
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
            this.pnlBranding = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPass = new System.Windows.Forms.TextBox();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBranding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBranding
            // 
            this.pnlBranding.BackColor = System.Drawing.Color.White;
            this.pnlBranding.Controls.Add(this.pictureBox1);
            this.pnlBranding.Location = new System.Drawing.Point(0, -1);
            this.pnlBranding.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBranding.Name = "pnlBranding";
            this.pnlBranding.Size = new System.Drawing.Size(568, 576);
            this.pnlBranding.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.Ảnh_chụp_màn_hình_2026_07_11_161601;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(564, 644);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Controls.Add(this.pictureBox3);
            this.pnlLogin.Controls.Add(this.pictureBox2);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtLoginPass);
            this.pnlLogin.Controls.Add(this.txtLoginUser);
            this.pnlLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pnlLogin.Location = new System.Drawing.Point(563, 3);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(551, 572);
            this.pnlLogin.TabIndex = 2;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.pictureBox3.Image = global::GUI.Properties.Resources.padlock;
            this.pictureBox3.Location = new System.Drawing.Point(67, 181);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(63, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.pictureBox2.Image = global::GUI.Properties.Resources.pngfind_com_male_symbol_png_349693;
            this.pictureBox2.Location = new System.Drawing.Point(67, 104);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(183, 267);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(291, 62);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPass
            // 
            this.txtLoginPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.txtLoginPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtLoginPass.ForeColor = System.Drawing.Color.White;
            this.txtLoginPass.Location = new System.Drawing.Point(167, 181);
            this.txtLoginPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoginPass.Name = "txtLoginPass";
            this.txtLoginPass.Size = new System.Drawing.Size(339, 27);
            this.txtLoginPass.TabIndex = 1;
            this.txtLoginPass.UseSystemPasswordChar = true;
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(62)))));
            this.txtLoginUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtLoginUser.ForeColor = System.Drawing.Color.White;
            this.txtLoginUser.Location = new System.Drawing.Point(167, 115);
            this.txtLoginUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.Size = new System.Drawing.Size(339, 27);
            this.txtLoginUser.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(99, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cửa hàng băng đĩa Audiophile";
            // 
            // frmAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 567);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlBranding);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG XÁC THỰC - MUSIC STORE";
            this.pnlBranding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBranding;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPass;
        private System.Windows.Forms.TextBox txtLoginUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
    }
}

