
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_Unit
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
            this.gcUnit = new DevExpress.XtraGrid.GridControl();
            this.gvUnit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // gcUnit
            // 
            this.gcUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUnit.Location = new System.Drawing.Point(0, 0);
            this.gcUnit.MainView = this.gvUnit;
            this.gcUnit.Name = "gcUnit";
            this.gcUnit.Size = new System.Drawing.Size(1364, 568);
            this.gcUnit.TabIndex = 5;
            this.gcUnit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUnit});
            // 
            // gvUnit
            // 
            this.gvUnit.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvUnit.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvUnit.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvUnit.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvUnit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName});
            this.gvUnit.GridControl = this.gcUnit;
            this.gvUnit.IndicatorWidth = 40;
            this.gvUnit.Name = "gvUnit";
            this.gvUnit.OptionsBehavior.Editable = false;
            this.gvUnit.OptionsBehavior.ReadOnly = true;
            this.gvUnit.OptionsView.ColumnAutoWidth = false;
            this.gvUnit.OptionsView.ShowGroupPanel = false;
            this.gvUnit.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvUnit.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvUnit_CustomDrawRowIndicator);
            this.gvUnit.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvUnit_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 88;
            // 
            // colName
            // 
            this.colName.Caption = "Đơn vị tính";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 258;
            // 
            // pageCategories_groupMaterialMenu_Unit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.gcUnit);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageCategories_groupMaterialMenu_Unit";
            this.Text = "Danh mục Đơn vị tính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageCategories_groupMaterialMenu_Unit_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageCategories_groupMaterialMenu_Unit_FormClosed);
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_Unit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUnit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
    }
}