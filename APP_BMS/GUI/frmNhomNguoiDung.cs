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
    public partial class frmNhomNguoiDung : Form
    {
        XuLy xl = new XuLy();
        public frmNhomNguoiDung()
        {

            InitializeComponent();
            this.Load += frmNhomNguoiDung_Load;
        }

        void frmNhomNguoiDung_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.LoadNhomNguoiDung();
        }
    }
}
