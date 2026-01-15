
namespace PresentationLayer
{
    partial class pageManagement_groupSalaryManagement_Overtime_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupSalaryManagement_Overtime_Edit));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Overtime_EmployeeID = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.Overtime_EmployeeID_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AttendanceData_EmployeeID_gv_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AttendanceData_EmployeeID_gv_colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Overtime_WorkingDate = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Overtime_WorkingDate_In = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Overtime_WorkingDate_Out = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_EmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_EmployeeID_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_In.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_Out.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.Overtime_WorkingDate_Out);
            this.layoutControl1.Controls.Add(this.Overtime_WorkingDate_In);
            this.layoutControl1.Controls.Add(this.Overtime_WorkingDate);
            this.layoutControl1.Controls.Add(this.Overtime_EmployeeID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(298, 142);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.emptySpaceItem4,
            this.layoutControlItem6,
            this.emptySpaceItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(298, 142);
            this.Root.TextVisible = false;
            // 
            // Overtime_EmployeeID
            // 
            this.Overtime_EmployeeID.Location = new System.Drawing.Point(97, 12);
            this.Overtime_EmployeeID.Name = "Overtime_EmployeeID";
            this.Overtime_EmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_EmployeeID.Properties.NullText = "";
            this.Overtime_EmployeeID.Properties.PopupView = this.Overtime_EmployeeID_gv;
            this.Overtime_EmployeeID.Size = new System.Drawing.Size(189, 20);
            this.Overtime_EmployeeID.StyleController = this.layoutControl1;
            this.Overtime_EmployeeID.TabIndex = 1;
            this.Overtime_EmployeeID.Tag = "*";
            // 
            // Overtime_EmployeeID_gv
            // 
            this.Overtime_EmployeeID_gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Overtime_EmployeeID_gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.Overtime_EmployeeID_gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.Overtime_EmployeeID_gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Overtime_EmployeeID_gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AttendanceData_EmployeeID_gv_colID,
            this.AttendanceData_EmployeeID_gv_colFullName});
            this.Overtime_EmployeeID_gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Overtime_EmployeeID_gv.IndicatorWidth = 50;
            this.Overtime_EmployeeID_gv.Name = "Overtime_EmployeeID_gv";
            this.Overtime_EmployeeID_gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.Overtime_EmployeeID_gv.OptionsView.ShowColumnHeaders = false;
            this.Overtime_EmployeeID_gv.OptionsView.ShowGroupPanel = false;
            this.Overtime_EmployeeID_gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.Overtime_EmployeeID_gv_CustomDrawRowIndicator);
            // 
            // AttendanceData_EmployeeID_gv_colID
            // 
            this.AttendanceData_EmployeeID_gv_colID.Caption = "Mã nhân viên";
            this.AttendanceData_EmployeeID_gv_colID.FieldName = "ID";
            this.AttendanceData_EmployeeID_gv_colID.Name = "AttendanceData_EmployeeID_gv_colID";
            // 
            // AttendanceData_EmployeeID_gv_colFullName
            // 
            this.AttendanceData_EmployeeID_gv_colFullName.Caption = "Họ và Tên";
            this.AttendanceData_EmployeeID_gv_colFullName.FieldName = "FullName";
            this.AttendanceData_EmployeeID_gv_colFullName.Name = "AttendanceData_EmployeeID_gv_colFullName";
            this.AttendanceData_EmployeeID_gv_colFullName.Visible = true;
            this.AttendanceData_EmployeeID_gv_colFullName.VisibleIndex = 0;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.Overtime_EmployeeID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem1.Text = "Nhân viên";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(252, 82);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(26, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Overtime_WorkingDate
            // 
            this.Overtime_WorkingDate.EditValue = null;
            this.Overtime_WorkingDate.Location = new System.Drawing.Point(97, 36);
            this.Overtime_WorkingDate.Name = "Overtime_WorkingDate";
            this.Overtime_WorkingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_WorkingDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_WorkingDate.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Overtime_WorkingDate.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd/MM/yyyy";
            this.Overtime_WorkingDate.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.Overtime_WorkingDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.Overtime_WorkingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.Overtime_WorkingDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.Overtime_WorkingDate.Size = new System.Drawing.Size(189, 20);
            this.Overtime_WorkingDate.StyleController = this.layoutControl1;
            this.Overtime_WorkingDate.TabIndex = 2;
            this.Overtime_WorkingDate.Tag = "*";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Overtime_WorkingDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(278, 24);
            this.layoutControlItem2.Text = "Ngày tăng ca";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // Overtime_WorkingDate_In
            // 
            this.Overtime_WorkingDate_In.EditValue = null;
            this.Overtime_WorkingDate_In.Location = new System.Drawing.Point(97, 60);
            this.Overtime_WorkingDate_In.Name = "Overtime_WorkingDate_In";
            this.Overtime_WorkingDate_In.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_WorkingDate_In.Properties.CalendarDateEditing = false;
            this.Overtime_WorkingDate_In.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties.EditFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "HH:mm");
            this.Overtime_WorkingDate_In.Properties.DisplayFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_In.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_In.Properties.EditFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_In.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_In.Properties.MaskSettings.Set("mask", "HH:mm");
            this.Overtime_WorkingDate_In.Size = new System.Drawing.Size(80, 20);
            this.Overtime_WorkingDate_In.StyleController = this.layoutControl1;
            this.Overtime_WorkingDate_In.TabIndex = 3;
            this.Overtime_WorkingDate_In.Tag = "*";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Overtime_WorkingDate_In;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(169, 24);
            this.layoutControlItem3.Text = "Giờ tăng ca: Từ";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // Overtime_WorkingDate_Out
            // 
            this.Overtime_WorkingDate_Out.EditValue = null;
            this.Overtime_WorkingDate_Out.Location = new System.Drawing.Point(206, 60);
            this.Overtime_WorkingDate_Out.Name = "Overtime_WorkingDate_Out";
            this.Overtime_WorkingDate_Out.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_WorkingDate_Out.Properties.CalendarDateEditing = false;
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties.EditFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "HH:mm");
            this.Overtime_WorkingDate_Out.Properties.DisplayFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_Out.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_Out.Properties.EditFormat.FormatString = "HH:mm";
            this.Overtime_WorkingDate_Out.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Overtime_WorkingDate_Out.Properties.MaskSettings.Set("mask", "HH:mm");
            this.Overtime_WorkingDate_Out.Size = new System.Drawing.Size(80, 20);
            this.Overtime_WorkingDate_Out.StyleController = this.layoutControl1;
            this.Overtime_WorkingDate_Out.TabIndex = 4;
            this.Overtime_WorkingDate_Out.Tag = "*";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Overtime_WorkingDate_Out;
            this.layoutControlItem4.Location = new System.Drawing.Point(169, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(109, 24);
            this.layoutControlItem4.Text = "đến";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(20, 20);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(156, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 36);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Hủy thao tác";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(38, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 36);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClose;
            this.layoutControlItem5.Location = new System.Drawing.Point(144, 82);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(108, 40);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnSave;
            this.layoutControlItem6.Location = new System.Drawing.Point(26, 82);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(108, 40);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 82);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(26, 40);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(134, 82);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(10, 40);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(278, 10);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // pageManagement_groupSalaryManagement_Overtime_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 142);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageManagement_groupSalaryManagement_Overtime_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tăng ca - Thao tác";
            this.Load += new System.EventHandler(this.pageManagement_groupSalaryManagement_Overtime_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_EmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_EmployeeID_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_In.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_In.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_Out.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Overtime_WorkingDate_Out.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SearchLookUpEdit Overtime_EmployeeID;
        private DevExpress.XtraGrid.Views.Grid.GridView Overtime_EmployeeID_gv;
        private DevExpress.XtraGrid.Columns.GridColumn AttendanceData_EmployeeID_gv_colID;
        private DevExpress.XtraGrid.Columns.GridColumn AttendanceData_EmployeeID_gv_colFullName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DateEdit Overtime_WorkingDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.DateEdit Overtime_WorkingDate_Out;
        private DevExpress.XtraEditors.DateEdit Overtime_WorkingDate_In;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
    }
}