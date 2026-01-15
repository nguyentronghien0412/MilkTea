
namespace PresentationLayer
{
    partial class pageManagement_groupSalaryManagement_Overtime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupSalaryManagement_Overtime));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.slkEmployee = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.slkEmployee_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.slkEmployee_gv_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.slkEmployee_gv_colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateWorkingDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateWorkingDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lkStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.gcOvertime = new DevExpress.XtraGrid.GridControl();
            this.gvOvertime = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvOvertime_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colPayrollID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colWorkingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colWorkingDate_In = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colWorkingDate_Out = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colWorkingDate_TotalHours = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colWorkingDate_TotalMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colSalaryByHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colStatusID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvOvertime_colEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colEmployeeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvOvertime_colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colCreatedBy_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvOvertime_colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colApprovedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colApprovedBy_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvOvertime_colApprovedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvOvertime_colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnApproved = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colStatusID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colEmployeeID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colCreatedBy_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colApprovedBy_lk)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnApproved);
            this.panelControl1.Controls.Add(this.slkEmployee);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.btnGetData);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.dateWorkingDateTo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dateWorkingDateFrom);
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
            this.slkEmployee.Location = new System.Drawing.Point(619, 5);
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
            this.labelControl4.Location = new System.Drawing.Point(565, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Nhân viên";
            // 
            // btnGetData
            // 
            this.btnGetData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGetData.ImageOptions.SvgImage")));
            this.btnGetData.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnGetData.Location = new System.Drawing.Point(844, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(88, 23);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "Lấy dữ liệu";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(363, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Trạng thái";
            // 
            // dateWorkingDateTo
            // 
            this.dateWorkingDateTo.EditValue = null;
            this.dateWorkingDateTo.Location = new System.Drawing.Point(257, 5);
            this.dateWorkingDateTo.Name = "dateWorkingDateTo";
            this.dateWorkingDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWorkingDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWorkingDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateWorkingDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWorkingDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateWorkingDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWorkingDateTo.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateWorkingDateTo.Size = new System.Drawing.Size(100, 20);
            this.dateWorkingDateTo.TabIndex = 2;
            this.dateWorkingDateTo.Tag = "*";
            this.dateWorkingDateTo.EditValueChanged += new System.EventHandler(this.dateWorkingDateTo_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(206, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "đến ngày";
            // 
            // dateWorkingDateFrom
            // 
            this.dateWorkingDateFrom.EditValue = null;
            this.dateWorkingDateFrom.Location = new System.Drawing.Point(100, 5);
            this.dateWorkingDateFrom.Name = "dateWorkingDateFrom";
            this.dateWorkingDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWorkingDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateWorkingDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateWorkingDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWorkingDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateWorkingDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateWorkingDateFrom.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dateWorkingDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dateWorkingDateFrom.TabIndex = 1;
            this.dateWorkingDateFrom.Tag = "*";
            this.dateWorkingDateFrom.EditValueChanged += new System.EventHandler(this.dateWorkingDateFrom_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tăng ca: Từ ngày";
            // 
            // lkStatus
            // 
            this.lkStatus.Location = new System.Drawing.Point(418, 5);
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
            // gcOvertime
            // 
            this.gcOvertime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcOvertime.Location = new System.Drawing.Point(0, 31);
            this.gcOvertime.MainView = this.gvOvertime;
            this.gcOvertime.Name = "gcOvertime";
            this.gcOvertime.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gvOvertime_colStatusID_lk,
            this.gvOvertime_colEmployeeID_lk,
            this.gvOvertime_colCreatedBy_lk,
            this.gvOvertime_colApprovedBy_lk});
            this.gcOvertime.Size = new System.Drawing.Size(1364, 537);
            this.gcOvertime.TabIndex = 10;
            this.gcOvertime.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOvertime});
            // 
            // gvOvertime
            // 
            this.gvOvertime.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvOvertime.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Red;
            this.gvOvertime.Appearance.FooterPanel.Options.UseFont = true;
            this.gvOvertime.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gvOvertime.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvOvertime.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvOvertime.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvOvertime.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvOvertime.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvOvertime_colID,
            this.gvOvertime_colPayrollID,
            this.gvOvertime_colWorkingDate,
            this.gvOvertime_colWorkingDate_In,
            this.gvOvertime_colWorkingDate_Out,
            this.gvOvertime_colWorkingDate_TotalHours,
            this.gvOvertime_colWorkingDate_TotalMinutes,
            this.gvOvertime_colSalaryByHour,
            this.gvOvertime_colTotal,
            this.gvOvertime_colStatusID,
            this.gvOvertime_colEmployeeID,
            this.gvOvertime_colCreatedBy,
            this.gvOvertime_colCreatedDate,
            this.gvOvertime_colApprovedBy,
            this.gvOvertime_colApprovedDate,
            this.gvOvertime_colUpdatedBy,
            this.gvOvertime_colUpdatedDate});
            this.gvOvertime.GridControl = this.gcOvertime;
            this.gvOvertime.IndicatorWidth = 60;
            this.gvOvertime.Name = "gvOvertime";
            this.gvOvertime.OptionsBehavior.Editable = false;
            this.gvOvertime.OptionsView.ColumnAutoWidth = false;
            this.gvOvertime.OptionsView.ShowFooter = true;
            this.gvOvertime.OptionsView.ShowGroupPanel = false;
            this.gvOvertime.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvOvertime_CustomDrawRowIndicator);
            this.gvOvertime.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvOvertime_FocusedRowChanged);
            // 
            // gvOvertime_colID
            // 
            this.gvOvertime_colID.Caption = "ID";
            this.gvOvertime_colID.FieldName = "ID";
            this.gvOvertime_colID.Name = "gvOvertime_colID";
            // 
            // gvOvertime_colPayrollID
            // 
            this.gvOvertime_colPayrollID.Caption = "PayrollID";
            this.gvOvertime_colPayrollID.FieldName = "PayrollID";
            this.gvOvertime_colPayrollID.Name = "gvOvertime_colPayrollID";
            // 
            // gvOvertime_colWorkingDate
            // 
            this.gvOvertime_colWorkingDate.Caption = "Ngày tăng ca";
            this.gvOvertime_colWorkingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gvOvertime_colWorkingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvOvertime_colWorkingDate.FieldName = "WorkingDate";
            this.gvOvertime_colWorkingDate.Name = "gvOvertime_colWorkingDate";
            this.gvOvertime_colWorkingDate.OptionsColumn.AllowMove = false;
            this.gvOvertime_colWorkingDate.Visible = true;
            this.gvOvertime_colWorkingDate.VisibleIndex = 2;
            this.gvOvertime_colWorkingDate.Width = 90;
            // 
            // gvOvertime_colWorkingDate_In
            // 
            this.gvOvertime_colWorkingDate_In.Caption = "Tăng ca từ";
            this.gvOvertime_colWorkingDate_In.DisplayFormat.FormatString = "HH:mm";
            this.gvOvertime_colWorkingDate_In.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvOvertime_colWorkingDate_In.FieldName = "WorkingDate_In";
            this.gvOvertime_colWorkingDate_In.Name = "gvOvertime_colWorkingDate_In";
            this.gvOvertime_colWorkingDate_In.OptionsColumn.AllowMove = false;
            this.gvOvertime_colWorkingDate_In.Visible = true;
            this.gvOvertime_colWorkingDate_In.VisibleIndex = 3;
            this.gvOvertime_colWorkingDate_In.Width = 80;
            // 
            // gvOvertime_colWorkingDate_Out
            // 
            this.gvOvertime_colWorkingDate_Out.Caption = "Tăng ca đến";
            this.gvOvertime_colWorkingDate_Out.DisplayFormat.FormatString = "HH:mm";
            this.gvOvertime_colWorkingDate_Out.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvOvertime_colWorkingDate_Out.FieldName = "WorkingDate_Out";
            this.gvOvertime_colWorkingDate_Out.Name = "gvOvertime_colWorkingDate_Out";
            this.gvOvertime_colWorkingDate_Out.OptionsColumn.AllowMove = false;
            this.gvOvertime_colWorkingDate_Out.Visible = true;
            this.gvOvertime_colWorkingDate_Out.VisibleIndex = 4;
            this.gvOvertime_colWorkingDate_Out.Width = 80;
            // 
            // gvOvertime_colWorkingDate_TotalHours
            // 
            this.gvOvertime_colWorkingDate_TotalHours.Caption = "Tổng số giờ";
            this.gvOvertime_colWorkingDate_TotalHours.FieldName = "WorkingDate_TotalHours";
            this.gvOvertime_colWorkingDate_TotalHours.Name = "gvOvertime_colWorkingDate_TotalHours";
            this.gvOvertime_colWorkingDate_TotalHours.OptionsColumn.AllowMove = false;
            this.gvOvertime_colWorkingDate_TotalHours.Visible = true;
            this.gvOvertime_colWorkingDate_TotalHours.VisibleIndex = 5;
            // 
            // gvOvertime_colWorkingDate_TotalMinutes
            // 
            this.gvOvertime_colWorkingDate_TotalMinutes.Caption = "Tổng số phút";
            this.gvOvertime_colWorkingDate_TotalMinutes.FieldName = "WorkingDate_TotalMinutes";
            this.gvOvertime_colWorkingDate_TotalMinutes.Name = "gvOvertime_colWorkingDate_TotalMinutes";
            this.gvOvertime_colWorkingDate_TotalMinutes.OptionsColumn.AllowMove = false;
            this.gvOvertime_colWorkingDate_TotalMinutes.Visible = true;
            this.gvOvertime_colWorkingDate_TotalMinutes.VisibleIndex = 6;
            this.gvOvertime_colWorkingDate_TotalMinutes.Width = 90;
            // 
            // gvOvertime_colSalaryByHour
            // 
            this.gvOvertime_colSalaryByHour.Caption = "Mức lương";
            this.gvOvertime_colSalaryByHour.DisplayFormat.FormatString = "n0";
            this.gvOvertime_colSalaryByHour.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvOvertime_colSalaryByHour.FieldName = "SalaryByHour";
            this.gvOvertime_colSalaryByHour.Name = "gvOvertime_colSalaryByHour";
            this.gvOvertime_colSalaryByHour.OptionsColumn.AllowMove = false;
            this.gvOvertime_colSalaryByHour.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "SalaryByHour", "Tổng cộng")});
            this.gvOvertime_colSalaryByHour.ToolTip = "(VNĐ/Giờ)";
            this.gvOvertime_colSalaryByHour.Visible = true;
            this.gvOvertime_colSalaryByHour.VisibleIndex = 7;
            this.gvOvertime_colSalaryByHour.Width = 80;
            // 
            // gvOvertime_colTotal
            // 
            this.gvOvertime_colTotal.Caption = "Thành tiền";
            this.gvOvertime_colTotal.DisplayFormat.FormatString = "n0";
            this.gvOvertime_colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvOvertime_colTotal.FieldName = "Total";
            this.gvOvertime_colTotal.Name = "gvOvertime_colTotal";
            this.gvOvertime_colTotal.OptionsColumn.AllowMove = false;
            this.gvOvertime_colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n0}")});
            this.gvOvertime_colTotal.Visible = true;
            this.gvOvertime_colTotal.VisibleIndex = 8;
            this.gvOvertime_colTotal.Width = 80;
            // 
            // gvOvertime_colStatusID
            // 
            this.gvOvertime_colStatusID.Caption = "Trạng thái";
            this.gvOvertime_colStatusID.ColumnEdit = this.gvOvertime_colStatusID_lk;
            this.gvOvertime_colStatusID.FieldName = "StatusID";
            this.gvOvertime_colStatusID.Name = "gvOvertime_colStatusID";
            this.gvOvertime_colStatusID.OptionsColumn.AllowEdit = false;
            this.gvOvertime_colStatusID.OptionsColumn.AllowMove = false;
            this.gvOvertime_colStatusID.Visible = true;
            this.gvOvertime_colStatusID.VisibleIndex = 1;
            this.gvOvertime_colStatusID.Width = 100;
            // 
            // gvOvertime_colStatusID_lk
            // 
            this.gvOvertime_colStatusID_lk.AutoHeight = false;
            this.gvOvertime_colStatusID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvOvertime_colStatusID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.gvOvertime_colStatusID_lk.Name = "gvOvertime_colStatusID_lk";
            this.gvOvertime_colStatusID_lk.NullText = "";
            this.gvOvertime_colStatusID_lk.ShowHeader = false;
            // 
            // gvOvertime_colEmployeeID
            // 
            this.gvOvertime_colEmployeeID.Caption = "Nhân viên";
            this.gvOvertime_colEmployeeID.ColumnEdit = this.gvOvertime_colEmployeeID_lk;
            this.gvOvertime_colEmployeeID.FieldName = "EmployeeID";
            this.gvOvertime_colEmployeeID.Name = "gvOvertime_colEmployeeID";
            this.gvOvertime_colEmployeeID.OptionsColumn.AllowEdit = false;
            this.gvOvertime_colEmployeeID.OptionsColumn.AllowMove = false;
            this.gvOvertime_colEmployeeID.Visible = true;
            this.gvOvertime_colEmployeeID.VisibleIndex = 0;
            this.gvOvertime_colEmployeeID.Width = 200;
            // 
            // gvOvertime_colEmployeeID_lk
            // 
            this.gvOvertime_colEmployeeID_lk.AutoHeight = false;
            this.gvOvertime_colEmployeeID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvOvertime_colEmployeeID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name4")});
            this.gvOvertime_colEmployeeID_lk.Name = "gvOvertime_colEmployeeID_lk";
            this.gvOvertime_colEmployeeID_lk.NullText = "";
            this.gvOvertime_colEmployeeID_lk.ShowHeader = false;
            // 
            // gvOvertime_colCreatedBy
            // 
            this.gvOvertime_colCreatedBy.Caption = "Người tạo";
            this.gvOvertime_colCreatedBy.ColumnEdit = this.gvOvertime_colCreatedBy_lk;
            this.gvOvertime_colCreatedBy.FieldName = "CreatedBy";
            this.gvOvertime_colCreatedBy.Name = "gvOvertime_colCreatedBy";
            this.gvOvertime_colCreatedBy.OptionsColumn.AllowMove = false;
            this.gvOvertime_colCreatedBy.Visible = true;
            this.gvOvertime_colCreatedBy.VisibleIndex = 9;
            this.gvOvertime_colCreatedBy.Width = 120;
            // 
            // gvOvertime_colCreatedBy_lk
            // 
            this.gvOvertime_colCreatedBy_lk.AutoHeight = false;
            this.gvOvertime_colCreatedBy_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvOvertime_colCreatedBy_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name5"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name6")});
            this.gvOvertime_colCreatedBy_lk.Name = "gvOvertime_colCreatedBy_lk";
            this.gvOvertime_colCreatedBy_lk.NullText = "";
            this.gvOvertime_colCreatedBy_lk.ShowHeader = false;
            // 
            // gvOvertime_colCreatedDate
            // 
            this.gvOvertime_colCreatedDate.Caption = "Ngày tạo";
            this.gvOvertime_colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gvOvertime_colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvOvertime_colCreatedDate.FieldName = "CreatedDate";
            this.gvOvertime_colCreatedDate.Name = "gvOvertime_colCreatedDate";
            this.gvOvertime_colCreatedDate.OptionsColumn.AllowMove = false;
            this.gvOvertime_colCreatedDate.Visible = true;
            this.gvOvertime_colCreatedDate.VisibleIndex = 10;
            this.gvOvertime_colCreatedDate.Width = 100;
            // 
            // gvOvertime_colApprovedBy
            // 
            this.gvOvertime_colApprovedBy.Caption = "Người duyệt";
            this.gvOvertime_colApprovedBy.ColumnEdit = this.gvOvertime_colApprovedBy_lk;
            this.gvOvertime_colApprovedBy.FieldName = "ApprovedBy";
            this.gvOvertime_colApprovedBy.Name = "gvOvertime_colApprovedBy";
            this.gvOvertime_colApprovedBy.OptionsColumn.AllowMove = false;
            this.gvOvertime_colApprovedBy.Visible = true;
            this.gvOvertime_colApprovedBy.VisibleIndex = 11;
            this.gvOvertime_colApprovedBy.Width = 120;
            // 
            // gvOvertime_colApprovedBy_lk
            // 
            this.gvOvertime_colApprovedBy_lk.AutoHeight = false;
            this.gvOvertime_colApprovedBy_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvOvertime_colApprovedBy_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name7", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Name8")});
            this.gvOvertime_colApprovedBy_lk.Name = "gvOvertime_colApprovedBy_lk";
            this.gvOvertime_colApprovedBy_lk.NullText = "";
            this.gvOvertime_colApprovedBy_lk.ShowHeader = false;
            // 
            // gvOvertime_colApprovedDate
            // 
            this.gvOvertime_colApprovedDate.Caption = "Ngày duyệt";
            this.gvOvertime_colApprovedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gvOvertime_colApprovedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvOvertime_colApprovedDate.FieldName = "ApprovedDate";
            this.gvOvertime_colApprovedDate.Name = "gvOvertime_colApprovedDate";
            this.gvOvertime_colApprovedDate.OptionsColumn.AllowMove = false;
            this.gvOvertime_colApprovedDate.Visible = true;
            this.gvOvertime_colApprovedDate.VisibleIndex = 12;
            this.gvOvertime_colApprovedDate.Width = 100;
            // 
            // gvOvertime_colUpdatedBy
            // 
            this.gvOvertime_colUpdatedBy.Caption = "Người cập nhật";
            this.gvOvertime_colUpdatedBy.FieldName = "UpdatedBy";
            this.gvOvertime_colUpdatedBy.Name = "gvOvertime_colUpdatedBy";
            // 
            // gvOvertime_colUpdatedDate
            // 
            this.gvOvertime_colUpdatedDate.Caption = "Ngày cập nhật";
            this.gvOvertime_colUpdatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gvOvertime_colUpdatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvOvertime_colUpdatedDate.FieldName = "UpdatedDate";
            this.gvOvertime_colUpdatedDate.Name = "gvOvertime_colUpdatedDate";
            // 
            // btnApproved
            // 
            this.btnApproved.Enabled = false;
            this.btnApproved.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnApproved.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnApproved.Location = new System.Drawing.Point(939, 4);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(102, 23);
            this.btnApproved.TabIndex = 8;
            this.btnApproved.Text = "Duyệt tăng ca";
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // pageManagement_groupSalaryManagement_Overtime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcOvertime);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageManagement_groupSalaryManagement_Overtime";
            this.Text = "Tăng ca";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageManagement_groupSalaryManagement_Overtime_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageManagement_groupSalaryManagement_Overtime_FormClosed);
            this.Load += new System.EventHandler(this.pageManagement_groupSalaryManagement_Overtime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateWorkingDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colStatusID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colEmployeeID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colCreatedBy_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOvertime_colApprovedBy_lk)).EndInit();
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
        private DevExpress.XtraEditors.DateEdit dateWorkingDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dateWorkingDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkStatus;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcOvertime;
        private DevExpress.XtraGrid.Views.Grid.GridView gvOvertime;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colStatusID;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colPayrollID;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colWorkingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colWorkingDate_In;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colWorkingDate_Out;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colWorkingDate_TotalHours;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colWorkingDate_TotalMinutes;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colSalaryByHour;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colTotal;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvOvertime_colStatusID_lk;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvOvertime_colEmployeeID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colCreatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvOvertime_colCreatedBy_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colApprovedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvOvertime_colApprovedBy_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colApprovedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gvOvertime_colUpdatedDate;
        private DevExpress.XtraEditors.SimpleButton btnApproved;
    }
}