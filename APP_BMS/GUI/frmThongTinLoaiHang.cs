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
    public partial class frmThongTinLoaiHang : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinLoaiHang()
        {
            InitializeComponent();
            this.Load += frmThongTinLoaiHang_Load;
        }

        void frmThongTinLoaiHang_Load(object sender, EventArgs e)
        {
            dgvLoaiHang.DataSource = xl.LoadLoaiHang();
        }
    }
}
