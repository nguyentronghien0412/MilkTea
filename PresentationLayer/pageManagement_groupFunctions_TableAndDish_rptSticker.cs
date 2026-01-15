using DataObject;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_rptSticker : DevExpress.XtraReports.UI.XtraReport
    {
        public pageManagement_groupFunctions_TableAndDish_rptSticker()
        {
            InitializeComponent();
        }

        public void BindData_Information(string Content)
        {
           rtxtContent.Rtf = Content;
        }
    }
}
