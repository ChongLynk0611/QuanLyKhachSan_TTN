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
    public partial class AddNV_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        NhanVien_BLL nvbl = new NhanVien_BLL();
        ChucVu_BLL cvbl = new ChucVu_BLL();
        DBAccess db = new DBAccess();
        string macv = "";
        int t = 0;

        public AddNV_GUI()
        {
            InitializeComponent();
        }
        private NhanVien_DTO getdatanv()
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.Manv = txtmanv.Text;
            nv.Macv = cbChucvu.SelectedValue.ToString();
            nv.Hoten = txthoten.Text;
            nv.Ngaysinh = dtpngaysinh.Value;
            nv.Gioitinh = txtgioitinh.Text;
            nv.Sdt = txtsdt.Text;
            nv.Cmnd = txtcmnd.Text;
            nv.Email = txtemail.Text;
            nv.Diachi = txtdc.Text;
            return nv;
        }
        private void showtxtnv()
        {
            txthoten.Enabled = true;
            dtpngaysinh.Enabled = true;
            txtgioitinh.Enabled = true;
            txtcmnd.Enabled = true;
            txtsdt.Enabled = true;
            txtemail.Enabled = true;
            txtdc.Enabled = true;
        }

        private void hidetxtnv()
        {
            txthoten.Enabled = false;
            dtpngaysinh.Enabled = false;
            txtgioitinh.Enabled = false;
            txtcmnd.Enabled = false;
            txtsdt.Enabled = false;
            txtemail.Enabled = false;
            txtdc.Enabled = false;
        }

        private void cleartxtnv()
        {
            txthoten.Text = "";
            dtpngaysinh.Value = DateTime.Today;
            txtgioitinh.Text = "";
            txtcmnd.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtdc.Text = "";
            cbChucvu.Focus();
        }

        private void clearbindnv()
        {
            txtmanv.DataBindings.Clear();
            txthoten.DataBindings.Clear();
            dtpngaysinh.DataBindings.Clear();
            txtgioitinh.DataBindings.Clear();
            txtsdt.DataBindings.Clear();
            txtcmnd.DataBindings.Clear();
            txtemail.DataBindings.Clear();
            txtdc.DataBindings.Clear();
            dgvnv.DataBindings.Clear();
        }

        private void bindatanv()
        {
            BindingSource bindSourceNV = new BindingSource();
            macv = cbChucvu.SelectedValue.ToString();
            bindSourceNV.DataSource = nvbl.dsnv(macv);
            clearbindnv();
            txtmanv.DataBindings.Add("Text", bindSourceNV, "manv");
            txthoten.DataBindings.Add("Text", bindSourceNV, "hoten");
            dtpngaysinh.DataBindings.Add("Value", bindSourceNV, "ngaysinh");
            txtgioitinh.DataBindings.Add("Text", bindSourceNV, "gioitinh");
            txtsdt.DataBindings.Add("Text", bindSourceNV, "sdt");
            txtcmnd.DataBindings.Add("Text", bindSourceNV, "cmnd");
            txtemail.DataBindings.Add("Text", bindSourceNV, "email");
            txtdc.DataBindings.Add("Text", bindSourceNV, "diachi");
            dgvnv.DataSource = bindSourceNV;
        }
    }
}
