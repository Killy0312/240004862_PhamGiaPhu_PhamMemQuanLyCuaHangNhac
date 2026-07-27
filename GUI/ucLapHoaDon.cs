using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucLapHoaDon : UserControl
    {
        private string connectionString = @"Server=.;Database=QLCuaHangBangDiaThietBi;Trusted_Connection=True;";
        private DataTable dtGioHang;

        public ucLapHoaDon()
        {
            InitializeComponent();
            KhoiTaoGioHang();
            TaoMaHoaDonMoi();
            LoadKhachHang();
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void KhoiTaoGioHang()
        {
            dtGioHang = new DataTable();
            dtGioHang.Columns.Add("MaSP", typeof(string));
            dtGioHang.Columns.Add("TenSP", typeof(string));
            dtGioHang.Columns.Add("LoaiSP", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal), "DonGia * SoLuong");

            dgvGioHang.DataSource = dtGioHang;

            dgvGioHang.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            dgvGioHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dgvGioHang.Columns["LoaiSP"].HeaderText = "Loại SP";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá (VNĐ)";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";
        }

        private void TaoMaHoaDonMoi()
        {
            txtSoHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void LoadKhachHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaKh, HotenKh + ' - ' + ISNULL(SoDtKh, '') AS DisplayText FROM KhachHang", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboKhachHang.DataSource = dt;
                    cboKhachHang.DisplayMember = "DisplayText";
                    cboKhachHang.ValueMember = "MaKh";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi nạp khách hàng: " + ex.Message);
                }
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string maSP = txtBarcode.Text.Trim();
                if (string.IsNullOrEmpty(maSP)) return;

                TimVaThemVaoGioHang(maSP);
                txtBarcode.Clear();
                txtBarcode.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TimVaThemVaoGioHang(string maSP)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sqlBD = @"SELECT BD.MsBangDia AS MaSP, BD.TenBangDia AS TenSP, 'BangDia' AS LoaiSP, ISNULL(BG.DonGiaBan, 0) AS DonGia
                                     FROM BangDia BD 
                                     LEFT JOIN BangGiaBangDia BG ON BD.MsBangDia = BG.MsBangDia
                                     WHERE BD.MsBangDia = @Ma";
                    SqlCommand cmdBD = new SqlCommand(sqlBD, conn);
                    cmdBD.Parameters.AddWithValue("@Ma", maSP);
                    SqlDataReader dr = cmdBD.ExecuteReader();

                    string tenSP = "", loaiSP = "";
                    decimal donGia = 0;
                    bool timThay = false;

                    if (dr.Read())
                    {
                        tenSP = dr["TenSP"].ToString();
                        loaiSP = dr["LoaiSP"].ToString();
                        donGia = Convert.ToDecimal(dr["DonGia"]);
                        timThay = true;
                    }
                    dr.Close();

                    if (!timThay)
                    {
                        string sqlTB = @"SELECT TB.MsThietBi AS MaSP, TB.TenThietBi AS TenSP, 'ThietBi' AS LoaiSP, ISNULL(BG.DonGiaBan, 0) AS DonGia
                                         FROM ThietBi TB 
                                         LEFT JOIN BangGiaThietBi BG ON TB.MsThietBi = BG.MsThietBi
                                         WHERE TB.MsThietBi = @Ma";
                        SqlCommand cmdTB = new SqlCommand(sqlTB, conn);
                        cmdTB.Parameters.AddWithValue("@Ma", maSP);
                        dr = cmdTB.ExecuteReader();

                        if (dr.Read())
                        {
                            tenSP = dr["TenSP"].ToString();
                            loaiSP = dr["LoaiSP"].ToString();
                            donGia = Convert.ToDecimal(dr["DonGia"]);
                            timThay = true;
                        }
                        dr.Close();
                    }

                    if (!timThay)
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm có mã: " + maSP, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataRow[] existingRows = dtGioHang.Select("MaSP = '" + maSP + "'");
                    if (existingRows.Length > 0)
                    {
                        int currentQty = Convert.ToInt32(existingRows[0]["SoLuong"]);
                        existingRows[0]["SoLuong"] = currentQty + 1;
                    }
                    else
                    {
                        DataRow newRow = dtGioHang.NewRow();
                        newRow["MaSP"] = maSP;
                        newRow["TenSP"] = tenSP;
                        newRow["LoaiSP"] = loaiSP;
                        newRow["DonGia"] = donGia;
                        newRow["SoLuong"] = 1;
                        dtGioHang.Rows.Add(newRow);
                    }

                    TinhTongTien();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn sản phẩm: " + ex.Message);
                }
            }
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (DataRow row in dtGioHang.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }
            lblTongTienVal.Text = string.Format("{0:#,##0} VNĐ", tongTien);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soHD = txtSoHD.Text;
            string maKH = cboKhachHang.SelectedValue.ToString();
            string maNV = "NV01";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string sqlHD = "INSERT INTO HoaDonBan (SoHdBan, NgayBan, MaKh, MsNv) VALUES (@SoHD, GETDATE(), @MaKH, @MaNV)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@SoHD", soHD);
                    cmdHD.Parameters.AddWithValue("@MaKH", maKH);
                    cmdHD.Parameters.AddWithValue("@MaNV", maNV);
                    cmdHD.ExecuteNonQuery();

                    foreach (DataRow row in dtGioHang.Rows)
                    {
                        string maSP = row["MaSP"].ToString();
                        string loaiSP = row["LoaiSP"].ToString();
                        int soLuong = Convert.ToInt32(row["SoLuong"]);
                        decimal donGia = Convert.ToDecimal(row["DonGia"]);

                        if (loaiSP == "BangDia")
                        {
                            string sqlCT = "INSERT INTO ChiTietHoaDonBangDia (SoHdBan, MsBangDia, Soluong, Dongia) VALUES (@SoHD, @MaSP, @SL, @Gia)";
                            SqlCommand cmdCT = new SqlCommand(sqlCT, conn, transaction);
                            cmdCT.Parameters.AddWithValue("@SoHD", soHD);
                            cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                            cmdCT.Parameters.AddWithValue("@SL", soLuong);
                            cmdCT.Parameters.AddWithValue("@Gia", donGia);
                            cmdCT.ExecuteNonQuery();
                        }
                        else
                        {
                            string sqlCT = "INSERT INTO ChiTietHoaDonThietBi (SoHdBan, MsThietBi, Soluong, Dongia) VALUES (@SoHD, @MaSP, @SL, @Gia)";
                            SqlCommand cmdCT = new SqlCommand(sqlCT, conn, transaction);
                            cmdCT.Parameters.AddWithValue("@SoHD", soHD);
                            cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                            cmdCT.Parameters.AddWithValue("@SL", soLuong);
                            cmdCT.Parameters.AddWithValue("@Gia", donGia);
                            cmdCT.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    InXuatHoaDonRaManHinh();

                    dtGioHang.Clear();
                    TaoMaHoaDonMoi();
                    TinhTongTien();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi thanh toán hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InXuatHoaDonRaManHinh()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==================================================");
            sb.AppendLine("          CỬA HÀNG BĂNG ĐĨA AUDIOPHILE           ");
            sb.AppendLine("              HÓA ĐƠN BÁN HÀNG BẢN IN             ");
            sb.AppendLine("==================================================");
            sb.AppendLine("Mã Hóa Đơn : " + txtSoHD.Text);
            sb.AppendLine("Thời Gian  : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Khách Hàng : " + cboKhachHang.Text);
            sb.AppendLine("Thu Ngân   : Phạm Gia Phú (NV01)");
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine(string.Format("{0,-20} {1,5} {2,10} {3,12}", "Tên SP", "SL", "Đơn Giá", "Thành Tiền"));
            sb.AppendLine("--------------------------------------------------");

            foreach (DataRow row in dtGioHang.Rows)
            {
                string ten = row["TenSP"].ToString();
                if (ten.Length > 18) ten = ten.Substring(0, 15) + "...";
                int sl = Convert.ToInt32(row["SoLuong"]);
                decimal gia = Convert.ToDecimal(row["DonGia"]);
                decimal tt = Convert.ToDecimal(row["ThanhTien"]);

                sb.AppendLine(string.Format("{0,-20} {1,5} {2,10:#,##0} {3,12:#,##0}", ten, sl, gia, tt));
            }

            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("TỔNG TIỀN THANH TOÁN : " + lblTongTienVal.Text);
            sb.AppendLine("==================================================");
            sb.AppendLine("    Cảm ơn Quý khách & Hẹn gặp lại quý khách!    ");

            MessageBox.Show(sb.ToString(), "IN HÓA ĐƠN THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                {
                    if (!row.IsNewRow) dgvGioHang.Rows.Remove(row);
                }
                TinhTongTien();
            }
        }

        private void btnHuyGio_Click(object sender, EventArgs e)
        {
            dtGioHang.Clear();
            TinhTongTien();
        }
    }
}