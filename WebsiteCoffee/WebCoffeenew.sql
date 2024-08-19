
-- Tạo bảng Phân quyền (Roles)
CREATE TABLE PhanQuyen (
    MaQuyen INT PRIMARY KEY IDENTITY(1,1),
    TenQuyen NVARCHAR(50) NOT NULL
);

-- Tạo bảng Tài khoản (Accounts)
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(50) NOT NULL,
    MatKhau NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(15),
    MaQuyen INT,
    FOREIGN KEY (MaQuyen) REFERENCES PhanQuyen(MaQuyen)
);

-- Tạo bảng Nhà cung cấp (Suppliers)
CREATE TABLE NhaCungCap (
    MaNhaCungCap INT PRIMARY KEY IDENTITY(1,1),
    TenNhaCungCap NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100)
);

-- Tạo bảng Loại sản phẩm (Product Categories)
CREATE TABLE LoaiSanPham (
    MaLoaiSP INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiSP NVARCHAR(50) NOT NULL
);

-- Tạo bảng Sản phẩm (Products)
CREATE TABLE SanPham (
    MaSanPham INT PRIMARY KEY IDENTITY(1,1),
    TenSanPham NVARCHAR(50) NOT NULL,
    Gia DECIMAL(18, 2) NOT NULL,
    MaLoaiSP INT,
    MoTa NVARCHAR(max),
    HinhAnh NVARCHAR(max),
    MaNhaCungCap INT,
    FOREIGN KEY (MaLoaiSP) REFERENCES LoaiSanPham(MaLoaiSP),
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap)
);

-- Tạo bảng Khuyến mãi (Promotions)
CREATE TABLE KhuyenMai (
    MaKhuyenMai INT PRIMARY KEY IDENTITY(1,1),
    TenKhuyenMai NVARCHAR(50) NOT NULL,
    PhanTramGiamGia DECIMAL(5, 2) NOT NULL,
    NgayBatDau DATETIME NOT NULL,
    NgayKetThuc DATETIME NOT NULL
);

-- Tạo bảng Đơn hàng (Orders)
CREATE TABLE DonHang (
    MaDonHang INT PRIMARY KEY IDENTITY(1,1),
    MaTaiKhoan INT,
    NgayDatHang DATETIME NOT NULL,
    TongTien DECIMAL(18, 2) NOT NULL,
    TrangThai NVARCHAR(50),
    MaKhuyenMai INT,
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan),
    FOREIGN KEY (MaKhuyenMai) REFERENCES KhuyenMai(MaKhuyenMai)
);

-- Tạo bảng Chi tiết đơn hàng (Order Details)
CREATE TABLE ChiTietDonHang (
    MaDonHang INT,
    MaSanPham INT,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18, 2) NOT NULL,
    PRIMARY KEY (MaDonHang, MaSanPham),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);

-- Tạo bảng Vận chuyển (Shipping)
CREATE TABLE VanChuyen (
    MaVanChuyen INT PRIMARY KEY IDENTITY(1,1),
    MaDonHang INT,
    NgayGiaoHang DATETIME,
    TrangThai NVARCHAR(50),
    DiaChiGiaoHang NVARCHAR(255),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);

-- Tạo bảng Phản hồi (Feedback)
CREATE TABLE PhanHoi (
    MaPhanHoi INT PRIMARY KEY IDENTITY(1,1),
    MaTaiKhoan INT,
    MaDonHang INT,
    DanhGia INT CHECK(DanhGia BETWEEN 1 AND 5),
    NhanXet NVARCHAR(255),
    FOREIGN KEY (MaTaiKhoan) REFERENCES TaiKhoan(MaTaiKhoan),
    FOREIGN KEY (MaDonHang) REFERENCES DonHang(MaDonHang)
);

insert into PhanQuyen
values
('Admin'),
('User')

insert into TaiKhoan
values
(N'Lê Quốc Anh',CONVERT(varchar(32), HASHBYTES('MD5','18072003'),2),'94quocanh1872003@gmail.com','0352446495',1),
(N'Nguyễn Tiến Thành',CONVERT(varchar(32), HASHBYTES('MD5','27102003'),2),'zingmi875@gmail.com','0352446495',2)

insert into LoaiSanPham
values
(N'Cà phê'),
(N'Trà'),
(N'Nước ép'),
(N'Đá xay'),
(N'Sinh tố')

insert into NhaCungCap
values
(N'Lê Quốc Anh',N'Củ Chi','0352446495','94quocanh1872003@gmail.com')
select *from PhanQuyen
select *from TaiKhoan
select *from LoaiSanPham
select *from NhaCungCap