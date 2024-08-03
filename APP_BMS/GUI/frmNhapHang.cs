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
    public partial class frmNhapHang : Form
    {
        XuLy xl = new XuLy();
        public frmNhapHang()
        {
            InitializeComponent();
            this.Load += frmNhapHang_Load;
        }

        void frmNhapHang_Load(object sender, EventArgs e)
        {
            dgvNhapHang.DataSource = xl.LoadDonNhapHang();
        }
    }
}
