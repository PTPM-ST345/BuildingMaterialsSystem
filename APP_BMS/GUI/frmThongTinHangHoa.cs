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
    public partial class frmThongTinHangHoa : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();

        public frmThongTinHangHoa()
        {
            InitializeComponent();
            this.Load += frmThongTinHangHoa_Load;

            dgvHangHoa.CellClick += dgvHangHoa_CellClick;
            textBox5.TextChanged += textBox5_TextChanged;
        }

        //TimKiem
        void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text;
            bool timKiemTheoMaHH = radioButton1.Checked;

            List<HangHoa> ketQuaTimKiem = xl.TimKiemHangHoa(keyword, timKiemTheoMaHH);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHH");
            dt.Columns.Add("TenHangHoa");
            dt.Columns.Add("DonVi");
            dt.Columns.Add("SoLuongTon");
            dt.Columns.Add("HinhAnh");
            dt.Columns.Add("GiaBan");
            dt.Columns.Add("MaLoai");
            dt.Columns.Add("MaNCC");

            foreach (var hh in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaHH"] = hh.MaHH;
                dr["TenHangHoa"] = hh.TenHangHoa;
                dr["DonVi"] = hh.DonVi;
                dr["SoLuongTon"] = hh.SoLuongTon;
                dr["HinhAnh"] = hh.HinhAnh;
                dr["GiaBan"] = hh.GiaBan;
                dr["MaLoai"] = hh.MaLoai;
                dr["MaNCC"] = hh.MaNCC;
                dt.Rows.Add(dr);
            }

            dgvHangHoa.DataSource = dt;
        }

        //DataBinding
        void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];

                txtMaHH.Text = row.Cells["MaHH"].Value.ToString();
                txtTenHH.Text = row.Cells["TenHangHoa"].Value.ToString();
                txtDonViTinh.Text = row.Cells["DonVi"].Value.ToString();
                txtSoLuongTon.Text = row.Cells["SoLuongTon"].Value.ToString();
                cboLoai.SelectedValue = row.Cells["MaLoai"].Value.ToString();
                cboNCC.SelectedValue = row.Cells["MaNCC"].Value.ToString();
                txtGiaBan.Text = row.Cells["GiaBan"].Value.ToString();
                txtHinhAnh.Text = row.Cells["HinhAnh"].Value.ToString();
            }
        }

        //Load
        void frmThongTinHangHoa_Load(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = xl.LoadHangHoa();

            dgvHangHoa.Columns["Loai"].Visible = false;
            dgvHangHoa.Columns["NhaCungCap"].Visible = false;

            cboLoai.DataSource = xl.LoadLoaiHang();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboNCC.DataSource = xl.LoadNhaCungCap();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";

            txtMaHH.Enabled = false;
            txtTenHH.Enabled = false;
            txtDonViTinh.Enabled = false;
            txtSoLuongTon.Enabled = false;
            cboLoai.Enabled = false;
            cboNCC.Enabled = false;
            txtGiaBan.Enabled = false;
            txtHinhAnh.Enabled = false;

            radioButton1.Checked = true;
            button5.Enabled = false;  
        }

        //Them
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //Xoa
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Sua
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //LamMoi
        private void button11_Click(object sender, EventArgs e)
        {

        }

        //Luu
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
