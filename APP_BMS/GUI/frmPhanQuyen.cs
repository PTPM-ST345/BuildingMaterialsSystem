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
            //phanQuyenNguoiDung_DKDataGridView.DataSource = xl.loadPhanQuyen();
            qL_NhomNguoiDungDataGridView.DataSource = xl.LoadNhomNguoiDung();
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
    }
}
