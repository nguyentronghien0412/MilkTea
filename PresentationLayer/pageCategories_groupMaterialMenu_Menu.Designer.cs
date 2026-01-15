
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_Menu
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
            this.gcMenu = new DevExpress.XtraGrid.GridControl();
            this.gvMenu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuGroupID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTasteQTy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSizeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrintSticker2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colSizeID_chkcmb = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lkStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colMenuGroupID_rlk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_rlk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colUnitID_rlk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSizeID_chkcmb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcMenu
            // 
            this.gcMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMenu.Location = new System.Drawing.Point(2, 2);
            this.gcMenu.MainView = this.gvMenu;
            this.gcMenu.Name = "gcMenu";
            this.gcMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colStatusID_rlk,
            this.repositoryItemRichTextEdit1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2,
            this.colMenuGroupID_rlk,
            this.colUnitID_rlk,
            this.colSizeID_chkcmb,
            this.repositoryItemCheckEdit1});
            this.gcMenu.Size = new System.Drawing.Size(1360, 533);
            this.gcMenu.TabIndex = 6;
            this.gcMenu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMenu});
            // 
            // gvMenu
            // 
            this.gvMenu.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvMenu.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMenu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMenu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMenu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.gridColumn1,
            this.colName,
            this.colCostPrice,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn9,
            this.gridColumn8,
            this.colMenuGroupID,
            this.colStatusID,
            this.colUnitID,
            this.colTasteQTy,
            this.colSizeName,
            this.colPrintSticker2});
            this.gvMenu.GridControl = this.gcMenu;
            this.gvMenu.GroupCount = 1;
            this.gvMenu.GroupFormat = "[#image]{1} {2}";
            this.gvMenu.IndicatorWidth = 60;
            this.gvMenu.Name = "gvMenu";
            this.gvMenu.OptionsBehavior.Editable = false;
            this.gvMenu.OptionsBehavior.ReadOnly = true;
            this.gvMenu.OptionsView.ColumnAutoWidth = false;
            this.gvMenu.OptionsView.ShowAutoFilterRow = true;
            this.gvMenu.OptionsView.ShowGroupPanel = false;
            this.gvMenu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMenuGroupID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMenu.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMenu_CustomDrawRowIndicator);
            this.gvMenu.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvMenu_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã thực đơn";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 80;
            // 
            // colName
            // 
            this.colName.Caption = "Tên thực đơn";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 183;
            // 
            // colCostPrice
            // 
            this.colCostPrice.Caption = "Giá vốn (VNĐ)";
            this.colCostPrice.DisplayFormat.FormatString = "n0";
            this.colCostPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostPrice.FieldName = "CostPrice";
            this.colCostPrice.Name = "colCostPrice";
            this.colCostPrice.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Giá bán (VNĐ)";
            this.gridColumn5.DisplayFormat.FormatString = "n0";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "SalePrice";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Công thức";
            this.gridColumn2.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.gridColumn2.FieldName = "Formula";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Hình ảnh";
            this.gridColumn9.ColumnEdit = this.repositoryItemPictureEdit1;
            this.gridColumn9.FieldName = "AvatarPicture";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 150;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ghi chú";
            this.gridColumn8.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.gridColumn8.FieldName = "Note";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            this.gridColumn8.Width = 250;
            // 
            // colMenuGroupID
            // 
            this.colMenuGroupID.Caption = "Nhóm thực đơn";
            this.colMenuGroupID.ColumnEdit = this.colMenuGroupID_rlk;
            this.colMenuGroupID.FieldName = "MenuGroupID";
            this.colMenuGroupID.Name = "colMenuGroupID";
            this.colMenuGroupID.Visible = true;
            this.colMenuGroupID.VisibleIndex = 8;
            this.colMenuGroupID.Width = 95;
            // 
            // colMenuGroupID_rlk
            // 
            this.colMenuGroupID_rlk.AutoHeight = false;
            this.colMenuGroupID_rlk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colMenuGroupID_rlk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name19", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name20")});
            this.colMenuGroupID_rlk.Name = "colMenuGroupID_rlk";
            this.colMenuGroupID_rlk.NullText = "";
            // 
            // colStatusID
            // 
            this.colStatusID.Caption = "Trạng thái";
            this.colStatusID.ColumnEdit = this.colStatusID_rlk;
            this.colStatusID.FieldName = "StatusID";
            this.colStatusID.Name = "colStatusID";
            this.colStatusID.Visible = true;
            this.colStatusID.VisibleIndex = 7;
            this.colStatusID.Width = 100;
            // 
            // colStatusID_rlk
            // 
            this.colStatusID_rlk.AutoHeight = false;
            this.colStatusID_rlk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colStatusID_rlk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name5", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name6")});
            this.colStatusID_rlk.Name = "colStatusID_rlk";
            this.colStatusID_rlk.NullText = "";
            // 
            // colUnitID
            // 
            this.colUnitID.Caption = "Đơn vị tính";
            this.colUnitID.ColumnEdit = this.colUnitID_rlk;
            this.colUnitID.FieldName = "UnitID";
            this.colUnitID.Name = "colUnitID";
            this.colUnitID.Visible = true;
            this.colUnitID.VisibleIndex = 4;
            // 
            // colUnitID_rlk
            // 
            this.colUnitID_rlk.AutoHeight = false;
            this.colUnitID_rlk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colUnitID_rlk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name35", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name36")});
            this.colUnitID_rlk.Name = "colUnitID_rlk";
            // 
            // colTasteQTy
            // 
            this.colTasteQTy.Caption = "SL vị";
            this.colTasteQTy.FieldName = "TasteQTy";
            this.colTasteQTy.Name = "colTasteQTy";
            this.colTasteQTy.Visible = true;
            this.colTasteQTy.VisibleIndex = 3;
            this.colTasteQTy.Width = 47;
            // 
            // colSizeName
            // 
            this.colSizeName.Caption = "Kích cỡ";
            this.colSizeName.FieldName = "SizeName";
            this.colSizeName.Name = "colSizeName";
            this.colSizeName.Visible = true;
            this.colSizeName.VisibleIndex = 5;
            this.colSizeName.Width = 105;
            // 
            // colPrintSticker2
            // 
            this.colPrintSticker2.Caption = "In sticker tên món khi thanh toán";
            this.colPrintSticker2.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPrintSticker2.FieldName = "PrintSticker2";
            this.colPrintSticker2.Name = "colPrintSticker2";
            this.colPrintSticker2.Visible = true;
            this.colPrintSticker2.VisibleIndex = 6;
            this.colPrintSticker2.Width = 200;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // colSizeID_chkcmb
            // 
            this.colSizeID_chkcmb.AutoHeight = false;
            this.colSizeID_chkcmb.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colSizeID_chkcmb.Name = "colSizeID_chkcmb";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lkStatus);
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 31);
            this.panelControl1.TabIndex = 7;
            // 
            // lkStatus
            // 
            this.lkStatus.Location = new System.Drawing.Point(12, 5);
            this.lkStatus.Name = "lkStatus";
            this.lkStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.lkStatus.Properties.NullText = "";
            this.lkStatus.Properties.ShowHeader = false;
            this.lkStatus.Size = new System.Drawing.Size(141, 20);
            this.lkStatus.TabIndex = 1;
            this.lkStatus.EditValueChanged += new System.EventHandler(this.lkStatus_EditValueChanged);
            // 
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(159, 5);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(75, 18);
            this.chkExpand.TabIndex = 0;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcMenu);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 31);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1364, 537);
            this.panelControl2.TabIndex = 8;
            // 
            // pageCategories_groupMaterialMenu_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupMaterialMenu_Menu";
            this.Text = "Danh mục thực đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupMaterialMenu_Menu_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupMaterialMenu_Menu_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colMenuGroupID_rlk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colStatusID_rlk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colUnitID_rlk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colSizeID_chkcmb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMenu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCostPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colStatusID_rlk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuGroupID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colMenuGroupID_rlk;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colUnitID_rlk;
        private DevExpress.XtraGrid.Columns.GridColumn colTasteQTy;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSizeName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit colSizeID_chkcmb;
        private DevExpress.XtraGrid.Columns.GridColumn colPrintSticker2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}