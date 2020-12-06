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
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.GUI
{
    public partial class AddKH_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        KhachHang_BLL khbl = new KhachHang_BLL();
        DBAccess db = new DBAccess();
        int t = 0;

        public AddKH_GUI()
        {
            InitializeComponent();
        }

        private KhachHang_DTO getdatakh()
        {
            KhachHang_DTO kh = new KhachHang_DTO();
            kh.Makh = txtmakh.Text;
            kh.Hoten = txthoten.Text;
            kh.Cmnd = txtcmnd.Text;
            kh.Sdt = txtsdt.Text;
            kh.Email = txtemail.Text;
            kh.Diachi = txtdc.Text;
            return kh;
        }

        private void showtxtkh()
        {
            txthoten.Enabled = true;
            txtcmnd.Enabled = true;
            txtsdt.Enabled = true;
            txtemail.Enabled = true;
            txtdc.Enabled = true;
        }

        private void hidetxtkh()
        {
            txthoten.Enabled = false;
            txtcmnd.Enabled = false;
            txtsdt.Enabled = false;
            txtemail.Enabled = false;
            txtdc.Enabled = false;
        }

        private void cleartxtkh()
        {
            txthoten.Text = "";
            txtcmnd.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdc.Text = "";
            txthoten.Focus();
        }

        private void clearbindkh()
        {
            txtmakh.DataBindings.Clear();
            txthoten.DataBindings.Clear();
            txtsdt.DataBindings.Clear();
            txtcmnd.DataBindings.Clear();
            txtemail.DataBindings.Clear();
            txtdc.DataBindings.Clear();
            dgvkh.DataBindings.Clear();
        }

        
    }
}
