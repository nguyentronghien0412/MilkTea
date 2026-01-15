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
    public partial class pageManagement_groupFunctions_TableAndDish_MessageNoConfigMaterial : DevExpress.XtraEditors.XtraForm
    {
        public List<string> lstMenuName = new List<string>();

        public pageManagement_groupFunctions_TableAndDish_MessageNoConfigMaterial()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_MessageNoConfigMaterial_Load(object sender, EventArgs e)
        {
            lbContent.Text = string.Join("\n", lstMenuName);
        }
    }
}