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

        public List<NhaCungCap> LoadNhaCungCap()
        {
            return qlch.NhaCungCaps.Select(ncc => ncc).ToList<NhaCungCap>();
        }

//LoaiHang
        public List<Loai> LoadLoaiHang()
        {
            return qlch.Loais.Select(dmsp => dmsp).ToList<Loai>();
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
