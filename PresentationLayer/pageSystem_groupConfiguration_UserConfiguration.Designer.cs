
namespace PresentationLayer
{
    partial class pageSystem_groupConfiguration_UserConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSystem_groupConfiguration_UserConfiguration));
            this.gcDefinition = new DevExpress.XtraGrid.GridControl();
            this.gvDefinition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinitionGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDefinitionGroupID_rlkDefinitionGroup = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colValueImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValueImage_pic = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.glkPrinterSticker = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.glkPrinterBill = new DevExpress.XtraEditors.GridLookUpEdit();
            this.glkPrinterBill_gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.glkPrinterBill_gv_colPrinterName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glkPrinterBill_gv_colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glkPrinterBill_gv_colDefault = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.glkPrinterBill_gv_colNetwork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.btnSendMail = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefinition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDefinitionGroupID_rlkDefinitionGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colValueImage_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glkPrinterSticker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkPrinterBill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkPrinterBill_gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcDefinition
            // 
            this.gcDefinition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDefinition.Location = new System.Drawing.Point(0, 0);
            this.gcDefinition.MainView = this.gvDefinition;
            this.gcDefinition.Name = "gcDefinition";
            this.gcDefinition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colDefinitionGroupID_rlkDefinitionGroup,
            this.colValueImage_pic});
            this.gcDefinition.Size = new System.Drawing.Size(975, 485);
            this.gcDefinition.TabIndex = 1;
            this.gcDefinition.Tag = "Translate@Name";
            this.gcDefinition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDefinition});
            // 
            // gvDefinition
            // 
            this.gvDefinition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvDefinition.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDefinition.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDefinition.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDefinition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colCode,
            this.colValue,
            this.colDefinitionGroupID,
            this.colValueImage});
            this.gvDefinition.GridControl = this.gcDefinition;
            this.gvDefinition.GroupCount = 1;
            this.gvDefinition.GroupFormat = "[#image]{1} {2}";
            this.gvDefinition.IndicatorWidth = 40;
            this.gvDefinition.Name = "gvDefinition";
            this.gvDefinition.OptionsBehavior.Editable = false;
            this.gvDefinition.OptionsBehavior.ReadOnly = true;
            this.gvDefinition.OptionsView.ColumnAutoWidth = false;
            this.gvDefinition.OptionsView.ShowAutoFilterRow = true;
            this.gvDefinition.OptionsView.ShowGroupPanel = false;
            this.gvDefinition.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDefinitionGroupID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDefinition.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvDefinition_RowCellClick);
            this.gvDefinition.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvDefinition_CustomDrawRowIndicator);
            this.gvDefinition.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDefinition_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Width = 79;
            // 
            // colName
            // 
            this.colName.Caption = "Tên thông số";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 270;
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã thông số";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.ReadOnly = true;
            this.colCode.Width = 120;
            // 
            // colValue
            // 
            this.colValue.Caption = "Giá trị";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 538;
            // 
            // colDefinitionGroupID
            // 
            this.colDefinitionGroupID.Caption = "Nhóm thông số";
            this.colDefinitionGroupID.ColumnEdit = this.colDefinitionGroupID_rlkDefinitionGroup;
            this.colDefinitionGroupID.FieldName = "DefinitionGroupID";
            this.colDefinitionGroupID.Name = "colDefinitionGroupID";
            this.colDefinitionGroupID.OptionsColumn.AllowEdit = false;
            this.colDefinitionGroupID.OptionsColumn.ReadOnly = true;
            this.colDefinitionGroupID.Visible = true;
            this.colDefinitionGroupID.VisibleIndex = 2;
            this.colDefinitionGroupID.Width = 94;
            // 
            // colDefinitionGroupID_rlkDefinitionGroup
            // 
            this.colDefinitionGroupID_rlkDefinitionGroup.AutoHeight = false;
            this.colDefinitionGroupID_rlkDefinitionGroup.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.colDefinitionGroupID_rlkDefinitionGroup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colDefinitionGroupID_rlkDefinitionGroup.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.colDefinitionGroupID_rlkDefinitionGroup.Name = "colDefinitionGroupID_rlkDefinitionGroup";
            this.colDefinitionGroupID_rlkDefinitionGroup.NullText = "";
            this.colDefinitionGroupID_rlkDefinitionGroup.Tag = "Translate@Name";
            // 
            // colValueImage
            // 
            this.colValueImage.Caption = "Hình ảnh";
            this.colValueImage.FieldName = "ValueImage";
            this.colValueImage.Name = "colValueImage";
            this.colValueImage.UnboundDataType = typeof(byte);
            this.colValueImage.Visible = true;
            this.colValueImage.VisibleIndex = 2;
            // 
            // colValueImage_pic
            // 
            this.colValueImage_pic.Name = "colValueImage_pic";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSendMail);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(975, 55);
            this.panelControl1.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.glkPrinterSticker);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.glkPrinterBill);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(558, 51);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Máy in";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(299, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Máy in Sticker";
            // 
            // glkPrinterSticker
            // 
            this.glkPrinterSticker.Location = new System.Drawing.Point(370, 26);
            this.glkPrinterSticker.Name = "glkPrinterSticker";
            this.glkPrinterSticker.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.glkPrinterSticker.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glkPrinterSticker.Properties.NullText = "";
            this.glkPrinterSticker.Properties.PopupView = this.gridView1;
            this.glkPrinterSticker.Properties.ReadOnly = true;
            this.glkPrinterSticker.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.glkPrinterSticker.Size = new System.Drawing.Size(181, 20);
            this.glkPrinterSticker.TabIndex = 3;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.IndicatorWidth = 40;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên máy in";
            this.gridColumn1.FieldName = "PrinterName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 200;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Trạng thái";
            this.gridColumn2.FieldName = "Status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mặc định";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn3.FieldName = "Default";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 100;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Network";
            this.gridColumn4.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn4.FieldName = "Network";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 100;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Máy in phiếu tính tiền";
            // 
            // glkPrinterBill
            // 
            this.glkPrinterBill.Location = new System.Drawing.Point(113, 26);
            this.glkPrinterBill.Name = "glkPrinterBill";
            this.glkPrinterBill.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.glkPrinterBill.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glkPrinterBill.Properties.NullText = "";
            this.glkPrinterBill.Properties.PopupView = this.glkPrinterBill_gv;
            this.glkPrinterBill.Properties.ReadOnly = true;
            this.glkPrinterBill.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.glkPrinterBill.Size = new System.Drawing.Size(181, 20);
            this.glkPrinterBill.TabIndex = 1;
            // 
            // glkPrinterBill_gv
            // 
            this.glkPrinterBill_gv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.glkPrinterBill_gv.Appearance.HeaderPanel.Options.UseFont = true;
            this.glkPrinterBill_gv.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.glkPrinterBill_gv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.glkPrinterBill_gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.glkPrinterBill_gv_colPrinterName,
            this.glkPrinterBill_gv_colStatus,
            this.glkPrinterBill_gv_colDefault,
            this.glkPrinterBill_gv_colNetwork});
            this.glkPrinterBill_gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.glkPrinterBill_gv.IndicatorWidth = 40;
            this.glkPrinterBill_gv.Name = "glkPrinterBill_gv";
            this.glkPrinterBill_gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.glkPrinterBill_gv.OptionsView.ColumnAutoWidth = false;
            this.glkPrinterBill_gv.OptionsView.ShowGroupPanel = false;
            this.glkPrinterBill_gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.glkPrinterBill_gv_CustomDrawRowIndicator);
            // 
            // glkPrinterBill_gv_colPrinterName
            // 
            this.glkPrinterBill_gv_colPrinterName.Caption = "Tên máy in";
            this.glkPrinterBill_gv_colPrinterName.FieldName = "PrinterName";
            this.glkPrinterBill_gv_colPrinterName.Name = "glkPrinterBill_gv_colPrinterName";
            this.glkPrinterBill_gv_colPrinterName.Visible = true;
            this.glkPrinterBill_gv_colPrinterName.VisibleIndex = 0;
            this.glkPrinterBill_gv_colPrinterName.Width = 200;
            // 
            // glkPrinterBill_gv_colStatus
            // 
            this.glkPrinterBill_gv_colStatus.Caption = "Trạng thái";
            this.glkPrinterBill_gv_colStatus.FieldName = "Status";
            this.glkPrinterBill_gv_colStatus.Name = "glkPrinterBill_gv_colStatus";
            this.glkPrinterBill_gv_colStatus.Visible = true;
            this.glkPrinterBill_gv_colStatus.VisibleIndex = 1;
            this.glkPrinterBill_gv_colStatus.Width = 100;
            // 
            // glkPrinterBill_gv_colDefault
            // 
            this.glkPrinterBill_gv_colDefault.Caption = "Mặc định";
            this.glkPrinterBill_gv_colDefault.ColumnEdit = this.repositoryItemCheckEdit1;
            this.glkPrinterBill_gv_colDefault.FieldName = "Default";
            this.glkPrinterBill_gv_colDefault.Name = "glkPrinterBill_gv_colDefault";
            this.glkPrinterBill_gv_colDefault.Visible = true;
            this.glkPrinterBill_gv_colDefault.VisibleIndex = 2;
            this.glkPrinterBill_gv_colDefault.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // glkPrinterBill_gv_colNetwork
            // 
            this.glkPrinterBill_gv_colNetwork.Caption = "Network";
            this.glkPrinterBill_gv_colNetwork.ColumnEdit = this.repositoryItemCheckEdit1;
            this.glkPrinterBill_gv_colNetwork.FieldName = "Network";
            this.glkPrinterBill_gv_colNetwork.Name = "glkPrinterBill_gv_colNetwork";
            this.glkPrinterBill_gv_colNetwork.Visible = true;
            this.glkPrinterBill_gv_colNetwork.VisibleIndex = 3;
            this.glkPrinterBill_gv_colNetwork.Width = 100;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gcDefinition);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 55);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(975, 485);
            this.panelControl2.TabIndex = 3;
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            this.xtraOpenFileDialog1.Filter = "PNG files (*.png)|*.png";
            // 
            // btnSendMail
            // 
            this.btnSendMail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnSendMail.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnSendMail.Location = new System.Drawing.Point(566, 7);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(198, 40);
            this.btnSendMail.TabIndex = 1;
            this.btnSendMail.Text = "Gửi email báo cáo doanh thu";
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // pageSystem_groupConfiguration_UserConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 540);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageSystem_groupConfiguration_UserConfiguration";
            this.Text = "Cấu hình người dùng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageSystem_groupConfiguration_UserConfiguration_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.pageSystem_groupConfiguration_UserConfiguration_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageSystem_groupConfiguration_UserConfiguration_FormClosed);
            this.Load += new System.EventHandler(this.pageSystem_groupConfiguration_UserConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDefinition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colDefinitionGroupID_rlkDefinitionGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colValueImage_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.glkPrinterSticker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkPrinterBill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glkPrinterBill_gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDefinition;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDefinition;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDefinitionGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colDefinitionGroupID_rlkDefinitionGroup;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GridLookUpEdit glkPrinterBill;
        private DevExpress.XtraGrid.Views.Grid.GridView glkPrinterBill_gv;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn glkPrinterBill_gv_colPrinterName;
        private DevExpress.XtraGrid.Columns.GridColumn glkPrinterBill_gv_colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn glkPrinterBill_gv_colDefault;
        private DevExpress.XtraGrid.Columns.GridColumn glkPrinterBill_gv_colNetwork;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colValueImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit colValueImage_pic;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit glkPrinterSticker;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnSendMail;
    }
}