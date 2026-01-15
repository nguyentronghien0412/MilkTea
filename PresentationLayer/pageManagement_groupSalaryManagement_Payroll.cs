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
    public partial class pageManagement_groupSalaryManagement_Payroll : DevExpress.XtraEditors.XtraForm
    {
        MainForm frmMain = (MainForm)Application.OpenForms[0];

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
        BusinessLogicLayer.busPayroll bPayroll = new BusinessLogicLayer.busPayroll();

        int arrIndex = -1;
        int selectedID = 0;

        #region Functions     

        public void Refreshed(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                GetListOfEmployees(callFrom);
                GetListOfCreatedBy(callFrom);
                btnGetData_Click(null, null);
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
                pageManagement_groupSalaryManagement_Payroll_Edit frmEdit = new pageManagement_groupSalaryManagement_Payroll_Edit();
                frmEdit._PayrollID = "0";
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit._PayrollID);

                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
                }
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
                if (gvListOfPayrolls.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Vui lòng chọn Bảng lương cần hủy.", 5000);
                    return;
                }

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn XÓA bảng lương của " + gvListOfPayrolls.GetFocusedRowCellDisplayText(gvListOfPayrolls_colEmployeeID).ToString() + "?") != DialogResult.Yes)
                    return;

                selectedID = int.Parse(gvListOfPayrolls.GetFocusedRowCellValue(gvListOfPayrolls_colID).ToString());
               
                string result = bPayroll.Delete(callFrom, selectedID.ToString());
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Delete:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Delete");
                    return;
                }
                else
                {
                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
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

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ dữ liệu cần tra cứu.";

                return "";
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                return ex.Message + "\n" + callFrom;
            }

        }

        private void GetListOfEmployees(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                slkEmployee.Properties.DataSource = null;

                DataTable vdtEmployees = new DataTable();
                string vResult = bPayroll.GetListOfEmployees(callFrom, ref vdtEmployees, datePayrollDateFrom.DateTime, datePayrollDateTo.DateTime);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetListOfEmployees:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetListOfEmployees");
                }
                else
                {
                    DataTable vdtEmployees2 = vdtEmployees.Copy();
                    gvListOfPayrolls_colEmployeeID_lk.ValueMember = "ID";
                    gvListOfPayrolls_colEmployeeID_lk.DisplayMember = "FullName";
                    gvListOfPayrolls_colEmployeeID_lk.DataSource = vdtEmployees2;

                    DataRow dr = vdtEmployees.NewRow();
                    dr["ID"] = -1;
                    dr["FullName"] = "Tất cả";
                    vdtEmployees.Rows.InsertAt(dr, 0);

                    slkEmployee.Properties.ValueMember = "ID";
                    slkEmployee.Properties.DisplayMember = "FullName";
                    slkEmployee.Properties.DataSource = vdtEmployees;
                    slkEmployee.EditValue = int.Parse(Utilities.Parameters.UserLogin.EmployeesID);
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void GetListOfCreatedBy(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                gvListOfPayrolls_colCreatedBy_lk.DataSource = null;

                DataTable vdtUser = new DataTable();
                string vResult = bPayroll.GetListOfCreatedBy(callFrom, ref vdtUser, datePayrollDateFrom.DateTime, datePayrollDateTo.DateTime);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetListOfCreatedBy:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetListOfCreatedBy");
                }
                else
                {
                    gvListOfPayrolls_colCreatedBy_lk.ValueMember = "ID";
                    gvListOfPayrolls_colCreatedBy_lk.DisplayMember = "FullName";
                    gvListOfPayrolls_colCreatedBy_lk.DataSource = vdtUser;
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        #region Events

        public pageManagement_groupSalaryManagement_Payroll()
        {
            InitializeComponent();

            arrIndex = Utilities.Multi.GetIndexArray(this.Name);
            if (arrIndex == -1)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy arrIndex của Bảng lương.");
                this.Close();
            }
        }

        private void pageManagement_groupSalaryManagement_Payroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(false, false, false, false, false, false, false, false, false, arrIndex);
            frmMain.ChangeCurrentForm(callFrom, "", "");
        }

        private void pageManagement_groupSalaryManagement_Payroll_Activated(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            frmMain.EnableAction(Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][1], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][2],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][3], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][4],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][5], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][6],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][7], Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][8],
                              Utilities.Parameters.UserLogin.arrButtonStatus[arrIndex][9], arrIndex);
            frmMain.ChangeCurrentForm(callFrom, this.Name, this.Text);
        }

        private void pageManagement_groupSalaryManagement_Payroll_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                datePayrollDateFrom.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);

                DateTime vDateTemp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 23, 59, 59);
                vDateTemp = vDateTemp.AddMonths(1);
                datePayrollDateTo.DateTime = vDateTemp.AddDays(-1);

                Populate_LookUpEdit(lkStatus, "Payroll_Status");
                Populate_LookUpEdit(gvListOfPayrolls_colStatusID_lk, "Payroll_Status");

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_Payroll", Utilities.Parameters.Permission_VIEW_ALL))
                {
                    slkEmployee.ReadOnly = false;
                }
                else
                {
                    slkEmployee.ReadOnly = true;
                }

                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
                frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
        }

        private void gvListOfPayrolls_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gvListOfPayrolls_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvListOfPayrolls.FocusedRowHandle < 0)
                {
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                    return;
                }

                int vStatusID = int.Parse(gvListOfPayrolls.GetFocusedRowCellValue(gvListOfPayrolls_colStatusID).ToString());
                if (vStatusID == (int)Utilities.CategoriesEnum.Payroll_Status.Chưa_thanh_toán)
                    frmMain.EnableAction(true, false, false, true, false, true, false, false, false, arrIndex);
                else
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void lkStatus_EditValueChanged(object sender, EventArgs e)
        {
            gcListOfPayrolls.DataSource = null;
        }

        private void datePayrollDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GetListOfEmployees(callFrom);
            GetListOfCreatedBy(callFrom);
            gcListOfPayrolls.DataSource = null;
        }

        private void datePayrollDateTo_EditValueChanged(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            GetListOfEmployees(callFrom);
            GetListOfCreatedBy(callFrom);
            gcListOfPayrolls.DataSource = null;
        }

        private void slkEmployee_EditValueChanged(object sender, EventArgs e)
        {
            gcListOfPayrolls.DataSource = null;
        }

        private void btnGetData_Click(object sender, EventArgs e)
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

                DateTime vFrom = new DateTime(datePayrollDateFrom.DateTime.Year, datePayrollDateFrom.DateTime.Month, datePayrollDateFrom.DateTime.Day, 0, 0, 0);
                DateTime vTo = new DateTime(datePayrollDateTo.DateTime.Year, datePayrollDateTo.DateTime.Month, datePayrollDateTo.DateTime.Day, 23, 59, 59);
                string vStatus = lkStatus.EditValue.ToString();
                string vEmployeeID = slkEmployee.EditValue.ToString();

                DataTable vdtPayroll = new DataTable();
                string[] varrFields = new string[] { "CreatedDate", "CreatedDate", "StatusID" };
                string[] varrOpers = new string[] { ">=", "<=", "=" };
                string[] varrValue = new string[] { "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                    vStatus };

                if (int.Parse(vEmployeeID) > 0)
                {
                    Array.Resize(ref varrFields, varrFields.Length + 1);
                    varrFields[varrFields.Length - 1] = "EmployeeID";

                    Array.Resize(ref varrOpers, varrOpers.Length + 1);
                    varrOpers[varrOpers.Length - 1] = "=";

                    Array.Resize(ref varrValue, varrValue.Length + 1);
                    varrValue[varrValue.Length - 1] = vEmployeeID;
                }

                string result = bGeneral.GetByCondition(callFrom, ref vdtPayroll, "Payroll", varrFields, varrOpers, varrValue, "EmployeeID ASC, CreatedDate ASC");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> GetByCondition");
                }

                gcListOfPayrolls.DataSource = vdtPayroll;

                if (selectedID > 0)
                    for (int i = 0; i < gvListOfPayrolls.RowCount; i++)
                    {
                        if (gvListOfPayrolls.GetRowCellValue(i, gvListOfPayrolls_colID) != null && gvListOfPayrolls.GetRowCellValue(i, gvListOfPayrolls_colID).ToString() == selectedID.ToString())
                        {
                            gvListOfPayrolls.SelectRow(i);
                            gvListOfPayrolls.FocusedRowHandle = i;
                            break;
                        }
                    }

                if (gvListOfPayrolls.RowCount == 0)
                    frmMain.EnableAction(true, false, false, false, false, true, false, false, false, arrIndex);
                gvListOfPayrolls_FocusedRowChanged(null, null);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        #endregion

        private void slkEmployee_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void gcListOfPayrolls_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string callFrom = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (gvListOfPayrolls.FocusedRowHandle < 0)
                    return;

                pageManagement_groupSalaryManagement_Payroll_Edit frmEdit = new pageManagement_groupSalaryManagement_Payroll_Edit();
                frmEdit._PayrollID = gvListOfPayrolls.GetFocusedRowCellValue(gvListOfPayrolls_colID).ToString();
                DialogResult dlg = frmEdit.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    selectedID = int.Parse(frmEdit._PayrollID);

                    object vStatus = lkStatus.EditValue;
                    object vEmployeeID = slkEmployee.EditValue;

                    GetListOfEmployees(callFrom);
                    GetListOfCreatedBy(callFrom);

                    lkStatus.EditValue = vStatus;
                    slkEmployee.EditValue = vEmployeeID;

                    btnGetData_Click(null, null);
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