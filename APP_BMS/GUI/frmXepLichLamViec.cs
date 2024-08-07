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
using ClosedXML;
using ClosedXML.Excel;

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

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Schedule");

                // Dòng đầu tiên: Ngày
                int colIndex = 1;
                for (var date = batDau; date <= ketThuc; date = date.AddDays(1))
                {
                    worksheet.Cell(1, colIndex).Value = date.ToShortDateString();
                    colIndex++;
                }

                // Dòng thứ hai: Mã nhân viên
                colIndex = 1;
                for (var date = batDau; date <= ketThuc; date = date.AddDays(1))
                {
                    var schedule = schedules.FirstOrDefault(s => s.Date.Date == date.Date);
                    if (schedule != null)
                    {
                        worksheet.Cell(2, colIndex).Value = schedule.EmployeeId;
                    }
                    colIndex++;
                }

                // Hiển thị hộp thoại lưu tệp
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save Schedule to Excel";
                    saveFileDialog.FileName = "Schedule.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("File đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}