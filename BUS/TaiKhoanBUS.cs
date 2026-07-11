using DTO;
using System;

namespace BUS
{
    public class TaiKhoanBUS
    {

        public string KiemTraDangNhap(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "Vui lòng nhập đầy đủ tài khoản và mật khẩu!";
            }

            return "OK";
        }

        public string DangKyTaiKhoan(TaiKhoanDTO tk)
        {
            if (string.IsNullOrEmpty(tk.TenDangNhap) || string.IsNullOrEmpty(tk.MatKhau))
            {
                return "Tài khoản và mật khẩu không được để trống!";
            }
            if (tk.MatKhau.Length < 6)
            {
                return "Mật khẩu phải có ít nhất 6 ký tực!";
            }

            return "OK"; 
        }
    }
}