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
        private bool isAddingNew = false;
        XuLy xl = new XuLy();

        public frmThongTinNhanVien()
        {
            InitializeComponent();
            this.Load += frmThongTinNhanVien_Load;
            dvgDSNhanVien.CellClick += dvgDSNhanVien_CellClick;
            textBox6.TextChanged += textBox6_TextChanged;
        }

        //TimKiem
        void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox6.Text;
            bool timKiemTheoMaNV = radioButton1.Checked;

            List<NhanVien> ketQuaTimKiem = xl.TimKiemNhanVien(keyword, timKiemTheoMaNV);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNV");
            dt.Columns.Add("TenNV");
            dt.Columns.Add("GioiTinh");
            dt.Columns.Add("NgaySinh");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("SDT");
            dt.Columns.Add("ChucVu");
            dt.Columns.Add("MatKhau");

            foreach (var nv in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaNV"] = nv.MaNV;
                dr["TenNV"] = nv.TenNV;
                dr["GioiTinh"] = nv.GioiTinh;
                dr["NgaySinh"] = nv.NgaySinh;
                dr["DiaChi"] = nv.DiaChi;
                dr["SDT"] = nv.SDT;
                dr["ChucVu"] = nv.ChucVu;
                dr["MatKhau"] = nv.MatKhau;
                dt.Rows.Add(dr);
            }

            dvgDSNhanVien.DataSource = dt;
        }

        //Load
        void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            comboBox1.Enabled = false;
            button5.Enabled = false;
            dateTimePicker1.Enabled = false;

            dvgDSNhanVien.DataSource = xl.LoadNhanVien();
            dvgDSNhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dvgDSNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
            dvgDSNhanVien.Columns["SDT"].HeaderText = "Số điện thoại";
            dvgDSNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
            dvgDSNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dvgDSNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dvgDSNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh"; 
            dvgDSNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";

            comboBox1.DataSource = xl.LoadGioiTinh();
        }

        //DataBinding
        private void dvgDSNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dvgDSNhanVien.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MaNV"].Value.ToString();
                textBox2.Text = row.Cells["TenNV"].Value.ToString();
                textBox4.Text = row.Cells["SDT"].Value.ToString();
                textBox5.Text = row.Cells["ChucVu"].Value.ToString();
                textBox3.Text = row.Cells["DiaChi"].Value.ToString();
                comboBox1.Text = row.Cells["GioiTinh"].Value.ToString();
                dateTimePicker1.Text = row.Cells["NgaySinh"].Value.ToString();
                textBox7.Text = row.Cells["MatKhau"].Value.ToString();
            }
        }

        //Them
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox1.Focus();
            button5.Enabled = true;
            isAddingNew = true;
        }

        //Xoa
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNVToDelete = textBox1.Text;
            string tenNV= textBox2.Text;

            int count = xl.DemSoDonNhapHangTheoMaNV(maNVToDelete);

            if (count > 0)
            {
                MessageBox.Show("Nhân viên này đang có đơn nhập hàng. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của nhân viên  " + tenNV + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaNhanVien(maNVToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox7.Text = "";
                        dvgDSNhanVien.DataSource = xl.LoadNhanVien();
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
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox7.Enabled = true;
            dateTimePicker1.Enabled = true;
            comboBox1.Enabled = true;
            textBox1.Focus();

            button5.Enabled = true;
            isAddingNew = false;
        }

        //LamMoi
        private void button11_Click(object sender, EventArgs e)
        {
            dvgDSNhanVien.DataSource = xl.LoadNhanVien();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox1.Focus();
        }

        //Luu
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đia chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (textBox5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (textBox7.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }

            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaNVDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                isSuccessful = xl.ThemNhanVien(textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString(),Convert.ToDateTime(dateTimePicker1.Text),textBox3.Text,textBox4.Text,textBox5.Text,textBox7.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatNhanVien(textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString(), Convert.ToDateTime(dateTimePicker1.Text), textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox7.Enabled = false;
                comboBox1.Enabled = false;
                button5.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dvgDSNhanVien.DataSource = xl.LoadNhanVien();
        }
    }
}
