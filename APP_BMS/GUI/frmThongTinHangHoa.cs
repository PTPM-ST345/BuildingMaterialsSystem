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
    public partial class frmThongTinHangHoa : Form
    {
        XuLy xl = new XuLy();
        public frmThongTinHangHoa()
        {
            InitializeComponent();
            this.Load += frmThongTinHangHoa_Load;
        }

        void frmThongTinHangHoa_Load(object sender, EventArgs e)
        {
            dgvHangHoa.DataSource = xl.LoadHangHoa();
        }
    }
}
