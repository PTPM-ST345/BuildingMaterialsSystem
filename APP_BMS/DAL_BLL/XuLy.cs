using System;
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
        public List<NhanVien> LoadNhanVien()
        {
            return qlch.NhanViens.Select(nv => nv).ToList<NhanVien>();
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


//KhachHang
        public List<KhachHang> LoadKhachHang()
        {
            return qlch.KhachHangs.Select(kh => kh).ToList<KhachHang>();
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

//DonNhapHang
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

            dnh.MaDonNhapHang = maDNH;
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

//Nhom Nguoi Dung
        public List<QL_NhomNguoiDung> LoadNhomNguoiDung()
        {
            return qlch.QL_NhomNguoiDungs.Select(dnh => dnh).ToList<QL_NhomNguoiDung>();
        }

//Man Hinh
        public List<DM_ManHinh> LoadDanhMucManHinh()
        {
            return qlch.DM_ManHinhs.Select(dnh => dnh).ToList<DM_ManHinh>();
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
    }
}
