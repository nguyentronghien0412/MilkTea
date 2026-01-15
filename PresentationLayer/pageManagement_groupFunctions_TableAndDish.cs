using BusinessLogicLayer;
using DataObject;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting;
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
using DevExpress.XtraReports.UI;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_TableAndDish : DevExpress.XtraEditors.XtraForm
    {
        int selectedOrderID = 0;
        BusinessLogicLayer.busOrder bOrder = new BusinessLogicLayer.busOrder();
        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageManagement_groupFunctions_TableAndDish()
        {
            InitializeComponent();
        }

        #region Functions

        public void LoadDefinition(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtDefinition = new DataTable();
                busGeneralFunctions bGeneral = new busGeneralFunctions();
                string _Result = bGeneral.GetAll(callFrom, ref dtDefinition, "Definition", "");
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Definition_GetAll:\n" + _Result);
                    MessageBox.Show(_Result + "\n" + callFrom + " -> Definition_GetAll", Utilities.Parameters.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (DataRow dr in dtDefinition.Rows)
                    if (dr["IsEncrypt"].ToString() == "1")
                        if (dr["Value"].ToString() != "")
                            dr["Value"] = Utilities.Functions.DecryptByRC2(dr["Value"].ToString(), Utilities.Parameters.KEY_Definition, Utilities.Parameters.IV_Definition);

                _Result = Utilities.Multi.LoadDefinition(dtDefinition);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> LoadDefinition:\n" + _Result);
                    MessageBox.Show(_Result + "\n" + callFrom + " -> LoadDefinition", Utilities.Parameters.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Populate_LookUpEdit(object lk, string TableName)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtTemp = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtTemp, TableName, "Name asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> " + TableName);
                    this.Close();
                }

                DataView dv = dtTemp.DefaultView;
                dv.Sort = "Name ASC";
                dtTemp = dv.ToTable();

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        private void CheckRight(string CallBy, bool AddNote, bool DishAdd, bool DishEdit, bool DishDelete, bool TableAdd, bool TableChange, bool TableMerge, 
            bool TableDelete, bool TablePrintList, bool TablePayment, bool TablePrintBill, bool TableCollect)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_ADDNOTE))
                    btnAddNote.Enabled = AddNote;
                else
                    btnAddNote.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_DISH_ADD))
                    btnDishAdd.Enabled = DishAdd;
                else
                    btnDishAdd.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_DISH_EDIT))
                    btnDishEdit.Enabled = DishEdit;
                else
                    btnDishEdit.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_DISH_DELETE))
                    btnDishDelete.Enabled = DishDelete;
                else
                    btnDishDelete.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_ADD))
                    btnTableAdd.Enabled = TableAdd;
                else
                    btnTableAdd.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_CHANGE))
                    btnTableChange.Enabled = TableChange;
                else
                    btnTableChange.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_MERGE))
                    btnTableMerge.Enabled = TableMerge;
                else
                    btnTableMerge.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_DELETE))
                    btnTableDelete.Enabled = TableDelete;
                else
                    btnTableDelete.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_PRINTLIST))
                    btnTablePrintList.Enabled = TablePrintList;
                else
                    btnTablePrintList.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_PAYMENT))
                    btnTablePayment.Enabled = TablePayment;
                else
                    btnTablePayment.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_PRINTBILL))
                    btnTablePrintBill.Enabled = TablePrintBill;
                else
                    btnTablePrintBill.Enabled = false;

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupFunctions_TableAndDish", Utilities.Parameters.Permission_TABLE_COLLECTEDMONEY))
                    btnTableCollectMoney.Enabled = TableCollect;
                else
                    btnTableCollectMoney.Enabled = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetDinnerTable(string CallBy, int Type)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                #region Clear Items

                for (int i = 0; i < galleryTable.Gallery.Groups.Count; i++)
                {
                    for (int j = 0; j < galleryTable.Gallery.Groups[i].Items.Count; j++)
                    {
                        galleryTable.Gallery.Groups[i].Items.RemoveAt(j);
                        j = -1;
                    }
                    galleryTable.Gallery.Groups.RemoveAt(i);
                    i = -1;
                }

                #endregion

                #region itemNoPayment

                if (Type == 1)
                {
                    DataTable dtOrder_NoPayment = new DataTable();
                    string result = bOrder.GetNoPayment(callFrom, ref dtOrder_NoPayment);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetNoPayment:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetNoPayment");
                        return;
                    }

                    GalleryItemGroup groupItemNoPayment = new GalleryItemGroup();
                    if (dtOrder_NoPayment.Rows.Count > 0)
                        groupItemNoPayment.Caption = "DANH SÁCH BÀN CHƯA THANH TOÁN";
                    else
                        groupItemNoPayment.Caption = "KHÔNG CÓ DỮ LIỆU";
                    groupItemNoPayment.CaptionAlignment = DevExpress.XtraBars.Ribbon.GalleryItemGroupCaptionAlignment.Center;
                    galleryTable.Gallery.Groups.Add(groupItemNoPayment);

                    if (dtOrder_NoPayment.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtOrder_NoPayment.Rows)
                        {
                            string caption = dr["DinnerTableName"].ToString();
                            string description = dr["OrderByName"].ToString() + " - " + DateTime.Parse(dr["OrderDate"].ToString()).ToString("HH:mm");
                            if (dr["Note"].ToString().Trim() != "")
                                description = description + "\n" + dr["Note"].ToString();

                            string tag = dr["OrderID"].ToString();
                            string hint = caption + "\n" + description;

                            Image img = Utilities.Functions.ByteArrayToImage((byte[])dr["UsingPicture"]);

                            GalleryItem itemNoPayment = new GalleryItem(img, img, caption, description, 1, 1, tag, hint);
                            itemNoPayment.Value = dr["OrderID"];
                            groupItemNoPayment.Items.Add(itemNoPayment);
                        }
                    }
                }

                #endregion

                #region itemPaymented

                if (Type == 2)
                {
                    DateTime _From = DateTime.Now;
                    DateTime _To = DateTime.Now;

                    pageManagement_groupFunctions_TableAndDish_DateViewType frmDateViewType = new pageManagement_groupFunctions_TableAndDish_DateViewType();
                    DialogResult dlg = frmDateViewType.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        _From = frmDateViewType.vDateFrom;
                        _To = frmDateViewType.vDateTo;
                    }

                    DataTable dtOrder_Paymented = new DataTable();
                    string result = bOrder.GetPaymentedByDate(callFrom, ref dtOrder_Paymented, _From, _To);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetPaymentedByDate:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetPaymentedByDate");
                        return;

                    }

                    GalleryItemGroup groupItemPaymented = new GalleryItemGroup();
                    if (dtOrder_Paymented.Rows.Count > 0)
                        groupItemPaymented.Caption = "DANH SÁCH BÀN ĐÃ THANH TOÁN";
                    else
                        groupItemPaymented.Caption = "KHÔNG CÓ DỮ LIỆU";
                    groupItemPaymented.CaptionAlignment = DevExpress.XtraBars.Ribbon.GalleryItemGroupCaptionAlignment.Center;
                    galleryTable.Gallery.Groups.Add(groupItemPaymented);

                    if (dtOrder_Paymented.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtOrder_Paymented.Rows)
                        {
                            string caption = dr["DinnerTableName"].ToString();
                            string description = dr["PaymentedByName"].ToString() + " - " + DateTime.Parse(dr["PaymentedDate"].ToString()).ToString("HH:mm");
                            if (dr["Note"].ToString().Trim() != "")
                                description = description + "\n" + dr["Note"].ToString();

                            string tag = dr["OrderID"].ToString();
                            string hint = caption + "\n" + description;

                            Image img = Utilities.Functions.ByteArrayToImage((byte[])dr["UsingPicture"]);

                            GalleryItem itemPaymented = new GalleryItem(img, img, caption, description, 1, 1, tag, hint);
                            itemPaymented.Value = dr["OrderID"];
                            groupItemPaymented.Items.Add(itemPaymented);
                        }
                    }
                }

                #endregion

                #region itemCancelled

                if (Type == 3)
                {
                    DateTime _From = DateTime.Now;
                    DateTime _To = DateTime.Now;

                    pageManagement_groupFunctions_TableAndDish_DateViewType frmDateViewType = new pageManagement_groupFunctions_TableAndDish_DateViewType();
                    DialogResult dlg = frmDateViewType.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        _From = frmDateViewType.vDateFrom;
                        _To = frmDateViewType.vDateTo;
                    }

                    DataTable dtOrder_Cancelled = new DataTable();
                    string result = bOrder.GetCancelledByDate(callFrom, ref dtOrder_Cancelled, _From, _To);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetCancelledByDate:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetCancelledByDate");
                        return;

                    }

                    GalleryItemGroup groupItemCancelled = new GalleryItemGroup();
                    if (dtOrder_Cancelled.Rows.Count > 0)
                        groupItemCancelled.Caption = "DANH SÁCH BÀN ĐÃ HỦY";
                    else
                        groupItemCancelled.Caption = "KHÔNG CÓ DỮ LIỆU";
                    groupItemCancelled.CaptionAlignment = DevExpress.XtraBars.Ribbon.GalleryItemGroupCaptionAlignment.Center;
                    galleryTable.Gallery.Groups.Add(groupItemCancelled);

                    if (dtOrder_Cancelled.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtOrder_Cancelled.Rows)
                        {
                            string caption = dr["DinnerTableName"].ToString();
                            string description = dr["CancelledByName"].ToString() + " - " + DateTime.Parse(dr["CancelledDate"].ToString()).ToString("HH:mm");
                            if (dr["Note"].ToString().Trim() != "")
                                description = description + "\n" + dr["Note"].ToString();

                            string tag = dr["OrderID"].ToString();
                            string hint = caption + "\n" + description;

                            Image img = Utilities.Functions.ByteArrayToImage((byte[])dr["UsingPicture"]);

                            GalleryItem itemCancelled = new GalleryItem(img, img, caption, description, 1, 1, tag, hint);
                            itemCancelled.Value = dr["OrderID"];
                            groupItemCancelled.Items.Add(itemCancelled);
                        }
                    }
                }

                #endregion

                #region itemNoCollected

                if (Type == 4)
                {
                    DataTable dtOrder_NoCollected = new DataTable();
                    string result = bOrder.GetNoCollected(callFrom, ref dtOrder_NoCollected);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetNoCollected:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetNoCollected");
                        return;

                    }

                    GalleryItemGroup groupItemNoCollected = new GalleryItemGroup();
                    if (dtOrder_NoCollected.Rows.Count > 0)
                        groupItemNoCollected.Caption = "DANH SÁCH BÀN CHƯA THU TIỀN";
                    else
                        groupItemNoCollected.Caption = "KHÔNG CÓ DỮ LIỆU";
                    groupItemNoCollected.CaptionAlignment = DevExpress.XtraBars.Ribbon.GalleryItemGroupCaptionAlignment.Center;
                    galleryTable.Gallery.Groups.Add(groupItemNoCollected);

                    if (dtOrder_NoCollected.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtOrder_NoCollected.Rows)
                        {
                            string caption = dr["DinnerTableName"].ToString();
                            string description = dr["PaymentedByName"].ToString() + " - " + DateTime.Parse(dr["PaymentedDate"].ToString()).ToString("HH:mm");
                            if (dr["Note"].ToString().Trim() != "")
                                description = description + "\n" + dr["Note"].ToString();

                            string tag = dr["OrderID"].ToString();
                            string hint = caption + "\n" + description;

                            Image img = Utilities.Functions.ByteArrayToImage((byte[])dr["UsingPicture"]);

                            GalleryItem itemPaymented = new GalleryItem(img, img, caption, description, 1, 1, tag, hint);
                            itemPaymented.Value = dr["OrderID"];
                            groupItemNoCollected.Items.Add(itemPaymented);
                        }
                    }
                }

                #endregion

                #region Init Detail

                lkDishTypeView.EditValue = null;
                lkDishTypeView.ReadOnly = true;
                btnDishAdd.Enabled = false;
                btnDishDelete.Enabled = false;

                #endregion
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void PrintBill(string CallBy, string OrderID, bool FromPrintBillButton)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (OrderID == "0")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để in.");
                    return;
                }

                DataTable dtOrder = new DataTable();
                string _Result = bOrder.GetByID(callFrom, ref dtOrder, OrderID);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByID:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByID");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, false, btnTableCollectMoney.Enabled);
                    return;
                }

                DataTable dtOrderDetails = new DataTable();
                string result = bOrder.GetDetailsByOrderID(callFrom, ref dtOrderDetails, OrderID, false);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetDetailsByOrderID:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetDetailsByOrderID");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, false, btnTableCollectMoney.Enabled);
                    return;
                }

                for (int i = 0; i < dtOrderDetails.Rows.Count - 1; i++)
                {
                    string _MenuID = dtOrderDetails.Rows[i]["MenuID"].ToString();
                    decimal _Price = decimal.Parse(dtOrderDetails.Rows[i]["Price"].ToString());
                    for (int j = i + 1; j < dtOrderDetails.Rows.Count; j++)
                    {
                        string _MenuID2 = dtOrderDetails.Rows[j]["MenuID"].ToString();
                        decimal _Price2 = decimal.Parse(dtOrderDetails.Rows[j]["Price"].ToString());

                        if (_MenuID == _MenuID2 && _Price == _Price2)
                        {
                            dtOrderDetails.Rows[i]["Quantity"] = int.Parse(dtOrderDetails.Rows[i]["Quantity"].ToString()) +
                                                                 int.Parse(dtOrderDetails.Rows[j]["Quantity"].ToString());

                            dtOrderDetails.Rows[i]["Total"] = decimal.Parse(dtOrderDetails.Rows[i]["Total"].ToString()) +
                                                                decimal.Parse(dtOrderDetails.Rows[j]["Total"].ToString());
                            dtOrderDetails.Rows.RemoveAt(j);
                            j = j - 1;
                        }
                    }
                }

                dtOrderDetails.AcceptChanges();

                DataView dv = dtOrderDetails.DefaultView;
                dv.Sort = "MenuGroupName, MenuName ASC";
                dtOrderDetails = dv.ToTable();

                #region dtoPrintBill

                dtoPrintBill PrintBill = new dtoPrintBill();
                PrintBill.CompanyName = Utilities.Parameters.Definition.COMPANY_NAME;
                PrintBill.CompanyAddress = Utilities.Parameters.Definition.COMPANY_ADDRESS;
                PrintBill.CompanyPhone = Utilities.Parameters.Definition.COMPANY_PHONE;
                PrintBill.CompanyFacebook = Utilities.Parameters.Definition.COMPANY_FACE;

                PrintBill.DinnerTableName = dtOrder.Rows[0]["DinnerTableName"].ToString();
                PrintBill.BillNo = dtOrder.Rows[0]["BillNo"].ToString();
                PrintBill.OrderDate = DateTime.Parse(dtOrder.Rows[0]["OrderDate"].ToString()).ToString("dd/MM/yyyy HH:mm");
                PrintBill.PaymentedDate = DateTime.Parse(dtOrder.Rows[0]["PaymentedDate"].ToString()).ToString("dd/MM/yyyy HH:mm");

                dtOrderDetails.Columns.Add("RankIndex", typeof(int));
                for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                {
                    dtOrderDetails.Rows[i]["RankIndex"] = i + 1;

                    string name = "";
                    if (dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() != "" && dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() != "")
                        name = "(" + dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() + "," + dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() + ")";
                    else if (dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() != "" && dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() == "")
                        name = "(" + dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() + ")";
                    else if (dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() == "" && dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() != "")
                        name = "(" + dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() + ")";

                    if (name != "")
                        dtOrderDetails.Rows[i]["MenuName"] = dtOrderDetails.Rows[i]["MenuName"].ToString() + " " + name;

                    busGeneralFunctions bGF = new busGeneralFunctions();
                    DataTable vdtSize = new DataTable();
                    string vResult = bGF.GetByCondition(callFrom, ref vdtSize, "Menu_Size", new string[] { "MenuID" }, new string[] { dtOrderDetails.Rows[i]["MenuID"].ToString() }, null);
                    if (result == Utilities.Parameters.ResultMessage && vdtSize.Rows.Count > 1)
                        dtOrderDetails.Rows[i]["MenuName"] = dtOrderDetails.Rows[i]["MenuName"].ToString() + " (" + dtOrderDetails.Rows[i]["SizeName"].ToString() + ")";
                }

                PrintBill.TotalAmount = decimal.Parse(dtOrder.Rows[0]["TotalAmount"].ToString()).ToString("n0");

                if (dtOrder.Rows[0]["PromotionPercent"].ToString() == "" ||
                    decimal.Parse(dtOrder.Rows[0]["PromotionPercent"].ToString()) == 0)
                    PrintBill.PromotionPercent = "";
                else
                    PrintBill.PromotionPercent = decimal.Parse(dtOrder.Rows[0]["PromotionPercent"].ToString()).ToString("n0");

                if (dtOrder.Rows[0]["PromotionAmount"].ToString() == "" ||
                   decimal.Parse(dtOrder.Rows[0]["PromotionAmount"].ToString()) == 0)
                    PrintBill.PromotionAmount = "";
                else
                    PrintBill.PromotionAmount = decimal.Parse(dtOrder.Rows[0]["PromotionAmount"].ToString()).ToString("n0");

                PrintBill.PaymentedAmount = decimal.Parse(dtOrder.Rows[0]["PaymentedTotal"].ToString()).ToString("n0");
                PrintBill.dtDetail = dtOrderDetails;

                #endregion

                pageManagement_groupFunctions_TableAndDish_Print frmPrint = new pageManagement_groupFunctions_TableAndDish_Print();

                if (FromPrintBillButton)
                    frmPrint.vType = "PrintBillButton";
                else
                    frmPrint.vType = "PrintBill";

                frmPrint.vIsPrint = true;
                frmPrint.vPrintBill = PrintBill;
                frmPrint.ShowDialog();

                #region PrintSticker

                bool vFlagPrintSticker = false;
                DataTable dtDefinition = new DataTable();
                _Result = bGeneral.GetByCondition(callFrom, ref dtDefinition, "Definition",
                                                        new string[] {"Code"}, new string[] { "'PRINT_STICKER'" },null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Definition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Definition");
                }
                else if (dtDefinition.Rows.Count == 1 && dtDefinition.Rows[0]["Value"].ToString() == "ON")
                {
                        vFlagPrintSticker = true;
                }

                if (vFlagPrintSticker)
                {
                    string PrinterName = GetPrinterName("PRINTER_STICKER");
                    foreach (DataRow dr in PrintBill.dtDetail.Rows)
                    {
                        if (dr["PrintSticker"].ToString() != "")
                        {
                            if (dr["PrintSticker"].ToString() == "1" || bool.Parse(dr["PrintSticker"].ToString()))
                            {
                                int vQuantity = int.Parse(dr["Quantity"].ToString());

                                DocumentViewer documentViewer1 = new DocumentViewer();
                                pageManagement_groupFunctions_TableAndDish_rptSticker_Payment rptView = new pageManagement_groupFunctions_TableAndDish_rptSticker_Payment();
                                rptView.BindData_Information(dr["MenuName"].ToString());
                                documentViewer1.PrintingSystem = rptView.PrintingSystem;
                                rptView.CreateDocument();

                                rptView.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                                rptView.ShowPrintStatusDialog = false;

                                using (ReportPrintTool printTool = new ReportPrintTool(rptView))
                                {
                                    if (PrinterName != "")
                                        printTool.PrinterSettings.PrinterName = PrinterName;

                                    for (int k = 1; k <= vQuantity; k++)
                                        printTool.Print();
                                }
                            }
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
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

        private void PrintBankAccount(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string vUserDefault_Name = "";
                string vUserLogin_Name = "";

                #region vUserDefault_Name

                DataTable dtDefinition = new DataTable();
                string _Result = bGeneral.GetAll(callFrom, ref dtDefinition, "Definition", null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetAll");
                    return;
                }

                foreach (DataRow dr in dtDefinition.Rows)
                {
                    if (dr["Code"].ToString() == "BANK_ACCOUNT")
                    {
                        vUserDefault_Name = dr["Value"].ToString();
                        break;
                    }
                }

                #endregion

                #region vUserLogin_Name

                busGeneralFunctions busGeneral = new busGeneralFunctions();
                DataTable vdtEmpl=new DataTable();
                string vResult = busGeneral.GetByCondition(callFrom, ref vdtEmpl, "Employees",
                                                          new string[] { "ID" },
                                                          new string[] { Utilities.Parameters.UserLogin.EmployeesID }, null);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Employees:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition Employees");
                    return;
                }

                foreach (DataRow dr in vdtEmpl.Rows)
                    vUserLogin_Name = dr["Bank_AccountName"].ToString();

                #endregion

                pageManagement_groupFunctions_TableAndDish_PrintBank frmPrintBank = new pageManagement_groupFunctions_TableAndDish_PrintBank();
                frmPrintBank._UserDefault_Name = vUserDefault_Name;
                frmPrintBank._UserLogin_Name = vUserLogin_Name;
                DialogResult dlg = frmPrintBank.ShowDialog();
                if (dlg != DialogResult.OK || frmPrintBank._SelectedUser == "") return;

                #region dtoBank

                dtoBank Bank = new dtoBank();
                Bank.CompanyName = Utilities.Parameters.Definition.COMPANY_NAME;
                Bank.CompanyAddress = Utilities.Parameters.Definition.COMPANY_ADDRESS;
                Bank.CompanyPhone = Utilities.Parameters.Definition.COMPANY_PHONE;

                if (frmPrintBank._SelectedUser == "DEFAULT")
                {
                    foreach (DataRow dr in dtDefinition.Rows)
                    {
                        if (dr["Code"].ToString() == "BANK_ACCOUNT")
                            Bank.BankAccount = dr["Value"].ToString();
                        else if (dr["Code"].ToString() == "BANK_ID")
                            Bank.BankID = dr["Value"].ToString();
                        else if (dr["Code"].ToString() == "BANK_NAME")
                            Bank.BankName = dr["Value"].ToString();
                        else if (dr["Code"].ToString() == "BANK_QRCODE")
                        {
                            if (dr["ValueImage"].ToString() != "")
                            {
                                byte[] b = (byte[])dr["ValueImage"];
                                Bank.BankQRCode = Utilities.Functions.ByteArrayToImage(b);
                            }
                            else
                            {
                                Bank.BankQRCode = null;
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataRow dr in vdtEmpl.Rows)
                    {
                        Bank.BankAccount = dr["Bank_AccountName"].ToString();
                        Bank.BankID = dr["Bank_AccountNumber"].ToString();
                        Bank.BankName = dr["BankName"].ToString();

                        if (dr["Bank_QRCode"].ToString() != "")
                        {
                            byte[] b = (byte[])dr["Bank_QRCode"];
                            Bank.BankQRCode = Utilities.Functions.ByteArrayToImage(b);
                        }
                        else
                        {
                            Bank.BankQRCode = null;
                        }
                    }
                }

                #endregion

                pageManagement_groupFunctions_TableAndDish_Print frmPrint = new pageManagement_groupFunctions_TableAndDish_Print();
                frmPrint.vType = "PrintBank";
                frmPrint.vIsPrint = true;
                frmPrint.vBank = Bank;
                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CalcTotal(string CallBy, string OrderID)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable _dtOrder = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref _dtOrder, "Orders", new string[] { "ID" }, new string[] { OrderID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + _Result);
                    return _Result + "\n" + callFrom + " -> General_GetByCondition";
                }

                DataTable _dtOrderDetail = new DataTable();
                BusinessLogicLayer.busOrder bOrder = new BusinessLogicLayer.busOrder();
                _Result = bOrder.GetDetailsByOrderID(callFrom, ref _dtOrderDetail, OrderID, false);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetDetailsByOrderID:\n" + _Result);
                    return _Result + "\n" + callFrom + " -> GetDetailsByOrderID";
                }
               
                decimal _TotalAmount = 0;
                foreach (DataRow dr in _dtOrderDetail.Rows)
                    _TotalAmount = _TotalAmount + decimal.Parse(dr["Total"].ToString());

                _dtOrder.Rows[0]["PaymentedTotal"] = _TotalAmount;
                _dtOrder.Rows[0]["TotalAmount"] = _TotalAmount;

                if (_dtOrder.Rows[0]["PromotionID"].ToString() != "")
                {
                    int _PromotionPercent = 0;
                    decimal _PromotionAmount = 0;

                    if (_dtOrder.Rows[0]["PromotionPercent"].ToString() != "" && int.Parse(_dtOrder.Rows[0]["PromotionPercent"].ToString()) != 0)
                    {
                        _PromotionPercent = int.Parse(_dtOrder.Rows[0]["PromotionPercent"].ToString());
                        _PromotionAmount = _PromotionPercent * (decimal)(0.01) * _TotalAmount;
                    }
                    else
                        _PromotionAmount = decimal.Parse(_dtOrder.Rows[0]["PromotionAmount"].ToString());

                    _dtOrder.Rows[0]["PromotionAmount"] = _PromotionAmount;
                    _dtOrder.Rows[0]["PaymentedTotal"] = _TotalAmount - _PromotionAmount;
                }

                _Result = bOrder.Update(callFrom, ref _dtOrder);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\nTính tổng tiền lỗi.");
                    return "Tính tổng tiền lỗi.\n" + callFrom;
                }

                return Utilities.Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        #endregion

        #region Events

        private void pageManagement_groupFunctions_TableAndDish_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                #region Check Price List

                DataTable dtPriceList = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtPriceList, "PriceList", new string[] { "StatusOfPriceListID" }, new string[] { ((int)Utilities.CategoriesEnum.StatusOfPriceList.Đang_hiện_hành).ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    CheckRight(callFrom, false, false, false, false, false, false, false, false, false, false, false, false);
                    return;
                }

                if (dtPriceList == null || dtPriceList.Rows.Count == 0)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Chưa có 'Bảng giá' hiện hành.\nVui lòng tạo Bảng giá để sử dụng chức năng này.");
                    CheckRight(callFrom, false, false, false, false, false, false, false, false, false, false, false, false);
                    return;
                }
                if (dtPriceList.Rows.Count > 1)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không thể sử dụng chức năng này.\nVì hiện tại có "+ dtPriceList.Rows.Count + @" 'Bảng giá' hiện hành.");
                    CheckRight(callFrom, false, false, false, false, false, false, false, false, false, false, false, false);
                    return;
                }

                #endregion

                CheckRight(callFrom, false, false, false, false, true, false, false, false, false, false, false, false);

                #region Type View

                Populate_LookUpEdit(lkTypeView, "StatusOfOrder");
                lkTypeView.EditValue = 1;

                #endregion

                #region Dish Type View

                DataTable dtDishTypeView = new DataTable();
                dtDishTypeView.Columns.Add("ID", typeof(int));
                dtDishTypeView.Columns.Add("Name", typeof(string));

                dtDishTypeView.Rows.Add(1, "Các món đã đặt");
                dtDishTypeView.Rows.Add(2, "Các món đã hủy");

                Utilities.Multi.Populate_LookUpEdit(lkDishTypeView, dtDishTypeView, "ID", "Name");

                #endregion

                Populate_LookUpEdit(gvOrderDetails_colKindOfHotpot1ID_lke, "KindOfHotpot");
                Populate_LookUpEdit(gvOrderDetails_colSizeID_lk, "Size");

                chkViewDetail.Checked = true;

                timerPromotion.Interval = 30 * 60 * 1000;
                timerPromotion.Enabled = true;
                timerPromotion.Start();
                timerPromotion_Tick(null, null);

                timerNow.Interval = 1000;
                timerNow.Enabled = true;
                timerNow.Start();
                timerNow_Tick(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_TableAndDish_TableAdd frmTableAdd = new pageManagement_groupFunctions_TableAndDish_TableAdd();
                frmTableAdd.BringToFront();
                DialogResult dlg = frmTableAdd.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    lkTypeView.EditValue = 1;
                    lkTypeView_EditValueChanged(null, null);

                    foreach (GalleryItem item in galleryTable.Gallery.GetAllItems())
                    {
                        if (int.Parse(item.Value.ToString()) == int.Parse(frmTableAdd.vOrderID))
                            item.Checked = true;
                        else
                            item.Checked = false;
                    }

                    galleryTable_Gallery_ItemClick(null, null);

                    GeneralFunctions.DisplayMessageMenuNoConfigMaterial(callFrom, frmTableAdd.vOrderID);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void galleryTable_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                #region Init Detail

                lkDishTypeView.EditValue = null;
                lkDishTypeView.ReadOnly = true;
                btnDishAdd.Enabled = false;
                btnDishDelete.Enabled = false;

                #endregion

                GalleryItem gItem = galleryTable.Gallery.GetCheckedItem();
                if (gItem == null || gItem.Value == null)
                {
                    CheckRight(callFrom, false, false, false, false, true, false, false, false, false, false, false, false);
                    return;
                }

                List<GalleryItem> lst_Item = galleryTable.Gallery.GetAllItems();
                for (int i = 0; i < lst_Item.Count; i++)
                    lst_Item[i].Checked = false;

                gItem.Checked = true;
                selectedOrderID = int.Parse(gItem.Value.ToString());

                DataTable dtOrder = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { selectedOrderID.ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    CheckRight(callFrom, false, false, false, false, true, false, false, false, false, false, false, false);
                    return;
                }

                if (int.Parse(dtOrder.Rows[0]["StatusOfOrderID"].ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán)
                    CheckRight(callFrom, true, true, false, false, true, true, true, true, true, true, false, false);
                else if (int.Parse(dtOrder.Rows[0]["StatusOfOrderID"].ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền)
                    CheckRight(callFrom, false, true, false, false, true, false, false, false, true, false, true, true);
                else if (int.Parse(dtOrder.Rows[0]["StatusOfOrderID"].ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền)
                    CheckRight(callFrom, false, false, false, false, true, false, false, false, true, false, true, false);
                else
                    CheckRight(callFrom, false, false, false, false, true, false, false, false, false, false, false, false);

                lkDishTypeView.EditValue = 1;
                lkDishTypeView_EditValueChanged(null, null);

                lkDishTypeView.ReadOnly = false;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void lkTypeView_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                CheckRight(callFrom, false, false, false, false, true, false, false, false, false, false, false, false);
                int type;
                if (lkTypeView.EditValue == null || lkTypeView.EditValue.ToString() == "")
                    type = 0;
                else
                    type = int.Parse(lkTypeView.EditValue.ToString());

                GetDinnerTable(callFrom, type);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            lkTypeView_EditValueChanged(null, null);
        }

        private void chkViewDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewDetail.Checked)
                galleryTable.Gallery.ShowItemText = true;
            else
                galleryTable.Gallery.ShowItemText = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvOrderDetails_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void lkDishTypeView_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                btnDishEdit.Enabled = false;
                btnDishDelete.Enabled = false;

                string _OrderID;
                bool _IsCancelled = false;
                if (lkDishTypeView.EditValue == null || lkDishTypeView.EditValue.ToString() == "")
                    _OrderID = "0";
                else
                {
                    _OrderID = selectedOrderID.ToString();
                    if (int.Parse(lkDishTypeView.EditValue.ToString()) == 2)
                        _IsCancelled = true;
                }

                DataTable dtOrderDetails = new DataTable();
                string result = bOrder.GetDetailsByOrderID(callFrom, ref dtOrderDetails, _OrderID, _IsCancelled);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetDetailsByOrderID:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetDetailsByOrderID");
                    return;
                }

                gcOrderDetails.DataSource = dtOrderDetails;
                gvOrderDetails.ExpandAllGroups();

                if (lkDishTypeView.EditValue != null && lkDishTypeView.EditValue.ToString() == "1")
                {
                    btnDishEdit.Enabled = true;
                    btnDishDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gvOrderDetails_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetails.FocusedRowHandle < 0)
                {
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, false, false, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                        btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                if (lkDishTypeView.EditValue != null && lkDishTypeView.EditValue.ToString() != "" && int.Parse(lkDishTypeView.EditValue.ToString()) == 1)
                {
                    if (lkTypeView.EditValue != null && lkTypeView.EditValue.ToString() != "" && int.Parse(lkTypeView.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thanh_toán)
                        CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, true, true, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                               btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    else if (lkTypeView.EditValue != null && lkTypeView.EditValue.ToString() != "" && int.Parse(lkTypeView.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền)
                        CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, true, true, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                               btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    else
                        CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, false, false, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                               btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnDishAdd_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn.");
                    return;
                }

                pageManagement_groupFunctions_TableAndDish_DishAdd frmDishAdd = new pageManagement_groupFunctions_TableAndDish_DishAdd();
                frmDishAdd.vOrderID = selectedOrderID;
                DialogResult dlg = frmDishAdd.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    if (lkTypeView.EditValue != null && lkTypeView.EditValue.ToString() != "" && 
                        int.Parse(lkTypeView.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền)
                        CalcTotal(callFrom, selectedOrderID.ToString());

                    lkDishTypeView_EditValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnDishDelete_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetails.FocusedRowHandle < 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Món.");
                    return;
                }

                string _Name = gvOrderDetails.GetFocusedRowCellDisplayText(gvOrderDetails_colMenuName);
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn hủy món '"+ _Name + "' ?") != DialogResult.Yes)
                    return;

                string _DetailID = gvOrderDetails.GetFocusedRowCellValue(gvOrderDetails_colID).ToString();
                DataTable dtOrderDetail = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtOrderDetail, "OrdersDetail", new string[] { "ID" }, new string[] { _DetailID }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, false, false, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                dtOrderDetail.Rows[0]["CancelledBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtOrderDetail.Rows[0]["CancelledDate"] = DateTime.Now;
                dtOrderDetail.AcceptChanges();

                string _Result = bOrder.OrderDetail_Update(callFrom, ref dtOrderDetail);
                if (_Result == Utilities.Parameters.ResultMessage)
                {
                    if (lkTypeView.EditValue != null && lkTypeView.EditValue.ToString() != "" &&
                       int.Parse(lkTypeView.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền)
                        CalcTotal(callFrom, selectedOrderID.ToString());

                    lkDishTypeView_EditValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void TablePaymentAndCollect(GalleryItem Table, DataTable dtOrder, int PromotionID, int PromotionPercent, decimal PromotionAmount, decimal Total, int OrderID)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (OrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để thu tiền.");
                    return;
                }

                pageManagement_groupFunctions_TableAndDish_Payment frmPayment = new pageManagement_groupFunctions_TableAndDish_Payment();
                frmPayment.vTableName = Table.Caption;
                frmPayment.vCollectBy = dtOrder.Rows[0]["OrderBy"];
                DialogResult dlg = frmPayment.ShowDialog();
                if (dlg != DialogResult.OK || frmPayment.vCollectBy == null || frmPayment.vPaymentType == "")
                    return;

                dtOrder.Rows[0]["BillNo"] = Utilities.Multi.CreateBillNo(Utilities.Parameters.Definition.BILL_PREFIX);
                dtOrder.Rows[0]["PaymentedBy"] = frmPayment.vCollectBy;
                dtOrder.Rows[0]["PaymentedDate"] = DateTime.Now;
                dtOrder.Rows[0]["PaymentedTotal"] = gvOrderDetails_colTotal.SummaryItem.SummaryValue;
                dtOrder.Rows[0]["TotalAmount"] = gvOrderDetails_colTotal.SummaryItem.SummaryValue;
                dtOrder.Rows[0]["StatusOfOrderID"] = (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền;

                dtOrder.Rows[0]["ActionBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtOrder.Rows[0]["ActionDate"] = DateTime.Now;
                dtOrder.Rows[0]["PaymentedType"] = frmPayment.vPaymentType;
                dtOrder.Rows[0]["StatusOfOrderID"] = (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

                if (PromotionID != 0)
                {
                    dtOrder.Rows[0]["PromotionID"] = PromotionID;
                    dtOrder.Rows[0]["PromotionPercent"] = PromotionPercent;
                    dtOrder.Rows[0]["PromotionAmount"] = PromotionAmount;
                    dtOrder.Rows[0]["PaymentedTotal"] = Total;
                }

                LoadDefinition(callFrom);

                string _Result = "";
                if (Utilities.Parameters.Definition.WAREHOUSE == "ON")
                    _Result = bOrder.Update_WarehouseSubtract(callFrom, ref dtOrder);
                else
                    _Result = bOrder.Update(callFrom, ref dtOrder);

                if (_Result == Utilities.Parameters.ResultMessage)
                {
                    lkTypeView_EditValueChanged(null, null);

                    PrintBill(callFrom, OrderID.ToString(), false);

                    GeneralFunctions.DisplayMessageMenuNoConfigMaterial(callFrom, OrderID.ToString());

                    if (Utilities.Parameters.Definition.SMTP_GG_ENABLE == "ON")
                    {
                        MainForm frmMain = (MainForm)Application.OpenForms[0];
                        frmMain.AutoReport();
                    }
                }
                else
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void TablePayment(GalleryItem Table, DataTable dtOrder, int PromotionID, int PromotionPercent, decimal PromotionAmount, decimal Total)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            pageManagement_groupFunctions_TableAndDish_EmployeeCollect frmEmployeeCollect = new pageManagement_groupFunctions_TableAndDish_EmployeeCollect();
            frmEmployeeCollect.vTableName = Table.Caption;
            frmEmployeeCollect.vCollectBy = dtOrder.Rows[0]["OrderBy"];
            DialogResult dlg = frmEmployeeCollect.ShowDialog();
            if (dlg != DialogResult.Yes)
                return;

            dtOrder.Rows[0]["BillNo"] = Utilities.Multi.CreateBillNo(Utilities.Parameters.Definition.BILL_PREFIX);
            dtOrder.Rows[0]["PaymentedBy"] = frmEmployeeCollect.vCollectBy;
            dtOrder.Rows[0]["PaymentedDate"] = DateTime.Now;
            dtOrder.Rows[0]["PaymentedTotal"] = gvOrderDetails_colTotal.SummaryItem.SummaryValue;
            dtOrder.Rows[0]["TotalAmount"] = gvOrderDetails_colTotal.SummaryItem.SummaryValue;
            dtOrder.Rows[0]["StatusOfOrderID"] = (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền;

            if (PromotionID != 0)
            {
                dtOrder.Rows[0]["PromotionID"] = PromotionID;
                dtOrder.Rows[0]["PromotionPercent"] = PromotionPercent;
                dtOrder.Rows[0]["PromotionAmount"] = PromotionAmount;
                dtOrder.Rows[0]["PaymentedTotal"] = Total;
            }

            string _Result = bOrder.Update(callFrom, ref dtOrder);
            if (_Result == Utilities.Parameters.ResultMessage)
            {
                lkTypeView_EditValueChanged(null, null);

                PrintBill(callFrom, selectedOrderID.ToString(), false);

                GeneralFunctions.DisplayMessageMenuNoConfigMaterial(callFrom, selectedOrderID.ToString());
            }
        }   
        
        private void btnTablePayment_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để thanh toán.");
                    return;
                }

                DataTable dtPromotion = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtPromotion, "PromotionOnTotalBill",
                                                               new string[] { "StatusID"},
                                                               new string[] { ((int)Utilities.CategoriesEnum.StatusOfPromotion.Đang_có_hiệu_lực).ToString()}, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                    return;
                }

                if (dtPromotion.Rows.Count > 1)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Không thể thanh toán.\nVì có "+ dtPromotion.Rows.Count + " chương trình khuyến mãi đang có hiệu lực.");
                    return;
                }

                lkDishTypeView.EditValue = 1;
                lkDishTypeView_EditValueChanged(null, null);

                GalleryItem _Item = galleryTable.Gallery.GetItemByValue(selectedOrderID);

                int _PromotionID = 0;
                int _PromotionPercent = 0;
                decimal _PromotionAmount = 0;
                decimal _Total = 0;

                if (dtPromotion.Rows.Count == 1)
                {
                    pageManagement_groupFunctions_TableAndDish_Confirm frmConfirm = new pageManagement_groupFunctions_TableAndDish_Confirm();
                    frmConfirm.vTableName = _Item.Caption;
                    frmConfirm.vTotalAmount = decimal.Parse(gvOrderDetails_colTotal.SummaryItem.SummaryValue.ToString());

                    if (dtPromotion.Rows[0]["ProPercent"].ToString() == "")
                        frmConfirm.vPromotionPercent = 0;
                    else
                        frmConfirm.vPromotionPercent = int.Parse(dtPromotion.Rows[0]["ProPercent"].ToString());

                    if (dtPromotion.Rows[0]["ProAmount"].ToString() == "")
                        frmConfirm.vPromotionAmount = 0;
                    else
                        frmConfirm.vPromotionAmount = decimal.Parse(dtPromotion.Rows[0]["ProAmount"].ToString());

                    if (frmConfirm.ShowDialog() != DialogResult.Yes)
                        return;

                    _PromotionID = int.Parse(dtPromotion.Rows[0]["ID"].ToString());
                    _PromotionPercent = frmConfirm.vPromotionPercent;
                    _PromotionAmount = frmConfirm.vPromotionAmount;
                    _Total = frmConfirm.vTotal;
                }

                DataTable dtOrder = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { selectedOrderID.ToString() }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> General_GetByCondition");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, btnTablePrintList.Enabled, false, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                TablePaymentAndCollect(_Item, dtOrder, _PromotionID, _PromotionPercent, _PromotionAmount, _Total, selectedOrderID);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }



        private void btnTableDelete_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để hủy.");
                    return;
                }

                GalleryItem _Item = galleryTable.Gallery.GetItemByValue(selectedOrderID);
                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn HỦY '" + _Item.Caption + "' ?") != DialogResult.Yes)
                    return;

                DataTable dtOrder = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { selectedOrderID.ToString() }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> General_GetByCondition");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       false, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                dtOrder.Rows[0]["CancelledBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtOrder.Rows[0]["CancelledDate"] = DateTime.Now;
                dtOrder.Rows[0]["StatusOfOrderID"] = (int)Utilities.CategoriesEnum.StatusOfOrder.Hủy;

                _Result = bOrder.Update(callFrom, ref dtOrder);
                if (_Result == Utilities.Parameters.ResultMessage)
                    lkTypeView_EditValueChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để thêm ghi chú.");
                    return;
                }

                pageManagement_groupFunctions_TableAndDish_AddNote frmAddNote = new pageManagement_groupFunctions_TableAndDish_AddNote();
                DialogResult dlg = frmAddNote.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    DataTable dtOrder = new DataTable();
                    string _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { selectedOrderID.ToString() }, null);
                    if (_Result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + _Result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> General_GetByCondition");
                        CheckRight(callFrom, false, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                           btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                        return;
                    }

                    dtOrder.Rows[0]["AddNoteBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    dtOrder.Rows[0]["AddNoteDate"] = DateTime.Now;

                    if (dtOrder.Rows[0]["Note"].ToString() == "")
                        dtOrder.Rows[0]["Note"] = frmAddNote.vNote;
                    else
                        dtOrder.Rows[0]["Note"] = dtOrder.Rows[0]["Note"].ToString() + "; " + frmAddNote.vNote;

                    _Result = bOrder.Update(callFrom, ref dtOrder);
                    if (_Result == Utilities.Parameters.ResultMessage)
                    {
                        lkTypeView_EditValueChanged(null, null);

                        foreach (GalleryItem item in galleryTable.Gallery.GetAllItems())
                        {
                            if (int.Parse(item.Value.ToString()) == selectedOrderID)
                                item.Checked = true;
                            else
                                item.Checked = false;
                        }

                        galleryTable_Gallery_ItemClick(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnTableChange_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để chuyển.");
                    return;
                }

                pageManagement_groupFunctions_TableAndDish_TableChange frmTableChange = new pageManagement_groupFunctions_TableAndDish_TableChange();
                frmTableChange.vOrderID = selectedOrderID.ToString();
                DialogResult dlg = frmTableChange.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    DataTable dtOrder = new DataTable();
                    string _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { selectedOrderID.ToString() }, null);
                    if (_Result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + _Result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> General_GetByCondition");
                        CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, false, btnTableMerge.Enabled,
                           btnTableDelete.Enabled, btnTablePrintList.Enabled, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                        return;
                    }

                    dtOrder.Rows[0]["ChangeBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                    dtOrder.Rows[0]["ChangeDate"] = DateTime.Now;
                    dtOrder.Rows[0]["DinnerTableID"] = frmTableChange.vDinnerTableID;

                    _Result = bOrder.Update(callFrom, ref dtOrder);
                    if (_Result == Utilities.Parameters.ResultMessage)
                    {
                        lkTypeView_EditValueChanged(null, null);

                        foreach (GalleryItem item in galleryTable.Gallery.GetAllItems())
                        {
                            if (int.Parse(item.Value.ToString()) == selectedOrderID)
                                item.Checked = true;
                            else
                                item.Checked = false;
                        }

                        galleryTable_Gallery_ItemClick(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnTableMerge_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để gộp.");
                    return;
                }

                pageManagement_groupFunctions_TableAndDish_TableMerge frmTableMerge = new pageManagement_groupFunctions_TableAndDish_TableMerge();
                frmTableMerge.vOrderID = selectedOrderID.ToString();
                DialogResult dlg = frmTableMerge.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    string _Result = bOrder.Merge(callFrom, selectedOrderID.ToString(), frmTableMerge.vOrderID_Merge);
                    if (_Result == Utilities.Parameters.ResultMessage)
                    {
                        lkTypeView_EditValueChanged(null, null);

                        foreach (GalleryItem item in galleryTable.Gallery.GetAllItems())
                        {
                            if (int.Parse(item.Value.ToString()) == selectedOrderID)
                                item.Checked = true;
                            else
                                item.Checked = false;
                        }

                        galleryTable_Gallery_ItemClick(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnTablePrintList_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để in.");
                    return;
                }

                DataTable dtOrder = new DataTable();
                string _Result = bOrder.GetByID(callFrom, ref dtOrder, selectedOrderID.ToString());
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByID:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByID");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, false, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                DataTable dtOrderDetails = new DataTable();
                string result = bOrder.GetDetailsByOrderID(callFrom, ref dtOrderDetails, selectedOrderID.ToString(), false);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetDetailsByOrderID:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetDetailsByOrderID");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, false, btnTablePayment.Enabled, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                for (int i = 0; i < dtOrderDetails.Rows.Count - 1; i++)
                {
                    string _MenuID = dtOrderDetails.Rows[i]["MenuID"].ToString();
                    string _SizeID = dtOrderDetails.Rows[i]["SizeID"].ToString();
                    decimal _Price = decimal.Parse(dtOrderDetails.Rows[i]["Price"].ToString());
                    for (int j = i + 1; j < dtOrderDetails.Rows.Count; j++)
                    {
                        string _MenuID2 = dtOrderDetails.Rows[j]["MenuID"].ToString();
                        string _SizeID2 = dtOrderDetails.Rows[j]["SizeID"].ToString();
                        decimal _Price2 = decimal.Parse(dtOrderDetails.Rows[j]["Price"].ToString());

                        if (_MenuID == _MenuID2 && _SizeID == _SizeID2 && _Price == _Price2)
                        {
                            dtOrderDetails.Rows[i]["Quantity"] = int.Parse(dtOrderDetails.Rows[i]["Quantity"].ToString()) +
                                                                 int.Parse(dtOrderDetails.Rows[j]["Quantity"].ToString());

                            dtOrderDetails.Rows[i]["Total"] = decimal.Parse(dtOrderDetails.Rows[i]["Total"].ToString()) +
                                                                decimal.Parse(dtOrderDetails.Rows[j]["Total"].ToString());
                            dtOrderDetails.Rows.RemoveAt(j);
                            j = j - 1;
                        }
                    }
                }

                dtOrderDetails.AcceptChanges();

                DataView dv = dtOrderDetails.DefaultView;
                dv.Sort = "MenuGroupName, MenuName ASC";
                dtOrderDetails = dv.ToTable();

                #region dtoPrintBill

                dtoPrintBill PrintBill = new dtoPrintBill();

                PrintBill.CompanyName = Utilities.Parameters.Definition.COMPANY_NAME;
                PrintBill.CompanyAddress = Utilities.Parameters.Definition.COMPANY_ADDRESS;
                PrintBill.CompanyPhone = Utilities.Parameters.Definition.COMPANY_PHONE;
                PrintBill.CompanyFacebook = Utilities.Parameters.Definition.COMPANY_FACE;

                PrintBill.DinnerTableName = dtOrder.Rows[0]["DinnerTableName"].ToString();
                PrintBill.OrderDate = DateTime.Parse(dtOrder.Rows[0]["OrderDate"].ToString()).ToString("dd/MM/yyyy HH:mm");

                dtOrderDetails.Columns.Add("RankIndex", typeof(int));
                for (int i = 0; i < dtOrderDetails.Rows.Count; i++)
                {
                    dtOrderDetails.Rows[i]["RankIndex"] = i + 1;

                    string name = "";
                    if (dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() != "" && dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() != "")
                        name = "(" + dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() + "," + dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() + ")";
                    else if (dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() != "" && dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() == "")
                        name = "(" + dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() + ")";
                    else if (dtOrderDetails.Rows[i]["KindOfHotpot1Name"].ToString() == "" && dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() != "")
                        name = "(" + dtOrderDetails.Rows[i]["KindOfHotpot2Name"].ToString() + ")";

                    if (name != "")
                        dtOrderDetails.Rows[i]["MenuName"] = dtOrderDetails.Rows[i]["MenuName"].ToString() + " " + name;

                    busGeneralFunctions bGF = new busGeneralFunctions();
                    DataTable vdtSize = new DataTable();
                    string vResult = bGF.GetByCondition(callFrom, ref vdtSize, "Menu_Size", new string[] { "MenuID" }, new string[] { dtOrderDetails.Rows[i]["MenuID"].ToString() }, null);
                    if (result == Utilities.Parameters.ResultMessage && vdtSize.Rows.Count > 1)
                        dtOrderDetails.Rows[i]["MenuName"] = dtOrderDetails.Rows[i]["MenuName"].ToString() + " (" + dtOrderDetails.Rows[i]["SizeName"].ToString() + ")";
                }

                PrintBill.dtDetail = dtOrderDetails;

                #endregion

                pageManagement_groupFunctions_TableAndDish_Print frmPrint = new pageManagement_groupFunctions_TableAndDish_Print();
                frmPrint.vType = "CheckBill";
                frmPrint.vIsPrint = true;
                frmPrint.vPrintBill = PrintBill;
                frmPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnTablePrintBill_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                PrintBill(callFrom, selectedOrderID.ToString(), true);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnDishEdit_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvOrderDetails.FocusedRowHandle < 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Món.");
                    return;
                }

                string _OrderDetailID = gvOrderDetails.GetFocusedRowCellValue(gvOrderDetails_colID).ToString();

                pageManagement_groupFunctions_TableAndDish_DishEdit frmDishEdit = new pageManagement_groupFunctions_TableAndDish_DishEdit();
                frmDishEdit.vOrderDetailID = _OrderDetailID;
                DialogResult dlg = frmDishEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    if (lkTypeView.EditValue != null && lkTypeView.EditValue.ToString() != "" &&
                        int.Parse(lkTypeView.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfOrder.Chưa_thu_tiền)
                        CalcTotal(callFrom, selectedOrderID.ToString());
             
                    lkDishTypeView_EditValueChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void timerPromotion_Tick(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string promotion = "";

                DataTable dtPromotionOnTotalBill = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtPromotionOnTotalBill, "PromotionOnTotalBill", 
                                                        new string[] { "StatusID" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.StatusOfPromotion.Đang_có_hiệu_lực).ToString() }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> General_GetByCondition");
                    return;
                }

                if (dtPromotionOnTotalBill.Rows.Count > 0)
                {
                    if (dtPromotionOnTotalBill.Rows.Count > 1)
                        Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Dữ liệu khuyến mãi lỗi.\nVì có " + dtPromotionOnTotalBill.Rows.Count + " chương trình khuyến mãi đang có hiệu lực.");

                    foreach (DataRow dr in dtPromotionOnTotalBill.Rows)
                    {
                        DateTime startDate = DateTime.Parse(dr["StartDate"].ToString());
                        DateTime stopDate = DateTime.Parse(dr["StopDate"].ToString());
                        if (stopDate < DateTime.Now)
                        {
                            dr["StatusID"] = (int)Utilities.CategoriesEnum.StatusOfPromotion.Hết_hạn;
                        }
                        else if (startDate <= DateTime.Now && DateTime.Now <= stopDate)
                        {
                            promotion = promotion + dr["Name"].ToString() + " giảm ";

                            if (dr["ProPercent"].ToString() != "")
                                promotion = promotion + dr["ProPercent"].ToString() + "%";
                            else
                                promotion = promotion + decimal.Parse(dr["ProAmount"].ToString()).ToString("n0") + " VNĐ";

                            if (startDate.Year == stopDate.Year && startDate.Month == stopDate.Month && startDate.Day == stopDate.Day)
                                promotion = promotion + ", trong ngày " + startDate.ToString("dd/MM/yyyy");
                            else
                                promotion = promotion + " (" + startDate.ToString("dd/MM/yyyy HH:mm:ss") + " -> " + stopDate.ToString("dd/MM/yyyy HH:mm:ss") + ")";
                        }
                    }

                    result = bGeneral.UpdateByID(callFrom, dtPromotionOnTotalBill);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Update");
                    }
                }

                lbPromotion.Text = promotion;
                if (promotion == "")
                    pnPromotion.Visible = false;
                else
                    pnPromotion.Visible = true;
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                PrintBankAccount(callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void timerNow_Tick(object sender, EventArgs e)
        {
            lbDatetimeNow.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnTableCollect_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (selectedOrderID == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn Bàn để thu tiền.");
                    return;
                }

                GalleryItem _Item = galleryTable.Gallery.GetItemByValue(selectedOrderID);

                pageManagement_groupFunctions_TableAndDish_CashOrBank frmCashOrBank = new pageManagement_groupFunctions_TableAndDish_CashOrBank();
                frmCashOrBank.vTableName = _Item.Caption;
                DialogResult dlg = frmCashOrBank.ShowDialog();
                if (dlg != DialogResult.OK || frmCashOrBank.vType == "")
                    return;

                DataTable dtOrder = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref dtOrder, "Orders", new string[] { "ID" }, new string[] { selectedOrderID.ToString() }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> General_GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> General_GetByCondition");
                    CheckRight(callFrom, btnAddNote.Enabled, btnDishAdd.Enabled, btnDishEdit.Enabled, btnDishDelete.Enabled, btnTableAdd.Enabled, btnTableChange.Enabled, btnTableMerge.Enabled,
                       btnTableDelete.Enabled, btnTablePrintList.Enabled, false, btnTablePrintBill.Enabled, btnTableCollectMoney.Enabled);
                    return;
                }

                dtOrder.Rows[0]["ActionBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);
                dtOrder.Rows[0]["ActionDate"] = DateTime.Now;
                dtOrder.Rows[0]["PaymentedType"] = frmCashOrBank.vType;
                dtOrder.Rows[0]["StatusOfOrderID"] = (int)Utilities.CategoriesEnum.StatusOfOrder.Đã_thu_tiền;

                LoadDefinition(callFrom);
                if (Utilities.Parameters.Definition.WAREHOUSE == "ON")
                    _Result = bOrder.Update_WarehouseSubtract(callFrom, ref dtOrder);
                else
                    _Result = bOrder.Update(callFrom, ref dtOrder);

                if (_Result == Utilities.Parameters.ResultMessage)
                {
                    lkTypeView_EditValueChanged(null, null);

                    if (Utilities.Parameters.Definition.SMTP_GG_ENABLE == "ON")
                    {
                        MainForm frmMain = (MainForm)Application.OpenForms[0];
                        frmMain.AutoReport();
                    }
                }
                else
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        private void btnSticker_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_TableAndDish_Sticker frmSticker = new pageManagement_groupFunctions_TableAndDish_Sticker();
                frmSticker.ShowDialog();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void btnPrintName_Click(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                int[] vListID = gvOrderDetails.GetSelectedRows();
                if (vListID.Length == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn món để in.");
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn in Tên món?") != DialogResult.Yes)
                    return;
                
                string PrinterName = GetPrinterName("PRINTER_STICKER");

                foreach (int idx in vListID)
                {
                    string vPrintSticker = gvOrderDetails.GetRowCellValue(idx, gvOrderDetails_colPrintSticker).ToString();
                    if (vPrintSticker != "")
                    {
                        if (vPrintSticker == "1" || bool.Parse(vPrintSticker))
                        {
                            string vMenuName = gvOrderDetails.GetRowCellValue(idx, gvOrderDetails_colMenuName).ToString();
                            int vQuantity = int.Parse(gvOrderDetails.GetRowCellValue(idx, gvOrderDetails_colQuantity).ToString());

                            DocumentViewer documentViewer1 = new DocumentViewer();
                            pageManagement_groupFunctions_TableAndDish_rptSticker_Payment rptView = new pageManagement_groupFunctions_TableAndDish_rptSticker_Payment();
                            rptView.BindData_Information(vMenuName);
                            documentViewer1.PrintingSystem = rptView.PrintingSystem;
                            rptView.CreateDocument();

                            rptView.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Print, CommandVisibility.None);
                            rptView.ShowPrintStatusDialog = false;

                            using (ReportPrintTool printTool = new ReportPrintTool(rptView))
                            {
                                if (PrinterName != "")
                                    printTool.PrinterSettings.PrinterName = PrinterName;

                                for (int k = 1; k <= vQuantity; k++)
                                    printTool.Print();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void gvOrderDetails_RowCountChanged(object sender, EventArgs e)
        {
            btnPrintName.Enabled = false;
            if (gvOrderDetails.RowCount > 0)
                btnPrintName.Enabled = true;
        }
    }
}