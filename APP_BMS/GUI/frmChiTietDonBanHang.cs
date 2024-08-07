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
    public partial class frmChiTietDonBanHang : Form
    {
        private bool isAddingNew = false;
        private string maDonBanHang;
        private string tenKhachHang;
        private DateTime ngayDat;
        XuLy xl = new XuLy();

        public frmChiTietDonBanHang(string maDonBanHang,string  tenKhachHang,DateTime ngayDat)
        {
            InitializeComponent();

            this.maDonBanHang = maDonBanHang;
            this.tenKhachHang = tenKhachHang;
            this.ngayDat = ngayDat;

            this.Load += frmChiTietDonBanHang_Load;
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
        //databinding
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
        //formload
        void frmChiTietDonBanHang_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Text = maDonBanHang;
            textBox5.Text = tenKhachHang;
            dateTimePicker1.Value = ngayDat;

            dataGridView1.DataSource = xl.LoadCT_DonBanHang(maDonBanHang);
            dataGridView1.ClearSelection();
            dataGridView1.Columns["HangHoa"].Visible = false;
            dataGridView1.Columns["DonBanHang"].Visible = false;

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

            string maDBHToDelete = textBox1.Text;
            string maHHToDelete = comboBox1.SelectedValue.ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết của đơn hàng " + maDBHToDelete + " có mã hàng hóa " + maHHToDelete + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    xl.XoaCTDBH(maDBHToDelete, maHHToDelete);
                    MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    dataGridView1.DataSource = xl.LoadCT_DonBanHang(maDBHToDelete);
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
            dataGridView1.DataSource = xl.LoadCT_DonBanHang(maDonBanHang);
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

           

            int soLuongNhap = Convert.ToInt32(textBox3.Text);
            string maHangHoa = comboBox1.SelectedValue.ToString();
            int? soLuongTon = xl.GetSoLuongTon(maHangHoa);

            if (soLuongTon.HasValue && soLuongNhap > soLuongTon.Value)
            {
                MessageBox.Show("Số lượng chỉ còn " + soLuongTon.Value + " sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }
            bool isSuccessful = false;
            if (isAddingNew)
            {
                if (xl.IsCTDBHDuplicated(textBox1.Text, comboBox1.SelectedValue.ToString()))
                {
                    MessageBox.Show("Chi tiết đơn bán hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                isSuccessful = xl.ThemCT_DBH(textBox1.Text, comboBox1.SelectedValue.ToString(), Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox7.Text));
            }
            else
            {
                isSuccessful = xl.CapNhatCT_DBH(textBox1.Text, comboBox1.SelectedValue.ToString(), Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox7.Text));
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

            dataGridView1.DataSource = xl.LoadCT_DonBanHang(maDonBanHang);
        }
    }
}
