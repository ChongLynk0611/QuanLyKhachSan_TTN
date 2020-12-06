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
using System.Collections;

namespace QuanLyKhachSan.GUI
{
    public partial class DatPhong_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        LoaiPhong_BLL lpbl = new LoaiPhong_BLL();
        Phong_BLL pbl = new Phong_BLL();
        DatPhong_BLL dpbl = new DatPhong_BLL();
        ChiTietDatPhong_BLL ctdpbl = new ChiTietDatPhong_BLL();
        HoaDon_BLL hdbl = new HoaDon_BLL();
        DBAccess db = new DBAccess();
        string tenlp = "";
        public static string madatphong = "";
        int t = 0;
        ArrayList arr = new ArrayList();
        ArrayList arr1 = new ArrayList();
        
        public DatPhong_GUI()
        {
            InitializeComponent();
        }

        private DatPhong_DTO getdatadp()
        {
            DatPhong_DTO dp = new DatPhong_DTO();
            dp.Madp = txtmadp.Text;
            dp.Manv = txtmanv.Text;
            dp.Makh = txtmakh.Text;
            dp.Tenlp = cbloaiphong.SelectedValue.ToString();
            dp.Ngaydat = dtpngaydat.Value;
            dp.Ngayden = dtpngayden.Value;
            dp.Ngaydi = dtpngaydi.Value;
            dp.Tiendatcoc = int.Parse(txttiencoc.Text);
            dp.Soluong = int.Parse(txtsoluong.Text);
            dp.Trangthai = ckbtrangtrai.Checked;
            return dp;
        }

        private CTDP_DTO getdatactdp(ArrayList arr, int i)
        {
            CTDP_DTO ctdp = new CTDP_DTO();
            ctdp.Madp = txtmadp.Text;
            ctdp.Maphong = arr[i].ToString();
            return ctdp;
        }

        private void showtxtdp()
        {
            txtmakh.Enabled = true;
            dtpngayden.Enabled = true;
            dtpngaydi.Enabled = true;
        }

        private void hidetxtdp()
        {
            txtmakh.Enabled = false;
            dtpngayden.Enabled = false;
            dtpngaydi.Enabled = false;
        }

        private void cleartxtdp()
        {
            txtmakh.Text = "";
            dtpngaydat.Value = DateTime.Today;
            dtpngayden.Value = DateTime.Today;
            dtpngaydi.Value = DateTime.Today;
            ckbtrangtrai.Checked = false;
            txttiencoc.Text = "";
            txtLpDat.Text = "";
            txtsoluong.Text = "";
            txtmakh.Focus();
        }

      
    }
}
