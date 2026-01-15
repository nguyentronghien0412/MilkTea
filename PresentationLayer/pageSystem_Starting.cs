using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class pageSystem_Starting : SplashScreen
    {
        public pageSystem_Starting()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © " + DateTime.Now.Year.ToString()+", Made by Nguyễn Trọng Hiến";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}