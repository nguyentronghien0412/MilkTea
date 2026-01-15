
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_MenuGroup
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
            this.gcMenuGroup = new DevExpress.XtraGrid.GridControl();
            this.gvMenuGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMenuGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_rlk)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMenuGroup
            // 
            this.gcMenuGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMenuGroup.Location = new System.Drawing.Point(0, 0);
            this.gcMenuGroup.MainView = this.gvMenuGroup;
            this.gcMenuGroup.Name = "gcMenuGroup";
            this.gcMenuGroup.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colStatusID_rlk});
            this.gcMenuGroup.Size = new System.Drawing.Size(1364, 568);
            this.gcMenuGroup.TabIndex = 5;
            this.gcMenuGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenuGroup});
            // 
            // gvMenuGroup
            // 
            this.gvMenuGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvMenuGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMenuGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMenuGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMenuGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colStatusID});
            this.gvMenuGroup.GridControl = this.gcMenuGroup;
            this.gvMenuGroup.IndicatorWidth = 40;
            this.gvMenuGroup.Name = "gvMenuGroup";
            this.gvMenuGroup.OptionsBehavior.Editable = false;
            this.gvMenuGroup.OptionsBehavior.ReadOnly = true;
            this.gvMenuGroup.OptionsView.ColumnAutoWidth = false;
            this.gvMenuGroup.OptionsView.ShowAutoFilterRow = true;
            this.gvMenuGroup.OptionsView.ShowGroupPanel = false;
            this.gvMenuGroup.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMenuGroup.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMenuGroup_CustomDrawRowIndicator);
            this.gvMenuGroup.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMenuGroup_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã nhóm";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 88;
            // 
            // colName
            // 
            this.colName.Caption = "Tên nhóm";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 258;
            // 
            // colStatusID
            // 
            this.colStatusID.Caption = "Trạng thái";
            this.colStatusID.ColumnEdit = this.colStatusID_rlk;
            this.colStatusID.FieldName = "StatusID";
            this.colStatusID.Name = "colStatusID";
            this.colStatusID.Visible = true;
            this.colStatusID.VisibleIndex = 1;
            this.colStatusID.Width = 122;
            // 
            // colStatusID_rlk
            // 
            this.colStatusID_rlk.AutoHeight = false;
            this.colStatusID_rlk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colStatusID_rlk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name9", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name10")});
            this.colStatusID_rlk.Name = "colStatusID_rlk";
            this.colStatusID_rlk.NullText = "";
            // 
            // pageCategories_groupMaterialMenu_MenuGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcMenuGroup);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupMaterialMenu_MenuGroup";
            this.Text = "Danh mục Nhóm thực đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupMaterialMenu_MenuGroup_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupMaterialMenu_MenuGroup_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_MenuGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMenuGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenuGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_rlk)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMenuGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenuGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colStatusID_rlk;
    }
}