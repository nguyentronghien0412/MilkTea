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
    public partial class pageCategories_groupMaterialMenu_MenuAndMaterial_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string Type = "";

        public string MenuID = "";
        public string MenuName = "";

        public string SizeID = "";
        public string SizeName = "";

        BusinessLogicLayer.busMenu bMenu = new BusinessLogicLayer.busMenu();
        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

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

        public pageCategories_groupMaterialMenu_MenuAndMaterial_Edit()
        {
            InitializeComponent();
        }

        private void pageCategories_groupMaterialMenu_MenuAndMaterial_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (MenuID == "" || SizeID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Thông tin thực đơn không hợp lệ.");
                    return;
                }

                this.Text = "Danh sách nguyên liệu của thực đơn '" + MenuName + "', kích cỡ " + SizeName;

                Populate_LookUpEdit(gvMaterials_colUnitID_lk, "Unit");

                DataTable dtMaterials = new DataTable();
                string result = bMenu.MenuAndMaterials_GetMaterials(callFrom, ref dtMaterials, ((int)Utilities.CategoriesEnum.MaterialsGroup.Vật_tư_và_Thiết_bị).ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> MenuAndMaterials_GetMaterials:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> MenuAndMaterials_GetMaterials");
                    return;
                }

                dtMaterials.Columns.Add("Quantity", typeof(decimal));
                dtMaterials.Columns.Add("Style", typeof(string));

                foreach (DataRow drM in dtMaterials.Rows)
                    drM["Style"] = drM["StyleQuantity"].ToString() + " " + drM["UnitName"].ToString() + "/" + drM["UnitName_Max"].ToString();

                if (Type == "EDIT")
                {
                    busMenu bMenu = new busMenu();
                    DataTable dtTemp = new DataTable();
                    result = bMenu.MenuAndMaterials_GetByMenuIDAndSizeID(callFrom, ref dtTemp, MenuID, SizeID);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> MenuAndMaterials_GetByMenuID:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> MenuAndMaterials_GetByMenuID");
                        return;
                    }

                    if (dtTemp != null && dtTemp.Rows.Count > 0)
                    {
                        foreach (DataRow drT in dtTemp.Rows)
                        {
                            foreach (DataRow drM in dtMaterials.Rows)
                            {
                                if (drT["MaterialsID"].ToString() == drM["ID"].ToString())
                                {
                                    drM["Quantity"] = drT["Quantity"];
                                    drM["MaterialsGroupName_Sub"] = "A. Nguyên liệu đang sử dụng";
                                    break;
                                }
                            }
                        }
                    }
                }

                gcMaterials.DataSource = dtMaterials;

                chkExpand.Checked = false;
                chkExpand_CheckedChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void chkExpand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExpand.Checked)
                gvMaterials.CollapseAllGroups();
            else
                gvMaterials.ExpandAllGroups();
        }

        private void gvMaterials_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gvMaterials_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (e.RowHandle < 0)
                    return;

                if (e.Column == gvMaterials_colQuantity)
                {
                    if (e.Value == null || e.Value.ToString() == "" || e.Value.ToString() == "0")
                        gvMaterials.SetFocusedRowCellValue(gvMaterials_colMaterialsGroupName_Sub, gvMaterials.GetFocusedRowCellValue(gvMaterials_colMaterialsGroupName));
                    else
                        gvMaterials.SetFocusedRowCellValue(gvMaterials_colMaterialsGroupName_Sub, "A. Nguyên liệu đang sử dụng");

                    timer1.Interval = 500;
                    timer1.Start();
                    timer1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chkExpand.Checked = false;
            chkExpand_CheckedChanged(null, null);
         
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gvMaterials.ActiveFilter.Clear();

                DataTable dtMenuAndMaterials = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtMenuAndMaterials, "MenuAndMaterials", new string[] { "ID" }, new string[] { "0" }, null);
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> MenuAndMaterials_GetMaterials:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> MenuAndMaterials_GetMaterials");
                    return;
                }

                for (int i = 0; i < gvMaterials.RowCount; i++)
                {
                    if (gvMaterials.GetRowCellValue(i, gvMaterials_colQuantity) != null &&
                        gvMaterials.GetRowCellValue(i, gvMaterials_colQuantity).ToString() != "" &&
                        gvMaterials.GetRowCellValue(i, gvMaterials_colQuantity).ToString() != "0")
                    {
                        DataRow dr = dtMenuAndMaterials.NewRow();

                        dr["MenuID"] = MenuID;
                        dr["SizeID"] = SizeID;
                        dr["MaterialsID"] = gvMaterials.GetRowCellValue(i, gvMaterials_colID).ToString();
                        dr["Quantity"] = gvMaterials.GetRowCellValue(i, gvMaterials_colQuantity).ToString();

                        dtMenuAndMaterials.Rows.Add(dr);
                    }
                }

                //if (dtMenuAndMaterials.Rows.Count == 0)
                //{
                //    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng nhập nguyên liệu sử dụng.");
                //    return;
                //}

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                if (Type == "NEW")
                    result = bMenu.MenuAndMaterials_Insert(callFrom, ref dtMenuAndMaterials);
                else
                {
                    DataTable dtMenuAndMaterials_Old = new DataTable();
                    result = bGeneral.GetByCondition(callFrom, ref dtMenuAndMaterials_Old, "MenuAndMaterials", new string[] { "MenuID", "SizeID" }, new string[] { MenuID, SizeID }, null);
                    if (result != Utilities.Parameters.ResultMessage)
                    {
                        Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> MenuAndMaterials_GetMaterials:\n" + result);
                        Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> MenuAndMaterials_GetMaterials");
                        return;
                    }

                    result = bMenu.MenuAndMaterials_Update(callFrom, ref dtMenuAndMaterials, dtMenuAndMaterials_Old);
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (Type == "NEW")
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

        private void gvMaterials_colQuantity_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            const char key1 = (char)44;
            const char key2 = (char)46;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != key1 && e.KeyChar != key2;
        }
    }
}