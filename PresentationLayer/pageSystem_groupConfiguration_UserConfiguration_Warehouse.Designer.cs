
namespace PresentationLayer
{
    partial class pageSystem_groupConfiguration_UserConfiguration_Warehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSystem_groupConfiguration_UserConfiguration_Warehouse));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnĐóng = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(460, 45);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Cấu hình Quản lý kho";
            // 
            // btnOpen
            // 
            this.btnOpen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnOpen.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOpen.ImageOptions.SvgImage")));
            this.btnOpen.Location = new System.Drawing.Point(132, 51);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(84, 60);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Mở";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnĐóng
            // 
            this.btnĐóng.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnĐóng.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnĐóng.ImageOptions.SvgImage")));
            this.btnĐóng.Location = new System.Drawing.Point(240, 51);
            this.btnĐóng.Name = "btnĐóng";
            this.btnĐóng.Size = new System.Drawing.Size(84, 60);
            this.btnĐóng.TabIndex = 2;
            this.btnĐóng.Text = "Đóng";
            this.btnĐóng.Click += new System.EventHandler(this.btnĐóng_Click);
            // 
            // pageSystem_groupConfiguration_UserConfiguration_Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 125);
            this.ControlBox = false;
            this.Controls.Add(this.btnĐóng);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageSystem_groupConfiguration_UserConfiguration_Warehouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý kho";
            this.Load += new System.EventHandler(this.pageSystem_groupConfiguration_UserConfiguration_Warehouse_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.SimpleButton btnĐóng;
    }
}