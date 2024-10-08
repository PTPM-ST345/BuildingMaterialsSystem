﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Linq;

namespace DAL_BLL
{
    public class XuLy
    {
        QLCHDataContext qlch = new QLCHDataContext();
        public XuLy()
        {

        }

//DangNhap
        public int DangNhap(string manv, string mk)
        {
            var nhanVien = qlch.NhanViens.FirstOrDefault(nv => nv.MaNV == manv && nv.MatKhau == mk);
            return nhanVien != null ? 1 : 0;
        }

//NhanVien
        public List<string> LoadGioiTinh()
        {
            return qlch.NhanViens
                       .Select(nv => nv.GioiTinh)
                       .Distinct()
                       .ToList();
        }

        public NhanVien ChiTietNhanVien(string manv)
        {
            return qlch.NhanViens.FirstOrDefault(nv => nv.MaNV == manv);
        }

        public int CapNhatMatKhau_1NV(string maNV, string matKhauCu, string matKhauMoi, string nhapLaiMatKhau)
        {
            var nhanVien = qlch.NhanViens.FirstOrDefault(nv => nv.MaNV == maNV);
            if (nhanVien != null)
            {
                if (matKhauCu == nhanVien.MatKhau)
                {
                    if (matKhauCu == matKhauMoi)
                    {
                        throw new Exception("Mật khẩu mới không được trùng với mật khẩu cũ.");
                    }

                    if (matKhauMoi == nhapLaiMatKhau)
                    {
                        nhanVien.MatKhau = matKhauMoi;
                        qlch.SubmitChanges();
                        return 1;
                    }
                    else
                    {
                        throw new Exception("Mật khẩu mới và nhập lại mật khẩu không khớp.");
                    }
                }
                else
                {
                    throw new Exception("Mật khẩu cũ không đúng.");
                }
            }
            else
            {
                throw new Exception("Nhân viên không tồn tại.");
            }
        }

        //
        public List<NhanVien> LoadNhanVien()
        {
            return qlch.NhanViens.Select(nv => nv).ToList<NhanVien>();
        }

        public List<NhanVien> TimKiemNhanVien(string keyword, bool timKiemTheoMaNV)
        {
            if (timKiemTheoMaNV)
            {
                return qlch.NhanViens.Where(l => l.MaNV.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.NhanViens.Where(l => l.TenNV.Contains(keyword)).ToList();
            }
        }

        public void XoaNhanVien(string pMaNV)
        {
            NhanVien nv = qlch.NhanViens.Where(l => l.MaNV == pMaNV).FirstOrDefault();
            if (nv != null)
            {
                qlch.NhanViens.DeleteOnSubmit(nv);
                qlch.SubmitChanges();
            }
        }

        public int DemSoDonNhapHangTheoMaNV(string pMaNV)
        {
            int countNV = qlch.DonNhapHangs.Count(h => h.MaNV == pMaNV);
            return countNV;
        }

        public bool IsMaNVDuplicated(string maNV)
        {
            return qlch.NhanViens.Any(l => l.MaNV == maNV);
        }

        public bool ThemNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string diaChi, string soDT, string matKhau)
        {
            if (IsMaNVDuplicated(maNV))
            {
                return false;
            }

            NhanVien nv = new NhanVien
            {
                MaNV = maNV,
                TenNV = tenNV,
                GioiTinh = gioiTinh,
                NgaySinh = ngaySinh,
                DiaChi = diaChi,
                SDT = soDT,
                MatKhau = matKhau
            };

            qlch.NhanViens.InsertOnSubmit(nv);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatNhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, string diaChi, string soDT,  string matKhau)
        {
            NhanVien nv = qlch.NhanViens.Where(l => l.MaNV == maNV).FirstOrDefault();
            if (maNV == null)
            {
                return false;
            }

            nv.TenNV = tenNV;
            nv.GioiTinh = gioiTinh;
            nv.NgaySinh = ngaySinh;
            nv.DiaChi = diaChi;
            nv.SDT = soDT;
            nv.MatKhau = matKhau;

            qlch.SubmitChanges();

            return true;
        }

//KhachHang
        public List<string> LoadGioiTinh_KH()
        {
            return qlch.KhachHangs
                       .Select(nv => nv.GioiTinh)
                       .Distinct()
                       .ToList();
        }

        //
        public List<KhachHang> LoadKhachHang()
        {
            return qlch.KhachHangs.Select(kh => kh).ToList<KhachHang>();
        }

