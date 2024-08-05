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
namespace GUI
{
    public partial class frmThemNDVaoNhom : Form
    {
        XuLy xl = new XuLy();
        public frmThemNDVaoNhom()
        {
            InitializeComponent();
            this.Load += frmThemNDVaoNhom_Load;
        }

        void frmThemNDVaoNhom_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadNhanVien();   
            dataGridView2.DataSource = xl.LoadNDNhomND();

            dataGridView2.ClearSelection();
            dataGridView1.ClearSelection();

            comboBox1.DataSource = xl.LoadNhomNguoiDung();
            comboBox1.DisplayMember = "TenNhom";
            comboBox1.ValueMember = "MaNhom";
        }

        private void LoadDK()
        {
            try
            {
                string maNhom = comboBox1.SelectedValue.ToString();
                dataGridView2.DataSource = xl.LoadNDNhomNDTheoMaNhom(maNhom);  
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                LoadDK();   
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn 1 nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maNV = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string maNhomND = comboBox1.SelectedValue.ToString();
            string ghiChu = string.Empty;

            if (xl.KiemTraTrungKhoaChinh(maNV, maNhomND))
            {
                MessageBox.Show("Nhân viên có mã " + maNV + " đã thuộc nhóm người dùng " + maNhomND + "!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            xl.ThemNguoiDungNhomNguoiDung(maNV, maNhomND, ghiChu);

            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDK();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn phải chọn 1 dòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dataGridView2.SelectedRows.Count > 0)
            {
                string maNV = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                string maNhom = dataGridView2.CurrentRow.Cells[1].Value.ToString();

                xl.XoaNguoiDungNhomNguoiDung(maNV, maNhom);

                MessageBox.Show("Xóa thành công");
                LoadDK();
            }
        }
    }
}
