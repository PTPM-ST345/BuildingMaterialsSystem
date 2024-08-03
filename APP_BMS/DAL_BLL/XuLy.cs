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

        public int DangNhap(string tendn, string mk)
        {
            var nhanVien = qlch.NhanViens.FirstOrDefault(nv => nv.TenDangNhap == tendn && nv.MatKhau == mk);
            return nhanVien != null ? 1 : 0;
        }

        public List<NhanVien> LoadNhanVien()
        {
            return qlch.NhanViens.Select(nv => nv).ToList<NhanVien>();
        }

        public List<KhachHang> LoadKhachHang()
        {
            return qlch.KhachHangs.Select(kh => kh).ToList<KhachHang>();
        }

        public List<NhaCungCap> LoadNhaCungCap()
        {
            return qlch.NhaCungCaps.Select(ncc => ncc).ToList<NhaCungCap>();
        }

        public List<DanhMucSanPham> LoadLoaiHang()
        {
            return qlch.DanhMucSanPhams.Select(dmsp => dmsp).ToList<DanhMucSanPham>();
        }

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
