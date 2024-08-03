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
    public partial class frmXuatHang : Form
    {
        XuLy xl = new XuLy();
        public frmXuatHang()
        {    
            InitializeComponent();
            this.Load += frmXuatHang_Load;
        }

        void frmXuatHang_Load(object sender, EventArgs e)
        {
            dgvXuatHang.DataSource = xl.LoadDonBanHang();
        }
    }
}
