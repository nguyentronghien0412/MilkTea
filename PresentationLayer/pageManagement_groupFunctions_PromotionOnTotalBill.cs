using BusinessLogicLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class pageManagement_groupFunctions_PromotionOnTotalBill : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        int arrIndex = -1;
        int selectedID = 0;

        #region Functions

        public void Refreshed(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_PromotionOnTotalBill_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void New(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageManagement_groupFunctions_PromotionOnTotalBill_Edit frmEdit = new pageManagement_groupFunctions_PromotionOnTotalBill_Edit();
                frmEdit.vPromotionID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit.vPromotionID);
                    pageManagement_groupFunctions_PromotionOnTotalBill_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        public void Edit(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvPromotion.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn Chương trình khuyến mãi cần cập nhật.", 5000);
                    return;
                }

                selectedID = int.Parse(gvPromotion.GetFocusedRowCellValue(gvPromotion_colID).ToString());

                pageManagement_groupFunctions_PromotionOnTotalBill_Edit frmEdit = new pageManagement_groupFunctions_PromotionOnTotalBill_Edit();
                frmEdit.vPromotionID = selectedID.ToString();
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                    pageManagement_groupFunctions_PromotionOnTotalBill_Load(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }

        }

        public void Delete(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvPromotion.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn dữ liệu cần xóa.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn xóa '" + gvPromotion.GetFocusedRowCellValue(gvPromotion_colName).ToString() + "'?") != DialogResult.Yes)
                    return;

                selectedID = int.Parse(gvPromotion.GetFocusedRowCellValue(gvPromotion_colID).ToString());

                string result = bGeneral.DeleteByID(callFrom, "PromotionOnTotalBill", selectedID.ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> PromotionOnTotalBill_Delete:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> PromotionOnTotalBill_Delete");
                    return;
                }

                pageManagement_groupFunctions_PromotionOnTotalBill_Load(null, null);
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

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        #endregion

        #region Events

        public pageManagement_groupFunctions_PromotionOnTotalBill()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Chương trình khuyến mãi.");
                this.Close();
            }
        }

        private void pageManagement_groupFunctions_PromotionOnTotalBill_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageManagement_groupFunctions_PromotionOnTotalBill_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageManagement_groupFunctions_PromotionOnTotalBill_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Populate_LookUpEdit(gvPromotion_colStatusID_rlk, "StatusOfPromotion");

                busPromotionOnTotalBill bPromotionOnTotalBill = new busPromotionOnTotalBill();
                DataTable dtPromotionOnTotalBill = new DataTable();
                string result = bPromotionOnTotalBill.GetAll(callFrom, ref dtPromotionOnTotalBill);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll");
                }

                gcPromotion.DataSource = dtPromotionOnTotalBill;

                if (selectedID > 0)
                    for (int i = 0; i < gvPromotion.RowCount; i++)
                    {
                        if (gvPromotion.GetRowCellValue(i, gvPromotion_colID) != null && gvPromotion.GetRowCellValue(i, gvPromotion_colID).ToString() == selectedID.ToString())
                        {
                            gvPromotion.SelectRow(i);
                            gvPromotion.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (dtPromotionOnTotalBill == null || dtPromotionOnTotalBill.Rows.Count == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                gvPromotion_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvPromotion_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvPromotion_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvPromotion.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                int statusID = int.Parse(gvPromotion.GetFocusedRowCellValue(gvPromotion_colStatusID).ToString());
                if (statusID == (int)Utilities.CategoriesEnum.StatusOfPromotion.Chưa_có_hiệu_lực)
                    frmMain.EnableAction(true, false, true, true, false, true, false, false, false, arrIndex);
                else if (statusID == (int)Utilities.CategoriesEnum.StatusOfPromotion.Đang_có_hiệu_lực)
                    frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        private void gcPromotion_Click(object sender, EventArgs e)
        {

        }
    }
}