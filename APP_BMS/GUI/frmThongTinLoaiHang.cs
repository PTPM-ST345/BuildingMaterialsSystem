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
    public partial class frmThongTinLoaiHang : Form
    {
        private bool isAddingNew = false;
        XuLy xl = new XuLy();

        public frmThongTinLoaiHang()
        {
            InitializeComponent();
            this.Load += frmThongTinLoaiHang_Load;
            dgvLoaiHang.CellClick += dgvLoaiHang_CellClick;
            textBox5.TextChanged += textBox5_TextChanged;
        }

        void textBox5_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox5.Text;
            bool timKiemTheoMaLoai = radioButton1.Checked;

            List<Loai> ketQuaTimKiem = xl.TimKiemLoaiHangHoa(keyword, timKiemTheoMaLoai);
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoai");
            dt.Columns.Add("TenLoai");
            dt.Columns.Add("ThongTin");

            foreach (var loai in ketQuaTimKiem)
            {
                DataRow dr = dt.NewRow();
                dr["MaLoai"] = loai.MaLoai;
                dr["TenLoai"] = loai.TenLoai;
                dr["ThongTin"] = loai.ThongTin;
                dt.Rows.Add(dr);
            }

            dgvLoaiHang.DataSource = dt;
        }

        void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiHang.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MaLoai"].Value.ToString();
                textBox2.Text = row.Cells["TenLoai"].Value.ToString();
                textBox3.Text = row.Cells["ThongTin"].Value.ToString();
            }
        }

        void frmThongTinLoaiHang_Load(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = xl.LoadLoaiHang();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            radioButton1.Checked = true;
            button7.Enabled = false;
        }
        //btnThem
        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
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

            string maLoaiToDelete = textBox1.Text;
            string tenLoai = textBox2.Text;

            int count = xl.DemSoHangHoaTheoMaLoai(maLoaiToDelete);

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
                        xl.XoaLoaiHangHoa(maLoaiToDelete);
                        MessageBox.Show("Xóa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        // Cập nhật lại giao diện sau khi xóa thành công
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        dgvLoaiHang.DataSource = xl.LoadLoaiHang();
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

            textBox1.Focus();
            button7.Enabled = true;

            isAddingNew = false;
        }

        //LamMoi
        private void button1_Click(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = xl.LoadLoaiHang();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        //Luu
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (textBox3.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mô tả cho loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            bool isSuccessful = false;

            if (isAddingNew)
            {
                if (xl.IsMaLoaiDuplicated(textBox1.Text))
                {
                    MessageBox.Show("Mã loại hàng đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                isSuccessful = xl.ThemLoaiHangHoa(textBox1.Text, textBox2.Text, textBox3.Text);
            }
            else
            {
                isSuccessful = xl.CapNhatLoaiHangHoa(textBox1.Text, textBox2.Text,  textBox3.Text);
            }

            if (isSuccessful)
            {
                MessageBox.Show(isAddingNew ? "Thêm thành công !!!" : "Sửa thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                button7.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                MessageBox.Show(isAddingNew ? "Thêm không được !!!" : "Mã loại không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            isAddingNew = false;

            dgvLoaiHang.DataSource = xl.LoadLoaiHang();
        }


    }
}
