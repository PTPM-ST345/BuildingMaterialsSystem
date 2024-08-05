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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhapHang.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MaDonNhapHang"].Value.ToString();
                dateTimePicker1.Text = row.Cells["NgayNhap"].Value.ToString();
                comboBox1.SelectedValue = row.Cells["MaNV"].Value.ToString();                
            }
        }

        //FormLoad
        void frmNhapHang_Load(object sender, EventArgs e)
        {
            dgvNhapHang.DataSource = xl.LoadDonNhapHang();
            dgvNhapHang.Columns["MaDonNhapHang"].HeaderText = "Mã đơn nhập hàng";
            dgvNhapHang.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            dgvNhapHang.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dgvNhapHang.ClearSelection();
            dgvNhapHang.Columns["NhanVien"].Visible = false;

            comboBox1.DataSource = xl.LoadNhanVien();
            comboBox1.DisplayMember = "TenNV";
            comboBox1.ValueMember = "MaNV";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            
            radioButton1.Checked = true;
            button8.Enabled = false; 
        }

        //Thêm
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";

            textBox1.Focus();
            button8.Enabled = true;
            isAddingNew = true;
        }

        //Xóa
        private void button10_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maDNHToDelete = textBox1.Text;

            int count = xl.DemSoCTDNHTheoMaDNH(maDNHToDelete);

            if (count > 0)
            {
                MessageBox.Show("Đơn nhập hàng đang tồn tại trong chi tiết đơn nhập hàng. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của đơn nhập hàng có mã là " + maDNHToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaDNH(maDNHToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Text = "";
                        dateTimePicker1.Text = "";
                        comboBox1.Text = "";
                        dgvNhapHang.DataSource = xl.LoadDonNhapHang();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Sửa
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;

            textBox1.Focus();
            button8.Enabled = true;

            isAddingNew = false;
        }

        //Làm mới
        private void button11_Click(object sender, EventArgs e)
        {
            dgvNhapHang.DataSource = xl.LoadDonNhapHang();
            textBox1.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            textBox1.Focus();
        }

        //Lưu
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã đơn nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaDNHDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã đơn nhập hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                isSuccessful = xl.ThemDNH(textBox1.Text, Convert.ToDateTime(dateTimePicker1.Text), comboBox1.SelectedValue.ToString());
            }
            else
            {
                isSuccessful = xl.CapNhatDNH(textBox1.Text, Convert.ToDateTime(dateTimePicker1.Text), comboBox1.SelectedValue.ToString());
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button8.Enabled = false;
                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dgvNhapHang.DataSource = xl.LoadDonNhapHang();
        }

        //ChiTietNhapHang
        private void button7_Click(object sender, EventArgs e)  
        {
            if (dgvNhapHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một đơn nhập hàng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string maDonNhapHang = textBox1.Text;
                string tenNhanVien = comboBox1.Text;
                DateTime ngayNhap = dateTimePicker1.Value;

                frmChiTietDonNhapHang ctForm = new frmChiTietDonNhapHang(maDonNhapHang, tenNhanVien, ngayNhap);
                // Hiển thị form CT_HoaDonNhap
                ctForm.Show();
            }
        }

    }
}
