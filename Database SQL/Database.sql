-- Tạo Database 
CREATE DATABASE MasterCD_DB;
GO
USE MasterCD_DB;
GO

-- 1. BẢNG LOẠI SẢN PHẨM (Category)
CREATE TABLE LoaiSanPham (
    MaLoai VARCHAR(20) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL
);
GO

-- 2. BẢNG SẢN PHẨM (Product)
CREATE TABLE SanPham (
    MaSP VARCHAR(20) PRIMARY KEY,
    TenSP NVARCHAR(255) NOT NULL,          -- product.name
    NgheSi_ThuongHieu NVARCHAR(255),       -- product.artist (Dùng chung cho Tên ca sĩ hoặc Thương hiệu thiết bị)
    MaLoai VARCHAR(20),                    -- product.category
    GiaBan DECIMAL(18, 0) DEFAULT 0,       -- product.price
    SoLuongTon INT DEFAULT 10,             -- Tình trạng (Còn hàng)
    HinhAnh VARCHAR(500),                  -- product.img
    MoTa NVARCHAR(MAX),                    -- product.description
    FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
);
GO

-- 3. BẢNG DANH SÁCH BÀI HÁT 
CREATE TABLE Tracklist (
    MaTrack INT IDENTITY(1,1) PRIMARY KEY,
    MaSP VARCHAR(20),                      -- Liên kết với Album
    ThuTu INT,                             -- id (1, 2, 3...)
    TenBaiHat NVARCHAR(255) NOT NULL,      -- title
    CaSi NVARCHAR(255),                    -- artist (của bài hát)
    ThoiLuong VARCHAR(10),                 -- duration (vd: "2:20")
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO

-- 4. BẢNG THÔNG SỐ KỸ THUẬT
CREATE TABLE ThongSoKyThuat (
    MaTS INT IDENTITY(1,1) PRIMARY KEY,
    MaSP VARCHAR(20),                      -- Liên kết với Thiết bị nghe
    TenThongSo NVARCHAR(255) NOT NULL,     -- label (vd: "Bảo hành")
    GiaTri NVARCHAR(255) NOT NULL,         -- value (vd: "12 Tháng chính hãng")
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO


INSERT INTO LoaiSanPham (MaLoai, TenLoai) VALUES 
('CD_VINYL', N'CD / Vinyl'),
('THIET_BI', N'Thiết bị nghe');
GO

-- Thêm Sản Phẩm (Giả lập giá bán và số lượng)
INSERT INTO SanPham (MaSP, TenSP, NgheSi_ThuongHieu, MaLoai, GiaBan, HinhAnh) VALUES 
('SP_LUX', N'Lux', N'ROSALÍA', 'CD_VINYL', 850000, 'url_hinh_lux.jpg'),
('SP_MINHTINH', N'Minh Tinh', N'Văn Mai Hương', 'CD_VINYL', 450000, 'url_hinh_minhtinh.jpg'),
('SP_WALKMAN', N'Sony Walkman NW-A105', N'Sony', 'THIET_BI', 5500000, 'url_hinh_sony.jpg');
GO

-- Thêm Dữ liệu cho Bảng Tracklist (Album LUX - ROSALÍA)
INSERT INTO Tracklist (MaSP, ThuTu, TenBaiHat, CaSi, ThoiLuong) VALUES 
('SP_LUX', 1, N'Sexo, Violencia y Llantas', N'ROSALÍA', '2:20'),
('SP_LUX', 2, N'Reliquia', N'ROSALÍA', '3:50'),
('SP_LUX', 3, N'Divinize', N'ROSALÍA', '4:03'),
('SP_LUX', 4, N'Porcelana', N'ROSALÍA, Dougie F', '4:08'),
('SP_LUX', 5, N'Mio Cristo Piange Diamanti', N'ROSALÍA', '4:29'),
('SP_LUX', 6, N'Berghain', N'ROSALÍA, Björk, Yves Tumor', '2:58'),
('SP_LUX', 7, N'La Perla', N'ROSALÍA, Yahritza Y Su Esencia', '3:15'),
('SP_LUX', 8, N'Mundo Nuevo', N'ROSALÍA', '2:20');
-- (Bạn có thể thêm tiếp các bài 9-15 của Lux vào đây theo cấu trúc trên)

-- Thêm Dữ liệu cho Bảng Tracklist (Album Minh Tinh - Văn Mai Hương)
INSERT INTO Tracklist (MaSP, ThuTu, TenBaiHat, CaSi, ThoiLuong) VALUES 
('SP_MINHTINH', 1, N'Đại Minh Tinh', N'Văn Mai Hương, Hứa Kim Tuyền', '4:07'),
('SP_MINHTINH', 2, N'Martini', N'Văn Mai Hương, Hứa Kim Tuyền', '3:20'),
('SP_MINHTINH', 3, N'Vườn Địa Đàng', N'Văn Mai Hương, Hứa Kim Tuyền', '3:07'),
('SP_MINHTINH', 4, N'A Red Flag', N'Văn Mai Hương, Hứa Kim Tuyền', '3:50'),
('SP_MINHTINH', 5, N'Bay Cùng Bay', N'Văn Mai Hương, Hứa Kim Tuyền, Tuimi', '4:12'),
('SP_MINHTINH', 6, N'Mưa Tháng Sáu', N'Văn Mai Hương, GREY D, Trung Quân', '4:17'),
('SP_MINHTINH', 7, N'Cơn Mưa Rào', N'Văn Mai Hương, Negav, Hứa Kim Tuyền', '3:45'),
('SP_MINHTINH', 8, N'Nam Bán Cầu', N'Văn Mai Hương, Hứa Kim Tuyền', '3:18');

-- Thêm Dữ liệu cho Bảng ThongSoKyThuat (Khi MaLoai = 'THIET_BI')
INSERT INTO ThongSoKyThuat (MaSP, TenThongSo, GiaTri) VALUES 
('SP_WALKMAN', N'Thương hiệu', N'Sony'),
('SP_WALKMAN', N'Bảo hành', N'12 Tháng chính hãng'),
('SP_WALKMAN', N'Tình trạng', N'Mới 100% Fullbox'),
('SP_WALKMAN', N'Giao hàng', N'Miễn phí vận chuyển hỏa tốc'),
('SP_WALKMAN', N'Đổi trả', N'1-đổi-1 trong 7 ngày nếu có lỗi NSX');
GO