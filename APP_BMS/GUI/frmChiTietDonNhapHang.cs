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
    public partial class frmChiTietDonNhapHang : Form
    {
        private bool isAddingNew = false;
        private string maDonNhapHang;
        private string tenNhanVien;
        private DateTime ngayNhap;
        XuLy xl = new XuLy();

        public frmChiTietDonNhapHang(string maDonNhapHang, string tenNhanVien, DateTime ngayNhap)
        {
            InitializeComponent();

            this.maDonNhapHang = maDonNhapHang;
            this.tenNhanVien = tenNhanVien;
            this.ngayNhap = ngayNhap;

            this.Load += frmChiTietDonNhapHang_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
            textBox3.KeyPress += textBox3_KeyPress;
            textBox7.KeyPress += textBox7_KeyPress;
        }

        void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn kí tự nhập vào
                errorProvider1.SetError(textBox7, "Chỉ được nhập số.");
            }
            else
            {
                errorProvider1.SetError(textBox7, "");
            }
        }

        void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Chặn kí tự nhập vào
                errorProvider1.SetError(textBox3, "Chỉ được nhập số.");
            }
            else
            {
                errorProvider1.SetError(textBox3, "");
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox3.Text = row.Cells["SoLuong"].Value.ToString();
                textBox7.Text = row.Cells["DonGia"].Value.ToString();
                comboBox1.SelectedValue = row.Cells["MaHH"].Value.ToString();
            }
        }

        //Load
        void frmChiTietDonNhapHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Text = maDonNhapHang;
            textBox5.Text = tenNhanVien;
            dateTimePicker1.Value = ngayNhap;

            dataGridView1.DataSource = xl.LoadCT_DonNhapHang(maDonNhapHang);
            dataGridView1.ClearSelection();
            dataGridView1.Columns["HangHoa"].Visible = false;
            dataGridView1.Columns["DonNhapHang"].Visible = false;

            comboBox1.DataSource = xl.LoadHangHoa();
            comboBox1.DisplayMember = "TenHangHoa";
            comboBox1.ValueMember = "MaHH";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;

            comboBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox3.Enabled = false;
            button2.Enabled = false;
        }

        //Them
        private void button13_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            textBox7.Enabled = true;
            textBox3.Enabled = true;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox3.Text = "";
            comboBox1.Focus();

            button2.Enabled = true;
            isAddingNew = true;
        }

        //Xoa
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maDNHToDelete = textBox1.Text;
            string maHHToDelete = comboBox1.SelectedValue.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết của đơn hàng " + maDNHToDelete + " có mã hàng hóa " + maHHToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    xl.XoaCTDNH(maDNHToDelete, maHHToDelete);
                    MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    dataGridView1.DataSource = xl.LoadCT_DonNhapHang(maDonNhapHang);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        //Sua
        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Enabled = true;
            textBox3.Enabled = true;

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox3.Text = "";
            comboBox1.Focus();

            button2.Enabled = true;
            isAddingNew = false;
        }

        //LamMoi
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadCT_DonNhapHang(maDonNhapHang);
            comboBox1.SelectedIndex = -1;
            textBox7.Text = "";
            textBox3.Text = "";

            dataGridView1.ClearSelection();
        }

        //Luu
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Bạn phải chọn hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }

            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox7.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }

            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsCTDNHDuplicated(textBox1.Text, comboBox1.SelectedValue.ToString()))
                {
                    MessageBox.Show("Chi tiết đơn nhập hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                isSuccessful = xl.ThemCT_DNH(textBox1.Text, comboBox1.SelectedValue.ToString(), Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox7.Text));
            }
            else
            {
                isSuccessful = xl.CapNhatCT_DNH(textBox1.Text, comboBox1.SelectedValue.ToString(), Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox7.Text));
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button2.Enabled = false;
                comboBox1.Enabled = false;
                textBox7.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dataGridView1.DataSource = xl.LoadCT_DonNhapHang(maDonNhapHang);
        }


    }
}
