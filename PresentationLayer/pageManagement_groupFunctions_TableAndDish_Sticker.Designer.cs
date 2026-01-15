namespace PresentationLayer
{
    partial class pageManagement_groupFunctions_TableAndDish_Sticker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageManagement_groupFunctions_TableAndDish_Sticker));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtContent = new DevExpress.XtraRichEdit.RichEditControl();
            this.txtQuantitySticker = new DevExpress.XtraEditors.TextEdit();
            this.groupControl22 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lkFontColor = new DevExpress.XtraEditors.ColorEdit();
            this.lkFonts = new DevExpress.XtraEditors.LookUpEdit();
            this.btnFontBold = new DevExpress.XtraEditors.SimpleButton();
            this.btnFontUnderline = new DevExpress.XtraEditors.SimpleButton();
            this.btnFontNormal = new DevExpress.XtraEditors.SimpleButton();
            this.lkFontSize = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.btnFontItalic = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl32 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.documentViewer1 = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantitySticker.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl22)).BeginInit();
            this.groupControl22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkFontColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFonts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFontSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 295);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Số bản in";
            // 
            // txtContent
            // 
            this.txtContent.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtContent.Appearance.Text.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContent.Appearance.Text.Options.UseFont = true;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Pixel;
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(348, 202);
            this.txtContent.TabIndex = 16;
            this.txtContent.Tag = "*";
            this.txtContent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtContent_KeyUp);
            // 
            // txtQuantitySticker
            // 
            this.txtQuantitySticker.EditValue = "1";
            this.txtQuantitySticker.Location = new System.Drawing.Point(56, 291);
            this.txtQuantitySticker.Name = "txtQuantitySticker";
            this.txtQuantitySticker.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantitySticker.Properties.Appearance.Options.UseFont = true;
            this.txtQuantitySticker.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQuantitySticker.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtQuantitySticker.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtQuantitySticker.Properties.MaskSettings.Set("mask", "d");
            this.txtQuantitySticker.Properties.MaxLength = 2;
            this.txtQuantitySticker.Properties.UseMaskAsDisplayFormat = true;
            this.txtQuantitySticker.Size = new System.Drawing.Size(50, 20);
            this.txtQuantitySticker.TabIndex = 17;
            // 
            // groupControl22
            // 
            this.groupControl22.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl22.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl22.Controls.Add(this.panelControl3);
            this.groupControl22.Controls.Add(this.panelControl2);
            this.groupControl22.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl22.Location = new System.Drawing.Point(0, 0);
            this.groupControl22.Name = "groupControl22";
            this.groupControl22.Size = new System.Drawing.Size(352, 285);
            this.groupControl22.TabIndex = 18;
            this.groupControl22.Text = "Nội dung";
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.txtContent);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 81);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(348, 202);
            this.panelControl3.TabIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lkFontColor);
            this.panelControl2.Controls.Add(this.lkFonts);
            this.panelControl2.Controls.Add(this.btnFontBold);
            this.panelControl2.Controls.Add(this.btnFontUnderline);
            this.panelControl2.Controls.Add(this.btnFontNormal);
            this.panelControl2.Controls.Add(this.lkFontSize);
            this.panelControl2.Controls.Add(this.labelControl38);
            this.panelControl2.Controls.Add(this.btnFontItalic);
            this.panelControl2.Controls.Add(this.labelControl32);
            this.panelControl2.Controls.Add(this.labelControl37);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(348, 58);
            this.panelControl2.TabIndex = 0;
            // 
            // lkFontColor
            // 
            this.lkFontColor.EditValue = System.Drawing.Color.Empty;
            this.lkFontColor.Location = new System.Drawing.Point(62, 32);
            this.lkFontColor.Name = "lkFontColor";
            this.lkFontColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFontColor.Properties.NullColor = System.Drawing.Color.Empty;
            this.lkFontColor.Size = new System.Drawing.Size(174, 20);
            this.lkFontColor.TabIndex = 13;
            this.lkFontColor.EditValueChanged += new System.EventHandler(this.lkFontColor_EditValueChanged);
            // 
            // lkFonts
            // 
            this.lkFonts.Location = new System.Drawing.Point(34, 6);
            this.lkFonts.Name = "lkFonts";
            this.lkFonts.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lkFonts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFonts.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name9"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name10", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkFonts.Properties.DropDownRows = 20;
            this.lkFonts.Properties.NullText = "";
            this.lkFonts.Properties.ShowHeader = false;
            this.lkFonts.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkFonts.Size = new System.Drawing.Size(202, 20);
            this.lkFonts.TabIndex = 8;
            this.lkFonts.EditValueChanged += new System.EventHandler(this.lkFonts_EditValueChanged);
            // 
            // btnFontBold
            // 
            this.btnFontBold.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFontBold.Appearance.Options.UseFont = true;
            this.btnFontBold.Location = new System.Drawing.Point(268, 5);
            this.btnFontBold.Name = "btnFontBold";
            this.btnFontBold.Size = new System.Drawing.Size(22, 23);
            this.btnFontBold.TabIndex = 10;
            this.btnFontBold.Text = "B";
            this.btnFontBold.Click += new System.EventHandler(this.btnFontBold_Click);
            // 
            // btnFontUnderline
            // 
            this.btnFontUnderline.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.btnFontUnderline.Appearance.Options.UseFont = true;
            this.btnFontUnderline.Location = new System.Drawing.Point(321, 5);
            this.btnFontUnderline.Name = "btnFontUnderline";
            this.btnFontUnderline.Size = new System.Drawing.Size(22, 23);
            this.btnFontUnderline.TabIndex = 12;
            this.btnFontUnderline.Text = "U";
            this.btnFontUnderline.Click += new System.EventHandler(this.btnFontUnderline_Click);
            // 
            // btnFontNormal
            // 
            this.btnFontNormal.Location = new System.Drawing.Point(241, 5);
            this.btnFontNormal.Name = "btnFontNormal";
            this.btnFontNormal.Size = new System.Drawing.Size(22, 23);
            this.btnFontNormal.TabIndex = 9;
            this.btnFontNormal.Text = "N";
            this.btnFontNormal.Click += new System.EventHandler(this.btnFontNormal_Click);
            // 
            // lkFontSize
            // 
            this.lkFontSize.Location = new System.Drawing.Point(269, 32);
            this.lkFontSize.Name = "lkFontSize";
            this.lkFontSize.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lkFontSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkFontSize.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name9"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Name10", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lkFontSize.Properties.DropDownRows = 20;
            this.lkFontSize.Properties.NullText = "";
            this.lkFontSize.Properties.ShowHeader = false;
            this.lkFontSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkFontSize.Size = new System.Drawing.Size(74, 20);
            this.lkFontSize.TabIndex = 14;
            this.lkFontSize.EditValueChanged += new System.EventHandler(this.lkFontSize_EditValueChanged);
            // 
            // labelControl38
            // 
            this.labelControl38.Location = new System.Drawing.Point(6, 36);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(50, 13);
            this.labelControl38.TabIndex = 132;
            this.labelControl38.Text = "Text Color";
            // 
            // btnFontItalic
            // 
            this.btnFontItalic.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.btnFontItalic.Appearance.Options.UseFont = true;
            this.btnFontItalic.Location = new System.Drawing.Point(294, 5);
            this.btnFontItalic.Name = "btnFontItalic";
            this.btnFontItalic.Size = new System.Drawing.Size(22, 23);
            this.btnFontItalic.TabIndex = 11;
            this.btnFontItalic.Text = "I";
            this.btnFontItalic.Click += new System.EventHandler(this.btnFontItalic_Click);
            // 
            // labelControl32
            // 
            this.labelControl32.Location = new System.Drawing.Point(244, 36);
            this.labelControl32.Name = "labelControl32";
            this.labelControl32.Size = new System.Drawing.Size(19, 13);
            this.labelControl32.TabIndex = 126;
            this.labelControl32.Text = "Size";
            // 
            // labelControl37
            // 
            this.labelControl37.Location = new System.Drawing.Point(6, 10);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(22, 13);
            this.labelControl37.TabIndex = 124;
            this.labelControl37.Text = "Font";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.groupControl22);
            this.panelControl1.Controls.Add(this.txtQuantitySticker);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(352, 319);
            this.panelControl1.TabIndex = 19;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(112, 295);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(197, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "* Chú ý: Số bản in tối đa là 10 (bản)";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.btnView);
            this.panelControl4.Controls.Add(this.btnClose);
            this.panelControl4.Controls.Add(this.btnPrint);
            this.panelControl4.Controls.Add(this.groupControl1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(352, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(409, 319);
            this.panelControl4.TabIndex = 20;
            // 
            // btnView
            // 
            this.btnView.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnView.ImageOptions.SvgImage")));
            this.btnView.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnView.Location = new System.Drawing.Point(51, 290);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(100, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "Xem bản in";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnClose.Location = new System.Drawing.Point(263, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Hủy thao tác";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnPrint.Location = new System.Drawing.Point(157, 290);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "In Sticker";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.documentViewer1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(405, 281);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Bản in";
            // 
            // documentViewer1
            // 
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.IsMetric = false;
            this.documentViewer1.Location = new System.Drawing.Point(2, 23);
            this.documentViewer1.Name = "documentViewer1";
            this.documentViewer1.Size = new System.Drawing.Size(401, 256);
            this.documentViewer1.TabIndex = 0;
            // 
            // pageManagement_groupFunctions_TableAndDish_Sticker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 319);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl4);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pageManagement_groupFunctions_TableAndDish_Sticker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In Sticker";
            this.Load += new System.EventHandler(this.pageManagement_groupFunctions_TableAndDish_Sticker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantitySticker.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl22)).EndInit();
            this.groupControl22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkFontColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFonts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkFontSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraRichEdit.RichEditControl txtContent;
        private DevExpress.XtraEditors.GroupControl groupControl22;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ColorEdit lkFontColor;
        private DevExpress.XtraEditors.LookUpEdit lkFonts;
        private DevExpress.XtraEditors.SimpleButton btnFontBold;
        private DevExpress.XtraEditors.SimpleButton btnFontUnderline;
        private DevExpress.XtraEditors.SimpleButton btnFontNormal;
        private DevExpress.XtraEditors.LookUpEdit lkFontSize;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.SimpleButton btnFontItalic;
        private DevExpress.XtraEditors.LabelControl labelControl32;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.TextEdit txtQuantitySticker;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraPrinting.Preview.DocumentViewer documentViewer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnView;
    }
}