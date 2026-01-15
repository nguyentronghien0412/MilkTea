using DataObject;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
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
    public partial class pageManagement_groupFunctions_TableAndDish_Print : DevExpress.XtraEditors.XtraForm
    {
        public string vType = "";
        public bool vIsPrint = false;
        public dtoPrintBill vPrintBill;
        public dtoBank vBank;

        public pageManagement_groupFunctions_TableAndDish_Print()
        {
            InitializeComponent();
        }

        private string GetPrinterName(string PrinterCode)
        {
            string PrinterName = "";

            if (File.Exists(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath)))
            {
                //load config
                XmlDocument doc = new XmlDocument();
                doc.Load(string.Format(@"{0}\SystemConfig.xml", Application.StartupPath));

                XmlNode PRINTER_GUIDE_DRUG = doc.SelectSingleNode(@"Root/"+ PrinterCode);
                if (PRINTER_GUIDE_DRUG != null)
                    if (PRINTER_GUIDE_DRUG.Attributes["PrinterName"] != null)
                        PrinterName = PRINTER_GUIDE_DRUG.Attributes["PrinterName"].Value;
            }

            return PrinterName;
        }

        private void pageManagement_groupFunctions_TableAndDish_Print_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (vType == "PrintBank")
                {
                    if (vBank == null)
                    {
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không có dữ liệu in");
                        return;
                    }
                }
                else
                {
                    if (vPrintBill == null || vPrintBill.dtDetail == null)
                    {
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không có dữ liệu in");
                        return;
                    }
                }
                
                string PrinterName = "";
                if (vType == "CheckBill" || vType == "PrintBill" || vType == "PrintBillButton" || vType == "PrintBank")
                {
                    PrinterName = GetPrinterName("PRINTER_BILL");
                    if (PrinterName == "")
                    {
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng cấu hình máy in.");
                        return;
                    }
                }

                if (vType == "CheckBill")
                {
                    #region CheckBill

                    this.Text = "In PHIẾU KIỂM MÓN";

                    pageManagement_groupFunctions_TableAndDish_rptCheck rptCheck = new pageManagement_groupFunctions_TableAndDish_rptCheck();
                    rptCheck.DataSource = vPrintBill.dtDetail;
                    rptCheck.BindData();
                    rptCheck.BindData_Information(vPrintBill);
                    documentViewer1.PrintingSystem = rptCheck.PrintingSystem;
                    rptCheck.CreateDocument();

                    if (vIsPrint)
                    {
                        using (ReportPrintTool printTool = new ReportPrintTool(rptCheck))
                        {
                            if (PrinterName != "")
                                printTool.PrinterSettings.PrinterName = PrinterName;

                            printTool.Print();
                            this.Close();
                        }
                    }
                    else
                    {
                        rptCheck.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                        rptCheck.ShowPrintStatusDialog = false;
                    }

                    #endregion
                }
                else if (vType == "PrintBill" || vType == "PrintBillButton")
                {
                    this.Text = "In PHIẾU THANH TOÁN";

                    #region Get Quantity Bill

                    int vQuantityBill = 0;
                    BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
                    DataTable dtDefinition = new DataTable();
                    string _Result = bGeneral.GetAll(callFrom, ref dtDefinition, "Definition", null);
                    if (_Result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + _Result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetAll");
                        return;
                    }

                    foreach (DataRow dr in dtDefinition.Rows)
                        if (dr["Code"].ToString() == "QUANTITY_BILL")
                        {
                            vQuantityBill = int.Parse(dr["Value"].ToString());
                            break;
                        }

                    if (vQuantityBill == 0 && vType == "PrintBillButton") 
                        vQuantityBill = 1;

                    #endregion

                    if (vPrintBill.PromotionAmount == "")
                    {
                        #region PrintBill Normal

                        pageManagement_groupFunctions_TableAndDish_rpt rptPayment = new pageManagement_groupFunctions_TableAndDish_rpt();
                        rptPayment.DataSource = vPrintBill.dtDetail;
                        rptPayment.BindData();
                        rptPayment.BindData_Information(vPrintBill);
                        documentViewer1.PrintingSystem = rptPayment.PrintingSystem;
                        rptPayment.CreateDocument();

                        if (vIsPrint)
                        {
                            using (ReportPrintTool printTool = new ReportPrintTool(rptPayment))
                            {
                                if (PrinterName != "")
                                    printTool.PrinterSettings.PrinterName = PrinterName;

                                for (int i = 1; i <= vQuantityBill; i++)
                                    printTool.Print();
                                
                                this.Close();
                            }
                        }
                        else
                        {
                            rptPayment.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                            rptPayment.ShowPrintStatusDialog = false;
                        }

                        #endregion
                    }
                    else
                    {
                        #region PrintBill Promotion

                        pageManagement_groupFunctions_TableAndDish_rptPromotion rptPromotion = new pageManagement_groupFunctions_TableAndDish_rptPromotion();
                        rptPromotion.DataSource = vPrintBill.dtDetail;
                        rptPromotion.BindData();
                        rptPromotion.BindData_Information(vPrintBill);
                        documentViewer1.PrintingSystem = rptPromotion.PrintingSystem;
                        rptPromotion.CreateDocument();

                        if (vIsPrint)
                        {
                            using (ReportPrintTool printTool = new ReportPrintTool(rptPromotion))
                            {
                                if (PrinterName != "")
                                    printTool.PrinterSettings.PrinterName = PrinterName;

                                for (int i = 1; i <= vQuantityBill; i++)
                                    printTool.Print();

                                this.Close();
                            }
                        }
                        else
                        {
                            rptPromotion.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                            rptPromotion.ShowPrintStatusDialog = false;
                        }

                        #endregion
                    }
                }
                else if (vType == "PrintBank")
                {
                    #region PrintBank

                    this.Text = "In Tài khoản ngân hàng";

                    pageManagement_groupFunctions_TableAndDish_rptBank rptBank = new pageManagement_groupFunctions_TableAndDish_rptBank();
                    rptBank.BindData_Information(vBank);
                    documentViewer1.PrintingSystem = rptBank.PrintingSystem;
                    rptBank.CreateDocument();

                    if (vIsPrint)
                    {
                        using (ReportPrintTool printTool = new ReportPrintTool(rptBank))
                        {
                            if (PrinterName != "")
                                printTool.PrinterSettings.PrinterName = PrinterName;

                            printTool.Print();
                            this.Close();
                        }
                    }
                    else
                    {
                        rptBank.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                        rptBank.ShowPrintStatusDialog = false;
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}