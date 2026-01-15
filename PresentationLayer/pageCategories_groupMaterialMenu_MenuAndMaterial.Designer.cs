
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_MenuAndMaterial
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvMaterials = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvMaterials_colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colMenuID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colUnitID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcMenuAndMaterials = new DevExpress.XtraGrid.GridControl();
            this.gvMenu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvMenu_colMenuGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenu_colMenuGroupID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvMenu_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenu_colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenu_colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenu_colSizeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMenu_colSizeID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::PresentationLayer.pageSystem_groupUser_UserAdministrator_WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials_colUnitID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMenuAndMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu_colMenuGroupID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu_colSizeID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gvMaterials
            // 
            this.gvMaterials.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvMaterials.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMaterials.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMaterials.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMaterials.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gvMaterials.Appearance.Row.Options.UseBackColor = true;
            this.gvMaterials.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvMaterials_colCode,
            this.gvMaterials_colName,
            this.gvMaterials_colID,
            this.gvMaterials_colQuantity,
            this.gvMaterials_colMenuID,
            this.gvMaterials_colUnitID});
            this.gvMaterials.GridControl = this.gcMenuAndMaterials;
            this.gvMaterials.IndicatorWidth = 40;
            this.gvMaterials.Name = "gvMaterials";
            this.gvMaterials.OptionsBehavior.Editable = false;
            this.gvMaterials.OptionsBehavior.ReadOnly = true;
            this.gvMaterials.OptionsView.ColumnAutoWidth = false;
            this.gvMaterials.OptionsView.ShowColumnHeaders = false;
            this.gvMaterials.OptionsView.ShowGroupPanel = false;
            this.gvMaterials.OptionsView.ShowIndicator = false;
            this.gvMaterials.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMaterials_CustomDrawRowIndicator);
            // 
            // gvMaterials_colCode
            // 
            this.gvMaterials_colCode.Caption = "Mã nguyên liệu";
            this.gvMaterials_colCode.FieldName = "Code";
            this.gvMaterials_colCode.Name = "gvMaterials_colCode";
            this.gvMaterials_colCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvMaterials_colCode.Width = 96;
            // 
            // gvMaterials_colName
            // 
            this.gvMaterials_colName.Caption = "Tên nguyên liệu";
            this.gvMaterials_colName.FieldName = "Name";
            this.gvMaterials_colName.Name = "gvMaterials_colName";
            this.gvMaterials_colName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvMaterials_colName.Visible = true;
            this.gvMaterials_colName.VisibleIndex = 0;
            this.gvMaterials_colName.Width = 120;
            // 
            // gvMaterials_colID
            // 
            this.gvMaterials_colID.Caption = "Mã ID";
            this.gvMaterials_colID.FieldName = "ID";
            this.gvMaterials_colID.Name = "gvMaterials_colID";
            // 
            // gvMaterials_colQuantity
            // 
            this.gvMaterials_colQuantity.Caption = "Số lượng";
            this.gvMaterials_colQuantity.DisplayFormat.FormatString = "n2";
            this.gvMaterials_colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvMaterials_colQuantity.FieldName = "Quantity";
            this.gvMaterials_colQuantity.Name = "gvMaterials_colQuantity";
            this.gvMaterials_colQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvMaterials_colQuantity.Visible = true;
            this.gvMaterials_colQuantity.VisibleIndex = 1;
            this.gvMaterials_colQuantity.Width = 60;
            // 
            // gvMaterials_colMenuID
            // 
            this.gvMaterials_colMenuID.Caption = "MenuID";
            this.gvMaterials_colMenuID.FieldName = "MenuID";
            this.gvMaterials_colMenuID.Name = "gvMaterials_colMenuID";
            // 
            // gvMaterials_colUnitID
            // 
            this.gvMaterials_colUnitID.Caption = "Đơn vị tính";
            this.gvMaterials_colUnitID.ColumnEdit = this.gvMaterials_colUnitID_lk;
            this.gvMaterials_colUnitID.FieldName = "UnitID";
            this.gvMaterials_colUnitID.Name = "gvMaterials_colUnitID";
            this.gvMaterials_colUnitID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gvMaterials_colUnitID.Visible = true;
            this.gvMaterials_colUnitID.VisibleIndex = 2;
            // 
            // gvMaterials_colUnitID_lk
            // 
            this.gvMaterials_colUnitID_lk.AutoHeight = false;
            this.gvMaterials_colUnitID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvMaterials_colUnitID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.gvMaterials_colUnitID_lk.Name = "gvMaterials_colUnitID_lk";
            this.gvMaterials_colUnitID_lk.NullText = "";
            // 
            // gcMenuAndMaterials
            // 
            this.gcMenuAndMaterials.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcMenuAndMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gvMaterials;
            gridLevelNode1.RelationName = "Level1";
            this.gcMenuAndMaterials.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcMenuAndMaterials.Location = new System.Drawing.Point(0, 29);
            this.gcMenuAndMaterials.MainView = this.gvMenu;
            this.gcMenuAndMaterials.Name = "gcMenuAndMaterials";
            this.gcMenuAndMaterials.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1,
            this.gvMenu_colMenuGroupID_lk,
            this.gvMaterials_colUnitID_lk,
            this.gvMenu_colSizeID_lk});
            this.gcMenuAndMaterials.Size = new System.Drawing.Size(1364, 539);
            this.gcMenuAndMaterials.TabIndex = 29;
            this.gcMenuAndMaterials.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenu,
            this.gvMaterials});
            // 
            // gvMenu
            // 
            this.gvMenu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvMenu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMenu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMenu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMenu.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(221)))), ((int)(((byte)(238)))));
            this.gvMenu.Appearance.Row.BackColor2 = System.Drawing.Color.White;
            this.gvMenu.Appearance.Row.Options.UseBackColor = true;
            this.gvMenu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvMenu_colMenuGroupID,
            this.gvMenu_colID,
            this.gvMenu_colCode,
            this.gvMenu_colName,
            this.gvMenu_colSizeID});
            this.gvMenu.CustomizationFormBounds = new System.Drawing.Rectangle(1390, 669, 210, 172);
            this.gvMenu.GridControl = this.gcMenuAndMaterials;
            this.gvMenu.GroupCount = 1;
            this.gvMenu.GroupFormat = "[#image]{1} {2}";
            this.gvMenu.IndicatorWidth = 50;
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.OptionsBehavior.Editable = false;
            this.gvMenu.OptionsBehavior.ReadOnly = true;
            this.gvMenu.OptionsDetail.ShowDetailTabs = false;
            this.gvMenu.OptionsPrint.ExpandAllDetails = true;
            this.gvMenu.OptionsPrint.PrintDetails = true;
            this.gvMenu.OptionsPrint.UsePrintStyles = false;
            this.gvMenu.OptionsView.ColumnAutoWidth = false;
            this.gvMenu.OptionsView.ShowGroupPanel = false;
            this.gvMenu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gvMenu_colMenuGroupID, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMenu.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvMenu_RowClick);
            this.gvMenu.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMenu_CustomDrawRowIndicator);
            this.gvMenu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMenu_FocusedRowChanged);
            // 
            // gvMenu_colMenuGroupID
            // 
            this.gvMenu_colMenuGroupID.Caption = "Nhóm thực đơn";
            this.gvMenu_colMenuGroupID.ColumnEdit = this.gvMenu_colMenuGroupID_lk;
            this.gvMenu_colMenuGroupID.FieldName = "MenuGroupID";
            this.gvMenu_colMenuGroupID.Name = "gvMenu_colMenuGroupID";
            this.gvMenu_colMenuGroupID.Visible = true;
            this.gvMenu_colMenuGroupID.VisibleIndex = 0;
            this.gvMenu_colMenuGroupID.Width = 150;
            // 
            // gvMenu_colMenuGroupID_lk
            // 
            this.gvMenu_colMenuGroupID_lk.AutoHeight = false;
            this.gvMenu_colMenuGroupID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvMenu_colMenuGroupID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name17", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name18")});
            this.gvMenu_colMenuGroupID_lk.Name = "gvMenu_colMenuGroupID_lk";
            this.gvMenu_colMenuGroupID_lk.NullText = "";
            // 
            // gvMenu_colID
            // 
            this.gvMenu_colID.Caption = "Mã ID";
            this.gvMenu_colID.FieldName = "ID";
            this.gvMenu_colID.Name = "gvMenu_colID";
            // 
            // gvMenu_colCode
            // 
            this.gvMenu_colCode.Caption = "Mã thực đơn";
            this.gvMenu_colCode.FieldName = "Code";
            this.gvMenu_colCode.Name = "gvMenu_colCode";
            this.gvMenu_colCode.Width = 84;
            // 
            // gvMenu_colName
            // 
            this.gvMenu_colName.AppearanceCell.Options.UseTextOptions = true;
            this.gvMenu_colName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvMenu_colName.Caption = "Tên thực đơn";
            this.gvMenu_colName.FieldName = "Name";
            this.gvMenu_colName.Name = "gvMenu_colName";
            this.gvMenu_colName.Visible = true;
            this.gvMenu_colName.VisibleIndex = 0;
            this.gvMenu_colName.Width = 250;
            // 
            // gvMenu_colSizeID
            // 
            this.gvMenu_colSizeID.Caption = "Kích cỡ";
            this.gvMenu_colSizeID.ColumnEdit = this.gvMenu_colSizeID_lk;
            this.gvMenu_colSizeID.FieldName = "SizeID";
            this.gvMenu_colSizeID.Name = "gvMenu_colSizeID";
            this.gvMenu_colSizeID.Visible = true;
            this.gvMenu_colSizeID.VisibleIndex = 1;
            // 
            // gvMenu_colSizeID_lk
            // 
            this.gvMenu_colSizeID_lk.AutoHeight = false;
            this.gvMenu_colSizeID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvMenu_colSizeID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.gvMenu_colSizeID_lk.Name = "gvMenu_colSizeID_lk";
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 29);
            this.panelControl1.TabIndex = 8;
            // 
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(5, 5);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(75, 20);
            this.chkExpand.TabIndex = 0;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // pageCategories_groupMaterialMenu_MenuAndMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcMenuAndMaterials);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupMaterialMenu_MenuAndMaterial";
            this.Text = "Danh mục Thực đơn & Nguyên liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupMaterialMenu_MenuAndMaterial_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupMaterialMenu_MenuAndMaterial_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_MenuAndMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials_colUnitID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMenuAndMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu_colMenuGroupID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu_colSizeID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraGrid.GridControl gcMenuAndMaterials;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterials;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colCode;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colName;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colQuantity;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gvMenu_colMenuGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn gvMenu_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvMenu_colCode;
        private DevExpress.XtraGrid.Columns.GridColumn gvMenu_colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvMenu_colMenuGroupID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colMenuID;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvMaterials_colUnitID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvMenu_colSizeID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvMenu_colSizeID_lk;
    }
}