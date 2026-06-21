namespace DTO 
{
    public class SanPhamDTO
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string NgheSi_ThuongHieu { get; set; }
        public string MaLoai { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        public SanPhamDTO()
        {
        }

        public SanPhamDTO(string maSP, string tenSP, string ngheSi_ThuongHieu, string maLoai, decimal giaBan, int soLuongTon, string hinhAnh, string moTa)
        {
            MaSP = maSP;
            TenSP = tenSP;
            NgheSi_ThuongHieu = ngheSi_ThuongHieu;
            MaLoai = maLoai;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
            HinhAnh = hinhAnh;
            MoTa = moTa;
        }
    }
}