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
    public partial class pageCategories_groupMaterialMenu_DinnerTable : DevExpress.XtraEditors.XtraForm
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
                pageCategories_groupMaterialMenu_DinnerTable_Load(null, null);
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
                pageCategories_groupMaterialMenu_DinnerTable_Edit frmEdit = new pageCategories_groupMaterialMenu_DinnerTable_Edit();
                frmEdit.vDinnerTableID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit.vDinnerTableID);
                    pageCategories_groupMaterialMenu_DinnerTable_Load(null, null);
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
                if (gvDinnerTable.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn Chức vụ cần cập nhật.", 5000);
                    return;
                }

                selectedID = int.Parse(gvDinnerTable.GetFocusedRowCellValue(colID).ToString());

                pageCategories_groupMaterialMenu_DinnerTable_Edit frmEdit = new pageCategories_groupMaterialMenu_DinnerTable_Edit();
                frmEdit.vDinnerTableID = selectedID.ToString();
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                    pageCategories_groupMaterialMenu_DinnerTable_Load(null, null);
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

        public pageCategories_groupMaterialMenu_DinnerTable()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Danh mục Bàn.");
                this.Close();
            }
        }

        private void pageCategories_groupMaterialMenu_DinnerTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageCategories_groupMaterialMenu_DinnerTable_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageCategories_groupMaterialMenu_DinnerTable_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Populate_LookUpEdit(StatusOfDinnerTableID_rlk, "StatusOfDinnerTable");

                DataTable dtDinnerTable = new DataTable();
                string result = bGeneral.GetAll(callFrom, ref dtDinnerTable, "DinnerTable", "Name ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll");
                }

                gcDinnerTable.DataSource = dtDinnerTable;

                if (selectedID > 0)
                    for (int i = 0; i < gvDinnerTable.RowCount; i++)
                    {
                        if (gvDinnerTable.GetRowCellValue(i, colID) != null && gvDinnerTable.GetRowCellValue(i, colID).ToString() == selectedID.ToString())
                        {
                            gvDinnerTable.SelectRow(i);
                            gvDinnerTable.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (dtDinnerTable == null || dtDinnerTable.Rows.Count == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                gvDinnerTable_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvDinnerTable_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvDinnerTable_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvDinnerTable.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                frmMain.EnableAction(true, false, true, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion
    }
}