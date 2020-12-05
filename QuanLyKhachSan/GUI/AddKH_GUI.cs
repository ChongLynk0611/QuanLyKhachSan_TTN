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

       
    }
}
