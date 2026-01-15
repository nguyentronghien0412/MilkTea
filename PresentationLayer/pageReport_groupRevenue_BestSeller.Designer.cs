
namespace PresentationLayer
{
    partial class pageReport_groupRevenue_BestSeller
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageReport_groupRevenue_BestSeller));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.chkViewByDate = new DevExpress.XtraEditors.CheckEdit();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.gcReport = new DevExpress.XtraGrid.GridControl();
            this.bgvReport = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.bgvReport_colCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvReport_colName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvReport_colTotalQuantity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvReport_colTotalAmount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvReport_colMenuGroup = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvReport_colActionDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.bgvReport_colSizeID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bgvReport_colSizeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gbDate = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewByDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvReport_colSizeID_lk)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Controls.Add(this.chkViewByDate);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateTo);
            this.panelControl1.Controls.Add(this.dateFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(532, 8);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(99, 18);
            this.chkExpand.TabIndex = 10;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // chkViewByDate
            // 
            this.chkViewByDate.Location = new System.Drawing.Point(321, 8);
            this.chkViewByDate.Name = "chkViewByDate";
            this.chkViewByDate.Properties.Caption = "Xem theo ngày";
            this.chkViewByDate.Size = new System.Drawing.Size(99, 18);
            this.chkViewByDate.TabIndex = 3;
            this.chkViewByDate.CheckedChanged += new System.EventHandler(this.chkViewByDate_CheckedChanged);
            // 
            // btnGetData
            // 
            this.btnGetData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetData.ImageOptions.SvgImage")));
            this.btnGetData.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnGetData.Location = new System.Drawing.Point(426, 6);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(100, 23);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "Lấy báo cáo";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(187, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Ngày bán: Từ";
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(213, 7);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateTo.Size = new System.Drawing.Size(100, 20);
            this.dateTo.TabIndex = 2;
            this.dateTo.EditValueChanged += new System.EventHandler(this.dateTo_EditValueChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(81, 7);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateFrom.Size = new System.Drawing.Size(100, 20);
            this.dateFrom.TabIndex = 1;
            this.dateFrom.EditValueChanged += new System.EventHandler(this.dateFrom_EditValueChanged);
            // 
            // gcReport
            // 
            this.gcReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReport.Location = new System.Drawing.Point(0, 35);
            this.gcReport.MainView = this.bgvReport;
            this.gcReport.Name = "gcReport";
            this.gcReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bgvReport_colSizeID_lk});
            this.gcReport.Size = new System.Drawing.Size(1364, 533);
            this.gcReport.TabIndex = 1;
            this.gcReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgvReport});
            // 
            // bgvReport
            // 
            this.bgvReport.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bgvReport.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.bgvReport.Appearance.FooterPanel.Options.UseFont = true;
            this.bgvReport.Appearance.FooterPanel.Options.UseForeColor = true;
            this.bgvReport.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bgvReport.Appearance.GroupFooter.Options.UseFont = true;
            this.bgvReport.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bgvReport.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgvReport.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bgvReport.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bgvReport.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.bgvReport.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bgvReport_colCode,
            this.bgvReport_colName,
            this.bgvReport_colTotalQuantity,
            this.bgvReport_colMenuGroup,
            this.bgvReport_colTotalAmount,
            this.bgvReport_colActionDate,
            this.bgvReport_colSizeID});
            this.bgvReport.GridControl = this.gcReport;
            this.bgvReport.GroupFormat = "[#image]{1} {2}";
            this.bgvReport.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", this.bgvReport_colTotalAmount, "{0:n0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "", this.bgvReport_colTotalQuantity, "Tổng tiền")});
            this.bgvReport.IndicatorWidth = 60;
            this.bgvReport.Name = "bgvReport";
            this.bgvReport.OptionsBehavior.Editable = false;
            this.bgvReport.OptionsBehavior.ReadOnly = true;
            this.bgvReport.OptionsMenu.EnableColumnMenu = false;
            this.bgvReport.OptionsMenu.EnableFooterMenu = false;
            this.bgvReport.OptionsView.ColumnAutoWidth = false;
            this.bgvReport.OptionsView.ShowAutoFilterRow = true;
            this.bgvReport.OptionsView.ShowFooter = true;
            this.bgvReport.OptionsView.ShowGroupPanel = false;
            this.bgvReport.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.bgvReport_CustomDrawRowIndicator);
            // 
            // bgvReport_colCode
            // 
            this.bgvReport_colCode.Caption = "Mã món";
            this.bgvReport_colCode.FieldName = "Code";
            this.bgvReport_colCode.Name = "bgvReport_colCode";
            this.bgvReport_colCode.OptionsColumn.AllowMove = false;
            this.bgvReport_colCode.Visible = true;
            this.bgvReport_colCode.Width = 101;
            // 
            // bgvReport_colName
            // 
            this.bgvReport_colName.Caption = "Tên món";
            this.bgvReport_colName.FieldName = "Name";
            this.bgvReport_colName.Name = "bgvReport_colName";
            this.bgvReport_colName.OptionsColumn.AllowMove = false;
            this.bgvReport_colName.Visible = true;
            this.bgvReport_colName.Width = 202;
            // 
            // bgvReport_colTotalQuantity
            // 
            this.bgvReport_colTotalQuantity.Caption = "Số lượng đã bán";
            this.bgvReport_colTotalQuantity.FieldName = "TotalQuantity";
            this.bgvReport_colTotalQuantity.Name = "bgvReport_colTotalQuantity";
            this.bgvReport_colTotalQuantity.OptionsColumn.AllowMove = false;
            this.bgvReport_colTotalQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "TotalQuantity", "Tổng cộng")});
            this.bgvReport_colTotalQuantity.Visible = true;
            this.bgvReport_colTotalQuantity.Width = 121;
            // 
            // bgvReport_colTotalAmount
            // 
            this.bgvReport_colTotalAmount.Caption = "Thành tiền";
            this.bgvReport_colTotalAmount.DisplayFormat.FormatString = "n0";
            this.bgvReport_colTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bgvReport_colTotalAmount.FieldName = "TotalAmount";
            this.bgvReport_colTotalAmount.Name = "bgvReport_colTotalAmount";
            this.bgvReport_colTotalAmount.OptionsColumn.AllowMove = false;
            this.bgvReport_colTotalAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAmount", "{0:n0}")});
            this.bgvReport_colTotalAmount.Visible = true;
            this.bgvReport_colTotalAmount.Width = 121;
            // 
            // bgvReport_colMenuGroup
            // 
            this.bgvReport_colMenuGroup.Caption = "Nhóm";
            this.bgvReport_colMenuGroup.FieldName = "MenuGroup";
            this.bgvReport_colMenuGroup.Name = "bgvReport_colMenuGroup";
            this.bgvReport_colMenuGroup.OptionsColumn.AllowMove = false;
            this.bgvReport_colMenuGroup.Visible = true;
            this.bgvReport_colMenuGroup.Width = 202;
            // 
            // bgvReport_colActionDate
            // 
            this.bgvReport_colActionDate.Caption = "Ngày thu tiền";
            this.bgvReport_colActionDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.bgvReport_colActionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.bgvReport_colActionDate.FieldName = "ActionDate";
            this.bgvReport_colActionDate.GroupFormat.FormatString = "dd/MM/yyyy";
            this.bgvReport_colActionDate.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.bgvReport_colActionDate.Name = "bgvReport_colActionDate";
            this.bgvReport_colActionDate.Visible = true;
            this.bgvReport_colActionDate.Width = 100;
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // bgvReport_colSizeID
            // 
            this.bgvReport_colSizeID.Caption = "Kích cỡ";
            this.bgvReport_colSizeID.ColumnEdit = this.bgvReport_colSizeID_lk;
            this.bgvReport_colSizeID.FieldName = "SizeID";
            this.bgvReport_colSizeID.Name = "bgvReport_colSizeID";
            this.bgvReport_colSizeID.Visible = true;
            // 
            // bgvReport_colSizeID_lk
            // 
            this.bgvReport_colSizeID_lk.AutoHeight = false;
            this.bgvReport_colSizeID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bgvReport_colSizeID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name83", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name84")});
            this.bgvReport_colSizeID_lk.Name = "bgvReport_colSizeID_lk";
            this.bgvReport_colSizeID_lk.NullText = "";
            this.bgvReport_colSizeID_lk.ShowHeader = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "DANH SÁCH CÁC MÓN ĐÃ BÁN";
            this.gridBand1.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gbDate});
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.RowCount = 2;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 922;
            // 
            // gbDate
            // 
            this.gbDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbDate.AppearanceHeader.Options.UseFont = true;
            this.gbDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gbDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gbDate.Caption = "Thời gian";
            this.gbDate.Columns.Add(this.bgvReport_colCode);
            this.gbDate.Columns.Add(this.bgvReport_colName);
            this.gbDate.Columns.Add(this.bgvReport_colSizeID);
            this.gbDate.Columns.Add(this.bgvReport_colTotalQuantity);
            this.gbDate.Columns.Add(this.bgvReport_colTotalAmount);
            this.gbDate.Columns.Add(this.bgvReport_colMenuGroup);
            this.gbDate.Columns.Add(this.bgvReport_colActionDate);
            this.gbDate.Name = "gbDate";
            this.gbDate.VisibleIndex = 0;
            this.gbDate.Width = 922;
            // 
            // pageReport_groupRevenue_BestSeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcReport);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageReport_groupRevenue_BestSeller";
            this.Text = "Danh sách các món đã bán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageReport_groupRevenue_BestSeller_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageReport_groupRevenue_BestSeller_FormClosed);
            this.Load += new System.EventHandler(this.pageReport_groupRevenue_BestSeller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkViewByDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvReport_colSizeID_lk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraGrid.GridControl gcReport;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvReport;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colTotalQuantity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colMenuGroup;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colTotalAmount;
        private DevExpress.XtraEditors.CheckEdit chkViewByDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colActionDate;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gbDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bgvReport_colSizeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit bgvReport_colSizeID_lk;
    }
}