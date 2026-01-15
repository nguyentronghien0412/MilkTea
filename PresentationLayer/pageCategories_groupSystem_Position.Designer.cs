
namespace PresentationLayer
{
    partial class pageCategories_groupSystem_Position
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
            this.gcPosition = new DevExpress.XtraGrid.GridControl();
            this.gvPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPosition
            // 
            this.gcPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPosition.Location = new System.Drawing.Point(0, 0);
            this.gcPosition.MainView = this.gvPosition;
            this.gcPosition.Name = "gcPosition";
            this.gcPosition.Size = new System.Drawing.Size(882, 532);
            this.gcPosition.TabIndex = 4;
            this.gcPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPosition});
            // 
            // gvPosition
            // 
            this.gvPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPosition.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvPosition.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName});
            this.gvPosition.GridControl = this.gcPosition;
            this.gvPosition.IndicatorWidth = 40;
            this.gvPosition.Name = "gvPosition";
            this.gvPosition.OptionsBehavior.Editable = false;
            this.gvPosition.OptionsBehavior.ReadOnly = true;
            this.gvPosition.OptionsView.ColumnAutoWidth = false;
            this.gvPosition.OptionsView.ShowGroupPanel = false;
            this.gvPosition.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvPosition.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvPosition_CustomDrawRowIndicator);
            this.gvPosition.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPosition_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã chức vụ";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 88;
            // 
            // colName
            // 
            this.colName.Caption = "Chức vụ";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 258;
            // 
            // pageCategories_groupSystem_Position
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 532);
            this.Controls.Add(this.gcPosition);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupSystem_Position";
            this.Text = "Danh mục Chức vụ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupSystem_Position_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupSystem_Position_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupSystem_Position_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcPosition;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPosition;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}