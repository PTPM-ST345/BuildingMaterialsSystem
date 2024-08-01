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

        public List<HangHoa> LoadHangHoa()
        {
            return qlch.HangHoas.Select(hh => hh).ToList<HangHoa>();
        }
    }
}
