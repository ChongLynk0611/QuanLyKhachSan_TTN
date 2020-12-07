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

        private void limitdate()
        {
            dtpngayden.MinDate = DateTime.Today;
            dtpngaydi.MinDate = DateTime.Today;
        }

        private void nolimitdate()
        {
            dtpngayden.MinDate = Convert.ToDateTime("01/01/1753");
            dtpngaydi.MinDate = Convert.ToDateTime("01/01/1753");
        }

        private void clearbinddp()
        {
            txtmadp.DataBindings.Clear();
            txtmanv.DataBindings.Clear();
            txtmakh.DataBindings.Clear();
            txtLpDat.DataBindings.Clear();
            dtpngaydat.DataBindings.Clear();
            dtpngayden.DataBindings.Clear();
            dtpngaydi.DataBindings.Clear();
            txttiencoc.DataBindings.Clear();
            txtsoluong.DataBindings.Clear();
            ckbtrangtrai.DataBindings.Clear();
            listDatphong.DataBindings.Clear();
            dgvdp.DataBindings.Clear();
        }

        private void bindatadp()
        {
            BindingSource bsdp = new BindingSource();
            bsdp.DataSource = dpbl.dsdp();
            clearbinddp();
            dgvdp.DataSource = bsdp;
            txtmadp.DataBindings.Add("Text", bsdp, "madp");
            txtmanv.DataBindings.Add("Text", bsdp, "manv");
            txtmakh.DataBindings.Add("Text", bsdp, "makh");
            txtLpDat.DataBindings.Add("Text", bsdp, "tenlp");
            dtpngaydat.DataBindings.Add("Value", bsdp, "ngaydat");
            dtpngayden.DataBindings.Add("Value", bsdp, "ngayden");
            dtpngaydi.DataBindings.Add("Value", bsdp, "ngaydi");
            txttiencoc.DataBindings.Add("Text", bsdp, "tiendatcoc");
            txtsoluong.DataBindings.Add("Text", bsdp, "soluong");
            ckbtrangtrai.DataBindings.Add("Checked", bsdp, "trangthai");
            bindatalistdatphong();
        }

        private void DatPhong_GUI_Load(object sender, EventArgs e)
        {
            DataTable dtblp = new DataTable();
            dtblp = lpbl.dslp();
            cbloaiphong.DataSource = dtblp;
            cbloaiphong.DisplayMember = "tenlp";
            cbloaiphong.ValueMember = "tenlp";
            bindatalistphong();
            bindatadp();
        }

        private void bindatalistphong()
        {
            BindingSource bsp = new BindingSource();
            tenlp = cbloaiphong.SelectedValue.ToString();
            bsp.DataSource = pbl.dsph(tenlp);
            listPhong.DataBindings.Clear();
            listPhong.DataSource = bsp;
            listPhong.DisplayMember = "maphong";
            listPhong.ValueMember = "maphong";
        }

        private void bindatalistdatphong()
        {
            BindingSource bsctdp = new BindingSource();
            bsctdp.DataSource = ctdpbl.dsdpct(txtmadp.Text);
            listDatphong.DataSource = bsctdp;
            listDatphong.DisplayMember = "maphong";
            listDatphong.ValueMember = "maphong";
        }

        private void cbloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnthem.Text == "Hủy bỏ")
            {
                txtLpDat.Text = cbloaiphong.SelectedValue.ToString();
                txttiencoc.Text = lpbl.getTiendatcoc(cbloaiphong.SelectedValue.ToString(), int.Parse(txtsoluong.Text)).ToString();
            }
            bindatalistphong();
        }

        private void dgvdp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bindatalistdatphong();
            txtmadp.Text = dgvdp.CurrentRow.Cells[0].Value.ToString();
            txtmanv.Text = dgvdp.CurrentRow.Cells[1].Value.ToString();
            txtmakh.Text = dgvdp.CurrentRow.Cells[2].Value.ToString();
            txtLpDat.Text = dgvdp.CurrentRow.Cells[3].Value.ToString();
            dtpngaydat.Value = Convert.ToDateTime(dgvdp.CurrentRow.Cells[4].Value);
            dtpngayden.Value = Convert.ToDateTime(dgvdp.CurrentRow.Cells[5].Value);
            dtpngaydi.Value = Convert.ToDateTime(dgvdp.CurrentRow.Cells[6].Value);
            txttiencoc.Text = dgvdp.CurrentRow.Cells[7].Value.ToString();
            txtsoluong.Text = dgvdp.CurrentRow.Cells[8].Value.ToString();
            ckbtrangtrai.Checked = Convert.ToBoolean(dgvdp.CurrentRow.Cells[9].Value);
        }

        private string setmadp()
        {
            int id;
            id = int.Parse(db.GetLastID("datphong", "madp").Substring(2, 3));
            if (id < 9)
                return "DP00" + (id + 1).ToString();
            else
                if (id < 99)
                    return "DP0" + (id + 1).ToString();
                else
                    return "DP" + (id + 1).ToString();
        }

        private void enablemove()
        {
            btnAddAll.Enabled = true;
            btnAddOne.Enabled = true;
            btnClearOne.Enabled = true;
            btnClearAll.Enabled = true;
        }

        private void disablemove()
        {
            btnAddAll.Enabled = false;
            btnAddOne.Enabled = false;
            btnClearOne.Enabled = false;
            btnClearAll.Enabled = false;
        }


    }
}
