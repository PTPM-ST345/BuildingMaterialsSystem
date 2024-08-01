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
    public partial class DangNhap : Form
    {
        XuLy xl = new XuLy();
        public DangNhap()
        {
            InitializeComponent();
            this.btnDangNhap.Click += btnDangNhap_Click;
            this.FormClosing += DangNhap_FormClosing;
            this.Load += DangNhap_Load;
            this.txtTenDN.TextChanged += txtTenDN_TextChanged;
        }

        void txtTenDN_TextChanged(object sender, EventArgs e)
        {
           
        }

        void DangNhap_Load(object sender, EventArgs e)
        {
            txtTenDN.Focus();
            txtTenDN.Clear();
            txtMatKhau.Clear();
        }

        void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ketqua;
            ketqua = MessageBox.Show("Bạn có đồng ý thoát ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ketqua == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(xl.DangNhap(txtTenDN.Text, txtMatKhau.Text) == 1)
            {
                this.Hide();
                frmTrangChu formtrangchu = new frmTrangChu();
                formtrangchu.Show();
            }
            else
            {
                MessageBox.Show("Mã Nhân Viên Hoặc Mật Khẩu Không Tồn Tại !!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