        public List<KhachHang> TimKiemKH(string keyword, bool timKiemTheoMaKH)
        {
            if (timKiemTheoMaKH)
            {
                return qlch.KhachHangs.Where(l => l.MaKH.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.KhachHangs.Where(l => l.HoTen.Contains(keyword)).ToList();
            }
        }

        public void XoaKhachHang(string pMaKH)
        {
            KhachHang kh = qlch.KhachHangs.Where(l => l.MaKH == pMaKH).FirstOrDefault();
            if (kh != null)
            {
                qlch.KhachHangs.DeleteOnSubmit(kh);
                qlch.SubmitChanges();
            }
        }

        public int DemSoDonBanHangTheoMaKH(string pMaKH)
        {
            int countKH = qlch.DonBanHangs.Count(h => h.MaKH == pMaKH);
            return countKH;
        }

        public bool IsMaKHDuplicated(string maKH)
        {
            return qlch.KhachHangs.Any(l => l.MaKH == maKH);
        }

        public bool ThemKhachHang(string maKH, string tenKH, DateTime ngaySinh, string gioiTinh,  string soDT, string taiKhoan,string matKhau, string email, string diaChi)
        {
            if (IsMaKHDuplicated(maKH))
            {
                return false;
            }

            KhachHang kh = new KhachHang
            {
                MaKH = maKH,
                HoTen = tenKH,
                NgaySinh = ngaySinh,
                GioiTinh = gioiTinh,
                DienThoai = soDT,
                TaiKhoan = taiKhoan,
                MatKhau = matKhau,
                Email = email,
                DiaChi = diaChi
            };

            qlch.KhachHangs.InsertOnSubmit(kh);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatKhachHang(string maKH, string tenKH, DateTime ngaySinh, string gioiTinh, string soDT, string taiKhoan, string matKhau, string email, string diaChi)
        {
            KhachHang kh = qlch.KhachHangs.Where(l => l.MaKH == maKH).FirstOrDefault();
            if (maKH == null)
            {
                return false;
            }

            kh.HoTen = tenKH;
            kh.NgaySinh = ngaySinh;
            kh.GioiTinh = gioiTinh;
            kh.DienThoai = soDT;
            kh.TaiKhoan = taiKhoan;
            kh.MatKhau = matKhau;
            kh.Email = email;
            kh.DiaChi = diaChi;
            qlch.SubmitChanges();

            return true;
        }
//NhaCungCap
        public List<NhaCungCap> LoadNhaCungCap()
        {
            return qlch.NhaCungCaps.Select(ncc => ncc).ToList<NhaCungCap>();
        }

        public List<NhaCungCap> TimKiemNhaCungCap(string keyword, bool timKiemTheoMaNCC)
        {
            if (timKiemTheoMaNCC)
            {
                return qlch.NhaCungCaps.Where(ncc => ncc.MaNCC.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.NhaCungCaps.Where(ncc => ncc.TenNCC.Contains(keyword)).ToList();
            }
        }

        public void XoaNCC(string pMaNCC)
        {
            NhaCungCap ncc = qlch.NhaCungCaps.Where(n => n.MaNCC == pMaNCC).FirstOrDefault();
            if (ncc != null)
            {
                qlch.NhaCungCaps.DeleteOnSubmit(ncc);
                qlch.SubmitChanges();
            }
        }

        public int DemSoHangHoaTheoMaNCC(string pMaNCC)
        {
            return qlch.HangHoas.Count(h => h.MaNCC == pMaNCC);
        }

        public bool IsMaNCCDuplicated(string maNCC)
        {
            return qlch.NhaCungCaps.Any(l => l.MaNCC == maNCC);
        }

        public bool ThemNCC(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            if (IsMaNCCDuplicated(maNCC))
            {
                return false;
            }

            NhaCungCap ncc = new NhaCungCap
            {
                MaNCC = maNCC,
                TenNCC = tenNCC,
                Diachi = diaChi,
                SDT = sdt
            };

            qlch.NhaCungCaps.InsertOnSubmit(ncc);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatNCC(string maNCC, string tenNCC, string diaChi, string sdt)
        {
            NhaCungCap ncc = qlch.NhaCungCaps.Where(l => l.MaNCC == maNCC).FirstOrDefault();
            if (ncc == null)
            {
                return false;
            }

            ncc.TenNCC = tenNCC;
            ncc.Diachi = diaChi;
            ncc.SDT = sdt;
            qlch.SubmitChanges();

            return true;
        }

//LoaiHang
        public List<Loai> LoadLoaiHang()
        {
            return qlch.Loais.Select(dmsp => dmsp).ToList<Loai>();
        }

        public List<Loai> TimKiemLoaiHangHoa(string keyword, bool timKiemTheoMaLoai)
        {
            if (timKiemTheoMaLoai)
            {
                return qlch.Loais.Where(l => l.MaLoai.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.Loais.Where(l => l.TenLoai.Contains(keyword)).ToList();
            }
        }

        public void XoaLoaiHangHoa(string pMaLoai)
        {
            Loai loai = qlch.Loais.Where(l => l.MaLoai  == pMaLoai).FirstOrDefault();
            if (loai != null)
            {
                qlch.Loais.DeleteOnSubmit(loai);
                qlch.SubmitChanges();
            }
        }

        public int DemSoHangHoaTheoMaLoai(string pMaLoai)
        {
            return qlch.HangHoas.Count(h => h.MaLoai == pMaLoai);
        }

        public bool IsMaLoaiDuplicated(string maLoai)
        {
            return qlch.Loais.Any(l => l.MaLoai == maLoai);
        }

        public bool ThemLoaiHangHoa(string maLoai, string tenLoai, string thongTin)
        {
            if (IsMaLoaiDuplicated(maLoai))
            {
                return false;
            }

            Loai loai = new Loai
            {
                MaLoai = maLoai,
                TenLoai = tenLoai,
                ThongTin = thongTin,
            };

            qlch.Loais.InsertOnSubmit(loai);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatLoaiHangHoa(string maLoai, string tenLoai, string thongTin)
        {
            Loai loai = qlch.Loais.Where(l => l.MaLoai == maLoai).FirstOrDefault();
            if (loai == null)
            {
                return false;
            }

            loai.TenLoai = tenLoai;
            loai.ThongTin = thongTin;

            qlch.SubmitChanges();

            return true;
        }


//HangHoa
        public List<HangHoa> LoadHangHoa()
        {
            return qlch.HangHoas.Select(hh => hh).ToList<HangHoa>();
        }

        public int? GetSoLuongTon(string maHangHoa)
        {
            var hangHoa = qlch.HangHoas.FirstOrDefault(hh => hh.MaHH == maHangHoa);
            return hangHoa != null ? hangHoa.SoLuongTon : 0;
        }

        public List<HangHoa> TimKiemHangHoa(string keyword, bool timKiemTheoMaHH)
        {
            if (timKiemTheoMaHH)
            {
                return qlch.HangHoas.Where(l => l.MaHH.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.HangHoas.Where(l => l.TenHangHoa.Contains(keyword)).ToList();
            }
        }

        public void XoaHangHoa(string pMaHH)
        {
            HangHoa hh = qlch.HangHoas.Where(l => l.MaHH == pMaHH).FirstOrDefault();
            if (hh != null)
            {
                qlch.HangHoas.DeleteOnSubmit(hh);
                qlch.SubmitChanges();
            }
        }

        public int DemSoDonHangTheoMaHH(string pMaHH)
        {
            int countBanHang = qlch.ChiTietDonBanHangs.Count(h => h.MaHH == pMaHH);
            int countNhapHang = qlch.ChiTietDonNhapHangs.Count(h => h.MaHH == pMaHH);
            return countBanHang + countNhapHang;
        }

        public bool IsMaHHDuplicated(string maHH)
        {
            return qlch.HangHoas.Any(l => l.MaHH == maHH);
        }

        public bool ThemHangHoa(string maHH, string tenHH, string donVi, int soLuongTon, string maLoai, string maNCC, int giaBan, string hinhAnh)
        {
            if (IsMaHHDuplicated(maHH))
            {
                return false;
            }

            HangHoa hh = new HangHoa
            {
                MaHH = maHH,
                TenHangHoa = tenHH,
                DonVi = donVi,
                SoLuongTon = soLuongTon,
                MaLoai = maLoai,
                MaNCC = maNCC,
                GiaBan = giaBan,
                HinhAnh = hinhAnh
                
            };

            qlch.HangHoas.InsertOnSubmit(hh);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatHangHoa(string maHH, string tenHH, string donVi, int soLuongTon, string maLoai, string maNCC, int giaBan, string hinhAnh)
        {
            HangHoa hh = qlch.HangHoas.Where(l => l.MaHH == maHH).FirstOrDefault();
            if (maHH == null)
            {
                return false;
            }

                hh.TenHangHoa = tenHH;
                hh.DonVi = donVi;
                hh.SoLuongTon = soLuongTon;
                hh.MaLoai = maLoai;
                hh.MaNCC = maNCC;
                hh.GiaBan = giaBan;
                hh.HinhAnh = hinhAnh;

            qlch.SubmitChanges();

            return true;
        }

//DonNhapHang##########
        public List<DonNhapHang> LoadDonNhapHang()
        {
            return qlch.DonNhapHangs.Select(dnh => dnh).ToList<DonNhapHang>();
        }

        public List<DonNhapHang> TimKiemDonNhapHang(string keyword, bool timKiemTheoMaDNH)
        {
            if (timKiemTheoMaDNH)
            {
                return qlch.DonNhapHangs.Where(l => l.MaDonNhapHang.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.DonNhapHangs.Where(l => l.MaNV.Contains(keyword)).ToList();
            }
        }

        public void XoaDNH(string pMaDNHToDelete)
        {
            DonNhapHang dnh = qlch.DonNhapHangs.Where(l => l.MaDonNhapHang == pMaDNHToDelete).FirstOrDefault();
            if (dnh != null)
            {
                qlch.DonNhapHangs.DeleteOnSubmit(dnh);
                qlch.SubmitChanges();
            }
        }

        public int DemSoCTDNHTheoMaDNH(string pMaDNHToDelete)
        {
            int countCTDNH = qlch.ChiTietDonNhapHangs.Count(h => h.MaDonNhapHang == pMaDNHToDelete);
            return countCTDNH;
        }

        public bool IsMaDNHDuplicated(string maDNH)
        {
            return qlch.DonNhapHangs.Any(l => l.MaDonNhapHang == maDNH);
        }

        public bool ThemDNH(string maDNH, DateTime ngayNhap, string maNV)
        {
            if (IsMaDNHDuplicated(maDNH))
            {
                return false;
            }

            DonNhapHang dnh = new DonNhapHang
            {
                MaDonNhapHang = maDNH,
                NgayNhap = ngayNhap,
                MaNV = maNV
            };

            qlch.DonNhapHangs.InsertOnSubmit(dnh);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatDNH(string maDNH, DateTime ngayNhap, string maNV)
        {
            DonNhapHang dnh = qlch.DonNhapHangs.Where(l => l.MaDonNhapHang == maDNH).FirstOrDefault();
            if (maDNH == null)
            {
                return false;
            }

            dnh.NgayNhap = ngayNhap;
            dnh.MaNV = maNV;
         
            qlch.SubmitChanges();
            return true;
        }
//CT_DonNhapHang
        public List<ChiTietDonNhapHang> LoadCT_DonNhapHang(string maDNH)
        {
            return qlch.ChiTietDonNhapHangs.Where(dnh => dnh.MaDonNhapHang == maDNH).ToList<ChiTietDonNhapHang>();
        }

        public void XoaCTDNH(string pMaDNHToDelete, string pMaHHToDelete)
        {
            ChiTietDonNhapHang ctdnh = qlch.ChiTietDonNhapHangs.Where(l => l.MaDonNhapHang == pMaDNHToDelete && l.MaHH == pMaHHToDelete).FirstOrDefault();
            if (ctdnh != null)
            {
                int? soLuongXoa = ctdnh.SoLuong;

                HangHoa hangHoa = qlch.HangHoas.Where(h => h.MaHH == pMaHHToDelete).FirstOrDefault();
                if (hangHoa != null)
                {
                    hangHoa.SoLuongTon -= soLuongXoa;
                }

                qlch.ChiTietDonNhapHangs.DeleteOnSubmit(ctdnh);
                qlch.SubmitChanges();
            }
        }

        public bool IsCTDNHDuplicated(string maDNH, string maHH)
        {
            return qlch.ChiTietDonNhapHangs.Any(l => l.MaDonNhapHang == maDNH && l.MaHH == maHH);
        }

        public bool ThemCT_DNH(string maDNH, string maHH, int soLuong, double donGia)
        {
            if (IsCTDNHDuplicated(maDNH, maHH))
            {
                return false;
            }

            ChiTietDonNhapHang ctdnh = new ChiTietDonNhapHang
            {
                MaDonNhapHang = maDNH,
                MaHH = maHH,
                SoLuong = soLuong,
                DonGia = donGia
            };

            qlch.ChiTietDonNhapHangs.InsertOnSubmit(ctdnh);
            qlch.SubmitChanges();

            CapNhatSoLuongTrongKho(maHH, LaySoLuongTrongKho(maHH) + soLuong);
            return true;
        }

        public bool CapNhatCT_DNH(string maDNH, string maHH, int soLuong, double donGia)
        {
            ChiTietDonNhapHang ctdnh = qlch.ChiTietDonNhapHangs.Where(l => l.MaDonNhapHang == maDNH && l.MaHH == maHH).FirstOrDefault();
            if (maDNH == null || maHH == null)
            {
                return false;
            }

            int? soLuongHienTai = ctdnh.SoLuong;
            int? chenhLechSoLuong = soLuong - soLuongHienTai;

            ctdnh.SoLuong = soLuong;
            ctdnh.DonGia = donGia;
            qlch.SubmitChanges();

            CapNhatSoLuongTrongKho(maHH, LaySoLuongTrongKho(maHH) + chenhLechSoLuong);
            return true;
        }

        public int? LaySoLuongTrongKho(string maHangHoa)
        {
            var hangHoa = qlch.HangHoas.Where(k => k.MaHH == maHangHoa).FirstOrDefault();
            return hangHoa != null ? hangHoa.SoLuongTon : 0;
        }

        public void CapNhatSoLuongTrongKho(string maHangHoa, int? soLuongMoi)
        {
            var hangHoa = qlch.HangHoas.Where(k => k.MaHH == maHangHoa).FirstOrDefault();
            if (hangHoa != null)
            {
                hangHoa.SoLuongTon = soLuongMoi;
                qlch.SubmitChanges();
            }
        }
//DonBanHang---###########
        public List<DonBanHang> LoadDonBanHang()
        {
            return qlch.DonBanHangs.Select(dnh => dnh).ToList<DonBanHang>();
        }

        public List<DonBanHang> TimKiemDonBanHang(string keyword, bool timKiemTheoMaDBH)
        {
            if (timKiemTheoMaDBH)
            {
                return qlch.DonBanHangs.Where(l => l.MaDonBanHang.Contains(keyword)).ToList();
            }
            else
            {
                return qlch.DonBanHangs.Where(l => l.MaKH.Contains(keyword)).ToList();
            }
        }

        public void XoaDBH(string maDBHToDelete)
        {
            DonBanHang dnh = qlch.DonBanHangs.Where(l => l.MaDonBanHang == maDBHToDelete).FirstOrDefault();
            if (dnh != null)
            {
                qlch.DonBanHangs.DeleteOnSubmit(dnh);
                qlch.SubmitChanges();
            }
        }

        public int DemSoCTDBHTheoMaDBH(string maDBHToDelete)
        {
            int countCTDBH = qlch.ChiTietDonBanHangs.Count(h => h.MaDonBanHang == maDBHToDelete);
            return countCTDBH;
        }

        public bool IsMaDBHDuplicated(string maDBH)
        {
            return qlch.DonBanHangs.Any(l => l.MaDonBanHang == maDBH);
        }

        public bool ThemDBH(string maDBH, DateTime ngayDat, DateTime ngayGiao, DateTime ngayThanhToan, string maKH)
        {
            if (IsMaDBHDuplicated(maDBH))
            {
                return false;
            }

            DonBanHang dnh = new DonBanHang
            {
                MaDonBanHang = maDBH,
                NgayDat = ngayDat,
                NgayGiao = ngayGiao,
                NgayThanhToan = ngayThanhToan,
                MaKH = maKH
            };

            qlch.DonBanHangs.InsertOnSubmit(dnh);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatDBH(string maDBH, DateTime ngayDat, DateTime ngayGiao, DateTime ngayThanhToan, string maKH)
        {
            DonBanHang dnh = qlch.DonBanHangs.Where(l => l.MaDonBanHang == maDBH).FirstOrDefault();
            if (maDBH == null)
            {
                return false;
            }

            dnh.NgayDat = ngayDat;
            dnh.NgayGiao = ngayGiao;
            dnh.NgayThanhToan = ngayThanhToan;
            dnh.MaKH = maKH;
            qlch.SubmitChanges();
            return true;
        }

//CT_DonBanHang
        public List<ChiTietDonBanHang> LoadCT_DonBanHang(string maDNH)
        {
            return qlch.ChiTietDonBanHangs.Where(dnh => dnh.MaDonBanHang == maDNH).ToList<ChiTietDonBanHang>();
        }

        public void XoaCTDBH(string pMaDNHToDelete, string pMaHHToDelete)
        {
            ChiTietDonBanHang ctdnh = qlch.ChiTietDonBanHangs.Where(l => l.MaDonBanHang == pMaDNHToDelete && l.MaHH == pMaHHToDelete).FirstOrDefault();
            if (ctdnh != null)
            {
                int? soLuongXoa = ctdnh.SoLuong;

                HangHoa hangHoa = qlch.HangHoas.Where(h => h.MaHH == pMaHHToDelete).FirstOrDefault();
                if (hangHoa != null)
                {
                    hangHoa.SoLuongTon -= soLuongXoa;
                }

                qlch.ChiTietDonBanHangs.DeleteOnSubmit(ctdnh);
                qlch.SubmitChanges();
            }
        }

        public bool IsCTDBHDuplicated(string maDBH, string maHH)
        {
            return qlch.ChiTietDonBanHangs.Any(l => l.MaDonBanHang == maDBH && l.MaHH == maHH);
        }

        public bool ThemCT_DBH(string maDNH, string maHH, int soLuong, double donGia)
        {
            if (IsCTDBHDuplicated(maDNH, maHH))
            {
                return false;
            }

            ChiTietDonBanHang ctdnh = new ChiTietDonBanHang
            {
                MaDonBanHang = maDNH,
                MaHH = maHH,
                SoLuong = soLuong,
                DonGia = donGia
            };

            qlch.ChiTietDonBanHangs.InsertOnSubmit(ctdnh);
            qlch.SubmitChanges();

            CapNhatSoLuongTrongKho(maHH, LaySoLuongTrongKho(maHH) - soLuong);
            return true;
        }

        public bool CapNhatCT_DBH(string maDNH, string maHH, int soLuong, double donGia)
        {
            ChiTietDonBanHang ctdnh = qlch.ChiTietDonBanHangs.Where(l => l.MaDonBanHang == maDNH && l.MaHH == maHH).FirstOrDefault();
            if (maDNH == null || maHH == null)
            {
                return false;
            }

            int? soLuongHienTai = ctdnh.SoLuong;
            int? chenhLechSoLuong = soLuong - soLuongHienTai;

            ctdnh.SoLuong = soLuong;
            ctdnh.DonGia = donGia;
            qlch.SubmitChanges();

            CapNhatSoLuongTrongKho(maHH, LaySoLuongTrongKho(maHH) - chenhLechSoLuong);
            return true;
        }


//Nhom Nguoi Dung
        public List<QL_NhomNguoiDung> LoadNhomNguoiDung()
        {
            return qlch.QL_NhomNguoiDungs.Select(dnh => dnh).ToList<QL_NhomNguoiDung>();
        }

        public void XoaNhomND(string pMaNhom)
        {
            QL_NhomNguoiDung loai = qlch.QL_NhomNguoiDungs.Where(l => l.MaNhom == pMaNhom).FirstOrDefault();
            if (loai != null)
            {
                qlch.QL_NhomNguoiDungs.DeleteOnSubmit(loai);
                qlch.SubmitChanges();
            }
        }

        public int DemSoNVTheoMaNhom(string pMaNhom)
        {
            return qlch.QL_NguoiDungNhomNguoiDungs.Count(h => h.MaNhomNguoiDung == pMaNhom);
        }

        public bool IsMaNhomDuplicated(string pMaNhom)
        {
            return qlch.QL_NhomNguoiDungs.Any(l => l.MaNhom == pMaNhom);
        }

        public bool ThemNhomND(string maNhom, string tenNhom, string ghiChu)
        {
            if (IsMaNhomDuplicated(maNhom))
            {
                return false;
            }

            QL_NhomNguoiDung loai = new QL_NhomNguoiDung
            {
                MaNhom = maNhom,
                TenNhom = tenNhom,
                GhiChu = ghiChu,
            };

            qlch.QL_NhomNguoiDungs.InsertOnSubmit(loai);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatNhomND(string maNhom, string tenNhom, string ghiChu)
        {
            QL_NhomNguoiDung loai = qlch.QL_NhomNguoiDungs.Where(l => l.MaNhom == maNhom).FirstOrDefault();
            if (loai == null)
            {
                return false;
            }

            loai.TenNhom = tenNhom;
            loai.GhiChu = ghiChu;

            qlch.SubmitChanges();

            return true;
        }

//Man Hinh
        public List<DM_ManHinh> LoadDanhMucManHinh()
        {
            return qlch.DM_ManHinhs.Select(dnh => dnh).ToList<DM_ManHinh>();
        }

        public void XoaMH(string pMaLoai)
        {
            DM_ManHinh loai = qlch.DM_ManHinhs.Where(l => l.MaManHinh == pMaLoai).FirstOrDefault();
            if (loai != null)
            {
                qlch.DM_ManHinhs.DeleteOnSubmit(loai);
                qlch.SubmitChanges();
            }
        }

        public int DemQuyenTheoMaMH(string pMaLoai)
        {
            return qlch.QL_PhanQuyens.Count(h => h.MaManHinh == pMaLoai);
        }

        public bool IsMaMHDuplicated(string maLoai)
        {
            return qlch.DM_ManHinhs.Any(l => l.MaManHinh == maLoai);
        }

        public bool ThemMH(string maLoai, string tenLoai)
        {
            if (IsMaMHDuplicated(maLoai))
            {
                return false;
            }

            DM_ManHinh loai = new DM_ManHinh
            {
                MaManHinh = maLoai,
                TenManHinh = tenLoai,
            };

            qlch.DM_ManHinhs.InsertOnSubmit(loai);
            qlch.SubmitChanges();

            return true;
        }

        public bool CapNhatMH(string maLoai, string tenLoai)
        {
            DM_ManHinh loai = qlch.DM_ManHinhs.Where(l => l.MaManHinh == maLoai).FirstOrDefault();
            if (loai == null)
            {
                return false;
            }

            loai.TenManHinh = tenLoai;

            qlch.SubmitChanges();

            return true;
        }

//Nguoi dung nhom nguoi dung
        public List<QL_NguoiDungNhomNguoiDung> LoadNDNhomND()
        {
            return qlch.QL_NguoiDungNhomNguoiDungs.Select(dnh => dnh).ToList<QL_NguoiDungNhomNguoiDung>();
        }

        public List<QL_NguoiDungNhomNguoiDung> LoadNDNhomNDTheoMaNhom(string maNhom)
        {
            return qlch.QL_NguoiDungNhomNguoiDungs.Where(nd => nd.MaNhomNguoiDung == maNhom).ToList();
        }

        public bool KiemTraTrungKhoaChinh(string maNV, string maNhomND)
        {
            int? kt = qlch.QL_NguoiDungNhomNguoiDungs.Count(nd => nd.MaNV == maNV && nd.MaNhomNguoiDung == maNhomND);
            return kt > 0;
        }

        public void ThemNguoiDungNhomNguoiDung(string maNV, string maNhomND, string ghiChu)
        {
            QL_NguoiDungNhomNguoiDung nguoiDungNhomNguoiDung = new QL_NguoiDungNhomNguoiDung
            {
                MaNV = maNV,
                MaNhomNguoiDung = maNhomND,
                GhiChu = ghiChu
            };
            qlch.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(nguoiDungNhomNguoiDung);
            qlch.SubmitChanges();
        }

        public void XoaNguoiDungNhomNguoiDung(string maNV, string maNhomND)
        {
            var nguoiDungNhomNguoiDung = qlch.QL_NguoiDungNhomNguoiDungs.SingleOrDefault(nd => nd.MaNV == maNV && nd.MaNhomNguoiDung == maNhomND);
            if (nguoiDungNhomNguoiDung != null)
            {
                qlch.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(nguoiDungNhomNguoiDung);
                qlch.SubmitChanges();
            }
        }

//PhanQuyen
        public List<PhanQuyenDTO> loadPhanQuyen(string maNhomNguoiDung)
        {
            var query = from mh in qlch.DM_ManHinhs
                        join pq in qlch.QL_PhanQuyens
                        on new { mh.MaManHinh, MaNhomNguoiDung = maNhomNguoiDung } equals new { pq.MaManHinh, pq.MaNhomNguoiDung } into gj
                        from subpq in gj.DefaultIfEmpty()
                        select new PhanQuyenDTO
                        {
                            MaManHinh = mh.MaManHinh,
                            TenManHinh = mh.TenManHinh,
                            MaNhomNguoiDung = subpq.MaNhomNguoiDung ?? maNhomNguoiDung,
                            CoQuyen = subpq.CoQuyen
                        };

            return query.ToList();
        }

        public List<QL_PhanQuyen> LoadQLPhanQuyen()
        {
            return qlch.QL_PhanQuyens.Select(dnh => dnh).ToList<QL_PhanQuyen>();
        }

        public bool CheckIfExists(string maNhomNguoiDung, string maManHinh)
        {
            return qlch.QL_PhanQuyens.Any(pq => pq.MaNhomNguoiDung == maNhomNguoiDung && pq.MaManHinh == maManHinh);
        }

        public void UpdatePhanQuyen(string maNhomNguoiDung, string maManHinh, bool coQuyen)
        {
            var phanQuyen = qlch.QL_PhanQuyens
                .FirstOrDefault(pq => pq.MaNhomNguoiDung == maNhomNguoiDung && pq.MaManHinh == maManHinh);

            if (phanQuyen != null)
            {
                phanQuyen.CoQuyen = coQuyen;
                qlch.SubmitChanges();
            }
        }

        public void AddPhanQuyen(string maNhomNguoiDung, string maManHinh, bool coQuyen)
        {
            QL_PhanQuyen phanQuyen = new QL_PhanQuyen
            {
                MaNhomNguoiDung = maNhomNguoiDung,
                MaManHinh = maManHinh,
                CoQuyen = coQuyen
            };

            qlch.QL_PhanQuyens.InsertOnSubmit(phanQuyen);
            qlch.SubmitChanges();
        }

        public List<string> GetMaNhomNguoiDung(string pMaNV)
        {
                var nhomNguoiDungs = qlch.QL_NguoiDungNhomNguoiDungs
                                            .Where(nd => nd.MaNV == pMaNV)
                                            .Select(nd => nd.MaNhomNguoiDung)
                                            .ToList();
                return nhomNguoiDungs;
        }

        public List<QL_PhanQuyen> GetMaManHinh(string pMaNhom)
        {
            // Truy vấn dữ liệu từ cơ sở dữ liệu
            var quyenManHinhEntities = qlch.QL_PhanQuyens
                                           .Where(pq => pq.MaNhomNguoiDung == pMaNhom)
                                           .ToList(); // Lấy dữ liệu dưới dạng danh sách thực thể

            // Chuyển đổi danh sách thực thể thành danh sách DTO
            var quyenManHinhDTOs = quyenManHinhEntities
                                    .Select(pq => new QL_PhanQuyen
                                    {
                                        MaManHinh = pq.MaManHinh,
                                        CoQuyen = pq.CoQuyen
                                    })
                                    .ToList();

            return quyenManHinhDTOs;
        }

//XepLich

        public List<NhanVienWithChucVu> LoadNhanVienWithChucVu()
        {
            var result = from nv in qlch.NhanViens
                         join qlnd in qlch.QL_NguoiDungNhomNguoiDungs
                         on nv.MaNV equals qlnd.MaNV into nvNhom
                         from qlnd in nvNhom.DefaultIfEmpty()
                         join nhom in qlch.QL_NhomNguoiDungs
                         on qlnd.MaNhomNguoiDung equals nhom.MaNhom into nhomGroup
                         from nhom in nhomGroup.DefaultIfEmpty()
                         select new NhanVienWithChucVu
                         {
                             MaNV = nv.MaNV,
                             TenNV = nv.TenNV,
                             GioiTinh = nv.GioiTinh,
                             NgaySinh = Convert.ToDateTime(nv.NgaySinh),
                             DiaChi = nv.DiaChi,
                             SDT = nv.SDT,
                             MatKhau = nv.MatKhau,
                             TenNhom = nhom != null ? nhom.TenNhom : "Chưa phân nhóm"
                         };

            return result.ToList<NhanVienWithChucVu>();
        }

        public List<NhanVien> GetNhanVienByNhom(string maNhom)
        {
            var result = from nv in qlch.NhanViens
                         join qlnd in qlch.QL_NguoiDungNhomNguoiDungs
                         on nv.MaNV equals qlnd.MaNV
                         where qlnd.MaNhomNguoiDung == maNhom
                         select nv;

            return result.ToList < NhanVien>();
        }

    }
}
