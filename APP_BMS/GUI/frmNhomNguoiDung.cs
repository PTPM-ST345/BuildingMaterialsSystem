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
    public partial class frmNhomNguoiDung : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();

        public frmNhomNguoiDung()
        {

            InitializeComponent();
            this.Load += frmNhomNguoiDung_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                maNhomTextBox.Text = row.Cells["MaNhom"].Value.ToString();
                tenNhomTextBox.Text = row.Cells["TenNhom"].Value.ToString();
                ghiChuTextBox.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }

        void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadNhomNguoiDung();
            dataGridView1.Columns["MaNhom"].HeaderText = "Mã Nhóm";
            dataGridView1.Columns["TenNhom"].HeaderText = "Tên nhóm";
            dataGridView1.Columns["GhiChu"].HeaderText = "Ghi Chú";

            maNhomTextBox.Enabled = false;
            tenNhomTextBox.Enabled = false;
            ghiChuTextBox.Enabled = false;
            button7.Enabled = false;   
        }

        private void button13_Click(object sender, EventArgs e)
        {
            maNhomTextBox.Enabled = true;
            tenNhomTextBox.Enabled = true;
            ghiChuTextBox.Enabled = true;
            maNhomTextBox.Text = "";
            tenNhomTextBox.Text = "";
            ghiChuTextBox.Text = "";
            maNhomTextBox.Focus();
            button7.Enabled = true;
            isAddingNew = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNhomTextBox.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maLoaiToDelete = maNhomTextBox.Text;
            string tenLoai = maNhomTextBox.Text;

            int count = xl.DemSoNVTheoMaNhom(maLoaiToDelete);

            if (count > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Đang có nguoi dung thuộc nhóm này. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của nhóm là " + tenLoai + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaNhomND(maLoaiToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        // Cập nhật lại giao diện sau khi xóa thành công
                        maNhomTextBox.Text = "";
                        tenNhomTextBox.Text = "";
                        ghiChuTextBox.Text = "";
                        dataGridView1.DataSource = xl.LoadNhomNguoiDung();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            maNhomTextBox.Enabled = true;
            tenNhomTextBox.Enabled = true;
            ghiChuTextBox.Enabled = true;

            maNhomTextBox.Focus();
            button7.Enabled = true;

            isAddingNew = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadNhomNguoiDung();
            maNhomTextBox.Text = "";
            tenNhomTextBox.Text = "";
            ghiChuTextBox.Text = "";
            maNhomTextBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maNhomTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhóm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maNhomTextBox.Focus();
                return;
            }
            if (tenNhomTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhóm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tenNhomTextBox.Focus();
                return;
            }
            if (ghiChuTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ghiChuTextBox.Focus();
                return;
            }
            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaNhomDuplicated(maNhomTextBox.Text))
                {
                    MessageBox.Show("Mã nhóm đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maNhomTextBox.Text = "";
                    maNhomTextBox.Focus();
                    return;
                }
                isSuccessful = xl.ThemNhomND(maNhomTextBox.Text, tenNhomTextBox.Text, ghiChuTextBox.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatNhomND(maNhomTextBox.Text, tenNhomTextBox.Text, ghiChuTextBox.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                maNhomTextBox.Enabled = false;
                tenNhomTextBox.Enabled = false;
                ghiChuTextBox.Enabled = false;
                button7.Enabled = false;   
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dataGridView1.DataSource = xl.LoadNhomNguoiDung();
        }
    }
}
