using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTraHang : Form
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private DataGridView dgvHoaDon;
        private TextBox txtTimKiem;
        private Button btnHuyDon, btnDong;

        public frmTraHang()
        {
            KhoiTaoGiaoDienTuDong();
            LoadDanhSachHoaDon();
        }

        private void KhoiTaoGiaoDienTuDong()
        {
            this.Text = "DANH SÁCH HÓA ĐƠN & HỦY ĐƠN TRẢ HÀNG";
            this.Size = new Size(900, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Panel Header & Tìm kiếm
            Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 65, BackColor = Color.Teal };
            Label lblTitle = new Label
            {
                Text = "TRA CỨU & HỦY HÓA ĐƠN TRẢ HÀNG",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Location = new Point(15, 18),
                AutoSize = true
            };

            txtTimKiem = new TextBox
            {
                Location = new Point(530, 20),
                Size = new Size(230, 26),
                Font = new Font("Segoe UI", 10F)
            };
            txtTimKiem.TextChanged += (s, e) => LoadDanhSachHoaDon(txtTimKiem.Text.Trim());

            Label lblTim = new Label
            {
                Text = "Tìm Mã HĐ / Tên / SĐT:",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(360, 22),
                AutoSize = true
            };

            pnlTop.Controls.AddRange(new Control[] { lblTitle, lblTim, txtTimKiem });

            // Bảng danh sách hóa đơn
            dgvHoaDon = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                RowHeadersVisible = false
            };

            // Panel Nút chức năng ở đáy
            Panel pnlBottom = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.FromArgb(240, 244, 247) };

            btnHuyDon = new Button
            {
                Text = "HỦY HÓA ĐƠN ĐƯỢC CHỌN (HOÀN KHO)",
                BackColor = Color.FromArgb(235, 87, 87),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(300, 38),
                Location = new Point(20, 10),
                Cursor = Cursors.Hand
            };
            btnHuyDon.FlatAppearance.BorderSize = 0;
            btnHuyDon.Click += BtnHuyDon_Click;

            btnDong = new Button
            {
                Text = "ĐÓNG",
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(110, 38),
                Location = new Point(750, 10),
                Cursor = Cursors.Hand
            };
            btnDong.FlatAppearance.BorderSize = 0;
            btnDong.Click += (s, e) => this.Close();

            pnlBottom.Controls.AddRange(new Control[] { btnHuyDon, btnDong });

            this.Controls.AddRange(new Control[] { dgvHoaDon, pnlBottom, pnlTop });
        }

        private void LoadDanhSachHoaDon(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                        SELECT 
                            HD.SoHdBan AS [Mã Hóa Đơn],
                            HD.NgayBan AS [Ngày Lập],
                            ISNULL(KH.HotenKh, N'Khách vãng lai') AS [Tên Khách Hàng],
                            ISNULL(KH.SoDtKh, '') AS [Số Điện Thoại],
                            ISNULL(NV.Hoten, N'Thu ngân') AS [Nhân Viên Lập],
                            ISNULL((SELECT SUM(Soluong * Dongia) FROM ChiTietHoaDonBangDia WHERE SoHdBan = HD.SoHdBan), 0) +
                            ISNULL((SELECT SUM(Soluong * Dongia) FROM ChiTietHoaDonThietBi WHERE SoHdBan = HD.SoHdBan), 0) AS [Tổng Tiền (VNĐ)]
                        FROM HoaDonBan HD
                        LEFT JOIN KhachHang KH ON HD.MaKh = KH.MaKh
                        LEFT JOIN NhanVien NV ON HD.MsNv = NV.MsNv
                        WHERE (@Key = '' OR HD.SoHdBan LIKE '%' + @Key + '%' OR KH.HotenKh LIKE '%' + @Key + '%' OR KH.SoDtKh LIKE '%' + @Key + '%')
                        ORDER BY HD.NgayBan DESC";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Key", keyword);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvHoaDon.DataSource = dt;
                    if (dgvHoaDon.Columns["Tổng Tiền (VNĐ)"] != null)
                    {
                        dgvHoaDon.Columns["Tổng Tiền (VNĐ)"].DefaultCellStyle.Format = "#,##0 VNĐ";
                        dgvHoaDon.Columns["Tổng Tiền (VNĐ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message);
                }
            }
        }

        private void BtnHuyDon_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn trong bảng để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvHoaDon.SelectedRows[0];
            string maHD = row.Cells["Mã Hóa Đơn"].Value.ToString();
            string tenKH = row.Cells["Tên Khách Hàng"].Value.ToString();
            decimal tongTien = Convert.ToDecimal(row.Cells["Tổng Tiền (VNĐ)"].Value);

            DialogResult dr = MessageBox.Show(
                $"Xác nhận HỦY HÓA ĐƠN sau:\n\n" +
                $"• Mã HĐ: {maHD}\n" +
                $"• Khách hàng: {tenKH}\n" +
                $"• Tổng tiền: {tongTien:#,##0} VNĐ\n\n" +
                $"Hệ thống sẽ CỘNG TRẢ LẠI TOÀN BỘ SỐ LƯỢNG HÀNG VÀO KHO và XÓA ĐƠN KHỎI DOANH THU.",
                "Xác nhận hoàn kho & Hủy đơn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.Yes)
            {
                if (ThucHienHuyHoaDon(maHD))
                {
                    MessageBox.Show($"Đã hủy thành công hóa đơn [{maHD}] và hoàn trả tồn kho đầy đủ!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachHoaDon(txtTimKiem.Text.Trim());
                }
            }
        }

        private bool ThucHienHuyHoaDon(string maHD)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Hoàn tồn Băng Đĩa
                    string sqlBD = @"
                        UPDATE BD SET BD.SoLuongTon = BD.SoLuongTon + CT.Soluong
                        FROM BangDia BD INNER JOIN ChiTietHoaDonBangDia CT ON BD.MsBangDia = CT.MsBangDia
                        WHERE CT.SoHdBan = @SoHD";
                    using (SqlCommand cmd = new SqlCommand(sqlBD, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", maHD);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Hoàn tồn Thiết Bị
                    string sqlTB = @"
                        UPDATE TB SET TB.SoLuongTon = TB.SoLuongTon + CT.Soluong
                        FROM ThietBi TB INNER JOIN ChiTietHoaDonThietBi CT ON TB.MsThietBi = CT.MsThietBi
                        WHERE CT.SoHdBan = @SoHD";
                    using (SqlCommand cmd = new SqlCommand(sqlTB, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", maHD);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. Xóa chi tiết
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietHoaDonBangDia WHERE SoHdBan = @SoHD", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", maHD);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM ChiTietHoaDonThietBi WHERE SoHdBan = @SoHD", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", maHD);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Xóa hóa đơn chính
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM HoaDonBan WHERE SoHdBan = @SoHD", conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHD", maHD);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi khi hủy đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}