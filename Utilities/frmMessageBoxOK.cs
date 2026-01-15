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
    public partial class frmMessageBoxOK : DevExpress.XtraEditors.XtraForm
    {
        string title = "";
        string content = "";
        Color c = Color.Black;

        public frmMessageBoxOK()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessageBoxOK_Load(object sender, EventArgs e)
        {
            Text = title;
            lbContent.Text = content;
            lbContent.ForeColor = c;
        }

        public void InitMessage(string TypeMessage, string Title, string Content)
        {
            string callFrom = Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (TypeMessage.ToUpper() == "N")//Normal
                    c = Color.Black;
                else if (TypeMessage.ToUpper() == "W")//Warning
                    c = Color.Blue;
                else if (TypeMessage.ToUpper() == "E")//Error
                    c = Color.Red;
                else
                    c = Color.Black;

                title = Title;

                content = Content;
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                MessageBox.Show(ex.Message + "\n" + callFrom, Parameters.Notification, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}