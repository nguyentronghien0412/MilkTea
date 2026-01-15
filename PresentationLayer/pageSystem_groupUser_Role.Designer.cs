
namespace PresentationLayer
{
    partial class pageSystem_groupUser_Role
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSystem_groupUser_Role));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcRole = new DevExpress.XtraGrid.GridControl();
            this.gvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedByName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedByName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tlRoleDetail = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlRoleDetail)).BeginInit();
            this.SuspendLayout();
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1364, 538);
            this.splitContainerControl1.SplitterPosition = 680;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.gcRole);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(680, 538);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Danh sách Nhóm quyền";
            // 
            // gcRole
            // 
            this.gcRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRole.Location = new System.Drawing.Point(2, 23);
            this.gcRole.MainView = this.gvRole;
            this.gcRole.Name = "gcRole";
            this.gcRole.Size = new System.Drawing.Size(676, 513);
            this.gcRole.TabIndex = 4;
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
            this.colName,
            this.colNote,
            this.colStatusName,
            this.colCreatedByName,
            this.colCreatedDate,
            this.colLastUpdatedByName,
            this.colLastUpdatedDate});
            this.gvRole.GridControl = this.gcRole;
            this.gvRole.IndicatorWidth = 40;
            this.gvRole.Name = "gvRole";
            this.gvRole.OptionsBehavior.Editable = false;
            this.gvRole.OptionsBehavior.ReadOnly = true;
            this.gvRole.OptionsView.ColumnAutoWidth = false;
            this.gvRole.OptionsView.ShowGroupPanel = false;
            this.gvRole.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvRole.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvRole_CustomDrawRowIndicator);
            this.gvRole.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvRole_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "Mã nhóm quyền";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.Caption = "Tên nhóm quyền";
            this.colName.FieldName = "Name";
            this.colName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 200;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 6;
            this.colNote.Width = 300;
            // 
            // colStatusName
            // 
            this.colStatusName.Caption = "Trạng thái";
            this.colStatusName.FieldName = "StatusName";
            this.colStatusName.Name = "colStatusName";
            this.colStatusName.Visible = true;
            this.colStatusName.VisibleIndex = 1;
            this.colStatusName.Width = 100;
            // 
            // colCreatedByName
            // 
            this.colCreatedByName.Caption = "Người tạo";
            this.colCreatedByName.FieldName = "CreatedByName";
            this.colCreatedByName.Name = "colCreatedByName";
            this.colCreatedByName.Visible = true;
            this.colCreatedByName.VisibleIndex = 2;
            this.colCreatedByName.Width = 120;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 3;
            this.colCreatedDate.Width = 90;
            // 
            // colLastUpdatedByName
            // 
            this.colLastUpdatedByName.Caption = "Người cập nhật";
            this.colLastUpdatedByName.FieldName = "LastUpdatedByName";
            this.colLastUpdatedByName.Name = "colLastUpdatedByName";
            this.colLastUpdatedByName.Visible = true;
            this.colLastUpdatedByName.VisibleIndex = 4;
            this.colLastUpdatedByName.Width = 120;
            // 
            // colLastUpdatedDate
            // 
            this.colLastUpdatedDate.Caption = "Ngày cập nhật";
            this.colLastUpdatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colLastUpdatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLastUpdatedDate.FieldName = "LastUpdatedDate";
            this.colLastUpdatedDate.Name = "colLastUpdatedDate";
            this.colLastUpdatedDate.Visible = true;
            this.colLastUpdatedDate.VisibleIndex = 5;
            this.colLastUpdatedDate.Width = 90;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.tlRoleDetail);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(674, 538);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Danh sách Quyền chi tiết";
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
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6});
            this.tlRoleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlRoleDetail.Location = new System.Drawing.Point(2, 23);
            this.tlRoleDetail.Name = "tlRoleDetail";
            this.tlRoleDetail.OptionsBehavior.Editable = false;
            this.tlRoleDetail.OptionsBehavior.ReadOnly = true;
            this.tlRoleDetail.OptionsView.AutoWidth = false;
            this.tlRoleDetail.OptionsView.ShowIndicator = false;
            this.tlRoleDetail.SelectImageList = this.imageList1;
            this.tlRoleDetail.Size = new System.Drawing.Size(670, 513);
            this.tlRoleDetail.TabIndex = 0;
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
            this.treeListColumn1.Width = 400;
            // 
            // colType
            // 
            this.colType.Caption = "Loại";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Width = 100;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Ngày tạo";
            this.treeListColumn2.FieldName = "CreatedDate";
            this.treeListColumn2.Format.FormatString = "dd/MM/yyyy";
            this.treeListColumn2.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 90;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Người tạo";
            this.treeListColumn3.FieldName = "CreatedByName";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 150;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "Mã ID";
            this.treeListColumn4.FieldName = "MainID";
            this.treeListColumn4.Name = "treeListColumn4";
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "ID";
            this.treeListColumn5.FieldName = "ID";
            this.treeListColumn5.Name = "treeListColumn5";
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "ParentID";
            this.treeListColumn6.FieldName = "ParentID";
            this.treeListColumn6.Name = "treeListColumn6";
            // 
            // pageSystem_groupUser_Role
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 538);
            this.Controls.Add(this.splitContainerControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "pageSystem_groupUser_Role";
            this.Text = "Nhóm quyền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.pageSystem_groupUser_Role_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.pageSystem_groupUser_Role_FormClosed);
            this.Load += new System.EventHandler(this.pageSystem_groupUser_Role_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlRoleDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRole;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedByName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedByName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastUpdatedDate;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraTreeList.TreeList tlRoleDetail;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
    }
}