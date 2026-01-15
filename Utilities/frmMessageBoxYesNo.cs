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

namespace Utilities
{
    public partial class frmMessageBoxYesNo : DevExpress.XtraEditors.XtraForm
    {
        string title = "";
        string content = "";

        DialogResult dlgReturn = DialogResult.No;

        public frmMessageBoxYesNo()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            dlgReturn = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            dlgReturn = DialogResult.No;
            this.Close();
        }

        private void frmMessageBoxYesNo_Load(object sender, EventArgs e)
        {
            Text = title;
            lbContent.Text = content;
        }

        public void InitMessage(string Title, string Content)
        {
            string callFrom = Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                title = Title;
                content = Content;
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                MessageBox.Show(ex.Message + "\n" + callFrom, Parameters.Notification, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMessageBoxYesNo_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = dlgReturn;
        }
    }
}