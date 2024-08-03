using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL_BLL;

namespace GUI
{
    public partial class frmThongTinKhachHang : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinKhachHang()
        {
            InitializeComponent();
            this.Load += frmThongTinKhachHang_Load;
        }

        void frmThongTinKhachHang_Load(object sender, EventArgs e)
        {
            dgvDSKH.DataSource =  xl.LoadKhachHang();
        }
    }
}
