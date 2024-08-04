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
    public partial class frmBaoCaoKho : Form
    {
        XuLy xl = new XuLy();
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

        
    }
}
