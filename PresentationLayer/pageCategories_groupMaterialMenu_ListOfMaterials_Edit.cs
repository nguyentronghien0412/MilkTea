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
    public partial class pageCategories_groupMaterialMenu_ListOfMaterials_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vMaterialsID = "";
        public DataTable vdtMaterials = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageCategories_groupMaterialMenu_ListOfMaterials_Edit()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void pageCategories_groupMaterialMenu_ListOfMaterials_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vMaterialsID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã Vật tư.");
                    return;
                }

                Populate_LookUpEdit(Materials_MaterialsGroupID, "MaterialsGroup");
                Populate_LookUpEdit(Materials_UnitID, "Unit");
                Populate_LookUpEdit(Materials_UnitID_Max, "Unit");
                Populate_LookUpEdit(Materials_StatusID, "MaterialsStatus");

                vdtMaterials = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtMaterials, "Materials", new string[] { "ID" }, new string[] { vMaterialsID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                }

                if (int.Parse(vMaterialsID) == 0)
                {
                    this.Text = "Vật tư - Tạo mới";

                    DataRow _drMaterials = vdtMaterials.NewRow();
                    _drMaterials["StatusID"] = (int)Utilities.CategoriesEnum.MaterialsStatus.Đang_sử_dụng;
                    vdtMaterials.Rows.Add(_drMaterials);
                }
                else
                {
                    this.Text = "Vật tư - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(vdtMaterials.Rows[0], this, callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                DataTable dtCheck = new DataTable();
                if (int.Parse(vMaterialsID) == 0)
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Materials", new string[] { "Name" }, new string[] { "'" + Materials_Name.Text.Trim() + "'" }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên vật tư đã có trong danh mục.";
                }
                else
                {
                    string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "Materials", new string[] { "Name", "ID" }, new string[] { "=", "<>" }, new string[] { "'" + Materials_Name.Text.Trim() + "'", vMaterialsID }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                        return result + "\n" + callFrom + " -> GetByCondition";
                    }
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                        return "Tên vật tư đã có trong danh mục.";
                }

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                msg = CheckValid(callFrom);
                if (msg != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, msg, 5000);
                    return;
                }

                Utilities.Multi.AssignData_FormToRow(vdtMaterials.Rows[0], this, callFrom);

                string result = "";
                if (int.Parse(vMaterialsID) == 0)
                    result = bGeneral.Insert(callFrom, ref vdtMaterials, true);
                else
                    result = bGeneral.UpdateByID(callFrom, vdtMaterials);

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(vMaterialsID) == 0)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Insert:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Insert");
                    }
                    else
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Update:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Update");
                    }

                    return;
                }
                else
                {
                    vMaterialsID = vdtMaterials.Rows[0]["ID"].ToString();
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void Materials_MaterialsGroupID_View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void Materials_UnitID_Max_View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void Materials_UnitID_View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void Materials_UnitID_EditValueChanged(object sender, EventArgs e)
        {
            emptySpaceItem5.Text = Materials_UnitID.Text + "/" + Materials_UnitID_Max.Text;
        }

        private void Materials_UnitID_Max_EditValueChanged(object sender, EventArgs e)
        {
            emptySpaceItem5.Text = Materials_UnitID.Text + "/" + Materials_UnitID_Max.Text;
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageCategories_groupMaterialMenu_Unit_Edit frmEdit = new pageCategories_groupMaterialMenu_Unit_Edit();
                frmEdit.vUnitID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    Populate_LookUpEdit(Materials_UnitID, "Unit");
                    Materials_UnitID.EditValue = int.Parse(frmEdit.vUnitID);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnAddUnitMax_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pageCategories_groupMaterialMenu_Unit_Edit frmEdit = new pageCategories_groupMaterialMenu_Unit_Edit();
                frmEdit.vUnitID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    Populate_LookUpEdit(Materials_UnitID_Max, "Unit");
                    Materials_UnitID_Max.EditValue = int.Parse(frmEdit.vUnitID);
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