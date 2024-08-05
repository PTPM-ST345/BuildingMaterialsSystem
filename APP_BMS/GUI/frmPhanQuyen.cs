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
    public partial class frmPhanQuyen : Form
    {
        XuLy xl = new XuLy();
        public frmPhanQuyen()
        {
            InitializeComponent();
            this.Load += frmPhanQuyen_Load;
        }

        void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            qL_NhomNguoiDungDataGridView.DataSource = xl.LoadNhomNguoiDung();
            string maNhomNguoiDung = qL_NhomNguoiDungDataGridView.Rows[0].Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(maNhomNguoiDung))
            {
                phanQuyenNguoiDung_DKDataGridView.DataSource = xl.loadPhanQuyen(maNhomNguoiDung);
            }
            phanQuyenNguoiDung_DKDataGridView.Columns["CoQuyen"].Visible = false;
            phanQuyenNguoiDung_DKDataGridView.Columns["MaNhomNguoiDung"].Visible = false;
            var coQuyenColumn = phanQuyenNguoiDung_DKDataGridView.Columns["CoQuyen"] as DataGridViewCheckBoxColumn;

            if (coQuyenColumn == null)
            {
                // If not a checkbox column, create and add it
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "CoQuyen",
                    HeaderText = "Có Quyền",
                    DataPropertyName = "CoQuyen",
                    ThreeState = false // Set this to true if you want three states (Checked, Unchecked, Indeterminate)
                };

                phanQuyenNguoiDung_DKDataGridView.Columns.Add(checkBoxColumn);
            }
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < phanQuyenNguoiDung_DKDataGridView.RowCount; i++)
            {
                string maNhomNguoiDung = qL_NhomNguoiDungDataGridView.CurrentRow.Cells[0].Value.ToString();
                string maManHinh = phanQuyenNguoiDung_DKDataGridView.Rows[i].Cells[0].Value.ToString();
                bool coQuyen = Convert.ToBoolean(phanQuyenNguoiDung_DKDataGridView.Rows[i].Cells[4].Value);

                // Check if the record exists
                bool exists = xl.CheckIfExists(maNhomNguoiDung, maManHinh);

                // Update or add the record based on existence
                if (exists)
                {
                    xl.UpdatePhanQuyen(maNhomNguoiDung, maManHinh, coQuyen);
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    xl.AddPhanQuyen(maNhomNguoiDung, maManHinh, coQuyen);
                    MessageBox.Show("Thêm thành công");
                }
            }
        }

        private void qL_NhomNguoiDungDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (qL_NhomNguoiDungDataGridView.SelectedRows.Count >= 0)
            {
                string maNhomNguoiDung = qL_NhomNguoiDungDataGridView.CurrentRow.Cells[0].Value.ToString();
                phanQuyenNguoiDung_DKDataGridView.DataSource = xl.loadPhanQuyen(maNhomNguoiDung);
            }
        }
    }
}
