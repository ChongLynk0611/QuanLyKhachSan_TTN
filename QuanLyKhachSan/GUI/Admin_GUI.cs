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
using QuanLyKhachSan.BLL;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.GUI
{
    public partial class Admin_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        Admin_BLL adbl = new Admin_BLL();
        DBAccess db = new DBAccess();
        string id = "";
        public Admin_GUI()
        {
            InitializeComponent();
        }
        private void bindDataAd()
        {
            DataRow r = adbl.infoAdmin(frmLogin.mnv);
            txtmanv.Text = r[0].ToString();
            txtchucvu.Text = r[1].ToString();
            txthoten.Text = r[2].ToString();
            txtngaysinh.Text = r[3].ToString();
            txtgioitinh.Text = r[4].ToString();
            txtsdt.Text = r[5].ToString();
            txtcmnd.Text = r[6].ToString();
            txtemail.Text = r[7].ToString();
            txtdc.Text = r[8].ToString();
            txtqqt.Text = r[9].ToString();
            txtmkqt.Text = r[10].ToString();
        }

        private void bindDataCbNV()
        {
            DataTable dtb = adbl.dsnvpq();
            cbmanv.DataSource = dtb;
            cbmanv.ValueMember = "manv";
            cbmanv.DisplayMember = "manv";
        }

    }
}
