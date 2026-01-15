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
    public partial class pageManagement_groupFunctions_TableAndDish_DateViewType : DevExpress.XtraEditors.XtraForm
    {
        public DateTime vDateFrom;
        public DateTime vDateTo;

        public pageManagement_groupFunctions_TableAndDish_DateViewType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            vDateFrom = dateFrom.DateTime;
            vDateTo = dateTo.DateTime;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_DateViewType_Load(object sender, EventArgs e)
        {
            dateFrom.DateTime = DateTime.Now;
            dateTo.DateTime = DateTime.Now;
        }
    }
}