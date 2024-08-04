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
    public partial class frmThongTinNhaCungCap : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();
        public frmThongTinNhaCungCap()
        {
            InitializeComponent();
            this.Load += frmThongTinNhaCungCap_Load;
            dgvNCC.CellClick += dgvNCC_CellClick;
            textBox5.TextChanged += textBox5_TextChanged;
        }
        
        //TimKiem
        void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text;
            bool timKiemTheoMaNCC = radioButton1.Checked;

            List<NhaCungCap> ketQuaTimKiem = xl.TimKiemNhaCungCap(keyword, timKiemTheoMaNCC);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNCC");
            dt.Columns.Add("TenNCC");
            dt.Columns.Add("Diachi");
            dt.Columns.Add("SDT");

            foreach (var ncc in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaNCC"] = ncc.MaNCC;
                dr["TenNCC"] = ncc.TenNCC;
                dr["Diachi"] = ncc.Diachi;
                dr["SDT"] = ncc.SDT;
                dt.Rows.Add(dr);
            }

            dgvNCC.DataSource = dt;
        }

        //Databinding
        void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNCC.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MaNCC"].Value.ToString();
                textBox2.Text = row.Cells["TenNCC"].Value.ToString();
                textBox3.Text = row.Cells["Diachi"].Value.ToString();
                textBox4.Text = row.Cells["SDT"].Value.ToString();
            }
        }

        //Form_Load
        void frmThongTinNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNCC.DataSource = xl.LoadNhaCungCap();
            dgvNCC.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNCC.Columns["Diachi"].HeaderText = "Địa chỉ";
            dgvNCC.Columns["SDT"].HeaderText = "Số điện thoại";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            radioButton1.Checked = true;
            button7.Enabled = false;
        }

        //Them
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            textBox1.Focus();
            button7.Enabled = true;
            isAddingNew = true;
        }

        //Xoa
        private void button9_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNCCToDelete = textBox1.Text;
            string tenNCC = textBox2.Text;

            int count = xl.DemSoHangHoaTheoMaNCC(maNCCToDelete);

            if (count > 0)
            {
                // Mã hàng hóa đang tồn tại trong Kho
                MessageBox.Show("Đang có hàng hóa thuộc nhà cung cấp này. Không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin của nhà cung cấp là " + tenNCC + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        xl.XoaNCC(maNCCToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        // Cập nhật lại giao diện sau khi xóa thành công
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        dgvNCC.DataSource = xl.LoadNhaCungCap();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa không được !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Sua
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox1.Focus();
            button7.Enabled = true;

            isAddingNew = false;
        }

        //LamMoi
        private void button1_Click(object sender, EventArgs e)
        {
            dgvNCC.DataSource = xl.LoadNhaCungCap();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Focus();
        }

        //Luu
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ cho nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (textBox4.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }

            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaNCCDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                isSuccessful = xl.ThemNCC(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatNCC(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button7.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã nhà cung cấp không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dgvNCC.DataSource = xl.LoadNhaCungCap();
        }
    }
}
