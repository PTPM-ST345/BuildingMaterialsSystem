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
    public partial class frmXepLichLamViec : Form
    {
        XuLy xl = new XuLy();
        public frmXepLichLamViec()
        {
            InitializeComponent();
            this.Load += frmXepLichLamViec_Load;
        }

        void frmXepLichLamViec_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadNhanVienWithChucVu();
            comboboxNhomNguoiDung.DataSource = xl.LoadNhomNguoiDung();
            comboboxNhomNguoiDung.DisplayMember = "TenNhom";
            comboboxNhomNguoiDung.ValueMember = "MaNhom";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var maNhom = comboboxNhomNguoiDung.SelectedValue.ToString();
            var batDau = datetimepickerBatDau.Value;
            var ketThuc = datetimepickerKetThuc.Value;

            if (batDau >= ketThuc)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ThuatToan tt = new ThuatToan();
            var nhanViens = xl.GetNhanVienByNhom(maNhom);

            var schedules = tt.ScheduleTasksForEmployees(nhanViens, batDau, ketThuc);

            dataGridView2.DataSource = schedules.Select(s => new
            {
                EmployeeId = s.EmployeeId,
                Date = s.Date.ToShortDateString() // Hiển thị ngày dưới dạng ngắn
            }).ToList();
            MessageBox.Show("Xếp lịch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
