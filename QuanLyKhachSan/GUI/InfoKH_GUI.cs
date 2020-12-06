using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.GUI
{
    public partial class InfoKH_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        DBAccess db = new DBAccess();
        string and_or1 = "";
        string and_or2 = "";
        string dk0 = "";
        string dk1 = "";
        string dk2 = "";
        string dk3 = "";
        string txt0 = "";
        string txt1 = "";
        string txt2 = "";
        string txt3 = "";
        public InfoKH_GUI()
        {
            InitializeComponent();
        }
        private void gettxtcb()
        {
            txt0 = txtCoBan.Text;
        }
        private void gettxtnc()
        {
            txt1 = txtNangCao1.Text;
            txt2 = txtNangCao2.Text;
            txt3 = txtNangCao3.Text;
        }
    }
}
