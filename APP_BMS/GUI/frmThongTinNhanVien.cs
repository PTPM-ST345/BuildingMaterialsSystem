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
    public partial class frmThongTinNhanVien : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            this.Load += frmThongTinNhanVien_Load;
            dvgDSNhanVien.CellClick += dvgDSNhanVien_CellClick;
        }

        void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = xl.LoadNhanVien();
            comboBox1.DisplayMember = "GioiTinh";
            comboBox1.ValueMember = "MaNV";

            dvgDSNhanVien.DataSource = xl.LoadNhanVien();

            dvgDSNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            dvgDSNhanVien.Columns["TenNV"].HeaderText = "Tên NV";
            dvgDSNhanVien.Columns["SDT"].HeaderText = "Số điện thoại";
            dvgDSNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
            dvgDSNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dvgDSNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dvgDSNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh"; 
            dvgDSNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
        }

        private void dvgDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dvgDSNhanVien.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MaNV"].Value.ToString();
                textBox2.Text = row.Cells["TenNV"].Value.ToString();
                //txtSDT.Text = row.Cells["SDT"].Value.ToString();
                //txtLoai.Text = row.Cells["Loai"].Value.ToString();
                //txtChucVu.Text = row.Cells["ChucVu"].Value.ToString();
                //txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                //txtGioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                //txtNgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                //txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }
    }
}
