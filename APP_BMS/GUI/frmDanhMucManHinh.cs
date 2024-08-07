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
    public partial class frmDanhMucManHinh : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();
        public frmDanhMucManHinh()
        {
            InitializeComponent();
            this.Load += frmDanhMucManHinh_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                dataGridView1.Text = row.Cells["MaManHinh"].Value.ToString();
                dataGridView1.Text = row.Cells["TenManHinh"].Value.ToString();
            }
        }

        void frmDanhMucManHinh_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadDanhMucManHinh();
            dataGridView1.Columns["MaManHinh"].HeaderText = "Mã màn hình";
            dataGridView1.Columns["TenManHinh"].HeaderText = "Tên màn hình";

            maManHinhTextBox.Enabled = false;
            tenManHinhTextBox.Enabled = false;
            button7.Enabled = false;   
        }

        private void button13_Click(object sender, EventArgs e)
        {
            maManHinhTextBox.Enabled = true;
            tenManHinhTextBox.Enabled = true;

            maManHinhTextBox.Text = "";
            tenManHinhTextBox.Text = "";

            maManHinhTextBox.Focus();
            button7.Enabled = true;
            isAddingNew = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maManHinhTextBox.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maLoaiToDelete = maManHinhTextBox.Text;
            string tenLoai = maManHinhTextBox.Text;

            int count = xl.DemQuyenTheoMaMH(maLoaiToDelete);

            if (count > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Đang có hàng hóa thuộc loại hàng này. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của loại hàng là " + tenLoai + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaMH(maLoaiToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        // Cập nhật lại giao diện sau khi xóa thành công
                        maManHinhTextBox.Text = "";
                        tenManHinhTextBox.Text = "";
                        
                        dataGridView1.DataSource = xl.LoadDanhMucManHinh();
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
            maManHinhTextBox.Enabled = true;
            tenManHinhTextBox.Enabled = true;
          

            maManHinhTextBox.Focus();
            button7.Enabled = true;

            isAddingNew = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadDanhMucManHinh();
            maManHinhTextBox.Text = "";
            tenManHinhTextBox.Text = "";

            maManHinhTextBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maManHinhTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã mh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maManHinhTextBox.Focus();
                return;
            }
            if (tenManHinhTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tenManHinhTextBox.Focus();
                return;
            }
            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaMHDuplicated(maManHinhTextBox.Text))
                {
                    MessageBox.Show("Mã loại hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maManHinhTextBox.Text = "";
                    maManHinhTextBox.Focus();
                    return;
                }
                isSuccessful = xl.ThemMH(maManHinhTextBox.Text, tenManHinhTextBox.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatMH(maManHinhTextBox.Text, tenManHinhTextBox.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button7.Enabled = false;
                maManHinhTextBox.Enabled = false;
                tenManHinhTextBox.Enabled = false;
               
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dataGridView1.DataSource = xl.LoadDanhMucManHinh();
        }
    }
}
