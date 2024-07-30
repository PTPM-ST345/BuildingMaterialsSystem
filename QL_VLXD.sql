CREATE DATABASE QuanLy_VLXD3;
GO
USE QuanLy_VLXD3;
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

-- Insert into QL_NhomNguoiDung
INSERT INTO QL_NhomNguoiDung (MaNhom, TenNhom, GhiChu) VALUES
('ND1', 'Admin', 'Quản trị hệ thống'),
('ND2', 'Sales', 'Nhân viên bán hàng'),
('ND3', 'Manager', 'Quản lý'),
('ND4', 'Warehouse', 'Nhân viên kho'),
('ND5', 'Supplier', 'Nhà cung cấp'),
('ND6', 'CustomerService', 'Dịch vụ khách hàng'),
('ND7', 'Finance', 'Tài chính');
GO
-- Insert into DM_ManHinh
INSERT INTO DM_ManHinh (MaManHinh, TenManHinh) VALUES
('MH1', 'Trang Chủ'),
('MH2', 'Quản Lý Người Dùng'),
('MH3', 'Quản Lý Sản Phẩm'),
('MH4', 'Quản Lý Đơn Hàng'),
('MH5', 'Báo Cáo Tài Chính'),
('MH6', 'Quản Lý Kho'),
('MH7', 'Hỗ Trợ Khách Hàng');
GO
-- Insert into QL_PhanQuyen
INSERT INTO QL_PhanQuyen (MaNhomNguoiDung, MaManHinh, CoQuyen) VALUES
('ND1', 'MH1', 1),
('ND2', 'MH3', 1),
('ND3', 'MH4', 1),
('ND4', 'MH6', 1),
('ND5', 'MH5', 0),
('ND6', 'MH7', 1),
('ND7', 'MH5', 1);
GO
-- Insert into NhanVien
INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SDT, ChucVu, MatKhau, TenDangNhap) VALUES
('NV001', 'Nguyen Van A', 'Nam', '1990-01-01', '123 Le Loi', '0123456789', 'Admin', 'pass1', 'nguyenvana'),
('NV002', 'Tran Thi B', 'Nu', '1992-02-02', '456 Hai Ba Trung', '0987654321', 'Sales', 'pass2', 'tranthib'),
('NV003', 'Le Van C', 'Nam', '1985-03-03', '789 Nguyen Trai', '0912345678', 'Manager', 'pass3', 'levanc'),
('NV004', 'Pham Thi D', 'Nu', '1988-04-04', '1011 Tran Hung Dao', '0908765432', 'Warehouse', 'pass4', 'phamthid'),
('NV005', 'Hoang Van E', 'Nam', '1980-05-05', '1213 Vo Thi Sau', '0934567890', 'Supplier', 'pass5', 'hoangvane'),
('NV006', 'Nguyen Thi F', 'Nu', '1995-06-06', '1415 Ly Thuong Kiet', '0945678901', 'CustomerService', 'pass6', 'nguyenthif'),
('NV007', 'Le Thi G', 'Nu', '1982-07-07', '1617 Ba Trieu', '0956789012', 'Finance', 'pass7', 'lethig');
GO
-- Insert into QL_NguoiDungNhomNguoiDung
INSERT INTO QL_NguoiDungNhomNguoiDung (TenDangNhap, MaNhomNguoiDung, GhiChu) VALUES
('nguyenvana', 'ND1', 'Quản trị hệ thống'),
('tranthib', 'ND2', 'Nhân viên bán hàng'),
('levanc', 'ND3', 'Quản lý'),
('phamthid', 'ND4', 'Nhân viên kho'),
('hoangvane', 'ND5', 'Nhà cung cấp'),
('nguyenthif', 'ND6', 'Dịch vụ khách hàng'),
('lethig', 'ND7', 'Tài chính');
GO
-- Insert into KhachHang
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, GioiTinh, DienThoai, TaiKhoan, MatKhau, Email, DiaChi) VALUES
('KH001', 'Nguyen Van H', '1980-01-01', 'Nam', '0901234567', 'nvh', 'passkh1', 'nvh@gmail.com', '123 Tan Binh'),
('KH002', 'Tran Thi I', '1985-02-02', 'Nu', '0912345678', 'tti', 'passkh2', 'tti@gmail.com', '456 Binh Thanh'),
('KH003', 'Le Van J', '1990-03-03', 'Nam', '0923456789', 'lvj', 'passkh3', 'lvj@gmail.com', '789 Thu Duc'),
('KH004', 'Pham Thi K', '1995-04-04', 'Nu', '0934567890', 'ptk', 'passkh4', 'ptk@gmail.com', '1011 Go Vap'),
('KH005', 'Hoang Van L', '2000-05-05', 'Nam', '0945678901', 'hvl', 'passkh5', 'hvl@gmail.com', '1213 Phu Nhuan'),
('KH006', 'Nguyen Thi M', '1985-06-06', 'Nu', '0956789012', 'ntm', 'passkh6', 'ntm@gmail.com', '1415 Binh Chanh'),
('KH007', 'Le Thi N', '1990-07-07', 'Nu', '0967890123', 'ltn', 'passkh7', 'ltn@gmail.com', '1617 District 1');
GO
-- Insert into NhaCungCap
INSERT INTO NhaCungCap (MaNCC, TenNCC, Diachi, SDT) VALUES
('NCC001', 'Cty Vat Lieu Xay Dung A', '123 Cong Hoa', '0901122334'),
('NCC002', 'Cty Vat Lieu Xay Dung B', '456 Le Van Sy', '0902233445'),
('NCC003', 'Cty Vat Lieu Xay Dung C', '789 Nguyen Kiem', '0903344556'),
('NCC004', 'Cty Vat Lieu Xay Dung D', '1011 Phan Xich Long', '0904455667'),
('NCC005', 'Cty Vat Lieu Xay Dung E', '1213 Phan Dinh Phung', '0905566778'),
('NCC006', 'Cty Vat Lieu Xay Dung F', '1415 Nguyen Van Troi', '0906677889'),
('NCC007', 'Cty Vat Lieu Xay Dung G', '1617 Nam Ky Khoi Nghia', '0907788990');
GO
-- Insert into DanhMucSanPham
INSERT INTO DanhMucSanPham (MaLoai, TenLoai, ThongTin, XuatXu, TrangThai) VALUES
('DM001', 'Gạch', 'Gạch xây dựng chất lượng cao', 'Vietnam', 1),
('DM002', 'Xi măng', 'Xi măng Portland', 'Vietnam', 1),
('DM003', 'Cát', 'Cát xây dựng', 'Vietnam', 1),
('DM004', 'Đá', 'Đá xây dựng', 'Vietnam', 1),
('DM005', 'Thép', 'Thép cường lực', 'Vietnam', 1),
('DM006', 'Sơn', 'Sơn tường chất lượng', 'Vietnam', 1),
('DM007', 'Kính', 'Kính chịu lực', 'Vietnam', 1);
GO
-- Insert into HangHoa
INSERT INTO HangHoa (MaHH, TenHangHoa, DonVi, SoLuongTon, HinhAnh, GiaBan, MaLoai, MaNCC) VALUES
('HH001', 'Gạch A', 'Viên', 1000, 'gach_a.jpg', 5000, 'DM001', 'NCC001'),
('HH002', 'Xi măng B', 'Bao', 500, 'ximang_b.jpg', 80000, 'DM002', 'NCC002'),
('HH003', 'Cát C', 'Tấn', 300, 'cat_c.jpg', 100000, 'DM003', 'NCC003'),
('HH004', 'Đá D', 'Khối', 200, 'da_d.jpg', 150000, 'DM004', 'NCC004'),
('HH005', 'Thép E', 'Cây', 100, 'thep_e.jpg', 200000, 'DM005', 'NCC005'),
('HH006', 'Sơn F', 'Thùng', 50, 'son_f.jpg', 400000, 'DM006', 'NCC006'),
('HH007', 'Kính G', 'Tấm', 30, 'kinh_g.jpg', 1000000, 'DM007', 'NCC007');
GO
-- Insert into DonBanHang
INSERT INTO DonBanHang (MaDonBanHang, NgayGiao, NgayDat, NgayThanhToan, MaKH) VALUES
('DBH001', '2023-01-01', '2022-12-30', '2023-01-01', 'KH001'),
('DBH002', '2023-01-02', '2022-12-31', '2023-01-02', 'KH002'),
('DBH003', '2023-01-03', '2022-12-31', '2023-01-03', 'KH003'),
('DBH004', '2023-01-04', '2023-01-01', '2023-01-04', 'KH004'),
('DBH005', '2023-01-05', '2023-01-01', '2023-01-05', 'KH005'),
('DBH006', '2023-01-06', '2023-01-02', '2023-01-06', 'KH006'),
('DBH007', '2023-01-07', '2023-01-02', '2023-01-07', 'KH007');
GO
-- Insert into ChiTietDonBanHang
INSERT INTO ChiTietDonBanHang (MaHH, MaDonBanHang, SoLuong, DonGia) VALUES
('HH001', 'DBH001', 100, 5000),
('HH002', 'DBH002', 50, 80000),
('HH003', 'DBH003', 20, 100000),
('HH004', 'DBH004', 10, 150000),
('HH005', 'DBH005', 5, 200000),
('HH006', 'DBH006', 2, 400000),
('HH007', 'DBH007', 1, 1000000);
GO
-- Insert into DonNhapHang
INSERT INTO DonNhapHang (MaDonNhapHang, NgayNhap, MaNV) VALUES
('DNH001', '2023-01-01', 'NV001'),
('DNH002', '2023-01-02', 'NV002'),
('DNH003', '2023-01-03', 'NV003'),
('DNH004', '2023-01-04', 'NV004'),
('DNH005', '2023-01-05', 'NV005'),
('DNH006', '2023-01-06', 'NV006'),
('DNH007', '2023-01-07', 'NV007');
GO
-- Insert into ChiTietDonNhapHang
INSERT INTO ChiTietDonNhapHang (MaHH, MaDonNhapHang, SoLuong, DonGia) VALUES
('HH001', 'DNH001', 100, 4500),
('HH002', 'DNH002', 50, 75000),
('HH003', 'DNH003', 20, 95000),
('HH004', 'DNH004', 10, 140000),
('HH005', 'DNH005', 5, 190000),
('HH006', 'DNH006', 2, 380000),
('HH007', 'DNH007', 1, 950000);
GO