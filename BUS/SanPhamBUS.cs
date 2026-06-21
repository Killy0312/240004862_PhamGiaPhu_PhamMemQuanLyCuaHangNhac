using DAL;
using System.Data;

namespace BUS
{
    public class SanPhamBUS
    {
        SanPhamDAL dalSanPham = new SanPhamDAL();

        public DataTable GetListSanPham()
        {
            return dalSanPham.GetListSanPham();
        }
    }
}