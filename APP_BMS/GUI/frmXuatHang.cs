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
    public partial class frmXuatHang : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();
        public frmXuatHang()
        {    
            InitializeComponent();
            this.Load += frmXuatHang_Load;
            dgvXuatHang.CellClick += dgvXuatHang_CellClick;
            textBox5.TextChanged += textBox5_TextChanged;
        }

        //TimKiem
        void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text;
            bool timKiemTheoMaDBH = radioButton1.Checked;

            List<DonBanHang> ketQuaTimKiem = xl.TimKiemDonBanHang(keyword, timKiemTheoMaDBH);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaDonBanHang");
            dt.Columns.Add("NgayDat");
            dt.Columns.Add("NgayGiao");
            dt.Columns.Add("NgayThanhToan");
            dt.Columns.Add("MaKH");

            foreach (var dnh in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaDonBanHang"] = dnh.MaDonBanHang;
                dr["NgayDat"] = dnh.NgayDat;
                dr["NgayGiao"] = dnh.NgayGiao;
                dr["NgayThanhToan"] = dnh.NgayThanhToan;
                dr["MaKH"] = dnh.MaKH;
                dt.Rows.Add(dr);
            }

            dgvXuatHang.DataSource = dt;
        }

        //DataBinding
        void dgvXuatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvXuatHang.Rows[e.RowIndex];

                txtMaDonBan.Text = row.Cells["MaDonBanHang"].Value.ToString();
                ngaydat.Text = row.Cells["NgayDat"].Value.ToString();
                ngaygiao.Text = row.Cells["NgayGiao"].Value.ToString();
                ngaythanhtoan.Text = row.Cells["NgayThanhToan"].Value.ToString();
                cboKhachHang.SelectedValue = row.Cells["MaKH"].Value.ToString();
            }
        }

        //FormLoad
        void frmXuatHang_Load(object sender, EventArgs e)
        {
            dgvXuatHang.DataSource = xl.LoadDonBanHang();
            dgvXuatHang.Columns["MaDonBanHang"].HeaderText = "Mã đơn bán hàng";
            dgvXuatHang.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dgvXuatHang.Columns["NgayGiao"].HeaderText = "Ngày giao";
            dgvXuatHang.Columns["NgayThanhToan"].HeaderText = "Ngày thanh toán";
            dgvXuatHang.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvXuatHang.ClearSelection();
            dgvXuatHang.Columns["KhachHang"].Visible = false;

            cboKhachHang.DataSource = xl.LoadKhachHang();
            cboKhachHang.DisplayMember = "HoTen";
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;

            txtMaDonBan.Enabled = false;
            ngaydat.Enabled = false;
            ngaygiao.Enabled = false;
            ngaythanhtoan.Enabled = false;
            cboKhachHang.Enabled = false;

            radioButton1.Checked = true;
            button8.Enabled = false; 
        }

        //Them
        private void button12_Click(object sender, EventArgs e)
        {
            txtMaDonBan.Enabled = true;
            ngaydat.Enabled = true;
            ngaygiao.Enabled = true;
            ngaythanhtoan.Enabled = true;
            cboKhachHang.Enabled = true;
            txtMaDonBan.Text = "";
            ngaydat.Text = "";
            ngaygiao.Text = "";
            ngaythanhtoan.Text = "";
            cboKhachHang.Text = "";

            txtMaDonBan.Focus();
            button8.Enabled = true;
            isAddingNew = true;
        }

        //Xoa
        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDonBan.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maDBHToDelete = txtMaDonBan.Text;

            int count = xl.DemSoCTDBHTheoMaDBH(maDBHToDelete);

            if (count > 0)
            {
                MessageBox.Show("Đơn bán hàng đang tồn tại trong chi tiết đơn bán hàng. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của đơn bán hàng có mã là " + maDBHToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaDBH(maDBHToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMaDonBan.Text = "";
                        ngaydat.Text = "";
                        ngaygiao.Text = "";
                        ngaythanhtoan.Text = "";
                        cboKhachHang.Text = "";
                        dgvXuatHang.DataSource = xl.LoadDonBanHang();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Sua
        private void button9_Click(object sender, EventArgs e)
        {
            txtMaDonBan.Enabled = true;
            ngaydat.Enabled = true;
            ngaygiao.Enabled = true;
            ngaythanhtoan.Enabled = true;
            cboKhachHang.Enabled = true;

            txtMaDonBan.Focus();
            button8.Enabled = true;
            isAddingNew = false;
        }

        //LamMoi
        private void button11_Click(object sender, EventArgs e)
        {
            dgvXuatHang.DataSource = xl.LoadDonBanHang();
            txtMaDonBan.Text = "";
            ngaydat.Text = "";
            ngaygiao.Text = "";
            ngaythanhtoan.Text = "";
            cboKhachHang.Text = "";
            txtMaDonBan.Focus();
        }

        //Luu
        private void button8_Click(object sender, EventArgs e)
        {
            if (txtMaDonBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã đơn bán hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDonBan.Focus();
                return;
            }
            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaDBHDuplicated(txtMaDonBan.Text))
                {
                    MessageBox.Show("Mã đơn bán hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaDonBan.Text = "";
                    txtMaDonBan.Focus();
                    return;
                }
                isSuccessful = xl.ThemDBH(txtMaDonBan.Text, Convert.ToDateTime(ngaydat.Text), Convert.ToDateTime(ngaygiao.Text), Convert.ToDateTime(ngaythanhtoan.Text), cboKhachHang.SelectedValue.ToString());
            }
            else
            {
                isSuccessful = xl.CapNhatDBH(txtMaDonBan.Text, Convert.ToDateTime(ngaydat.Text), Convert.ToDateTime(ngaygiao.Text), Convert.ToDateTime(ngaythanhtoan.Text), cboKhachHang.SelectedValue.ToString());
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button8.Enabled = false;

                txtMaDonBan.Enabled = false;
                ngaydat.Enabled = false;
                ngaygiao.Enabled = false;
                ngaythanhtoan.Enabled = false;
                cboKhachHang.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dgvXuatHang.DataSource = xl.LoadDonBanHang();
        }

        //XemChiTiet
        private void button7_Click(object sender, EventArgs e)
        {
            if (dgvXuatHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn bán hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string maDonBanHang = txtMaDonBan.Text;
                string tenKhachHang = cboKhachHang.Text;
                DateTime ngayDat = ngaydat.Value;

                frmChiTietDonBanHang ctForm = new frmChiTietDonBanHang(maDonBanHang, tenKhachHang, ngayDat);
                ctForm.Show();
            }
        }
    }
}
