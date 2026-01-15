using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish_Sticker : DevExpress.XtraEditors.XtraForm
    {
        pageManagement_groupFunctions_TableAndDish_rptSticker rptView = new pageManagement_groupFunctions_TableAndDish_rptSticker();

        public pageManagement_groupFunctions_TableAndDish_Sticker()
        {
            InitializeComponent();
        }

        private void lkFonts_EditValueChanged(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (txtContent.Document.Selection.Length == 0)
                    return;
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.FontName = lkFonts.EditValue.ToString();
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnFontNormal_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.Underline = UnderlineType.None;
                cp.Bold = false;
                cp.Italic = false;
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnFontBold_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.Bold = true;
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnFontItalic_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.Italic = true;
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnFontUnderline_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.Underline = UnderlineType.Single;
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void lkFontColor_EditValueChanged(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (txtContent.Document.Selection.Length == 0)
                    return;
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.ForeColor = (Color)lkFontColor.EditValue;
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void lkFontSize_EditValueChanged(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (txtContent.Document.Selection.Length == 0)
                    return;
                DocumentRange range = txtContent.Document.Selection;
                ParagraphProperties pp = txtContent.Document.BeginUpdateParagraphs(range);
                txtContent.Document.EndUpdateParagraphs(pp);
                CharacterProperties cp = txtContent.Document.BeginUpdateCharacters(range);
                cp.FontSize = int.Parse(lkFontSize.EditValue.ToString());
                txtContent.Document.EndUpdateCharacters(cp);

                btnPrint.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void pageManagement_groupFunctions_TableAndDish_Sticker_Load(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable vdtFonts = new DataTable();
                vdtFonts.Columns.Add("ID");
                vdtFonts.Columns.Add("Name");

                foreach (FontFamily font in System.Drawing.FontFamily.Families)
                    vdtFonts.Rows.Add(font.Name, font.Name);

                lkFonts.Properties.ValueMember = "ID";
                lkFonts.Properties.DisplayMember = "Name";
                lkFonts.Properties.DataSource = vdtFonts;
                lkFonts.ItemIndex = 0;

                DataTable vdtSize = new DataTable();
                vdtSize.Columns.Add("ID");
                vdtSize.Columns.Add("Name");

                for (int i = 1; i < 100; i++)
                    vdtSize.Rows.Add(i, i);

                lkFontSize.Properties.ValueMember = "ID";
                lkFontSize.Properties.DisplayMember = "Name";
                lkFontSize.Properties.DataSource = vdtSize;
                lkFontSize.ItemIndex = 10;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void LoadPrintView()
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                rptView = new pageManagement_groupFunctions_TableAndDish_rptSticker();
                rptView.BindData_Information(txtContent.RtfText);
                documentViewer1.PrintingSystem = rptView.PrintingSystem;
                rptView.CreateDocument();

                rptView.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                rptView.ShowPrintStatusDialog = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void txtContent_KeyUp(object sender, KeyEventArgs e)
        {
            btnPrint.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Utilities.Functions.MessageBoxYesNo("Bạn muốn đóng giao diện này?") != DialogResult.Yes)
                return;

            this.Close();
        }

        private string GetPrinterName(string PrinterCode)
        {
            string PrinterName = "";

            if (File.Exists(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath)))
            {
                //load config
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath));

                XmlNode PRINTER_GUIDE_DRUG = doc.SelectSingleNode(@"Root/" + PrinterCode);
                if (PRINTER_GUIDE_DRUG != null)
                    if (PRINTER_GUIDE_DRUG.Attributes["PrinterName"] != null)
                        PrinterName = PRINTER_GUIDE_DRUG.Attributes["PrinterName"].Value;
            }

            return PrinterName;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (txtQuantitySticker.Text == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập số bản in.");
                    return;
                }
                if (int.Parse(txtQuantitySticker.Text) < 1 || int.Parse(txtQuantitySticker.Text) > 10)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Số bản in ít nhất là 1, nhiều nhất là 10.");
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn in Sticker?") != DialogResult.Yes)
                    return;

                string PrinterName= GetPrinterName("PRINTER_STICKER");
                using (ReportPrintTool printTool = new ReportPrintTool(rptView))
                {
                    if (PrinterName != "")
                        printTool.PrinterSettings.PrinterName = PrinterName;

                    for (int i = 1; i <= int.Parse(txtQuantitySticker.Text); i++)
                        printTool.Print();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                LoadPrintView();
                btnPrint.Enabled = true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }
    }
}