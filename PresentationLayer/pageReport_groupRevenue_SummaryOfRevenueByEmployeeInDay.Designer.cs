namespace PresentationLayer
{
    partial class pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.slkEmployees = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActionBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActionByName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.gcData = new DevExpress.XtraGrid.GridControl();
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PaymentedByID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PaymentedByName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Bank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Grab = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Shopee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Total = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::PresentationLayer.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_Waiting), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployees.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.slkEmployees);
            this.panelControl1.Controls.Add(this.dateTo);
            this.panelControl1.Controls.Add(this.dateFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetData.ImageOptions.SvgImage")));
            this.btnGetData.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnGetData.Location = new System.Drawing.Point(575, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(100, 23);
            this.btnGetData.TabIndex = 12;
            this.btnGetData.Text = "Lấy báo cáo";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(315, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Nhân viên";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(183, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Ngày thu: Từ";
            // 
            // slkEmployees
            // 
            this.slkEmployees.EditValue = "";
            this.slkEmployees.Location = new System.Drawing.Point(369, 7);
            this.slkEmployees.Name = "slkEmployees";
            this.slkEmployees.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkEmployees.Properties.NullText = "";
            this.slkEmployees.Properties.PopupView = this.searchLookUpEdit1View;
            this.slkEmployees.Size = new System.Drawing.Size(200, 20);
            this.slkEmployees.TabIndex = 8;
            this.slkEmployees.EditValueChanged += new System.EventHandler(this.slkEmployees_EditValueChanged);
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colActionBy,
            this.colActionByName});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowColumnHeaders = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colActionBy
            // 
            this.colActionBy.Caption = "gridColumn1";
            this.colActionBy.FieldName = "ActionBy";
            this.colActionBy.Name = "colActionBy";
            // 
            // colActionByName
            // 
            this.colActionByName.Caption = "gridColumn2";
            this.colActionByName.FieldName = "ActionByName";
            this.colActionByName.Name = "colActionByName";
            this.colActionByName.Visible = true;
            this.colActionByName.VisibleIndex = 0;
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(209, 7);
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
            this.dateTo.TabIndex = 7;
            this.dateTo.EditValueChanged += new System.EventHandler(this.dateTo_EditValueChanged);
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(77, 7);
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
            this.dateFrom.TabIndex = 6;
            this.dateFrom.EditValueChanged += new System.EventHandler(this.dateFrom_EditValueChanged);
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = false;
            this.documentViewer1.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(1364, 409);
            this.documentViewer1.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(1364, 114);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // gvData
            // 
            this.gvData.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvData.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Red;
            this.gvData.Appearance.FooterPanel.Options.UseFont = true;
            this.gvData.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.PaymentedByID,
            this.PaymentedByName,
            this.Cash,
            this.Bank,
            this.Grab,
            this.Shopee,
            this.Total});
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 40;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsBehavior.ReadOnly = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowFooter = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvData_CustomDrawRowIndicator);
            // 
            // PaymentedByID
            // 
            this.PaymentedByID.Caption = "Mã nhân viên";
            this.PaymentedByID.FieldName = "PaymentedByID";
            this.PaymentedByID.Name = "PaymentedByID";
            this.PaymentedByID.Visible = true;
            this.PaymentedByID.VisibleIndex = 0;
            this.PaymentedByID.Width = 100;
            // 
            // PaymentedByName
            // 
            this.PaymentedByName.Caption = "Tên nhân viên";
            this.PaymentedByName.FieldName = "PaymentedByName";
            this.PaymentedByName.Name = "PaymentedByName";
            this.PaymentedByName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PaymentedByName", "Tổng cộng")});
            this.PaymentedByName.Visible = true;
            this.PaymentedByName.VisibleIndex = 1;
            this.PaymentedByName.Width = 250;
            // 
            // Cash
            // 
            this.Cash.Caption = "Tiền mặt";
            this.Cash.DisplayFormat.FormatString = "n0";
            this.Cash.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Cash.FieldName = "Cash";
            this.Cash.Name = "Cash";
            this.Cash.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cash", "{0:N0}")});
            this.Cash.Visible = true;
            this.Cash.VisibleIndex = 2;
            this.Cash.Width = 100;
            // 
            // Bank
            // 
            this.Bank.Caption = "Chuyển khoản";
            this.Bank.DisplayFormat.FormatString = "n0";
            this.Bank.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Bank.FieldName = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Bank", "{0:N0}")});
            this.Bank.Visible = true;
            this.Bank.VisibleIndex = 3;
            this.Bank.Width = 100;
            // 
            // Grab
            // 
            this.Grab.Caption = "Grab";
            this.Grab.DisplayFormat.FormatString = "n0";
            this.Grab.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Grab.FieldName = "Grab";
            this.Grab.Name = "Grab";
            this.Grab.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Grab", "{0:N0}")});
            this.Grab.Visible = true;
            this.Grab.VisibleIndex = 4;
            this.Grab.Width = 100;
            // 
            // Shopee
            // 
            this.Shopee.Caption = "Shopee";
            this.Shopee.DisplayFormat.FormatString = "n0";
            this.Shopee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Shopee.FieldName = "Shopee";
            this.Shopee.Name = "Shopee";
            this.Shopee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Shopee", "{0:N0}")});
            this.Shopee.Visible = true;
            this.Shopee.VisibleIndex = 5;
            this.Shopee.Width = 100;
            // 
            // Total
            // 
            this.Total.Caption = "Tổng tiền";
            this.Total.DisplayFormat.FormatString = "n0";
            this.Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Total.FieldName = "Total";
            this.Total.Name = "Total";
            this.Total.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N0}")});
            this.Total.Visible = true;
            this.Total.VisibleIndex = 6;
            this.Total.Width = 100;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 35);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcData);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.documentViewer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1364, 533);
            this.splitContainerControl1.SplitterPosition = 114;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay";
            this.Text = "Tổng hợp doanh thu theo nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_FormClosed);
            this.Load += new System.EventHandler(this.pageReport_groupRevenue_SummaryOfRevenueByEmployeeInDay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployees.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit slkEmployees;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colActionBy;
        private DevExpress.XtraGrid.Columns.GridColumn colActionByName;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraGrid.GridControl gcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraGrid.Columns.GridColumn PaymentedByID;
        private DevExpress.XtraGrid.Columns.GridColumn PaymentedByName;
        private DevExpress.XtraGrid.Columns.GridColumn Cash;
        private DevExpress.XtraGrid.Columns.GridColumn Bank;
        private DevExpress.XtraGrid.Columns.GridColumn Grab;
        private DevExpress.XtraGrid.Columns.GridColumn Shopee;
        private DevExpress.XtraGrid.Columns.GridColumn Total;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}