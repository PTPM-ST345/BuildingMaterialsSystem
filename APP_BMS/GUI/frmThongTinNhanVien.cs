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
    public partial class frmThongTinNhanVien : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinNhanVien()
        {
            InitializeComponent();
            this.Load += frmThongTinNhanVien_Load;
        }

        void frmThongTinNhanVien_Load(object sender, EventArgs e)
        {
            dvgDSNhanVien.DataSource = xl.LoadNhanVien();
        }
    }
}
