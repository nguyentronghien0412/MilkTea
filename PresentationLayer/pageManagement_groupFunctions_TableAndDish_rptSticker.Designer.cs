namespace PresentationLayer
{
    partial class pageManagement_groupFunctions_TableAndDish_rptSticker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupFunctions_TableAndDish_rptSticker));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.rtxtContent = new DevExpress.XtraReports.UI.XRRichText();
            ((System.ComponentModel.ISupportInitialize)(this.rtxtContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 254F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rtxtContent});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 300F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // rtxtContent
            // 
            this.rtxtContent.Dpi = 254F;
            this.rtxtContent.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.rtxtContent.LocationFloat = new DevExpress.Utils.PointFloat(10F, 5F);
            this.rtxtContent.Name = "rtxtContent";
            this.rtxtContent.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.rtxtContent.SerializableRtfString = resources.GetString("rtxtContent.SerializableRtfString");
            this.rtxtContent.SizeF = new System.Drawing.SizeF(480F, 280F);
            // 
            // pageManagement_groupFunctions_TableAndDish_rptSticker
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.Dpi = 254F;
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(0F, 0F, 0F, 0F);
            this.PageHeight = 300;
            this.PageWidth = 500;
            this.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.ShowPreviewMarginLines = false;
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.SnapGridSize = 25F;
            this.Version = "23.1";
            ((System.ComponentModel.ISupportInitialize)(this.rtxtContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRRichText rtxtContent;
    }
}
