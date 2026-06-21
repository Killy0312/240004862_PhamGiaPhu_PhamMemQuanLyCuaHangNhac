using System;
using System.Windows.Forms;
using BUS;

namespace GUI
{
    public partial class Form1 : Form
    {
        SanPhamBUS busSanPham = new SanPhamBUS();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgvSanPham.DataSource = busSanPham.GetListSanPham();

                if (dgvSanPham.Columns.Count > 0)
                {
                    dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                    dgvSanPham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                    dgvSanPham.Columns["NgheSi_ThuongHieu"].HeaderText = "Nghệ Sĩ / Thương Hiệu";
                    dgvSanPham.Columns["MaLoai"].HeaderText = "Mã Loại";
                    dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgvSanPham.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
                    dgvSanPham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
                    dgvSanPham.Columns["MoTa"].HeaderText = "Mô Tả";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}