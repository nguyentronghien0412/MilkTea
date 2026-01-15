
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_ListOfMaterials
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
            this.gcListOfMaterials = new DevExpress.XtraGrid.GridControl();
            this.gvListOfMaterials = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStyleQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialsGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialsGroupID_slk = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.colMaterialsGroupID_slk_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStatusID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lkMaterialsStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcListOfMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colMaterialsGroupID_slk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colMaterialsGroupID_slk_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colUnitID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_rlk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkMaterialsStatus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcListOfMaterials
            // 
            this.gcListOfMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcListOfMaterials.Location = new System.Drawing.Point(2, 2);
            this.gcListOfMaterials.MainView = this.gvListOfMaterials;
            this.gcListOfMaterials.Name = "gcListOfMaterials";
            this.gcListOfMaterials.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colStatusID_rlk,
            this.colMaterialsGroupID_slk,
            this.colUnitID_lk,
            this.colStatusID_lk});
            this.gcListOfMaterials.Size = new System.Drawing.Size(1360, 535);
            this.gcListOfMaterials.TabIndex = 3;
            this.gcListOfMaterials.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvListOfMaterials});
            // 
            // gvListOfMaterials
            // 
            this.gvListOfMaterials.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvListOfMaterials.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvListOfMaterials.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvListOfMaterials.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvListOfMaterials.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colStyleQuantity,
            this.colCode,
            this.colMaterialsGroupID,
            this.colUnitID,
            this.gridColumn4,
            this.colStatusID});
            this.gvListOfMaterials.GridControl = this.gcListOfMaterials;
            this.gvListOfMaterials.GroupCount = 1;
            this.gvListOfMaterials.GroupFormat = "[#image]{1} {2}";
            this.gvListOfMaterials.IndicatorWidth = 60;
            this.gvListOfMaterials.Name = "gvListOfMaterials";
            this.gvListOfMaterials.OptionsBehavior.Editable = false;
            this.gvListOfMaterials.OptionsBehavior.ReadOnly = true;
            this.gvListOfMaterials.OptionsView.ColumnAutoWidth = false;
            this.gvListOfMaterials.OptionsView.ShowAutoFilterRow = true;
            this.gvListOfMaterials.OptionsView.ShowGroupPanel = false;
            this.gvListOfMaterials.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMaterialsGroupID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvListOfMaterials.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvListOfMaterials_CustomDrawRowIndicator);
            this.gvListOfMaterials.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvListOfMaterials_FocusedRowChanged);
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
            this.colName.Caption = "Tên vật tư - Thiết bị";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 258;
            // 
            // colStyleQuantity
            // 
            this.colStyleQuantity.Caption = "Quy cách";
            this.colStyleQuantity.DisplayFormat.FormatString = "n0";
            this.colStyleQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStyleQuantity.FieldName = "StyleQuantity";
            this.colStyleQuantity.Name = "colStyleQuantity";
            this.colStyleQuantity.Visible = true;
            this.colStyleQuantity.VisibleIndex = 2;
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 109;
            // 
            // colMaterialsGroupID
            // 
            this.colMaterialsGroupID.Caption = "Nhóm vật tư";
            this.colMaterialsGroupID.ColumnEdit = this.colMaterialsGroupID_slk;
            this.colMaterialsGroupID.FieldName = "MaterialsGroupID";
            this.colMaterialsGroupID.Name = "colMaterialsGroupID";
            this.colMaterialsGroupID.Visible = true;
            this.colMaterialsGroupID.VisibleIndex = 3;
            // 
            // colMaterialsGroupID_slk
            // 
            this.colMaterialsGroupID_slk.AutoHeight = false;
            this.colMaterialsGroupID_slk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colMaterialsGroupID_slk.Name = "colMaterialsGroupID_slk";
            this.colMaterialsGroupID_slk.NullText = "";
            this.colMaterialsGroupID_slk.PopupView = this.colMaterialsGroupID_slk_View;
            // 
            // colMaterialsGroupID_slk_View
            // 
            this.colMaterialsGroupID_slk_View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.colMaterialsGroupID_slk_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.colMaterialsGroupID_slk_View.Name = "colMaterialsGroupID_slk_View";
            this.colMaterialsGroupID_slk_View.OptionsBehavior.Editable = false;
            this.colMaterialsGroupID_slk_View.OptionsBehavior.ReadOnly = true;
            this.colMaterialsGroupID_slk_View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.colMaterialsGroupID_slk_View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // colUnitID
            // 
            this.colUnitID.Caption = "Đơn vị quy đổi nhỏ nhất";
            this.colUnitID.ColumnEdit = this.colUnitID_lk;
            this.colUnitID.FieldName = "UnitID";
            this.colUnitID.Name = "colUnitID";
            this.colUnitID.Visible = true;
            this.colUnitID.VisibleIndex = 3;
            this.colUnitID.Width = 143;
            // 
            // colUnitID_lk
            // 
            this.colUnitID_lk.AutoHeight = false;
            this.colUnitID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colUnitID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name7", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name8")});
            this.colUnitID_lk.Name = "colUnitID_lk";
            this.colUnitID_lk.NullText = "";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Đơn vị quy đổi lớn nhất";
            this.gridColumn4.ColumnEdit = this.colUnitID_lk;
            this.gridColumn4.FieldName = "UnitID_Max";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 139;
            // 
            // colStatusID
            // 
            this.colStatusID.Caption = "Trạng thái";
            this.colStatusID.ColumnEdit = this.colStatusID_lk;
            this.colStatusID.FieldName = "StatusID";
            this.colStatusID.Name = "colStatusID";
            this.colStatusID.Visible = true;
            this.colStatusID.VisibleIndex = 5;
            this.colStatusID.Width = 156;
            // 
            // colStatusID_lk
            // 
            this.colStatusID_lk.AutoHeight = false;
            this.colStatusID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colStatusID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name9", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name10")});
            this.colStatusID_lk.Name = "colStatusID_lk";
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lkMaterialsStatus);
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 29);
            this.panelControl1.TabIndex = 7;
            // 
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(307, 5);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(75, 20);
            this.chkExpand.TabIndex = 2;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcListOfMaterials);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 29);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1364, 539);
            this.panelControl2.TabIndex = 8;
            // 
            // lkMaterialsStatus
            // 
            this.lkMaterialsStatus.Location = new System.Drawing.Point(110, 5);
            this.lkMaterialsStatus.Name = "lkMaterialsStatus";
            this.lkMaterialsStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkMaterialsStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.lkMaterialsStatus.Properties.NullText = "";
            this.lkMaterialsStatus.Properties.ShowHeader = false;
            this.lkMaterialsStatus.Size = new System.Drawing.Size(172, 20);
            this.lkMaterialsStatus.TabIndex = 1;
            this.lkMaterialsStatus.EditValueChanged += new System.EventHandler(this.lkMaterialsStatus_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Xem theo Trạng thái";
            // 
            // pageCategories_groupMaterialMenu_ListOfMaterials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupMaterialMenu_ListOfMaterials";
            this.Text = "Danh sách vật tư và hàng hóa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupMaterialMenu_ListOfMaterials_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupMaterialMenu_ListOfMaterials_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_ListOfMaterials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcListOfMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvListOfMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colMaterialsGroupID_slk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colMaterialsGroupID_slk_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colUnitID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_rlk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkMaterialsStatus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcListOfMaterials;
        private DevExpress.XtraGrid.Views.Grid.GridView gvListOfMaterials;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colStatusID_rlk;
        private DevExpress.XtraGrid.Columns.GridColumn colStyleQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialsGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit colMaterialsGroupID_slk;
        private DevExpress.XtraGrid.Views.Grid.GridView colMaterialsGroupID_slk_View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colUnitID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colStatusID_lk;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkMaterialsStatus;
    }
}