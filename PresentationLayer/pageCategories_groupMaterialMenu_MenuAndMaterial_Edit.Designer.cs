
namespace PresentationLayer
{
    partial class pageCategories_groupMaterialMenu_MenuAndMaterial_Edit
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageCategories_groupMaterialMenu_MenuAndMaterial_Edit));
            this.gvMaterials_colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colQuantity_txt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcMaterials = new DevExpress.XtraGrid.GridControl();
            this.gvMaterials = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gvMaterials_colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colUnitID_lk = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gvMaterials_colUnitID_Max = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colStyle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colMaterialsGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvMaterials_colMaterialsGroupName_Sub = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkExpand = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials_colQuantity_txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials_colUnitID_lk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvMaterials_colQuantity
            // 
            this.gvMaterials_colQuantity.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvMaterials_colQuantity.AppearanceCell.BackColor2 = System.Drawing.Color.White;
            this.gvMaterials_colQuantity.AppearanceCell.Options.UseBackColor = true;
            this.gvMaterials_colQuantity.Caption = "Số lượng";
            this.gvMaterials_colQuantity.ColumnEdit = this.gvMaterials_colQuantity_txt;
            this.gvMaterials_colQuantity.FieldName = "Quantity";
            this.gvMaterials_colQuantity.Name = "gvMaterials_colQuantity";
            this.gvMaterials_colQuantity.Visible = true;
            this.gvMaterials_colQuantity.VisibleIndex = 2;
            // 
            // gvMaterials_colQuantity_txt
            // 
            this.gvMaterials_colQuantity_txt.AutoHeight = false;
            this.gvMaterials_colQuantity_txt.BeepOnError = false;
            this.gvMaterials_colQuantity_txt.DisplayFormat.FormatString = "n2";
            this.gvMaterials_colQuantity_txt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvMaterials_colQuantity_txt.EditFormat.FormatString = "n2";
            this.gvMaterials_colQuantity_txt.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gvMaterials_colQuantity_txt.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.gvMaterials_colQuantity_txt.MaskSettings.Set("mask", "n");
            this.gvMaterials_colQuantity_txt.MaxLength = 8;
            this.gvMaterials_colQuantity_txt.Name = "gvMaterials_colQuantity_txt";
            this.gvMaterials_colQuantity_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvMaterials_colQuantity_txt_KeyPress);
            // 
            // gcMaterials
            // 
            this.gcMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMaterials.Location = new System.Drawing.Point(0, 0);
            this.gcMaterials.MainView = this.gvMaterials;
            this.gcMaterials.Name = "gcMaterials";
            this.gcMaterials.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gvMaterials_colUnitID_lk,
            this.gvMaterials_colQuantity_txt});
            this.gcMaterials.Size = new System.Drawing.Size(731, 523);
            this.gcMaterials.TabIndex = 0;
            this.gcMaterials.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaterials});
            // 
            // gvMaterials
            // 
            this.gvMaterials.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvMaterials.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMaterials.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvMaterials.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvMaterials.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gvMaterials_colID,
            this.gvMaterials_colName,
            this.gvMaterials_colCode,
            this.gvMaterials_colUnitID,
            this.gvMaterials_colUnitID_Max,
            this.gvMaterials_colStyle,
            this.gvMaterials_colMaterialsGroupName,
            this.gvMaterials_colQuantity,
            this.gvMaterials_colMaterialsGroupName_Sub});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.gvMaterials_colQuantity;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            formatConditionRuleValue1.Appearance.BackColor2 = System.Drawing.Color.White;
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Greater;
            formatConditionRuleValue1.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gvMaterials.FormatRules.Add(gridFormatRule1);
            this.gvMaterials.GridControl = this.gcMaterials;
            this.gvMaterials.GroupCount = 1;
            this.gvMaterials.GroupFormat = "[#image]{1} {2}";
            this.gvMaterials.IndicatorWidth = 50;
            this.gvMaterials.Name = "gvMaterials";
            this.gvMaterials.OptionsView.ColumnAutoWidth = false;
            this.gvMaterials.OptionsView.ShowGroupPanel = false;
            this.gvMaterials.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gvMaterials_colMaterialsGroupName_Sub, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvMaterials.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvMaterials_CustomDrawRowIndicator);
            this.gvMaterials.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvMaterials_CellValueChanged);
            // 
            // gvMaterials_colID
            // 
            this.gvMaterials_colID.Caption = "Mã ID";
            this.gvMaterials_colID.FieldName = "ID";
            this.gvMaterials_colID.Name = "gvMaterials_colID";
            this.gvMaterials_colID.OptionsColumn.AllowEdit = false;
            // 
            // gvMaterials_colName
            // 
            this.gvMaterials_colName.Caption = "Tên nguyên liệu";
            this.gvMaterials_colName.FieldName = "Name";
            this.gvMaterials_colName.Name = "gvMaterials_colName";
            this.gvMaterials_colName.OptionsColumn.AllowEdit = false;
            this.gvMaterials_colName.Visible = true;
            this.gvMaterials_colName.VisibleIndex = 1;
            this.gvMaterials_colName.Width = 250;
            // 
            // gvMaterials_colCode
            // 
            this.gvMaterials_colCode.Caption = "Mã nguyên liệu";
            this.gvMaterials_colCode.FieldName = "Code";
            this.gvMaterials_colCode.Name = "gvMaterials_colCode";
            this.gvMaterials_colCode.OptionsColumn.AllowEdit = false;
            this.gvMaterials_colCode.Visible = true;
            this.gvMaterials_colCode.VisibleIndex = 0;
            this.gvMaterials_colCode.Width = 100;
            // 
            // gvMaterials_colUnitID
            // 
            this.gvMaterials_colUnitID.Caption = "Đơn vị tính";
            this.gvMaterials_colUnitID.ColumnEdit = this.gvMaterials_colUnitID_lk;
            this.gvMaterials_colUnitID.FieldName = "UnitID";
            this.gvMaterials_colUnitID.Name = "gvMaterials_colUnitID";
            this.gvMaterials_colUnitID.OptionsColumn.AllowEdit = false;
            this.gvMaterials_colUnitID.Visible = true;
            this.gvMaterials_colUnitID.VisibleIndex = 3;
            // 
            // gvMaterials_colUnitID_lk
            // 
            this.gvMaterials_colUnitID_lk.AutoHeight = false;
            this.gvMaterials_colUnitID_lk.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gvMaterials_colUnitID_lk.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name27", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name28")});
            this.gvMaterials_colUnitID_lk.Name = "gvMaterials_colUnitID_lk";
            this.gvMaterials_colUnitID_lk.NullText = "";
            this.gvMaterials_colUnitID_lk.ShowHeader = false;
            // 
            // gvMaterials_colUnitID_Max
            // 
            this.gvMaterials_colUnitID_Max.Caption = "Đơn vị quy đổi lớn nhất";
            this.gvMaterials_colUnitID_Max.ColumnEdit = this.gvMaterials_colUnitID_lk;
            this.gvMaterials_colUnitID_Max.FieldName = "UnitID_Max";
            this.gvMaterials_colUnitID_Max.Name = "gvMaterials_colUnitID_Max";
            this.gvMaterials_colUnitID_Max.OptionsColumn.AllowEdit = false;
            this.gvMaterials_colUnitID_Max.Width = 150;
            // 
            // gvMaterials_colStyle
            // 
            this.gvMaterials_colStyle.Caption = "Quy cách";
            this.gvMaterials_colStyle.FieldName = "Style";
            this.gvMaterials_colStyle.Name = "gvMaterials_colStyle";
            this.gvMaterials_colStyle.OptionsColumn.AllowEdit = false;
            this.gvMaterials_colStyle.Visible = true;
            this.gvMaterials_colStyle.VisibleIndex = 4;
            this.gvMaterials_colStyle.Width = 120;
            // 
            // gvMaterials_colMaterialsGroupName
            // 
            this.gvMaterials_colMaterialsGroupName.Caption = "Nhóm nguyên liệu";
            this.gvMaterials_colMaterialsGroupName.FieldName = "MaterialsGroupName";
            this.gvMaterials_colMaterialsGroupName.Name = "gvMaterials_colMaterialsGroupName";
            this.gvMaterials_colMaterialsGroupName.OptionsColumn.AllowEdit = false;
            // 
            // gvMaterials_colMaterialsGroupName_Sub
            // 
            this.gvMaterials_colMaterialsGroupName_Sub.Caption = "Nhóm nguyên liệu";
            this.gvMaterials_colMaterialsGroupName_Sub.FieldName = "MaterialsGroupName_Sub";
            this.gvMaterials_colMaterialsGroupName_Sub.Name = "gvMaterials_colMaterialsGroupName_Sub";
            this.gvMaterials_colMaterialsGroupName_Sub.Visible = true;
            this.gvMaterials_colMaterialsGroupName_Sub.VisibleIndex = 6;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.chkExpand);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(731, 45);
            this.panelControl1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(365, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 35);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy thao tác";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.Location = new System.Drawing.Point(242, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 35);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkExpand
            // 
            this.chkExpand.Location = new System.Drawing.Point(8, 13);
            this.chkExpand.Name = "chkExpand";
            this.chkExpand.Properties.Caption = "Gom nhóm";
            this.chkExpand.Size = new System.Drawing.Size(75, 20);
            this.chkExpand.TabIndex = 1;
            this.chkExpand.CheckedChanged += new System.EventHandler(this.chkExpand_CheckedChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gcMaterials);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 45);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(731, 523);
            this.panelControl2.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pageCategories_groupMaterialMenu_MenuAndMaterial_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 568);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageCategories_groupMaterialMenu_MenuAndMaterial_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách nguyên liệu của thực đơn";
            this.Load += new System.EventHandler(this.pageCategories_groupMaterialMenu_MenuAndMaterial_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials_colQuantity_txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterials_colUnitID_lk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkExpand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMaterials;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterials;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.CheckEdit chkExpand;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colID;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colName;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colCode;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gvMaterials_colUnitID_lk;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colUnitID_Max;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colStyle;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colMaterialsGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colQuantity;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gvMaterials_colMaterialsGroupName_Sub;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gvMaterials_colQuantity_txt;
    }
}