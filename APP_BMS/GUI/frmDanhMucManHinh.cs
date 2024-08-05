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
    public partial class frmDanhMucManHinh : Form
    {
        XuLy xl = new XuLy();
        public frmDanhMucManHinh()
        {
            InitializeComponent();
            this.Load += frmDanhMucManHinh_Load;
        }

        void frmDanhMucManHinh_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadDanhMucManHinh();
        }
    }
}
