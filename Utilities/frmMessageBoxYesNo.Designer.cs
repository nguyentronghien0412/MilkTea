
namespace Utilities
{
    partial class frmMessageBoxYesNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageBoxYesNo));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnNo = new DevExpress.XtraEditors.SimpleButton();
            this.btnYes = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lbContent = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnNo);
            this.panelControl1.Controls.Add(this.btnYes);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 133);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(598, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNo.ImageOptions.SvgImage")));
            this.btnNo.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnNo.Location = new System.Drawing.Point(308, 5);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 23);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "Không đồng ý";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnYes.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYes.ImageOptions.SvgImage")));
            this.btnYes.ImageOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            this.btnYes.Location = new System.Drawing.Point(194, 5);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(100, 23);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Đồng ý";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbContent);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(598, 133);
            this.panelControl2.TabIndex = 1;
            // 
            // lbContent
            // 
            this.lbContent.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbContent.Appearance.Options.UseFont = true;
            this.lbContent.Appearance.Options.UseTextOptions = true;
            this.lbContent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lbContent.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbContent.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lbContent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbContent.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lbContent.LineVisible = true;
            this.lbContent.Location = new System.Drawing.Point(2, 2);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(594, 129);
            this.lbContent.TabIndex = 0;
            this.lbContent.Text = "Message content";
            // 
            // frmMessageBoxYesNo
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(598, 168);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "frmMessageBoxYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message Box";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMessageBoxYesNo_FormClosed);
            this.Load += new System.EventHandler(this.frmMessageBoxYesNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lbContent;
        private DevExpress.XtraEditors.SimpleButton btnYes;
        private DevExpress.XtraEditors.SimpleButton btnNo;
    }
}