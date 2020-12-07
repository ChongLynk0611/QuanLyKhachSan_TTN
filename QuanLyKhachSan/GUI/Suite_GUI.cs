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

namespace QuanLyKhachSan.GUI
{
    public partial class Suite_GUI : DevExpress.XtraEditors.XtraUserControl
    {
        Phong_BLL pbl = new Phong_BLL();
        public Suite_GUI()
        {
            InitializeComponent();
        }
        
    }
}
