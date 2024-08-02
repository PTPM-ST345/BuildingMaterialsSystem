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

    }
}
