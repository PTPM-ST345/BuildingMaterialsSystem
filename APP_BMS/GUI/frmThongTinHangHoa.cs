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
            dgvHangHoa.Columns["MaHH"].HeaderText = "Mã hàng hóa";
            dgvHangHoa.Columns["TenHangHoa"].HeaderText = "Tên hàng hóa";
            dgvHangHoa.Columns["DonVi"].HeaderText = "Đơn vị";
            dgvHangHoa.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dgvHangHoa.Columns["MaLoai"].HeaderText = "Mã loại";
            dgvHangHoa.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
            dgvHangHoa.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvHangHoa.Columns["HinhAnh"].HeaderText = "Hình ảnh";

            dgvHangHoa.Columns["STT"].Visible = false;
            dgvHangHoa.Columns["Loai"].Visible = false;
            dgvHangHoa.Columns["NhaCungCap"].Visible = false;

            cboLoai.DataSource = xl.LoadLoaiHang();
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboNCC.DataSource = xl.LoadNhaCungCap();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;

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
            txtMaHH.Enabled = true; 
            txtTenHH.Enabled = true; 
            txtDonViTinh.Enabled = true; 
            txtSoLuongTon.Enabled = true; 
            cboLoai.Enabled = true; 
            cboNCC.Enabled = true; 
            txtGiaBan.Enabled = true; 
            txtHinhAnh.Enabled = true; 
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtDonViTinh.Text = "";
            txtSoLuongTon.Text = "";
            cboLoai.Text = "";
            cboNCC.Text = "";
            txtGiaBan.Text = "";
            txtHinhAnh.Text = "";
            txtMaHH.Focus();
            button5.Enabled = true;
            isAddingNew = true;
        }

        //Xoa
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHH.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maHHToDelete = txtMaHH.Text;
            string tenHH = txtTenHH.Text;

            int count = xl.DemSoDonHangTheoMaHH(maHHToDelete);

            if (count > 0)
            {
                MessageBox.Show("Hàng hóa này đang thuộc đơn hàng nhập hoặc xuất. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của hàng hóa là " + tenHH + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaHangHoa(maHHToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMaHH.Text = "";
                        txtTenHH.Text = "";
                        txtDonViTinh.Text = "";
                        txtSoLuongTon.Text = "";
                        cboLoai.Text = "";
                        cboNCC.Text = "";
                        txtGiaBan.Text = "";
                        txtHinhAnh.Text = "";
                        dgvHangHoa.DataSource = xl.LoadHangHoa();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Sua
        private void button4_Click(object sender, EventArgs e)
        {
            txtMaHH.Enabled = true;
            txtTenHH.Enabled = true;
            txtDonViTinh.Enabled = true;
            txtSoLuongTon.Enabled = true;
            cboLoai.Enabled = true;
            cboNCC.Enabled = true;
            txtGiaBan.Enabled = true;
            txtHinhAnh.Enabled = true;

            txtMaHH.Focus();
            button5.Enabled = true;

            isAddingNew = false;
        }

        //LamMoi
        private void button11_Click(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = xl.LoadHangHoa();
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtDonViTinh.Text = "";
            txtSoLuongTon.Text = "";
            cboLoai.Text = "";
            cboNCC.Text = "";
            txtGiaBan.Text = "";
            txtHinhAnh.Text = "";
            txtMaHH.Focus();
        }

        //Luu
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaHH.Focus();
                return;
            }
            if (txtTenHH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenHH.Focus();
                return;
            }
            if (txtDonViTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn vị tính hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonViTinh.Focus();
                return;
            }
            if (txtSoLuongTon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng tồn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongTon.Focus();
                return;
            }
            if (txtGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá bán cho hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaBan.Focus();
                return;
            }
            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaHHDuplicated(txtMaHH.Text))
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHH.Text = "";
                    txtMaHH.Focus();
                    return;
                }
                isSuccessful = xl.ThemHangHoa(txtMaHH.Text, txtTenHH.Text, txtDonViTinh.Text,Convert.ToInt32(txtSoLuongTon.Text), cboLoai.SelectedValue.ToString(),cboNCC.SelectedValue.ToString(),Convert.ToInt32(txtGiaBan.Text),txtHinhAnh.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatHangHoa(txtMaHH.Text, txtTenHH.Text, txtDonViTinh.Text, Convert.ToInt32(txtSoLuongTon.Text), cboLoai.SelectedValue.ToString(), cboNCC.SelectedValue.ToString(), Convert.ToInt32(txtGiaBan.Text), txtHinhAnh.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button5.Enabled = false;
                txtMaHH.Enabled = false;
                txtTenHH.Enabled = false;
                txtDonViTinh.Enabled = false;
                txtSoLuongTon.Enabled = false;
                cboLoai.Enabled = false;
                cboNCC.Enabled = false;
                txtGiaBan.Enabled = false;
                txtHinhAnh.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dgvHangHoa.DataSource = xl.LoadHangHoa();
        }
    }
}
