using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DTO;
namespace GUI
{
    public partial class frmThongTinTaiKhoan : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinTaiKhoan()
        {
            InitializeComponent();
            this.Load += frmThongTinTaiKhoan_Load;
        }


        void frmThongTinTaiKhoan_Load(object sender, EventArgs e)
        {

            lb_manv.Text = Properties.Settings.Default.username;
            uplabel();
        }

        public void uplabel()
        {
            var nhanVien = xl.ChiTietNhanVien(lb_manv.Text);
            if (nhanVien != null)
            {
                lb_ten.Text = nhanVien.TenNV;
                lb_sdth.Text = nhanVien.SDT;
                lb_diachi.Text = nhanVien.DiaChi;
                lb_gioitinh.Text = nhanVien.GioiTinh;
                lb_ns.Text = nhanVien.NgaySinh.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau formdmk = new frmDoiMatKhau();
            formdmk.ShowDialog();
        }
    }
}
