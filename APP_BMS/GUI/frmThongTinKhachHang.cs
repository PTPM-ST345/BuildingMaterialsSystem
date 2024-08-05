using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL_BLL;

namespace GUI
{
    public partial class frmThongTinKhachHang : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();
        public frmThongTinKhachHang()
        {
            InitializeComponent();
            this.Load += frmThongTinKhachHang_Load;
            textBox6.TextChanged += textBox6_TextChanged;
            dgvDSKH.CellClick += dgvDSKH_CellClick;
        }

        //TimKiem
        void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox6.Text;
            bool timKiemTheoMaKH = radioButton1.Checked;

            List<KhachHang> ketQuaTimKiem = xl.TimKiemKH(keyword, timKiemTheoMaKH);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaKH");
            dt.Columns.Add("HoTen");
            dt.Columns.Add("NgaySinh");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("DienThoai");
            dt.Columns.Add("TaiKhoan");
            dt.Columns.Add("MatKhau");
            dt.Columns.Add("Email");
            dt.Columns.Add("DiaChi");

            foreach (var nv in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaKH"] = nv.MaKH;
                dr["HoTen"] = nv.HoTen;
                dr["NgaySinh"] = nv.NgaySinh;
                dr["GioiTinh"] = nv.GioiTinh;
                dr["DienThoai"] = nv.DienThoai;
                dr["TaiKhoan"] = nv.TaiKhoan;
                dr["MatKhau"] = nv.MatKhau;
                dr["Email"] = nv.Email;
                dr["DiaChi"] = nv.DiaChi;
                dt.Rows.Add(dr);
            }

            dgvDSKH.DataSource = dt;
        }

        //FormLoad
        void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;
            txtTK.Enabled = false;
            txtMK.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            button5.Enabled = false;

            radioButton1.Checked = true;

            dgvDSKH.DataSource =  xl.LoadKhachHang();
            dgvDSKH.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dgvDSKH.Columns["HoTen"].HeaderText = "Tên khách hàng";
            dgvDSKH.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDSKH.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDSKH.Columns["DienThoai"].HeaderText = "Số điện thoại";
            dgvDSKH.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvDSKH.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgvDSKH.Columns["Email"].HeaderText = "Email";
            dgvDSKH.Columns["DiaChi"].HeaderText = "Địa chỉ";

            comboBox1.DataSource = xl.LoadGioiTinh_KH();
        }

        //Databinding
        void dgvDSKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDSKH.Rows[e.RowIndex];

                txtMaKH.Text = row.Cells["MaKH"].Value.ToString();
                txtTenKH.Text = row.Cells["HoTen"].Value.ToString();
                dateTimePicker1.Text = row.Cells["NgaySinh"].Value.ToString();
                comboBox1.Text = row.Cells["GioiTinh"].Value.ToString();
                txtSDT.Text = row.Cells["DienThoai"].Value.ToString();
                txtTK.Text = row.Cells["TaiKhoan"].Value.ToString();
                txtMK.Text = row.Cells["MatKhau"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            }
        }

        //Them
        private void button1_Click(object sender, EventArgs e)
        {
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSDT.Enabled = true;
            txtTK.Enabled = true;
            txtMK.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;

            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtTK.Text = "";
            txtMK.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";

            txtMaKH.Focus();
            button5.Enabled = true;
            isAddingNew = true;
        }

        //Xoa
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maKHToDelete = txtMaKH.Text;
            string tenKH = txtTenKH.Text;

            int count = xl.DemSoDonBanHangTheoMaKH(maKHToDelete);

            if (count > 0)
            {
                MessageBox.Show("Khách hàng này đang có đơn mua hàng. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của khách hàng " + tenKH + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaKhachHang(maKHToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtMaKH.Text = "";
                        txtTenKH.Text = "";
                        txtSDT.Text = "";
                        txtTK.Text = "";
                        txtMK.Text = "";
                        txtEmail.Text = "";
                        txtDiaChi.Text = "";
                        dgvDSKH.DataSource = xl.LoadKhachHang();
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
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSDT.Enabled = true;
            txtTK.Enabled = true;
            txtMK.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            txtMaKH.Focus();

            button5.Enabled = true;
            isAddingNew = false;
        }

        //LamMoi
        private void button11_Click(object sender, EventArgs e)
        {
            dgvDSKH.DataSource = xl.LoadKhachHang();
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDT.Text = "";
            txtTK.Text = "";
            txtMK.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtMaKH.Focus();
        }

        //Luu
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaKH.Focus();
                return;
            }
            if (txtTenKH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenKH.Focus();
                return;
            }
            if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtTK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTK.Focus();
                return;
            }
            if (txtMK.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMK.Focus();
                return;
            }

            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaKHDuplicated(txtMaKH.Text))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaKH.Text = "";
                    txtMaKH.Focus();
                    return;
                }
                isSuccessful = xl.ThemKhachHang(txtMaKH.Text,txtTenKH.Text, Convert.ToDateTime(dateTimePicker1.Text),comboBox1.SelectedValue.ToString(),txtSDT.Text,txtTK.Text,txtMK.Text,txtEmail.Text,txtDiaChi.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatKhachHang(txtMaKH.Text, txtTenKH.Text, Convert.ToDateTime(dateTimePicker1.Text), comboBox1.SelectedValue.ToString(), txtSDT.Text, txtTK.Text, txtMK.Text, txtEmail.Text, txtDiaChi.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtSDT.Enabled = false;
                txtTK.Enabled = false;
                txtMK.Enabled = false;
                txtEmail.Enabled = false;
                txtDiaChi.Enabled = false;
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
                button5.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã KH không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dgvDSKH.DataSource = xl.LoadKhachHang();
        }

    }
}
