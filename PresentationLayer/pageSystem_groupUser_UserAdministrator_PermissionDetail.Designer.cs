
namespace PresentationLayer
{
    partial class pageSystem_groupUser_UserAdministrator_PermissionDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSystem_groupUser_UserAdministrator_PermissionDetail));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.tlPermissionDetail = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coltlUserAndPermissionDetail_Type = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.coltlUserAndPermissionDetail_MainID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlPermissionDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "BO_Security_Permission_Model_32x32.png");
            this.imageList2.Images.SetKeyName(1, "BO_Security_Permission_Type.png");
            this.imageList2.Images.SetKeyName(2, "BO_Security_Permission_32x32.png");
            this.imageList2.Images.SetKeyName(3, "Action_Navigation_History_Forward_32x32.png");
            this.imageList2.Images.SetKeyName(4, "BOProduct_32x32.png");
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnCancel);
            this.groupControl1.Controls.Add(this.btnOK);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 438);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(375, 60);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Thông tin nhóm quyền";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(198, 8);
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
            this.btnOK.Location = new System.Drawing.Point(64, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(120, 44);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tlPermissionDetail
            // 
            this.tlPermissionDetail.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tlPermissionDetail.Appearance.HeaderPanel.Options.UseFont = true;
            this.tlPermissionDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tlPermissionDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tlPermissionDetail.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.coltlUserAndPermissionDetail_Type,
            this.coltlUserAndPermissionDetail_MainID,
            this.treeListColumn6,
            this.treeListColumn7});
            this.tlPermissionDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlPermissionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPermissionDetail.IndicatorWidth = 40;
            this.tlPermissionDetail.Location = new System.Drawing.Point(0, 0);
            this.tlPermissionDetail.Name = "tlPermissionDetail";
            this.tlPermissionDetail.OptionsBehavior.Editable = false;
            this.tlPermissionDetail.OptionsBehavior.ReadOnly = true;
            this.tlPermissionDetail.OptionsSelection.MultiSelect = true;
            this.tlPermissionDetail.OptionsView.CheckBoxStyle = DevExpress.XtraTreeList.DefaultNodeCheckBoxStyle.Check;
            this.tlPermissionDetail.OptionsView.ShowIndicator = false;
            this.tlPermissionDetail.SelectImageList = this.imageList2;
            this.tlPermissionDetail.Size = new System.Drawing.Size(375, 438);
            this.tlPermissionDetail.TabIndex = 5;
            this.tlPermissionDetail.Tag = "Translate@Name";
            this.tlPermissionDetail.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlPermissionDetail_AfterCheckNode);
            this.tlPermissionDetail.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlPermissionDetail_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Tên quyền";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 346;
            // 
            // coltlUserAndPermissionDetail_Type
            // 
            this.coltlUserAndPermissionDetail_Type.Caption = "Loại";
            this.coltlUserAndPermissionDetail_Type.FieldName = "Type";
            this.coltlUserAndPermissionDetail_Type.Name = "coltlUserAndPermissionDetail_Type";
            this.coltlUserAndPermissionDetail_Type.Width = 100;
            // 
            // coltlUserAndPermissionDetail_MainID
            // 
            this.coltlUserAndPermissionDetail_MainID.Caption = "Mã ID";
            this.coltlUserAndPermissionDetail_MainID.FieldName = "MainID";
            this.coltlUserAndPermissionDetail_MainID.Name = "coltlUserAndPermissionDetail_MainID";
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
            // pageSystem_groupUser_UserAdministrator_PermissionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 498);
            this.ControlBox = false;
            this.Controls.Add(this.tlPermissionDetail);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageSystem_groupUser_UserAdministrator_PermissionDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm quyền";
            this.Load += new System.EventHandler(this.pageSystem_groupUser_UserAdministrator_PermissionDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlPermissionDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraTreeList.TreeList tlPermissionDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coltlUserAndPermissionDetail_Type;
        private DevExpress.XtraTreeList.Columns.TreeListColumn coltlUserAndPermissionDetail_MainID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
    }
}