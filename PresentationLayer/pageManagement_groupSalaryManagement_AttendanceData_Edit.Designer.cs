
namespace PresentationLayer
{
    partial class pageManagement_groupSalaryManagement_AttendanceData_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupSalaryManagement_AttendanceData_Edit));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.slkChangeShift = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkChangeShift = new DevExpress.XtraEditors.CheckEdit();
            this.AttendanceData_RecordTypeID = new DevExpress.XtraEditors.LookUpEdit();
            this.AttendanceData_AttendanceTime = new DevExpress.XtraEditors.DateEdit();
            this.AttendanceData_EmployeeID = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.slkEmployee_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AttendanceData_EmployeeID_gv_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AttendanceData_EmployeeID_gv_colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkChangeShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangeShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_RecordTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_AttendanceTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_EmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.slkChangeShift);
            this.layoutControl1.Controls.Add(this.chkChangeShift);
            this.layoutControl1.Controls.Add(this.AttendanceData_RecordTypeID);
            this.layoutControl1.Controls.Add(this.btnClose);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.AttendanceData_AttendanceTime);
            this.layoutControl1.Controls.Add(this.AttendanceData_EmployeeID);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(314, 157);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(164, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 36);
            this.btnClose.StyleController = this.layoutControl1;
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Hủy thao tác";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(46, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 36);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(314, 157);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(260, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(34, 41);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSave;
            this.layoutControlItem3.Location = new System.Drawing.Point(34, 96);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(108, 41);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnClose;
            this.layoutControlItem4.Location = new System.Drawing.Point(152, 96);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(108, 41);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(142, 96);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 41);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(34, 41);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // slkChangeShift
            // 
            this.slkChangeShift.Location = new System.Drawing.Point(96, 84);
            this.slkChangeShift.Name = "slkChangeShift";
            this.slkChangeShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.slkChangeShift.Properties.NullText = "";
            this.slkChangeShift.Properties.PopupView = this.gridView1;
            this.slkChangeShift.Properties.ReadOnly = true;
            this.slkChangeShift.Size = new System.Drawing.Size(206, 20);
            this.slkChangeShift.StyleController = this.layoutControl1;
            this.slkChangeShift.TabIndex = 5;
            this.slkChangeShift.Tag = "";
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.IndicatorWidth = 50;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã nhân viên";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Họ và Tên";
            this.gridColumn2.FieldName = "FullName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // chkChangeShift
            // 
            this.chkChangeShift.Location = new System.Drawing.Point(12, 84);
            this.chkChangeShift.Name = "chkChangeShift";
            this.chkChangeShift.Properties.Caption = "Đổi ca";
            this.chkChangeShift.Size = new System.Drawing.Size(80, 20);
            this.chkChangeShift.StyleController = this.layoutControl1;
            this.chkChangeShift.TabIndex = 4;
            this.chkChangeShift.CheckedChanged += new System.EventHandler(this.chkChangeShift_CheckedChanged);
            // 
            // AttendanceData_RecordTypeID
            // 
            this.AttendanceData_RecordTypeID.Location = new System.Drawing.Point(97, 60);
            this.AttendanceData_RecordTypeID.Name = "AttendanceData_RecordTypeID";
            this.AttendanceData_RecordTypeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AttendanceData_RecordTypeID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name25", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name26")});
            this.AttendanceData_RecordTypeID.Properties.NullText = "";
            this.AttendanceData_RecordTypeID.Properties.ShowHeader = false;
            this.AttendanceData_RecordTypeID.Size = new System.Drawing.Size(205, 20);
            this.AttendanceData_RecordTypeID.StyleController = this.layoutControl1;
            this.AttendanceData_RecordTypeID.TabIndex = 3;
            this.AttendanceData_RecordTypeID.Tag = "*";
            this.AttendanceData_RecordTypeID.EditValueChanged += new System.EventHandler(this.AttendanceData_RecordTypeID_EditValueChanged);
            // 
            // AttendanceData_AttendanceTime
            // 
            this.AttendanceData_AttendanceTime.EditValue = null;
            this.AttendanceData_AttendanceTime.Location = new System.Drawing.Point(97, 36);
            this.AttendanceData_AttendanceTime.Name = "AttendanceData_AttendanceTime";
            this.AttendanceData_AttendanceTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties.MaskSettings.Set("mask", "dd/MM/yyyy HH:mm");
            this.AttendanceData_AttendanceTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.AttendanceData_AttendanceTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AttendanceData_AttendanceTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.AttendanceData_AttendanceTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.AttendanceData_AttendanceTime.Properties.MaskSettings.Set("mask", "dd/MM/yyyy HH:mm");
            this.AttendanceData_AttendanceTime.Size = new System.Drawing.Size(205, 20);
            this.AttendanceData_AttendanceTime.StyleController = this.layoutControl1;
            this.AttendanceData_AttendanceTime.TabIndex = 2;
            this.AttendanceData_AttendanceTime.Tag = "*";
            // 
            // AttendanceData_EmployeeID
            // 
            this.AttendanceData_EmployeeID.Location = new System.Drawing.Point(97, 12);
            this.AttendanceData_EmployeeID.Name = "AttendanceData_EmployeeID";
            this.AttendanceData_EmployeeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.AttendanceData_EmployeeID.Properties.NullText = "";
            this.AttendanceData_EmployeeID.Properties.PopupView = this.slkEmployee_gv;
            this.AttendanceData_EmployeeID.Size = new System.Drawing.Size(205, 20);
            this.AttendanceData_EmployeeID.StyleController = this.layoutControl1;
            this.AttendanceData_EmployeeID.TabIndex = 1;
            this.AttendanceData_EmployeeID.Tag = "*";
            this.AttendanceData_EmployeeID.EditValueChanged += new System.EventHandler(this.AttendanceData_EmployeeID_EditValueChanged);
            // 
            // slkEmployee_gv
            // 
            this.slkEmployee_gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.slkEmployee_gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.slkEmployee_gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.slkEmployee_gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.slkEmployee_gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AttendanceData_EmployeeID_gv_colID,
            this.AttendanceData_EmployeeID_gv_colFullName});
            this.slkEmployee_gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.slkEmployee_gv.IndicatorWidth = 50;
            this.slkEmployee_gv.Name = "slkEmployee_gv";
            this.slkEmployee_gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.slkEmployee_gv.OptionsView.ShowColumnHeaders = false;
            this.slkEmployee_gv.OptionsView.ShowGroupPanel = false;
            this.slkEmployee_gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.slkEmployee_gv_CustomDrawRowIndicator);
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
            this.layoutControlItem1.Control = this.AttendanceData_EmployeeID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem1.Text = "Nhân viên";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.AttendanceData_AttendanceTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem2.Text = "Giờ chấm công";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.AttendanceData_RecordTypeID;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(294, 24);
            this.layoutControlItem5.Text = "Loại chấm công";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(80, 20);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkChangeShift;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(84, 24);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.slkChangeShift;
            this.layoutControlItem7.Location = new System.Drawing.Point(84, 72);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(210, 24);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // pageManagement_groupSalaryManagement_AttendanceData_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 157);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageManagement_groupSalaryManagement_AttendanceData_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dữ liệu chấm công - Thao tác";
            this.Load += new System.EventHandler(this.pageManagement_groupSalaryManagement_AttendanceData_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkChangeShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangeShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_RecordTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_AttendanceTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_AttendanceTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceData_EmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slkEmployee_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SearchLookUpEdit AttendanceData_EmployeeID;
        private DevExpress.XtraGrid.Views.Grid.GridView slkEmployee_gv;
        private DevExpress.XtraGrid.Columns.GridColumn AttendanceData_EmployeeID_gv_colID;
        private DevExpress.XtraGrid.Columns.GridColumn AttendanceData_EmployeeID_gv_colFullName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.DateEdit AttendanceData_AttendanceTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.LookUpEdit AttendanceData_RecordTypeID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CheckEdit chkChangeShift;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SearchLookUpEdit slkChangeShift;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}