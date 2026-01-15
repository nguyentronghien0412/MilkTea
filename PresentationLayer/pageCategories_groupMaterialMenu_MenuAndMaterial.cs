using BusinessLogicLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class pageCategories_groupMaterialMenu_MenuAndMaterial : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];
        int arrIndex = -1;
        int selectedID = 0;

        string MenuID = "";
        string MenuName = "";

        string SizeID = "";
        string SizeName = "";

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        #region Functions

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

        private void LoadData(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                busMenu bMenu = new busMenu();

                DataTable dtMenu = new DataTable();
                string result = bMenu.GetAll_FullSize_IsActive(callFrom, ref dtMenu);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll Menu:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll Menu");
                }
                if (dtMenu.Rows.Count == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Error, "Không có dữ liệu Thực đơn.");
                    return;
                }

                dtMenu.TableName = "Main";

                DataTable dtMaterials = new DataTable();
                result = bMenu.MenuAndMaterials_GetAllIsActive(callFrom, ref dtMaterials);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetAll Materials:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetAll Materials");
                }

                dtMaterials.TableName = "Detail";

                DataSet ds = new DataSet();
                ds.Tables.Add(dtMenu);
                ds.Tables.Add(dtMaterials);

                //Set up a master-detail relationship between the DataTables
                DataColumn keyColumn = ds.Tables["Main"].Columns["MenuID_SizeID"];
                DataColumn foreignKeyColumn = ds.Tables["Detail"].Columns["MenuID_SizeID"];
                ds.Relations.Add("Main_Detail", keyColumn, foreignKeyColumn);

                //Bind the grid control to the data source 
                gcMenuAndMaterials.DataSource = ds.Tables["Main"];
                gcMenuAndMaterials.ForceInitialize();

                gvMenu.Columns["ID"].VisibleIndex = -1;

                gcMenuAndMaterials.LevelTree.Nodes.Add("Main_Detail", gvMaterials);
                gvMaterials.Columns["MenuID"].VisibleIndex = -1;

                gvMaterials.ViewCaption = "Category Products";

                chkExpand.Checked = false;
                chkExpand_CheckedChanged(null, null);
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
                pageCategories_groupMaterialMenu_MenuAndMaterial_Edit frmEdit = new pageCategories_groupMaterialMenu_MenuAndMaterial_Edit();
                frmEdit.Type = "NEW";
                frmEdit.MenuID = MenuID;
                frmEdit.MenuName = MenuName;
                frmEdit.SizeID = SizeID;
                frmEdit.SizeName = SizeName;
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(MenuID);
                    pageCategories_groupMaterialMenu_MenuAndMaterial_Load(null, null);
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
                pageCategories_groupMaterialMenu_MenuAndMaterial_Edit frmEdit = new pageCategories_groupMaterialMenu_MenuAndMaterial_Edit();
                frmEdit.Type = "EDIT";
                frmEdit.MenuID = MenuID;
                frmEdit.MenuName = MenuName;
                frmEdit.SizeID = SizeID;
                frmEdit.SizeName = SizeName;
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(MenuID);
                    pageCategories_groupMaterialMenu_MenuAndMaterial_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        public pageCategories_groupMaterialMenu_MenuAndMaterial()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex.");
                this.Close();
            }
        }

        private void gvMenu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvMaterials_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void pageCategories_groupMaterialMenu_MenuAndMaterial_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                Populate_LookUpEdit(gvMenu_colMenuGroupID_lk, "MenuGroup");
                Populate_LookUpEdit(gvMaterials_colUnitID_lk, "Unit");
                Populate_LookUpEdit(gvMenu_colSizeID_lk, "Size");
                LoadData(callFrom);

                chkExpand.Checked = false;
                chkExpand_CheckedChanged(null, null);
                if (selectedID > 0)
                    for (int i = 0; i < gvMenu.RowCount; i++)
                    {
                        if (gvMenu.GetRowCellValue(i, gvMenu_colID) != null && gvMenu.GetRowCellValue(i, gvMenu_colID).ToString() == selectedID.ToString())
                        {
                            gvMenu.SelectRow(i);
                            gvMenu.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (gvMenu.RowCount == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                gvMenu_RowClick(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void pageCategories_groupMaterialMenu_MenuAndMaterial_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageCategories_groupMaterialMenu_MenuAndMaterial_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
            {
                for (int i = 0; i < gvMenu.RowCount; i++)
                    gvMenu.CollapseMasterRow(i);
                gvMenu.CollapseAllGroups();
            }
            else
            {
                gvMenu.ExpandAllGroups();
                for (int i = 0; i < gvMenu.RowCount; i++)
                    gvMenu.ExpandMasterRow(i);
            }
        }

        private void gvMenu_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            gvMenu_FocusedRowChanged(null, null);
        }

        private void gvMenu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvMenu.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(false, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                MenuID = gvMenu.GetFocusedRowCellValue(gvMenu_colID).ToString();
                MenuName = gvMenu.GetFocusedRowCellValue(gvMenu_colName).ToString();

                SizeID = gvMenu.GetFocusedRowCellValue(gvMenu_colSizeID).ToString();
                SizeName = gvMenu.GetFocusedRowCellDisplayText(gvMenu_colSizeID).ToString();

                busMenu bMenu = new busMenu();
                DataTable dtMaterials = new DataTable();
                string result = bMenu.MenuAndMaterials_GetByMenuIDAndSizeID(callFrom, ref dtMaterials, MenuID, SizeID);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> MenuAndMaterials_GetByMenuID:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> MenuAndMaterials_GetByMenuID");
                    frmMain.EnableAction(false, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                if (dtMaterials != null && dtMaterials.Rows.Count > 0)
                    frmMain.EnableAction(false, false, true, false, false, true, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}