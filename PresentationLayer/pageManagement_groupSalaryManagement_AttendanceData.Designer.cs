
namespace PresentationLayer
{
    partial class pageManagement_groupSalaryManagement_AttendanceData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupSalaryManagement_AttendanceData));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.slkEmployee = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.slkEmployee_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.slkEmployee_gv_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkEmployee_gv_colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateAttendanceTimeTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateAttendanceTimeFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.gcAttendanceData = new DevExpress.XtraGrid.GridControl();
            this.gvAttendanceData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvAttendanceData_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colCreatedBy_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvAttendanceData_colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colEmployeeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvAttendanceData_colAttendanceTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colStatusID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvAttendanceData_colCancelDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colCancelBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colRecordTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvAttendanceData_colRecordTypeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvAttendanceData_colEmployeeID_ChangeShift = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttendanceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colCreatedBy_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colEmployeeID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colStatusID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colRecordTypeID_lk)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.slkEmployee);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.dateAttendanceTimeTo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateAttendanceTimeFrom);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lkStatus);
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 31);
            this.panelControl1.TabIndex = 8;
            // 
            // slkEmployee
            // 
            this.slkEmployee.Location = new System.Drawing.Point(630, 5);
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
            this.labelControl4.Location = new System.Drawing.Point(576, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Nhân viên";
            // 
            // btnGetData
            // 
            this.btnGetData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetData.ImageOptions.SvgImage")));
            this.btnGetData.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnGetData.Location = new System.Drawing.Point(855, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(88, 23);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "Lấy dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(374, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Trạng thái";
            // 
            // dateAttendanceTimeTo
            // 
            this.dateAttendanceTimeTo.EditValue = null;
            this.dateAttendanceTimeTo.Location = new System.Drawing.Point(268, 5);
            this.dateAttendanceTimeTo.Name = "dateAttendanceTimeTo";
            this.dateAttendanceTimeTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAttendanceTimeTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAttendanceTimeTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateAttendanceTimeTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateAttendanceTimeTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateAttendanceTimeTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateAttendanceTimeTo.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateAttendanceTimeTo.Size = new System.Drawing.Size(100, 20);
            this.dateAttendanceTimeTo.TabIndex = 2;
            this.dateAttendanceTimeTo.Tag = "*";
            this.dateAttendanceTimeTo.EditValueChanged += new System.EventHandler(this.dateAttendanceTimeTo_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(217, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "đến ngày";
            // 
            // dateAttendanceTimeFrom
            // 
            this.dateAttendanceTimeFrom.EditValue = null;
            this.dateAttendanceTimeFrom.Location = new System.Drawing.Point(111, 5);
            this.dateAttendanceTimeFrom.Name = "dateAttendanceTimeFrom";
            this.dateAttendanceTimeFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAttendanceTimeFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateAttendanceTimeFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateAttendanceTimeFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateAttendanceTimeFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateAttendanceTimeFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateAttendanceTimeFrom.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateAttendanceTimeFrom.Size = new System.Drawing.Size(100, 20);
            this.dateAttendanceTimeFrom.TabIndex = 1;
            this.dateAttendanceTimeFrom.Tag = "*";
            this.dateAttendanceTimeFrom.EditValueChanged += new System.EventHandler(this.dateAttendanceTimeFrom_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Chấm công: Từ ngày";
            // 
            // lkStatus
            // 
            this.lkStatus.Location = new System.Drawing.Point(429, 5);
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
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(1235, 6);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(75, 20);
            this.chkExpand.TabIndex = 0;
            this.chkExpand.Visible = false;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // gcAttendanceData
            // 
            this.gcAttendanceData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAttendanceData.Location = new System.Drawing.Point(0, 31);
            this.gcAttendanceData.MainView = this.gvAttendanceData;
            this.gcAttendanceData.Name = "gcAttendanceData";
            this.gcAttendanceData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gvAttendanceData_colEmployeeID_lk,
            this.gvAttendanceData_colStatusID_lk,
            this.gvAttendanceData_colCreatedBy_lk,
            this.gvAttendanceData_colRecordTypeID_lk});
            this.gcAttendanceData.Size = new System.Drawing.Size(1364, 520);
            this.gcAttendanceData.TabIndex = 6;
            this.gcAttendanceData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttendanceData});
            // 
            // gvAttendanceData
            // 
            this.gvAttendanceData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvAttendanceData.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvAttendanceData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvAttendanceData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvAttendanceData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvAttendanceData_colID,
            this.gvAttendanceData_colCreatedDate,
            this.gvAttendanceData_colCreatedBy,
            this.gvAttendanceData_colEmployeeID,
            this.gvAttendanceData_colAttendanceTime,
            this.gvAttendanceData_colStatusID,
            this.gvAttendanceData_colCancelDate,
            this.gvAttendanceData_colCancelBy,
            this.gvAttendanceData_colRecordTypeID,
            this.gvAttendanceData_colEmployeeID_ChangeShift});
            this.gvAttendanceData.GridControl = this.gcAttendanceData;
            this.gvAttendanceData.IndicatorWidth = 60;
            this.gvAttendanceData.Name = "gvAttendanceData";
            this.gvAttendanceData.OptionsBehavior.Editable = false;
            this.gvAttendanceData.OptionsBehavior.ReadOnly = true;
            this.gvAttendanceData.OptionsView.ColumnAutoWidth = false;
            this.gvAttendanceData.OptionsView.ShowAutoFilterRow = true;
            this.gvAttendanceData.OptionsView.ShowGroupPanel = false;
            this.gvAttendanceData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvAttendanceData_CustomDrawRowIndicator);
            this.gvAttendanceData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvAttendanceData_FocusedRowChanged);
            // 
            // gvAttendanceData_colID
            // 
            this.gvAttendanceData_colID.Caption = "ID";
            this.gvAttendanceData_colID.FieldName = "ID";
            this.gvAttendanceData_colID.Name = "gvAttendanceData_colID";
            this.gvAttendanceData_colID.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colID.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colID.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colID.Width = 100;
            // 
            // gvAttendanceData_colCreatedDate
            // 
            this.gvAttendanceData_colCreatedDate.Caption = "Ngày tạo";
            this.gvAttendanceData_colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gvAttendanceData_colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvAttendanceData_colCreatedDate.FieldName = "CreatedDate";
            this.gvAttendanceData_colCreatedDate.Name = "gvAttendanceData_colCreatedDate";
            this.gvAttendanceData_colCreatedDate.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colCreatedDate.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colCreatedDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colCreatedDate.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colCreatedDate.Visible = true;
            this.gvAttendanceData_colCreatedDate.VisibleIndex = 6;
            this.gvAttendanceData_colCreatedDate.Width = 140;
            // 
            // gvAttendanceData_colCreatedBy
            // 
            this.gvAttendanceData_colCreatedBy.Caption = "Người tạo";
            this.gvAttendanceData_colCreatedBy.ColumnEdit = this.gvAttendanceData_colCreatedBy_lk;
            this.gvAttendanceData_colCreatedBy.FieldName = "CreatedBy";
            this.gvAttendanceData_colCreatedBy.Name = "gvAttendanceData_colCreatedBy";
            this.gvAttendanceData_colCreatedBy.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colCreatedBy.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colCreatedBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colCreatedBy.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colCreatedBy.Visible = true;
            this.gvAttendanceData_colCreatedBy.VisibleIndex = 5;
            this.gvAttendanceData_colCreatedBy.Width = 150;
            // 
            // gvAttendanceData_colCreatedBy_lk
            // 
            this.gvAttendanceData_colCreatedBy_lk.AutoHeight = false;
            this.gvAttendanceData_colCreatedBy_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvAttendanceData_colCreatedBy_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UserID", "Name17", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name18")});
            this.gvAttendanceData_colCreatedBy_lk.Name = "gvAttendanceData_colCreatedBy_lk";
            this.gvAttendanceData_colCreatedBy_lk.NullText = "";
            this.gvAttendanceData_colCreatedBy_lk.ShowHeader = false;
            // 
            // gvAttendanceData_colEmployeeID
            // 
            this.gvAttendanceData_colEmployeeID.Caption = "Nhân viên";
            this.gvAttendanceData_colEmployeeID.ColumnEdit = this.gvAttendanceData_colEmployeeID_lk;
            this.gvAttendanceData_colEmployeeID.FieldName = "EmployeeID";
            this.gvAttendanceData_colEmployeeID.Name = "gvAttendanceData_colEmployeeID";
            this.gvAttendanceData_colEmployeeID.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colEmployeeID.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colEmployeeID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colEmployeeID.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colEmployeeID.Visible = true;
            this.gvAttendanceData_colEmployeeID.VisibleIndex = 0;
            this.gvAttendanceData_colEmployeeID.Width = 150;
            // 
            // gvAttendanceData_colEmployeeID_lk
            // 
            this.gvAttendanceData_colEmployeeID_lk.AutoHeight = false;
            this.gvAttendanceData_colEmployeeID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvAttendanceData_colEmployeeID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name2")});
            this.gvAttendanceData_colEmployeeID_lk.Name = "gvAttendanceData_colEmployeeID_lk";
            this.gvAttendanceData_colEmployeeID_lk.NullText = "";
            this.gvAttendanceData_colEmployeeID_lk.ShowHeader = false;
            // 
            // gvAttendanceData_colAttendanceTime
            // 
            this.gvAttendanceData_colAttendanceTime.Caption = "Giờ chấm công";
            this.gvAttendanceData_colAttendanceTime.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gvAttendanceData_colAttendanceTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvAttendanceData_colAttendanceTime.FieldName = "AttendanceTime";
            this.gvAttendanceData_colAttendanceTime.Name = "gvAttendanceData_colAttendanceTime";
            this.gvAttendanceData_colAttendanceTime.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colAttendanceTime.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colAttendanceTime.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colAttendanceTime.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colAttendanceTime.Visible = true;
            this.gvAttendanceData_colAttendanceTime.VisibleIndex = 1;
            this.gvAttendanceData_colAttendanceTime.Width = 140;
            // 
            // gvAttendanceData_colStatusID
            // 
            this.gvAttendanceData_colStatusID.Caption = "Trạng thái";
            this.gvAttendanceData_colStatusID.ColumnEdit = this.gvAttendanceData_colStatusID_lk;
            this.gvAttendanceData_colStatusID.FieldName = "StatusID";
            this.gvAttendanceData_colStatusID.Name = "gvAttendanceData_colStatusID";
            this.gvAttendanceData_colStatusID.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colStatusID.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colStatusID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colStatusID.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colStatusID.Visible = true;
            this.gvAttendanceData_colStatusID.VisibleIndex = 4;
            this.gvAttendanceData_colStatusID.Width = 120;
            // 
            // gvAttendanceData_colStatusID_lk
            // 
            this.gvAttendanceData_colStatusID_lk.AutoHeight = false;
            this.gvAttendanceData_colStatusID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvAttendanceData_colStatusID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.gvAttendanceData_colStatusID_lk.Name = "gvAttendanceData_colStatusID_lk";
            this.gvAttendanceData_colStatusID_lk.NullText = "";
            this.gvAttendanceData_colStatusID_lk.ShowHeader = false;
            // 
            // gvAttendanceData_colCancelDate
            // 
            this.gvAttendanceData_colCancelDate.Caption = "Ngày hủy";
            this.gvAttendanceData_colCancelDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gvAttendanceData_colCancelDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvAttendanceData_colCancelDate.FieldName = "CancelDate";
            this.gvAttendanceData_colCancelDate.Name = "gvAttendanceData_colCancelDate";
            this.gvAttendanceData_colCancelDate.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colCancelDate.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colCancelDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colCancelDate.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colCancelDate.Visible = true;
            this.gvAttendanceData_colCancelDate.VisibleIndex = 8;
            this.gvAttendanceData_colCancelDate.Width = 140;
            // 
            // gvAttendanceData_colCancelBy
            // 
            this.gvAttendanceData_colCancelBy.Caption = "Người hủy";
            this.gvAttendanceData_colCancelBy.ColumnEdit = this.gvAttendanceData_colCreatedBy_lk;
            this.gvAttendanceData_colCancelBy.FieldName = "CancelBy";
            this.gvAttendanceData_colCancelBy.Name = "gvAttendanceData_colCancelBy";
            this.gvAttendanceData_colCancelBy.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colCancelBy.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colCancelBy.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colCancelBy.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colCancelBy.Visible = true;
            this.gvAttendanceData_colCancelBy.VisibleIndex = 7;
            this.gvAttendanceData_colCancelBy.Width = 150;
            // 
            // gvAttendanceData_colRecordTypeID
            // 
            this.gvAttendanceData_colRecordTypeID.Caption = "Loại chấm công";
            this.gvAttendanceData_colRecordTypeID.ColumnEdit = this.gvAttendanceData_colRecordTypeID_lk;
            this.gvAttendanceData_colRecordTypeID.FieldName = "RecordTypeID";
            this.gvAttendanceData_colRecordTypeID.Name = "gvAttendanceData_colRecordTypeID";
            this.gvAttendanceData_colRecordTypeID.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colRecordTypeID.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colRecordTypeID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colRecordTypeID.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colRecordTypeID.Visible = true;
            this.gvAttendanceData_colRecordTypeID.VisibleIndex = 2;
            this.gvAttendanceData_colRecordTypeID.Width = 100;
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
            // gvAttendanceData_colEmployeeID_ChangeShift
            // 
            this.gvAttendanceData_colEmployeeID_ChangeShift.Caption = "Đổi ca";
            this.gvAttendanceData_colEmployeeID_ChangeShift.ColumnEdit = this.gvAttendanceData_colEmployeeID_lk;
            this.gvAttendanceData_colEmployeeID_ChangeShift.FieldName = "EmployeeID_ChangeShift";
            this.gvAttendanceData_colEmployeeID_ChangeShift.Name = "gvAttendanceData_colEmployeeID_ChangeShift";
            this.gvAttendanceData_colEmployeeID_ChangeShift.OptionsColumn.AllowEdit = false;
            this.gvAttendanceData_colEmployeeID_ChangeShift.OptionsColumn.AllowMove = false;
            this.gvAttendanceData_colEmployeeID_ChangeShift.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvAttendanceData_colEmployeeID_ChangeShift.OptionsFilter.AllowFilter = false;
            this.gvAttendanceData_colEmployeeID_ChangeShift.Visible = true;
            this.gvAttendanceData_colEmployeeID_ChangeShift.VisibleIndex = 3;
            this.gvAttendanceData_colEmployeeID_ChangeShift.Width = 150;
            // 
            // pageManagement_groupSalaryManagement_AttendanceData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 551);
            this.Controls.Add(this.gcAttendanceData);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageManagement_groupSalaryManagement_AttendanceData";
            this.Text = "Dữ liệu chấm công";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageManagement_groupSalaryManagement_AttendanceData_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageManagement_groupSalaryManagement_AttendanceData_FormClosed);
            this.Load += new System.EventHandler(this.pageManagement_groupSalaryManagement_AttendanceData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateAttendanceTimeFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttendanceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colCreatedBy_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colEmployeeID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colStatusID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendanceData_colRecordTypeID_lk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkStatus;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraGrid.GridControl gcAttendanceData;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttendanceData;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvAttendanceData_colEmployeeID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colAttendanceTime;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colStatusID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvAttendanceData_colStatusID_lk;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateAttendanceTimeTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateAttendanceTimeFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.SearchLookUpEdit slkEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView slkEmployee_gv;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn slkEmployee_gv_colID;
        private DevExpress.XtraGrid.Columns.GridColumn slkEmployee_gv_colFullName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvAttendanceData_colCreatedBy_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colCancelDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colCancelBy;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colRecordTypeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvAttendanceData_colRecordTypeID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvAttendanceData_colEmployeeID_ChangeShift;
    }
}