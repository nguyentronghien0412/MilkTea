using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class pageSystem_groupConfiguration_UserConfiguration_Warehouse : DevExpress.XtraEditors.XtraForm
    {
        public string _Title = "";
        public pageSystem_groupConfiguration_UserConfiguration_Warehouse()
        {
            InitializeComponent();
        }

        private void btnĐóng_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void pageSystem_groupConfiguration_UserConfiguration_Warehouse_Load(object sender, EventArgs e)
        {
            if (_Title != "")
            {
                this.Text = _Title;
                labelControl1.Text = _Title;
            }
        }
    }
}