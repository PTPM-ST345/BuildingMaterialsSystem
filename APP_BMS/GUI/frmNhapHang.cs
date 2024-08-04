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
    public partial class frmNhapHang : Form
    {

        private bool isAddingNew = false;
        XuLy xl = new XuLy();
        public frmNhapHang()
        {
            InitializeComponent();
            this.Load += frmNhapHang_Load;
            dgvNhapHang.CellClick += dgvNhapHang_CellClick;
            textBox5.TextChanged += textBox5_TextChanged;
        }
        //TimKiem
        void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text;
            bool timKiemTheoMaDNH = radioButton1.Checked;

            List<DonNhapHang> ketQuaTimKiem = xl.TimKiemDonNhapHang(keyword, timKiemTheoMaDNH);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDonNhapHang");
            dt.Columns.Add("NgayNhap");
            dt.Columns.Add("MaNV");

            foreach (var dnh in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaDonNhapHang"] = dnh.MaDonNhapHang;
                dr["NgayNhap"] = dnh.NgayNhap;
                dr["MaNV"] = dnh.MaNV;
                dt.Rows.Add(dr);
            }

            dgvNhapHang.DataSource = dt;
        }

        //DataBinding
        void dgvNhapHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //FormLoad
        void frmNhapHang_Load(object sender, EventArgs e)
        {
            dgvNhapHang.DataSource = xl.LoadDonNhapHang();
            dgvNhapHang.Columns["MaDonNhapHang"].HeaderText = "Mã đơn nhập hàng";
            dgvNhapHang.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvNhapHang.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

            dgvNhapHang.Columns["NhanVien"].Visible = false;

            comboBox1.DataSource = xl.LoadNhanVien();
            comboBox1.DisplayMember = "TenNV";
            comboBox1.ValueMember = "MaNV";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //Thêm
        private void button12_Click(object sender, EventArgs e)
        {

        }

        //Xóa
        private void button10_Click(object sender, EventArgs e)
        {

        }

        //Sửa
        private void button9_Click(object sender, EventArgs e)
        {

        }

        //Làm mới
        private void button11_Click(object sender, EventArgs e)
        {

        }

        //Lưu
        private void button8_Click(object sender, EventArgs e)
        {

        }

        //ChiTietNhapHang
        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvNhapHang.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string soHoaDonNhap = textBox1.Text;
                string tenNhanVien = comboBox1.Text;
                DateTime ngayNhap = dateTimePicker1.Value;

                frmChiTietDonNhapHang ctForm = new frmChiTietDonNhapHang();

                // Hiển thị form CT_HoaDonNhap
                ctForm.Show();
            }
        }
    }
}
