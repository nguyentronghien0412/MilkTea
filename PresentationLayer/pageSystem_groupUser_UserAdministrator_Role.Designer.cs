
namespace PresentationLayer
{
    partial class pageSystem_groupUser_UserAdministrator_Role
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSystem_groupUser_UserAdministrator_Role));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.gcRole = new DevExpress.XtraGrid.GridControl();
            this.gvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlkcolUserAndRole_RoleID = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.rlkcolUserAndRole_CreatedBy = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkcolUserAndRole_RoleID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkcolUserAndRole_CreatedBy)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnOK);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 378);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(346, 60);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Thông tin nhóm quyền";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(180, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy thao tác";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.ImageOptions.Image")));
            this.btnOK.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(46, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 44);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gcRole
            // 
            this.gcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRole.Location = new System.Drawing.Point(0, 0);
            this.gcRole.MainView = this.gvRole;
            this.gcRole.Name = "gcRole";
            this.gcRole.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlkcolUserAndRole_RoleID,
            this.rlkcolUserAndRole_CreatedBy});
            this.gcRole.Size = new System.Drawing.Size(346, 378);
            this.gcRole.TabIndex = 55;
            this.gcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRole});
            // 
            // gvRole
            // 
            this.gvRole.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvRole.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvRole.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvRole.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gvRole.FormatRules.Add(gridFormatRule1);
            this.gvRole.GridControl = this.gcRole;
            this.gvRole.IndicatorWidth = 40;
            this.gvRole.Name = "gvRole";
            this.gvRole.OptionsBehavior.Editable = false;
            this.gvRole.OptionsBehavior.ReadOnly = true;
            this.gvRole.OptionsSelection.MultiSelect = true;
            this.gvRole.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvRole.OptionsView.ShowGroupPanel = false;
            this.gvRole.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvRole.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvRole_CustomDrawRowIndicator);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.Caption = "Tên nhóm quyền";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 248;
            // 
            // rlkcolUserAndRole_RoleID
            // 
            this.rlkcolUserAndRole_RoleID.AutoHeight = false;
            this.rlkcolUserAndRole_RoleID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkcolUserAndRole_RoleID.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.rlkcolUserAndRole_RoleID.Name = "rlkcolUserAndRole_RoleID";
            this.rlkcolUserAndRole_RoleID.NullText = "";
            // 
            // rlkcolUserAndRole_CreatedBy
            // 
            this.rlkcolUserAndRole_CreatedBy.AutoHeight = false;
            this.rlkcolUserAndRole_CreatedBy.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rlkcolUserAndRole_CreatedBy.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name4")});
            this.rlkcolUserAndRole_CreatedBy.Name = "rlkcolUserAndRole_CreatedBy";
            this.rlkcolUserAndRole_CreatedBy.NullText = "";
            // 
            // pageSystem_groupUser_UserAdministrator_Role
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 438);
            this.ControlBox = false;
            this.Controls.Add(this.gcRole);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageSystem_groupUser_UserAdministrator_Role";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm nhóm quyền";
            this.Load += new System.EventHandler(this.pageSystem_groupUser_UserAdministrator_Role_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkcolUserAndRole_RoleID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlkcolUserAndRole_CreatedBy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraGrid.GridControl gcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRole;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkcolUserAndRole_RoleID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlkcolUserAndRole_CreatedBy;
    }
}