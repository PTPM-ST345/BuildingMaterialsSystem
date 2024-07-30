CREATE DATABASE QuanLy_VLXD2;
GO
USE QuanLy_VLXD2;
GO

-- Create QL_NhomNguoiDung table first
CREATE TABLE QL_NhomNguoiDung (
    MaNhom VARCHAR(20) PRIMARY KEY,
    TenNhom NVARCHAR(50) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Create DM_ManHinh table
CREATE TABLE DM_ManHinh (
    MaManHinh NVARCHAR(50) PRIMARY KEY,
    TenManHinh NVARCHAR(50) NOT NULL
);
GO

-- Create QL_PhanQuyen table
CREATE TABLE QL_PhanQuyen (
    MaNhomNguoiDung VARCHAR(20),
    MaManHinh NVARCHAR(50),
    CoQuyen BIT NOT NULL,
    PRIMARY KEY (MaNhomNguoiDung, MaManHinh),
    FOREIGN KEY (MaNhomNguoiDung) REFERENCES QL_NhomNguoiDung(MaNhom),
    FOREIGN KEY (MaManHinh) REFERENCES DM_ManHinh(MaManHinh)
);
GO
-- Create NhanVien table
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(50),
    GioiTinh NVARCHAR(5),
    NgaySinh DATETIME,
    DiaChi NVARCHAR(50),
    SDT NVARCHAR(15),
    ChucVu NVARCHAR(50),
    MatKhau NVARCHAR(30),
    TenDangNhap NVARCHAR(50) UNIQUE,
);
GO

-- Create QL_NguoiDungNhomNguoiDung table
CREATE TABLE QL_NguoiDungNhomNguoiDung (
    TenDangNhap NVARCHAR(50) ,
    MaNhomNguoiDung VARCHAR(20) ,
    GhiChu NVARCHAR(200),
    PRIMARY KEY (TenDangNhap, MaNhomNguoiDung),
    FOREIGN KEY (TenDangNhap) REFERENCES NhanVien(TenDangNhap),
    FOREIGN KEY (MaNhomNguoiDung) REFERENCES QL_NhomNguoiDung(MaNhom)
);
GO

-- Create KhachHang table
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(100),
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    DienThoai NVARCHAR(15),
    TaiKhoan NVARCHAR(50),
    MatKhau NVARCHAR(50),
    Email NVARCHAR(100),
    DiaChi NVARCHAR(MAX)
);
GO

-- Create NhaCungCap table
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(10) PRIMARY KEY,
    TenNCC NVARCHAR(50),
    Diachi NVARCHAR(50),
    SDT NVARCHAR(15)
);
GO

-- Create DanhMucSanPham table
CREATE TABLE DanhMucSanPham (
    MaLoai VARCHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(50),
    ThongTin TEXT,
    XuatXu NVARCHAR(50),
    TrangThai INT
);
GO

-- Create HangHoa table
CREATE TABLE HangHoa (
    MaHH VARCHAR(10) PRIMARY KEY,
    TenHangHoa NVARCHAR(50),
    DonVi NVARCHAR(50),
	SoLuongTon INT,
    HinhAnh NVARCHAR(255),
    GiaBan INT,
    MaLoai VARCHAR(10) FOREIGN KEY REFERENCES DanhMucSanPham(MaLoai),
    MaNCC VARCHAR(10) FOREIGN KEY REFERENCES NhaCungCap(MaNCC)

);
GO

-- Tạo bảng DonBanHang
CREATE TABLE DonBanHang (
    MaDonBanHang VARCHAR(15) PRIMARY KEY,
    NgayGiao DATE,
    NgayDat DATE,
    NgayThanhToan DATE,
    MaKH VARCHAR(10),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO	
-- Tạo bảng ChiTietDonHang
CREATE TABLE ChiTietDonBanHang(
    MaHH VARCHAR(10),
    MaDonBanHang VARCHAR(15),
    SoLuong INT,
    DonGia FLOAT,
	PRIMARY KEY (MaHH, MaDonBanHang),
    FOREIGN KEY (MaHH) REFERENCES HangHoa(MaHH),
    FOREIGN KEY (MaDonBanHang) REFERENCES DonBanHang(MaDonBanHang)
);
GO	

-- Create DonNhapHang table
CREATE TABLE DonNhapHang (
    MaDonNhapHang VARCHAR(15) PRIMARY KEY,
    NgayNhap DATE,
	MaNV VARCHAR(10),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO
-- Create ChiTietDonNhapHang table
CREATE TABLE ChiTietDonNhapHang (
    MaHH VARCHAR(10),
	MaDonNhapHang VARCHAR(15),
    SoLuong INT,
    DonGia FLOAT,
	PRIMARY KEY (MaHH, MaDonNhapHang),
	FOREIGN KEY (MaHH) REFERENCES HangHoa(MaHH),
	FOREIGN KEY (MaDonNhapHang) REFERENCES DonNhapHang(MaDonNhapHang)
);
GO