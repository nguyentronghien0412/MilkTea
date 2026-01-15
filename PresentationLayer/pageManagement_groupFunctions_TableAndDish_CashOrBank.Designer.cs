
namespace PresentationLayer
{
    partial class pageManagement_groupFunctions_TableAndDish_CashOrBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupFunctions_TableAndDish_CashOrBank));
            this.btnCash = new DevExpress.XtraEditors.SimpleButton();
            this.btnBank = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lbTableName = new DevExpress.XtraEditors.LabelControl();
            this.btnShopeeFood = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrab = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // btnCash
            // 
            this.btnCash.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCash.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCash.ImageOptions.SvgImage")));
            this.btnCash.Location = new System.Drawing.Point(27, 67);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(89, 56);
            this.btnCash.TabIndex = 0;
            this.btnCash.Text = "Tiền mặt";
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnBank
            // 
            this.btnBank.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnBank.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBank.ImageOptions.SvgImage")));
            this.btnBank.Location = new System.Drawing.Point(147, 67);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(89, 56);
            this.btnBank.TabIndex = 1;
            this.btnBank.Text = "Chuyển khoản";
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(261, 27);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Hình thức thanh toán";
            // 
            // btnCancel
            // 
            this.btnCancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.Location = new System.Drawing.Point(27, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 56);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy thao tác";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbTableName
            // 
            this.lbTableName.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTableName.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lbTableName.Appearance.Options.UseFont = true;
            this.lbTableName.Appearance.Options.UseForeColor = true;
            this.lbTableName.Appearance.Options.UseTextOptions = true;
            this.lbTableName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbTableName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbTableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTableName.Location = new System.Drawing.Point(0, 27);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(261, 29);
            this.lbTableName.TabIndex = 4;
            this.lbTableName.Text = "BÀN 01";
            // 
            // btnShopeeFood
            // 
            this.btnShopeeFood.ImageOptions.ImageIndex = 0;
            this.btnShopeeFood.ImageOptions.ImageList = this.imageList2;
            this.btnShopeeFood.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnShopeeFood.Location = new System.Drawing.Point(147, 136);
            this.btnShopeeFood.Name = "btnShopeeFood";
            this.btnShopeeFood.Size = new System.Drawing.Size(89, 56);
            this.btnShopeeFood.TabIndex = 3;
            this.btnShopeeFood.Text = "Chuyển khoản";
            this.btnShopeeFood.Click += new System.EventHandler(this.btnShopeeFood_Click);
            // 
            // btnGrab
            // 
            this.btnGrab.ImageOptions.ImageIndex = 0;
            this.btnGrab.ImageOptions.ImageList = this.imageList1;
            this.btnGrab.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnGrab.Location = new System.Drawing.Point(27, 136);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(89, 56);
            this.btnGrab.TabIndex = 2;
            this.btnGrab.Text = "Grab";
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Grab.png");
            this.imageList1.Images.SetKeyName(1, "ShopeeFood.jpg");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "ShopeeFood.png");
            // 
            // pageManagement_groupFunctions_TableAndDish_CashOrBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 278);
            this.ControlBox = false;
            this.Controls.Add(this.btnShopeeFood);
            this.Controls.Add(this.btnGrab);
            this.Controls.Add(this.lbTableName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.btnCash);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageManagement_groupFunctions_TableAndDish_CashOrBank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hình thức thanh toán";
            this.Load += new System.EventHandler(this.pageManagement_groupFunctions_TableAndDish_CashOrBank_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCash;
        private DevExpress.XtraEditors.SimpleButton btnBank;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lbTableName;
        private DevExpress.XtraEditors.SimpleButton btnShopeeFood;
        private DevExpress.XtraEditors.SimpleButton btnGrab;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}