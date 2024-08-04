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
//###########---NhaCungCap---###########
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

        

//###########---HangHoa---###########
        public List<HangHoa> LoadHangHoa()
        {
            return qlch.HangHoas.Select(hh => hh).ToList<HangHoa>();
        }

        public List<DonNhapHang> LoadDonNhapHang()
        {
            return qlch.DonNhapHangs.Select(dnh => dnh).ToList<DonNhapHang>();
        }

        public List<DonBanHang> LoadDonBanHang()
        {
            return qlch.DonBanHangs.Select(dnh => dnh).ToList<DonBanHang>();
        }
    }
}
