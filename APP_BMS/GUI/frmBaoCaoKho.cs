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
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using ClosedXML.Excel;

namespace GUI
{
    public partial class frmBaoCaoKho : Form
    {
        XuLy xl = new XuLy();
        private ToolTip chartToolTip;

        public frmBaoCaoKho()
        {
            InitializeComponent();
            this.Load += frmBaoCaoKho_Load;
        }

        void frmBaoCaoKho_Load(object sender, EventArgs e)
        {
            dgv_BaoCaoKho.DataSource = xl.LoadHangHoa();
            dgv_BaoCaoKho.Columns["Loai"].Visible = false;
            dgv_BaoCaoKho.Columns["NhaCungCap"].Visible = false;
            for (int i = 1; i <= dgv_BaoCaoKho.Rows.Count; i++)
            {
                dgv_BaoCaoKho.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void btnBaoCaoExcel_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dgv_BaoCaoKho.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất");
                return;
            }
            List<HangHoa> pListHH = new List<HangHoa>();
            // Đổ dữ liệu vào danh sách
            foreach (DataGridViewRow item in dgv_BaoCaoKho.Rows)
            {
                HangHoa i = new HangHoa();
                i.STT = item.Cells[0].Value.ToString();
                i.MaHH = item.Cells[1].Value.ToString();
                i.TenHangHoa = item.Cells[2].Value.ToString();
                i.DonVi = item.Cells[3].Value.ToString();
                i.SoLuongTon = Convert.ToInt32(item.Cells[4].Value.ToString());
                i.GiaBan = Convert.ToInt32(item.Cells[6].Value.ToString());
                pListHH.Add(i);
            }
            string path = string.Empty;
            excel.ExportHH(pListHH, ref path, false);
            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<HangHoa> hangHoas = xl.LoadHangHoa();
            chart1.Series.Clear();
            var series = new Series("Số lượng");
            series.ChartType = SeriesChartType.Column;

            foreach (var hangHoa in hangHoas)
            {
                series.Points.AddXY(hangHoa.TenHangHoa, hangHoa.SoLuongTon);
            }

            chart1.Series.Add(series);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Nếu biểu đồ chưa được tạo, thông báo cho người dùng
            if (chart1.Series.Count == 0)
            {
                MessageBox.Show("Vui lòng hiển thị biểu đồ trước khi xuất file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo hộp thoại lưu file
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Lưu File Excel";
                saveFileDialog.FileName = "ThongKe.xlsx";

                // Hiển thị hộp thoại lưu file và kiểm tra nếu người dùng đã chọn một tệp
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Xuất biểu đồ thành hình ảnh
                    using (var chartImage = new Bitmap(chart1.Width, chart1.Height))
                    {
                        chart1.DrawToBitmap(chartImage, new Rectangle(0, 0, chart1.Width, chart1.Height));

                        // Tạo file Excel
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("ThongKe");

                            // Thêm dữ liệu vào worksheet (tuỳ chọn)
                            worksheet.Cell(1, 1).Value = "Dữ liệu hàng hóa";
                            worksheet.Cell(2, 1).Value = "Tên hàng hóa";
                            worksheet.Cell(2, 2).Value = "Số lượng tồn";

                            int row = 3;
                            foreach (var hangHoa in xl.LoadHangHoa())
                            {
                                worksheet.Cell(row, 1).Value = hangHoa.TenHangHoa;
                                worksheet.Cell(row, 2).Value = hangHoa.SoLuongTon;
                                row++;
                            }

                            // Thêm biểu đồ vào worksheet
                            using (var memoryStream = new MemoryStream())
                            {
                                chartImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                                memoryStream.Seek(0, SeekOrigin.Begin);

                                // Thay vì dùng byte[], truyền MemoryStream
                                var chartPicture = worksheet.AddPicture(memoryStream, "Chart.png");
                                chartPicture.MoveTo(worksheet.Cell("E1"));
                            }

                            // Lưu file Excel tại vị trí người dùng chọn
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("File đã được lưu tại " + saveFileDialog.FileName, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
    }
}
