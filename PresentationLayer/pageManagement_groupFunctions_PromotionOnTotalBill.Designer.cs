
namespace PresentationLayer
{
    partial class pageManagement_groupFunctions_PromotionOnTotalBill
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.gvPromotion_colStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colStatusID_rlk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcPromotion = new DevExpress.XtraGrid.GridControl();
            this.gvPromotion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvPromotion_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colStopDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colProPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colProAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPromotion_colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion_colStatusID_rlk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPromotion_colStatusID
            // 
            this.gvPromotion_colStatusID.Caption = "Trạng thái";
            this.gvPromotion_colStatusID.ColumnEdit = this.gvPromotion_colStatusID_rlk;
            this.gvPromotion_colStatusID.FieldName = "StatusID";
            this.gvPromotion_colStatusID.Name = "gvPromotion_colStatusID";
            this.gvPromotion_colStatusID.Visible = true;
            this.gvPromotion_colStatusID.VisibleIndex = 5;
            this.gvPromotion_colStatusID.Width = 122;
            // 
            // gvPromotion_colStatusID_rlk
            // 
            this.gvPromotion_colStatusID_rlk.AutoHeight = false;
            this.gvPromotion_colStatusID_rlk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvPromotion_colStatusID_rlk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name9", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name10")});
            this.gvPromotion_colStatusID_rlk.Name = "gvPromotion_colStatusID_rlk";
            this.gvPromotion_colStatusID_rlk.NullText = "";
            // 
            // gcPromotion
            // 
            this.gcPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPromotion.Location = new System.Drawing.Point(0, 0);
            this.gcPromotion.MainView = this.gvPromotion;
            this.gcPromotion.Name = "gcPromotion";
            this.gcPromotion.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gvPromotion_colStatusID_rlk});
            this.gcPromotion.Size = new System.Drawing.Size(1364, 568);
            this.gcPromotion.TabIndex = 6;
            this.gcPromotion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPromotion});
            this.gcPromotion.Click += new System.EventHandler(this.gcPromotion_Click);
            // 
            // gvPromotion
            // 
            this.gvPromotion.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvPromotion.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPromotion.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPromotion.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPromotion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvPromotion_colID,
            this.gvPromotion_colName,
            this.gvPromotion_colCreatedDate,
            this.gvPromotion_colCreatedBy,
            this.gvPromotion_colUpdatedDate,
            this.gvPromotion_colUpdatedBy,
            this.gvPromotion_colStartDate,
            this.gvPromotion_colStopDate,
            this.gvPromotion_colProPercent,
            this.gvPromotion_colProAmount,
            this.gvPromotion_colStatusID,
            this.gvPromotion_colNote});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gvPromotion_colStatusID;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Lime;
            formatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = new decimal(new int[] {
            2,
            0,
            0,
            0});
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gvPromotion.FormatRules.Add(gridFormatRule1);
            this.gvPromotion.GridControl = this.gcPromotion;
            this.gvPromotion.IndicatorWidth = 40;
            this.gvPromotion.Name = "gvPromotion";
            this.gvPromotion.OptionsBehavior.Editable = false;
            this.gvPromotion.OptionsBehavior.ReadOnly = true;
            this.gvPromotion.OptionsView.ColumnAutoWidth = false;
            this.gvPromotion.OptionsView.ShowAutoFilterRow = true;
            this.gvPromotion.OptionsView.ShowGroupPanel = false;
            this.gvPromotion.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gvPromotion_colStartDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvPromotion.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPromotion_CustomDrawRowIndicator);
            this.gvPromotion.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPromotion_FocusedRowChanged);
            // 
            // gvPromotion_colID
            // 
            this.gvPromotion_colID.Caption = "Mã ID";
            this.gvPromotion_colID.FieldName = "ID";
            this.gvPromotion_colID.Name = "gvPromotion_colID";
            this.gvPromotion_colID.Width = 88;
            // 
            // gvPromotion_colName
            // 
            this.gvPromotion_colName.Caption = "Tên chương trình";
            this.gvPromotion_colName.FieldName = "Name";
            this.gvPromotion_colName.Name = "gvPromotion_colName";
            this.gvPromotion_colName.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gvPromotion_colName.Visible = true;
            this.gvPromotion_colName.VisibleIndex = 0;
            this.gvPromotion_colName.Width = 258;
            // 
            // gvPromotion_colCreatedDate
            // 
            this.gvPromotion_colCreatedDate.Caption = "Ngày tạo";
            this.gvPromotion_colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gvPromotion_colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvPromotion_colCreatedDate.FieldName = "CreatedDate";
            this.gvPromotion_colCreatedDate.Name = "gvPromotion_colCreatedDate";
            this.gvPromotion_colCreatedDate.Visible = true;
            this.gvPromotion_colCreatedDate.VisibleIndex = 7;
            this.gvPromotion_colCreatedDate.Width = 120;
            // 
            // gvPromotion_colCreatedBy
            // 
            this.gvPromotion_colCreatedBy.Caption = "Người tạo";
            this.gvPromotion_colCreatedBy.FieldName = "CreatedByName";
            this.gvPromotion_colCreatedBy.Name = "gvPromotion_colCreatedBy";
            this.gvPromotion_colCreatedBy.Visible = true;
            this.gvPromotion_colCreatedBy.VisibleIndex = 8;
            this.gvPromotion_colCreatedBy.Width = 200;
            // 
            // gvPromotion_colUpdatedDate
            // 
            this.gvPromotion_colUpdatedDate.Caption = "Ngày cập nhật";
            this.gvPromotion_colUpdatedDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gvPromotion_colUpdatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvPromotion_colUpdatedDate.FieldName = "UpdatedDate";
            this.gvPromotion_colUpdatedDate.Name = "gvPromotion_colUpdatedDate";
            this.gvPromotion_colUpdatedDate.Visible = true;
            this.gvPromotion_colUpdatedDate.VisibleIndex = 9;
            this.gvPromotion_colUpdatedDate.Width = 120;
            // 
            // gvPromotion_colUpdatedBy
            // 
            this.gvPromotion_colUpdatedBy.Caption = "Người cập nhật";
            this.gvPromotion_colUpdatedBy.FieldName = "UpdatedByName";
            this.gvPromotion_colUpdatedBy.Name = "gvPromotion_colUpdatedBy";
            this.gvPromotion_colUpdatedBy.Visible = true;
            this.gvPromotion_colUpdatedBy.VisibleIndex = 10;
            this.gvPromotion_colUpdatedBy.Width = 200;
            // 
            // gvPromotion_colStartDate
            // 
            this.gvPromotion_colStartDate.Caption = "Ngày bắt đầu";
            this.gvPromotion_colStartDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gvPromotion_colStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvPromotion_colStartDate.FieldName = "StartDate";
            this.gvPromotion_colStartDate.Name = "gvPromotion_colStartDate";
            this.gvPromotion_colStartDate.Visible = true;
            this.gvPromotion_colStartDate.VisibleIndex = 1;
            this.gvPromotion_colStartDate.Width = 120;
            // 
            // gvPromotion_colStopDate
            // 
            this.gvPromotion_colStopDate.Caption = "Ngày kết thúc";
            this.gvPromotion_colStopDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gvPromotion_colStopDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gvPromotion_colStopDate.FieldName = "StopDate";
            this.gvPromotion_colStopDate.Name = "gvPromotion_colStopDate";
            this.gvPromotion_colStopDate.Visible = true;
            this.gvPromotion_colStopDate.VisibleIndex = 2;
            this.gvPromotion_colStopDate.Width = 120;
            // 
            // gvPromotion_colProPercent
            // 
            this.gvPromotion_colProPercent.Caption = "Phần trăm";
            this.gvPromotion_colProPercent.FieldName = "ProPercent";
            this.gvPromotion_colProPercent.Name = "gvPromotion_colProPercent";
            this.gvPromotion_colProPercent.Visible = true;
            this.gvPromotion_colProPercent.VisibleIndex = 3;
            // 
            // gvPromotion_colProAmount
            // 
            this.gvPromotion_colProAmount.Caption = "Tiền mặt";
            this.gvPromotion_colProAmount.DisplayFormat.FormatString = "n0";
            this.gvPromotion_colProAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvPromotion_colProAmount.FieldName = "ProAmount";
            this.gvPromotion_colProAmount.Name = "gvPromotion_colProAmount";
            this.gvPromotion_colProAmount.Visible = true;
            this.gvPromotion_colProAmount.VisibleIndex = 4;
            // 
            // gvPromotion_colNote
            // 
            this.gvPromotion_colNote.Caption = "Ghi chú";
            this.gvPromotion_colNote.FieldName = "Note";
            this.gvPromotion_colNote.Name = "gvPromotion_colNote";
            this.gvPromotion_colNote.Visible = true;
            this.gvPromotion_colNote.VisibleIndex = 6;
            this.gvPromotion_colNote.Width = 300;
            // 
            // pageManagement_groupFunctions_PromotionOnTotalBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcPromotion);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageManagement_groupFunctions_PromotionOnTotalBill";
            this.Text = "Chương trình khuyến mãi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageManagement_groupFunctions_PromotionOnTotalBill_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageManagement_groupFunctions_PromotionOnTotalBill_FormClosed);
            this.Load += new System.EventHandler(this.pageManagement_groupFunctions_PromotionOnTotalBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion_colStatusID_rlk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromotion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPromotion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPromotion;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colName;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colStatusID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvPromotion_colStatusID_rlk;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colStopDate;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colProPercent;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colProAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gvPromotion_colNote;
    }
}