
namespace PresentationLayer
{
    partial class pageSystem_groupUser_Role_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSystem_groupUser_Role_Edit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.Role_Note = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Role_StatusID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Role_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tlRoleDetail = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colMainID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Role_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_StatusID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlRoleDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.Role_Note);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.Role_StatusID);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.Role_Name);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(760, 72);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Thông tin nhóm quyền";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(653, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy thao tác";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(573, 23);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 44);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Role_Note
            // 
            this.Role_Note.Location = new System.Drawing.Point(97, 47);
            this.Role_Note.Name = "Role_Note";
            this.Role_Note.Size = new System.Drawing.Size(470, 20);
            this.Role_Note.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 51);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Ghi chú:";
            // 
            // Role_StatusID
            // 
            this.Role_StatusID.Location = new System.Drawing.Point(439, 25);
            this.Role_StatusID.Name = "Role_StatusID";
            this.Role_StatusID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Role_StatusID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name2")});
            this.Role_StatusID.Properties.NullText = "";
            this.Role_StatusID.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.Role_StatusID.Properties.ShowHeader = false;
            this.Role_StatusID.Size = new System.Drawing.Size(128, 20);
            this.Role_StatusID.TabIndex = 1;
            this.Role_StatusID.Tag = "*";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(378, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Trạng thái:";
            // 
            // Role_Name
            // 
            this.Role_Name.Location = new System.Drawing.Point(97, 24);
            this.Role_Name.Name = "Role_Name";
            this.Role_Name.Size = new System.Drawing.Size(275, 20);
            this.Role_Name.TabIndex = 0;
            this.Role_Name.Tag = "*";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên nhóm quyền:";
            // 
            // tlRoleDetail
            // 
            this.tlRoleDetail.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tlRoleDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.tlRoleDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tlRoleDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlRoleDetail.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.colType,
            this.treeListColumn3,
            this.treeListColumn4,
            this.colMainID,
            this.treeListColumn6,
            this.treeListColumn7});
            this.tlRoleDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlRoleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlRoleDetail.IndicatorWidth = 40;
            this.tlRoleDetail.Location = new System.Drawing.Point(0, 72);
            this.tlRoleDetail.Name = "tlRoleDetail";
            this.tlRoleDetail.OptionsBehavior.Editable = false;
            this.tlRoleDetail.OptionsBehavior.ReadOnly = true;
            this.tlRoleDetail.OptionsSelection.MultiSelect = true;
            this.tlRoleDetail.OptionsView.AutoWidth = false;
            this.tlRoleDetail.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlRoleDetail.OptionsView.ShowIndicator = false;
            this.tlRoleDetail.SelectImageList = this.imageList1;
            this.tlRoleDetail.Size = new System.Drawing.Size(760, 434);
            this.tlRoleDetail.StateImageList = this.imageList1;
            this.tlRoleDetail.TabIndex = 4;
            this.tlRoleDetail.Tag = "Translate@Name";
            this.tlRoleDetail.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlRoleDetail_AfterCheckNode);
            this.tlRoleDetail.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlRoleDetail_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Tên quyền";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 450;
            // 
            // colType
            // 
            this.colType.Caption = "Loại";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Width = 100;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "Ngày tạo";
            this.treeListColumn3.FieldName = "CreatedDate";
            this.treeListColumn3.Format.FormatString = "dd/MM/yyyy";
            this.treeListColumn3.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowEdit = false;
            this.treeListColumn3.OptionsColumn.ReadOnly = true;
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 1;
            this.treeListColumn3.Width = 90;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "Người tạo";
            this.treeListColumn4.FieldName = "CreatedByName";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 2;
            this.treeListColumn4.Width = 150;
            // 
            // colMainID
            // 
            this.colMainID.Caption = "Mã ID";
            this.colMainID.FieldName = "MainID";
            this.colMainID.Name = "colMainID";
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "ID";
            this.treeListColumn6.FieldName = "ID";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "ParentID";
            this.treeListColumn7.FieldName = "ParentID";
            this.treeListColumn7.Name = "treeListColumn7";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BO_Security_Permission_Model_32x32.png");
            this.imageList1.Images.SetKeyName(1, "BO_Security_Permission_Type.png");
            this.imageList1.Images.SetKeyName(2, "BO_Security_Permission_32x32.png");
            this.imageList1.Images.SetKeyName(3, "Action_Navigation_History_Forward_32x32.png");
            // 
            // pageSystem_groupUser_Role_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 506);
            this.ControlBox = false;
            this.Controls.Add(this.tlRoleDetail);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageSystem_groupUser_Role_Edit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhóm quyền thao tác";
            this.Load += new System.EventHandler(this.pageSystem_groupUser_Role_Edit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Role_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_StatusID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlRoleDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit Role_Note;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit Role_StatusID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Role_Name;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList tlRoleDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colMainID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private System.Windows.Forms.ImageList imageList1;
    }
}