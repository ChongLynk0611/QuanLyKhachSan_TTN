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
        private void getData1(string dk, string txt)
        {
            dgvkh.DataBindings.Clear();
            string sql = "Select * From khachhang Where " + dk + " like '%" + txt + "%'";
            DataTable dtb = db.getDS(sql);
            dgvkh.DataSource = dtb;
        }

        private void getData2(string dk1, string dk2, string txt1, string txt2, string ao1)
        {
            dgvkh.DataBindings.Clear();
            string sql = "Select * From khachhang Where " + dk1 + " like '%" + txt1 + "%' " + ao1 + " " + dk2 + " like '%" + txt2 + "%'";
            DataTable dtb = db.getDS(sql);
            dgvkh.DataSource = dtb;
        }

        private void getData3(string dk1, string dk2, string dk3, string txt1, string txt2, string txt3, string ao1, string ao2)
        {
            dgvkh.DataBindings.Clear();
            string sql = "Select * From khachhang Where " + dk1 + " like '%" + txt1 + "%' " + ao1 + " " + dk2 + " like '%" + txt2 + "%' " + ao2 + " " + dk3 + " like '%" + txt3 + "%'";
            DataTable dtb = db.getDS(sql);
            dgvkh.DataSource = dtb;
        }
    }
}
