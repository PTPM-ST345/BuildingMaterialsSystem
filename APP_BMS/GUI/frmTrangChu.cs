using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
            this.FormClosing += frmTrangChu_FormClosing;
        }

        void frmTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý đăng xuất ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (ketqua == DialogResult.Yes)
                {
                    this.Hide();
                    DangNhap frmlogin = new DangNhap();
                    frmlogin.Show();
                }
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }

        private void btnTTTK_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinTaiKhoan formtttk = new frmThongTinTaiKhoan() { TopLevel = false, TopMost = true };
            formtttk.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formtttk);
            formtttk.Show();
        }

        private void btnTTNV_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinNhanVien formttnv = new frmThongTinNhanVien() { TopLevel = false, TopMost = true };
            formttnv.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formttnv);
            formttnv.Show();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            panel1.BackgroundImage = null;
            frmDoiMatKhau formdmk = new frmDoiMatKhau();
            formdmk.ShowDialog();
        }

        private void btnTTKH_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinKhachHang formttnv = new frmThongTinKhachHang() { TopLevel = false, TopMost = true };
            formttnv.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formttnv);
            formttnv.Show();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinNhaCungCap formncc = new frmThongTinNhaCungCap() { TopLevel = false, TopMost = true };
            formncc.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formncc);
            formncc.Show();
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinLoaiHang formlh = new frmThongTinLoaiHang() { TopLevel = false, TopMost = true };
            formlh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formlh);
            formlh.Show();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmThongTinHangHoa formhh = new frmThongTinHangHoa() { TopLevel = false, TopMost = true };
            formhh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formhh);
            formhh.Show();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmNhapHang formnh = new frmNhapHang() { TopLevel = false, TopMost = true };
            formnh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formnh);
            formnh.Show();
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmXuatHang formxh = new frmXuatHang() { TopLevel = false, TopMost = true };
            formxh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formxh);
            formxh.Show();
        }

        private void btnBaoCaoKho_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmBaoCaoKho formkho = new frmBaoCaoKho() { TopLevel = false, TopMost = true };
            formkho.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formkho);
            formkho.Show();
        }

        private void btnBaoCaoLoaiSanPham_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSLoaiHang formlh = new frmDSLoaiHang() { TopLevel = false, TopMost = true };
            formlh.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formlh);
            formlh.Show();
        }

        private void btnBaoCaoNCC_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.BackgroundImage = null;
            frmDSNhaCungCap formdsncc = new frmDSNhaCungCap() { TopLevel = false, TopMost = true };
            formdsncc.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(formdsncc);
            formdsncc.Show();
        }



    }
}
