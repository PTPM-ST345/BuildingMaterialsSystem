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
    public partial class frmThongTinNhaCungCap : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinNhaCungCap()
        {
            InitializeComponent();
            this.Load += frmThongTinNhaCungCap_Load;
        }

        void frmThongTinNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvNCC.DataSource = xl.LoadNhaCungCap();
        }
    }
}
