
namespace PresentationLayer
{
    partial class pageReport_groupWarehouse_Inventory
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
            this.gvInventoryDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcInventory = new DevExpress.XtraGrid.GridControl();
            this.bgvInventory = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gvInventory_colMaterialsID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colStyleQuantity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colMaterialsGroupName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gvInventory_colQuantityCurrent = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colUnitID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gvInventory_colQuantityCurrent_Box = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colUnitID_Max = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gvInventory_colPriceNearest = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gvInventory_colAmountTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvInventoryDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvInventoryDetail
            // 
            this.gvInventoryDetail.GridControl = this.gcInventory;
            this.gvInventoryDetail.IndicatorWidth = 50;
            this.gvInventoryDetail.Name = "gvInventoryDetail";
            this.gvInventoryDetail.OptionsView.ShowGroupPanel = false;
            this.gvInventoryDetail.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvInventoryDetail_CustomDrawRowIndicator);
            // 
            // gcInventory
            // 
            this.gcInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcInventory.Location = new System.Drawing.Point(2, 2);
            this.gcInventory.MainView = this.bgvInventory;
            this.gcInventory.Name = "gcInventory";
            this.gcInventory.Size = new System.Drawing.Size(1360, 536);
            this.gcInventory.TabIndex = 0;
            this.gcInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bgvInventory,
            this.gvInventoryDetail});
            // 
            // bgvInventory
            // 
            this.bgvInventory.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bgvInventory.Appearance.BandPanel.Options.UseFont = true;
            this.bgvInventory.Appearance.BandPanel.Options.UseTextOptions = true;
            this.bgvInventory.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bgvInventory.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.bgvInventory.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Blue;
            this.bgvInventory.Appearance.FooterPanel.Options.UseFont = true;
            this.bgvInventory.Appearance.FooterPanel.Options.UseForeColor = true;
            this.bgvInventory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bgvInventory.Appearance.HeaderPanel.Options.UseFont = true;
            this.bgvInventory.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.bgvInventory.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bgvInventory.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.bgvInventory.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gvInventory_colMaterialsID,
            this.gvInventory_colName,
            this.gvInventory_colCode,
            this.gvInventory_colUnitID,
            this.gvInventory_colUnitID_Max,
            this.gvInventory_colStyleQuantity,
            this.gvInventory_colQuantityCurrent,
            this.gvInventory_colQuantityCurrent_Box,
            this.gvInventory_colMaterialsGroupName,
            this.gvInventory_colPriceNearest,
            this.gvInventory_colAmountTotal});
            this.bgvInventory.GridControl = this.gcInventory;
            this.bgvInventory.GroupCount = 1;
            this.bgvInventory.GroupFormat = "[#image]{1} {2}";
            this.bgvInventory.IndicatorWidth = 60;
            this.bgvInventory.Name = "bgvInventory";
            this.bgvInventory.OptionsBehavior.Editable = false;
            this.bgvInventory.OptionsBehavior.ReadOnly = true;
            this.bgvInventory.OptionsView.ColumnAutoWidth = false;
            this.bgvInventory.OptionsView.ShowFooter = true;
            this.bgvInventory.OptionsView.ShowGroupPanel = false;
            this.bgvInventory.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gvInventory_colMaterialsGroupName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.bgvInventory.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.bgvInventory_CustomDrawRowIndicator);
            this.bgvInventory.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.bgvInventory_PrintInitialize);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Thông tin vật tư / hàng hóa";
            this.gridBand1.Columns.Add(this.gvInventory_colMaterialsID);
            this.gridBand1.Columns.Add(this.gvInventory_colName);
            this.gridBand1.Columns.Add(this.gvInventory_colCode);
            this.gridBand1.Columns.Add(this.gvInventory_colStyleQuantity);
            this.gridBand1.Columns.Add(this.gvInventory_colMaterialsGroupName);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 475;
            // 
            // gvInventory_colMaterialsID
            // 
            this.gvInventory_colMaterialsID.Caption = "Mã ID";
            this.gvInventory_colMaterialsID.FieldName = "MaterialsID";
            this.gvInventory_colMaterialsID.Name = "gvInventory_colMaterialsID";
            // 
            // gvInventory_colName
            // 
            this.gvInventory_colName.Caption = "Tên";
            this.gvInventory_colName.FieldName = "Name";
            this.gvInventory_colName.Name = "gvInventory_colName";
            this.gvInventory_colName.Visible = true;
            this.gvInventory_colName.Width = 300;
            // 
            // gvInventory_colCode
            // 
            this.gvInventory_colCode.Caption = "Mã";
            this.gvInventory_colCode.FieldName = "Code";
            this.gvInventory_colCode.Name = "gvInventory_colCode";
            this.gvInventory_colCode.Visible = true;
            this.gvInventory_colCode.Width = 90;
            // 
            // gvInventory_colStyleQuantity
            // 
            this.gvInventory_colStyleQuantity.Caption = "Quy cách";
            this.gvInventory_colStyleQuantity.FieldName = "StyleQuantity";
            this.gvInventory_colStyleQuantity.Name = "gvInventory_colStyleQuantity";
            this.gvInventory_colStyleQuantity.Visible = true;
            this.gvInventory_colStyleQuantity.Width = 85;
            // 
            // gvInventory_colMaterialsGroupName
            // 
            this.gvInventory_colMaterialsGroupName.Caption = "Nhóm";
            this.gvInventory_colMaterialsGroupName.FieldName = "MaterialsGroupName";
            this.gvInventory_colMaterialsGroupName.Name = "gvInventory_colMaterialsGroupName";
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Đơn vị quy đổi nhỏ nhất";
            this.gridBand2.Columns.Add(this.gvInventory_colQuantityCurrent);
            this.gridBand2.Columns.Add(this.gvInventory_colUnitID);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 155;
            // 
            // gvInventory_colQuantityCurrent
            // 
            this.gvInventory_colQuantityCurrent.Caption = "SL tồn";
            this.gvInventory_colQuantityCurrent.DisplayFormat.FormatString = "n2";
            this.gvInventory_colQuantityCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvInventory_colQuantityCurrent.FieldName = "QuantityCurrent";
            this.gvInventory_colQuantityCurrent.Name = "gvInventory_colQuantityCurrent";
            this.gvInventory_colQuantityCurrent.Visible = true;
            // 
            // gvInventory_colUnitID
            // 
            this.gvInventory_colUnitID.Caption = "Đơn vị tính";
            this.gvInventory_colUnitID.FieldName = "UnitID";
            this.gvInventory_colUnitID.Name = "gvInventory_colUnitID";
            this.gvInventory_colUnitID.Visible = true;
            this.gvInventory_colUnitID.Width = 80;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Đơn vị quy đổi lớn nhất";
            this.gridBand3.Columns.Add(this.gvInventory_colQuantityCurrent_Box);
            this.gridBand3.Columns.Add(this.gvInventory_colUnitID_Max);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 155;
            // 
            // gvInventory_colQuantityCurrent_Box
            // 
            this.gvInventory_colQuantityCurrent_Box.Caption = "SL tồn";
            this.gvInventory_colQuantityCurrent_Box.DisplayFormat.FormatString = "n2";
            this.gvInventory_colQuantityCurrent_Box.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvInventory_colQuantityCurrent_Box.FieldName = "QuantityCurrent_Box";
            this.gvInventory_colQuantityCurrent_Box.Name = "gvInventory_colQuantityCurrent_Box";
            this.gvInventory_colQuantityCurrent_Box.Visible = true;
            // 
            // gvInventory_colUnitID_Max
            // 
            this.gvInventory_colUnitID_Max.Caption = "Đơn vị tính";
            this.gvInventory_colUnitID_Max.FieldName = "UnitID_Max";
            this.gvInventory_colUnitID_Max.Name = "gvInventory_colUnitID_Max";
            this.gvInventory_colUnitID_Max.Visible = true;
            this.gvInventory_colUnitID_Max.Width = 80;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Số tiền tồn kho";
            this.gridBand4.Columns.Add(this.gvInventory_colPriceNearest);
            this.gridBand4.Columns.Add(this.gvInventory_colAmountTotal);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 190;
            // 
            // gvInventory_colPriceNearest
            // 
            this.gvInventory_colPriceNearest.Caption = "Giá gần nhất";
            this.gvInventory_colPriceNearest.DisplayFormat.FormatString = "n0";
            this.gvInventory_colPriceNearest.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvInventory_colPriceNearest.FieldName = "PriceNearest";
            this.gvInventory_colPriceNearest.Name = "gvInventory_colPriceNearest";
            this.gvInventory_colPriceNearest.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PriceNearest", "Tổng cộng")});
            this.gvInventory_colPriceNearest.Visible = true;
            this.gvInventory_colPriceNearest.Width = 90;
            // 
            // gvInventory_colAmountTotal
            // 
            this.gvInventory_colAmountTotal.Caption = "Tạm tính";
            this.gvInventory_colAmountTotal.DisplayFormat.FormatString = "n0";
            this.gvInventory_colAmountTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvInventory_colAmountTotal.FieldName = "AmountTotal";
            this.gvInventory_colAmountTotal.Name = "gvInventory_colAmountTotal";
            this.gvInventory_colAmountTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountTotal", "{0:n0}")});
            this.gvInventory_colAmountTotal.Visible = true;
            this.gvInventory_colAmountTotal.Width = 100;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1364, 28);
            this.panelControl1.TabIndex = 1;
            // 
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(10, 5);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(75, 20);
            this.chkExpand.TabIndex = 5;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.gcInventory);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 28);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1364, 540);
            this.panelControl2.TabIndex = 2;
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // pageReport_groupWarehouse_Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 568);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageReport_groupWarehouse_Inventory";
            this.Text = "Báo cáo tồn kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageReport_groupWarehouse_Inventory_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageReport_groupWarehouse_Inventory_FormClosed);
            this.Load += new System.EventHandler(this.pageReport_groupWarehouse_Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvInventoryDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInventoryDetail;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bgvInventory;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colMaterialsID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colStyleQuantity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colMaterialsGroupName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colQuantityCurrent;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colUnitID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colQuantityCurrent_Box;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colUnitID_Max;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colPriceNearest;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gvInventory_colAmountTotal;
    }
}