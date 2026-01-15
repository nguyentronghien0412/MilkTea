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
    public partial class pageManagement_groupFunctions_TableAndDish_AddNote : DevExpress.XtraEditors.XtraForm
    {
        public string vNote = "";
        public pageManagement_groupFunctions_TableAndDish_AddNote()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNote.Text.Trim() == "")
            {
                Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập ghi chú.");
                return;
            }

            vNote = txtNote.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}