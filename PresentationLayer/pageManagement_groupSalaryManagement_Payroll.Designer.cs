
namespace PresentationLayer
{
    partial class pageManagement_groupSalaryManagement_Payroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupSalaryManagement_Payroll));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.slkEmployee = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.slkEmployee_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.slkEmployee_gv_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkEmployee_gv_colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.datePayrollDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.datePayrollDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.gcListOfPayrolls = new DevExpress.XtraGrid.GridControl();
            this.gvListOfPayrolls = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvListOfPayrolls_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colCreatedBy_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvListOfPayrolls_colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colDateFrom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colDatetTo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colEmployeeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvListOfPayrolls_SalaryByHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colStatusID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvListOfPayrolls_colPaymentedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colPaymentedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colRecordTypeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvListOfPayrolls_colTotalSalary_Overtime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colTotalSalary_WokingDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvListOfPayrolls_colTotalSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcListOfPayrolls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls_colCreatedBy_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls_colEmployeeID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls_colStatusID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colRecordTypeID_lk)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.slkEmployee);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.datePayrollDateTo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.datePayrollDateFrom);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lkStatus);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 31);
            this.panelControl1.TabIndex = 9;
            // 
            // slkEmployee
            // 
            this.slkEmployee.Location = new System.Drawing.Point(414, 5);
            this.slkEmployee.Name = "slkEmployee";
            this.slkEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkEmployee.Properties.NullText = "";
            this.slkEmployee.Properties.PopupView = this.slkEmployee_gv;
            this.slkEmployee.Size = new System.Drawing.Size(219, 20);
            this.slkEmployee.TabIndex = 4;
            this.slkEmployee.Tag = "*";
            this.slkEmployee.EditValueChanged += new System.EventHandler(this.slkEmployee_EditValueChanged);
            // 
            // slkEmployee_gv
            // 
            this.slkEmployee_gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.slkEmployee_gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.slkEmployee_gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.slkEmployee_gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.slkEmployee_gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.slkEmployee_gv_colID,
            this.slkEmployee_gv_colFullName});
            this.slkEmployee_gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.slkEmployee_gv.IndicatorWidth = 50;
            this.slkEmployee_gv.Name = "slkEmployee_gv";
            this.slkEmployee_gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.slkEmployee_gv.OptionsView.ShowColumnHeaders = false;
            this.slkEmployee_gv.OptionsView.ShowGroupPanel = false;
            this.slkEmployee_gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.slkEmployee_gv_CustomDrawRowIndicator);
            // 
            // slkEmployee_gv_colID
            // 
            this.slkEmployee_gv_colID.Caption = "Mã nhân viên";
            this.slkEmployee_gv_colID.FieldName = "ID";
            this.slkEmployee_gv_colID.Name = "slkEmployee_gv_colID";
            // 
            // slkEmployee_gv_colFullName
            // 
            this.slkEmployee_gv_colFullName.Caption = "Họ và Tên";
            this.slkEmployee_gv_colFullName.FieldName = "FullName";
            this.slkEmployee_gv_colFullName.Name = "slkEmployee_gv_colFullName";
            this.slkEmployee_gv_colFullName.Visible = true;
            this.slkEmployee_gv_colFullName.VisibleIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(361, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Nhân viên";
            // 
            // btnGetData
            // 
            this.btnGetData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetData.ImageOptions.SvgImage")));
            this.btnGetData.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnGetData.Location = new System.Drawing.Point(840, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(88, 23);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "Lấy dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(639, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Trạng thái";
            // 
            // datePayrollDateTo
            // 
            this.datePayrollDateTo.EditValue = null;
            this.datePayrollDateTo.Location = new System.Drawing.Point(256, 5);
            this.datePayrollDateTo.Name = "datePayrollDateTo";
            this.datePayrollDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePayrollDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePayrollDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datePayrollDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePayrollDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datePayrollDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePayrollDateTo.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.datePayrollDateTo.Size = new System.Drawing.Size(100, 20);
            this.datePayrollDateTo.TabIndex = 2;
            this.datePayrollDateTo.Tag = "*";
            this.datePayrollDateTo.EditValueChanged += new System.EventHandler(this.datePayrollDateTo_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(205, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "đến ngày";
            // 
            // datePayrollDateFrom
            // 
            this.datePayrollDateFrom.EditValue = null;
            this.datePayrollDateFrom.Location = new System.Drawing.Point(99, 5);
            this.datePayrollDateFrom.Name = "datePayrollDateFrom";
            this.datePayrollDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePayrollDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datePayrollDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datePayrollDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePayrollDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datePayrollDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datePayrollDateFrom.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.datePayrollDateFrom.Size = new System.Drawing.Size(100, 20);
            this.datePayrollDateFrom.TabIndex = 1;
            this.datePayrollDateFrom.Tag = "*";
            this.datePayrollDateFrom.EditValueChanged += new System.EventHandler(this.datePayrollDateFrom_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Ngày lập: Từ ngày";
            // 
            // lkStatus
            // 
            this.lkStatus.Location = new System.Drawing.Point(693, 5);
            this.lkStatus.Name = "lkStatus";
            this.lkStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.lkStatus.Properties.NullText = "";
            this.lkStatus.Properties.ShowHeader = false;
            this.lkStatus.Size = new System.Drawing.Size(141, 20);
            this.lkStatus.TabIndex = 3;
            this.lkStatus.Tag = "*";
            this.lkStatus.EditValueChanged += new System.EventHandler(this.lkStatus_EditValueChanged);
            // 
            // gcListOfPayrolls
            // 
            this.gcListOfPayrolls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListOfPayrolls.Location = new System.Drawing.Point(0, 31);
            this.gcListOfPayrolls.MainView = this.gvListOfPayrolls;
            this.gcListOfPayrolls.Name = "gcListOfPayrolls";
            this.gcListOfPayrolls.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gvListOfPayrolls_colEmployeeID_lk,
            this.gvListOfPayrolls_colStatusID_lk,
            this.gvListOfPayrolls_colCreatedBy_lk,
            this.gvAttendanceData_colRecordTypeID_lk});
            this.gcListOfPayrolls.Size = new System.Drawing.Size(1364, 537);
            this.gcListOfPayrolls.TabIndex = 10;
            this.gcListOfPayrolls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListOfPayrolls});
            this.gcListOfPayrolls.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gcListOfPayrolls_MouseDoubleClick);
            // 
            // gvListOfPayrolls
            // 
            this.gvListOfPayrolls.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvListOfPayrolls.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Red;
            this.gvListOfPayrolls.Appearance.FooterPanel.Options.UseFont = true;
            this.gvListOfPayrolls.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvListOfPayrolls.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvListOfPayrolls.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvListOfPayrolls.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvListOfPayrolls.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvListOfPayrolls.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvListOfPayrolls_colID,
            this.gvListOfPayrolls_colCreatedBy,
            this.gvListOfPayrolls_colCreatedDate,
            this.gvListOfPayrolls_colDateFrom,
            this.gvListOfPayrolls_colDatetTo,
            this.gvListOfPayrolls_colEmployeeID,
            this.gvListOfPayrolls_SalaryByHour,
            this.gvListOfPayrolls_colStatusID,
            this.gvListOfPayrolls_colPaymentedBy,
            this.gvListOfPayrolls_colPaymentedDate,
            this.gvListOfPayrolls_colTotalSalary_Overtime,
            this.gvListOfPayrolls_colTotalSalary_WokingDay,
            this.gvListOfPayrolls_colTotalSalary});
            this.gvListOfPayrolls.GridControl = this.gcListOfPayrolls;
            this.gvListOfPayrolls.IndicatorWidth = 60;
            this.gvListOfPayrolls.Name = "gvListOfPayrolls";
            this.gvListOfPayrolls.OptionsBehavior.Editable = false;
            this.gvListOfPayrolls.OptionsBehavior.ReadOnly = true;
            this.gvListOfPayrolls.OptionsView.ColumnAutoWidth = false;
            this.gvListOfPayrolls.OptionsView.ShowAutoFilterRow = true;
            this.gvListOfPayrolls.OptionsView.ShowFooter = true;
            this.gvListOfPayrolls.OptionsView.ShowGroupPanel = false;
            this.gvListOfPayrolls.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvListOfPayrolls_CustomDrawRowIndicator);
            this.gvListOfPayrolls.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvListOfPayrolls_FocusedRowChanged);
            // 
            // gvListOfPayrolls_colID
            // 
            this.gvListOfPayrolls_colID.Caption = "ID";
            this.gvListOfPayrolls_colID.FieldName = "ID";
            this.gvListOfPayrolls_colID.Name = "gvListOfPayrolls_colID";
            this.gvListOfPayrolls_colID.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colID.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colID.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colID.Width = 100;
            // 
            // gvListOfPayrolls_colCreatedBy
            // 
            this.gvListOfPayrolls_colCreatedBy.Caption = "Người lập";
            this.gvListOfPayrolls_colCreatedBy.ColumnEdit = this.gvListOfPayrolls_colCreatedBy_lk;
            this.gvListOfPayrolls_colCreatedBy.FieldName = "CreatedBy";
            this.gvListOfPayrolls_colCreatedBy.Name = "gvListOfPayrolls_colCreatedBy";
            this.gvListOfPayrolls_colCreatedBy.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colCreatedBy.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colCreatedBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colCreatedBy.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colCreatedBy.Visible = true;
            this.gvListOfPayrolls_colCreatedBy.VisibleIndex = 5;
            this.gvListOfPayrolls_colCreatedBy.Width = 200;
            // 
            // gvListOfPayrolls_colCreatedBy_lk
            // 
            this.gvListOfPayrolls_colCreatedBy_lk.AutoHeight = false;
            this.gvListOfPayrolls_colCreatedBy_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvListOfPayrolls_colCreatedBy_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name17", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name18")});
            this.gvListOfPayrolls_colCreatedBy_lk.Name = "gvListOfPayrolls_colCreatedBy_lk";
            this.gvListOfPayrolls_colCreatedBy_lk.NullText = "";
            this.gvListOfPayrolls_colCreatedBy_lk.ShowHeader = false;
            // 
            // gvListOfPayrolls_colCreatedDate
            // 
            this.gvListOfPayrolls_colCreatedDate.Caption = "Ngày lập";
            this.gvListOfPayrolls_colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gvListOfPayrolls_colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvListOfPayrolls_colCreatedDate.FieldName = "CreatedDate";
            this.gvListOfPayrolls_colCreatedDate.Name = "gvListOfPayrolls_colCreatedDate";
            this.gvListOfPayrolls_colCreatedDate.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colCreatedDate.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colCreatedDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colCreatedDate.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colCreatedDate.Visible = true;
            this.gvListOfPayrolls_colCreatedDate.VisibleIndex = 4;
            this.gvListOfPayrolls_colCreatedDate.Width = 140;
            // 
            // gvListOfPayrolls_colDateFrom
            // 
            this.gvListOfPayrolls_colDateFrom.Caption = "Từ ngày";
            this.gvListOfPayrolls_colDateFrom.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gvListOfPayrolls_colDateFrom.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvListOfPayrolls_colDateFrom.FieldName = "DateFrom";
            this.gvListOfPayrolls_colDateFrom.Name = "gvListOfPayrolls_colDateFrom";
            this.gvListOfPayrolls_colDateFrom.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colDateFrom.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colDateFrom.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colDateFrom.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colDateFrom.Visible = true;
            this.gvListOfPayrolls_colDateFrom.VisibleIndex = 6;
            this.gvListOfPayrolls_colDateFrom.Width = 100;
            // 
            // gvListOfPayrolls_colDatetTo
            // 
            this.gvListOfPayrolls_colDatetTo.Caption = "Đến ngày";
            this.gvListOfPayrolls_colDatetTo.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gvListOfPayrolls_colDatetTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvListOfPayrolls_colDatetTo.FieldName = "DateTo";
            this.gvListOfPayrolls_colDatetTo.Name = "gvListOfPayrolls_colDatetTo";
            this.gvListOfPayrolls_colDatetTo.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colDatetTo.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colDatetTo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colDatetTo.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colDatetTo.Visible = true;
            this.gvListOfPayrolls_colDatetTo.VisibleIndex = 7;
            this.gvListOfPayrolls_colDatetTo.Width = 100;
            // 
            // gvListOfPayrolls_colEmployeeID
            // 
            this.gvListOfPayrolls_colEmployeeID.Caption = "Nhân viên";
            this.gvListOfPayrolls_colEmployeeID.ColumnEdit = this.gvListOfPayrolls_colEmployeeID_lk;
            this.gvListOfPayrolls_colEmployeeID.FieldName = "EmployeeID";
            this.gvListOfPayrolls_colEmployeeID.Name = "gvListOfPayrolls_colEmployeeID";
            this.gvListOfPayrolls_colEmployeeID.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colEmployeeID.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colEmployeeID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colEmployeeID.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colEmployeeID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "EmployeeID", "Tổng cộng")});
            this.gvListOfPayrolls_colEmployeeID.Visible = true;
            this.gvListOfPayrolls_colEmployeeID.VisibleIndex = 0;
            this.gvListOfPayrolls_colEmployeeID.Width = 200;
            // 
            // gvListOfPayrolls_colEmployeeID_lk
            // 
            this.gvListOfPayrolls_colEmployeeID_lk.AutoHeight = false;
            this.gvListOfPayrolls_colEmployeeID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvListOfPayrolls_colEmployeeID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name2")});
            this.gvListOfPayrolls_colEmployeeID_lk.Name = "gvListOfPayrolls_colEmployeeID_lk";
            this.gvListOfPayrolls_colEmployeeID_lk.NullText = "";
            this.gvListOfPayrolls_colEmployeeID_lk.ShowHeader = false;
            // 
            // gvListOfPayrolls_SalaryByHour
            // 
            this.gvListOfPayrolls_SalaryByHour.Caption = "Lương 1 giờ";
            this.gvListOfPayrolls_SalaryByHour.DisplayFormat.FormatString = "n0";
            this.gvListOfPayrolls_SalaryByHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvListOfPayrolls_SalaryByHour.FieldName = "SalaryByHour";
            this.gvListOfPayrolls_SalaryByHour.Name = "gvListOfPayrolls_SalaryByHour";
            this.gvListOfPayrolls_SalaryByHour.Visible = true;
            this.gvListOfPayrolls_SalaryByHour.VisibleIndex = 8;
            // 
            // gvListOfPayrolls_colStatusID
            // 
            this.gvListOfPayrolls_colStatusID.Caption = "Trạng thái";
            this.gvListOfPayrolls_colStatusID.ColumnEdit = this.gvListOfPayrolls_colStatusID_lk;
            this.gvListOfPayrolls_colStatusID.FieldName = "StatusID";
            this.gvListOfPayrolls_colStatusID.Name = "gvListOfPayrolls_colStatusID";
            this.gvListOfPayrolls_colStatusID.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colStatusID.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colStatusID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colStatusID.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colStatusID.Visible = true;
            this.gvListOfPayrolls_colStatusID.VisibleIndex = 9;
            this.gvListOfPayrolls_colStatusID.Width = 120;
            // 
            // gvListOfPayrolls_colStatusID_lk
            // 
            this.gvListOfPayrolls_colStatusID_lk.AutoHeight = false;
            this.gvListOfPayrolls_colStatusID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvListOfPayrolls_colStatusID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.gvListOfPayrolls_colStatusID_lk.Name = "gvListOfPayrolls_colStatusID_lk";
            this.gvListOfPayrolls_colStatusID_lk.NullText = "";
            this.gvListOfPayrolls_colStatusID_lk.ShowHeader = false;
            // 
            // gvListOfPayrolls_colPaymentedBy
            // 
            this.gvListOfPayrolls_colPaymentedBy.Caption = "Người thanh toán";
            this.gvListOfPayrolls_colPaymentedBy.ColumnEdit = this.gvListOfPayrolls_colCreatedBy_lk;
            this.gvListOfPayrolls_colPaymentedBy.FieldName = "PaymentedBy";
            this.gvListOfPayrolls_colPaymentedBy.Name = "gvListOfPayrolls_colPaymentedBy";
            this.gvListOfPayrolls_colPaymentedBy.Visible = true;
            this.gvListOfPayrolls_colPaymentedBy.VisibleIndex = 10;
            this.gvListOfPayrolls_colPaymentedBy.Width = 150;
            // 
            // gvListOfPayrolls_colPaymentedDate
            // 
            this.gvListOfPayrolls_colPaymentedDate.Caption = "Ngày thanh toán";
            this.gvListOfPayrolls_colPaymentedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gvListOfPayrolls_colPaymentedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvListOfPayrolls_colPaymentedDate.FieldName = "PaymentedDate";
            this.gvListOfPayrolls_colPaymentedDate.Name = "gvListOfPayrolls_colPaymentedDate";
            this.gvListOfPayrolls_colPaymentedDate.Visible = true;
            this.gvListOfPayrolls_colPaymentedDate.VisibleIndex = 11;
            this.gvListOfPayrolls_colPaymentedDate.Width = 120;
            // 
            // gvAttendanceData_colRecordTypeID_lk
            // 
            this.gvAttendanceData_colRecordTypeID_lk.AutoHeight = false;
            this.gvAttendanceData_colRecordTypeID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvAttendanceData_colRecordTypeID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name27", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name28")});
            this.gvAttendanceData_colRecordTypeID_lk.Name = "gvAttendanceData_colRecordTypeID_lk";
            this.gvAttendanceData_colRecordTypeID_lk.NullText = "";
            this.gvAttendanceData_colRecordTypeID_lk.ShowHeader = false;
            // 
            // gvListOfPayrolls_colTotalSalary_Overtime
            // 
            this.gvListOfPayrolls_colTotalSalary_Overtime.Caption = "Lương tăng ca";
            this.gvListOfPayrolls_colTotalSalary_Overtime.DisplayFormat.FormatString = "n0";
            this.gvListOfPayrolls_colTotalSalary_Overtime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvListOfPayrolls_colTotalSalary_Overtime.FieldName = "TotalSalary_Overtime";
            this.gvListOfPayrolls_colTotalSalary_Overtime.Name = "gvListOfPayrolls_colTotalSalary_Overtime";
            this.gvListOfPayrolls_colTotalSalary_Overtime.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colTotalSalary_Overtime.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colTotalSalary_Overtime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colTotalSalary_Overtime.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colTotalSalary_Overtime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalSalary_Overtime", "{0:n0}")});
            this.gvListOfPayrolls_colTotalSalary_Overtime.Visible = true;
            this.gvListOfPayrolls_colTotalSalary_Overtime.VisibleIndex = 2;
            this.gvListOfPayrolls_colTotalSalary_Overtime.Width = 90;
            // 
            // gvListOfPayrolls_colTotalSalary_WokingDay
            // 
            this.gvListOfPayrolls_colTotalSalary_WokingDay.Caption = "Tiền lương";
            this.gvListOfPayrolls_colTotalSalary_WokingDay.DisplayFormat.FormatString = "n0";
            this.gvListOfPayrolls_colTotalSalary_WokingDay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.FieldName = "TotalSalary_WokingDay";
            this.gvListOfPayrolls_colTotalSalary_WokingDay.Name = "gvListOfPayrolls_colTotalSalary_WokingDay";
            this.gvListOfPayrolls_colTotalSalary_WokingDay.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalSalary_WokingDay", "{0:n0}")});
            this.gvListOfPayrolls_colTotalSalary_WokingDay.Visible = true;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.VisibleIndex = 1;
            this.gvListOfPayrolls_colTotalSalary_WokingDay.Width = 90;
            // 
            // gvListOfPayrolls_colTotalSalary
            // 
            this.gvListOfPayrolls_colTotalSalary.Caption = "Tổng lương";
            this.gvListOfPayrolls_colTotalSalary.DisplayFormat.FormatString = "n0";
            this.gvListOfPayrolls_colTotalSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvListOfPayrolls_colTotalSalary.FieldName = "TotalSalary";
            this.gvListOfPayrolls_colTotalSalary.Name = "gvListOfPayrolls_colTotalSalary";
            this.gvListOfPayrolls_colTotalSalary.OptionsColumn.AllowEdit = false;
            this.gvListOfPayrolls_colTotalSalary.OptionsColumn.AllowMove = false;
            this.gvListOfPayrolls_colTotalSalary.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvListOfPayrolls_colTotalSalary.OptionsFilter.AllowFilter = false;
            this.gvListOfPayrolls_colTotalSalary.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalSalary", "{0:n0}")});
            this.gvListOfPayrolls_colTotalSalary.Visible = true;
            this.gvListOfPayrolls_colTotalSalary.VisibleIndex = 3;
            this.gvListOfPayrolls_colTotalSalary.Width = 90;
            // 
            // pageManagement_groupSalaryManagement_Payroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcListOfPayrolls);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageManagement_groupSalaryManagement_Payroll";
            this.Text = "Bảng lương";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageManagement_groupSalaryManagement_Payroll_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageManagement_groupSalaryManagement_Payroll_FormClosed);
            this.Load += new System.EventHandler(this.pageManagement_groupSalaryManagement_Payroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datePayrollDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcListOfPayrolls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls_colCreatedBy_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls_colEmployeeID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfPayrolls_colStatusID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colRecordTypeID_lk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit slkEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView slkEmployee_gv;
        private DevExpress.XtraGrid.Columns.GridColumn slkEmployee_gv_colID;
        private DevExpress.XtraGrid.Columns.GridColumn slkEmployee_gv_colFullName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit datePayrollDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit datePayrollDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkStatus;
        private DevExpress.XtraGrid.GridControl gcListOfPayrolls;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListOfPayrolls;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvListOfPayrolls_colCreatedBy_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colEmployeeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvListOfPayrolls_colEmployeeID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colDateFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colStatusID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvListOfPayrolls_colStatusID_lk;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvAttendanceData_colRecordTypeID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colDatetTo;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_SalaryByHour;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colPaymentedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colPaymentedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colTotalSalary_Overtime;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colTotalSalary_WokingDay;
        private DevExpress.XtraGrid.Columns.GridColumn gvListOfPayrolls_colTotalSalary;
    }
}