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
    public partial class frmMessageBox : DevExpress.XtraEditors.XtraForm
    {
        string title = "";
        string content = "";
        Color c = Color.Black;
        int displayTime = 5000;

        public frmMessageBox()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Screen scr = Screen.FromPoint(this.Location);
            this.Location = new Point(scr.WorkingArea.Right - this.Width, scr.WorkingArea.Top);

            this.Text = title;
            lbContent.Text = content;
            lbContent.ForeColor = c;

            timer1.Interval = displayTime;
            timer1.Start();
        }

        public void InitMessage(string TypeMessage, string Title, string Content, int DisplayTime)
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
                displayTime = DisplayTime;
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                MessageBox.Show(ex.Message + "\n" + callFrom, Parameters.Notification, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}