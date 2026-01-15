
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_DinnerTable
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
            this.gcDinnerTable = new DevExpress.XtraGrid.GridControl();
            this.gvDinnerTable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusOfDinnerTableID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StatusOfDinnerTableID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDinnerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDinnerTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusOfDinnerTableID_rlk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDinnerTable
            // 
            this.gcDinnerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDinnerTable.Location = new System.Drawing.Point(0, 0);
            this.gcDinnerTable.MainView = this.gvDinnerTable;
            this.gcDinnerTable.Name = "gcDinnerTable";
            this.gcDinnerTable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.StatusOfDinnerTableID_rlk,
            this.repositoryItemRichTextEdit1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemPictureEdit2});
            this.gcDinnerTable.Size = new System.Drawing.Size(1364, 568);
            this.gcDinnerTable.TabIndex = 5;
            this.gcDinnerTable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDinnerTable});
            // 
            // gvDinnerTable
            // 
            this.gvDinnerTable.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvDinnerTable.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvDinnerTable.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvDinnerTable.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvDinnerTable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.gridColumn1,
            this.colName,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colStatusOfDinnerTableID,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvDinnerTable.GridControl = this.gcDinnerTable;
            this.gvDinnerTable.IndicatorWidth = 40;
            this.gvDinnerTable.Name = "gvDinnerTable";
            this.gvDinnerTable.OptionsBehavior.Editable = false;
            this.gvDinnerTable.OptionsBehavior.ReadOnly = true;
            this.gvDinnerTable.OptionsView.ColumnAutoWidth = false;
            this.gvDinnerTable.OptionsView.ShowAutoFilterRow = true;
            this.gvDinnerTable.OptionsView.ShowGroupPanel = false;
            this.gvDinnerTable.RowHeight = 90;
            this.gvDinnerTable.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvDinnerTable.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvDinnerTable_CustomDrawRowIndicator);
            this.gvDinnerTable.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvDinnerTable_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã bàn";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã bàn";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // colName
            // 
            this.colName.Caption = "Tên bàn";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            this.colName.Width = 183;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Vị trí";
            this.gridColumn2.FieldName = "Position";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số lượng ghế";
            this.gridColumn3.FieldName = "NumberOfSeats";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 90;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Chiều dài (cm)";
            this.gridColumn4.FieldName = "Longs";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 90;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Chiều rộng (cm)";
            this.gridColumn5.FieldName = "Width";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Chiều cao (cm)";
            this.gridColumn6.FieldName = "Height";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 100;
            // 
            // colStatusOfDinnerTableID
            // 
            this.colStatusOfDinnerTableID.Caption = "Trạng thái";
            this.colStatusOfDinnerTableID.ColumnEdit = this.StatusOfDinnerTableID_rlk;
            this.colStatusOfDinnerTableID.FieldName = "StatusOfDinnerTableID";
            this.colStatusOfDinnerTableID.Name = "colStatusOfDinnerTableID";
            this.colStatusOfDinnerTableID.Visible = true;
            this.colStatusOfDinnerTableID.VisibleIndex = 8;
            this.colStatusOfDinnerTableID.Width = 100;
            // 
            // StatusOfDinnerTableID_rlk
            // 
            this.StatusOfDinnerTableID_rlk.AutoHeight = false;
            this.StatusOfDinnerTableID_rlk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatusOfDinnerTableID_rlk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name5", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name6")});
            this.StatusOfDinnerTableID_rlk.Name = "StatusOfDinnerTableID_rlk";
            this.StatusOfDinnerTableID_rlk.NullText = "";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ghi chú";
            this.gridColumn8.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.gridColumn8.FieldName = "Note";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 250;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Bàn trống";
            this.gridColumn9.ColumnEdit = this.repositoryItemPictureEdit1;
            this.gridColumn9.FieldName = "EmptyPicture";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 90;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Bàn có khách";
            this.gridColumn10.ColumnEdit = this.repositoryItemPictureEdit2;
            this.gridColumn10.FieldName = "UsingPicture";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 90;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            this.repositoryItemPictureEdit2.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            this.repositoryItemPictureEdit2.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // pageCategories_groupMaterialMenu_DinnerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcDinnerTable);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupMaterialMenu_DinnerTable";
            this.Text = "Danh mục Bàn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupMaterialMenu_DinnerTable_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupMaterialMenu_DinnerTable_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_DinnerTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDinnerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDinnerTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusOfDinnerTableID_rlk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDinnerTable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDinnerTable;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusOfDinnerTableID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit StatusOfDinnerTableID_rlk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
    }
}