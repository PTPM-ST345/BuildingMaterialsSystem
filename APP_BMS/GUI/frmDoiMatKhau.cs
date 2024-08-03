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

namespace GUI
{
    public partial class frmDoiMatKhau : Form
    {
        XuLy xl = new XuLy();
        public frmDoiMatKhau()
        {
            InitializeComponent();
            this.FormClosing += frmDoiMatKhau_FormClosing;
            this.Load += frmDoiMatKhau_Load;
        }

        void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            lbl_manv.Text = Properties.Settings.Default.username;
        }

        void frmDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = lbl_manv.Text;
                string matKhauCu = txt_mkcu.Text;
                string matKhauMoi = txt_mkmoi.Text;
                string nhapLaiMatKhau = txt_retypepass.Text;

                int result = xl.CapNhatMatKhau_1NV(maNV, matKhauCu, matKhauMoi, nhapLaiMatKhau);
                if (result > 0)
                {
                    MessageBox.Show("Cập Nhật Mật Khẩu Thành Công", "Thành Công", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập Nhật Mật Khẩu Không Thành Công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
