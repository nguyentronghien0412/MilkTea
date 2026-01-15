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
    public partial class pageManagement_groupSalaryManagement_Overtime_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string _OvertimeID = "";
        public DataTable _dtOvertime = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageManagement_groupSalaryManagement_Overtime_Edit()
        {
            InitializeComponent();
        }

        private void pageManagement_groupSalaryManagement_Overtime_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (_OvertimeID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã Dữ liệu tăng ca.");
                    return;
                }

                if (Utilities.Multi.CheckRight_PermissionByCode("pageManagement_groupSalaryManagement_Overtime", Utilities.Parameters.Permission_VIEW_ALL))
                    Overtime_EmployeeID.ReadOnly = false;
                else
                    Overtime_EmployeeID.ReadOnly = true;

                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees ",
                                                        new string[] { "StatusID", "ID" },
                                                        new string[] { "=", "<>" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(), ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString() },
                                                        "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }
                else
                {
                    Overtime_EmployeeID.Properties.ValueMember = "ID";
                    Overtime_EmployeeID.Properties.DisplayMember = "FullName";
                    Overtime_EmployeeID.Properties.DataSource = dtEmployees;
                }

                _dtOvertime = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref _dtOvertime, "Overtime", new string[] { "ID" }, new string[] { _OvertimeID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Overtime:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition Overtime");
                }

                if (int.Parse(_OvertimeID) == 0)
                {
                    this.Text = "Tăng ca - Tạo mới";

                    DataRow _drOvertime = _dtOvertime.NewRow();
                    _drOvertime["StatusID"] = (int)Utilities.CategoriesEnum.Overtime_Status.Chưa_duyệt;
                    _drOvertime["EmployeeID"] = int.Parse(Utilities.Parameters.UserLogin.EmployeesID);
                    _dtOvertime.Rows.Add(_drOvertime);
                }
                else
                {
                    this.Text = "Tăng ca - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(_dtOvertime.Rows[0], this, callFrom);
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string CheckValid(string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                    return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

                DateTime vWorkingDate_In = new DateTime(Overtime_WorkingDate.DateTime.Year,
                                                       Overtime_WorkingDate.DateTime.Month,
                                                       Overtime_WorkingDate.DateTime.Day,
                                                       Overtime_WorkingDate_In.DateTime.Hour,
                                                       Overtime_WorkingDate_In.DateTime.Minute, 0);

                DateTime vWorkingDate_Out = new DateTime(Overtime_WorkingDate.DateTime.Year,
                                                         Overtime_WorkingDate.DateTime.Month,
                                                         Overtime_WorkingDate.DateTime.Day,
                                                         Overtime_WorkingDate_Out.DateTime.Hour,
                                                         Overtime_WorkingDate_Out.DateTime.Minute, 0);

                if (vWorkingDate_Out <= vWorkingDate_In)
                    return "Giờ tăng ca không hợp lệ.";

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

                decimal vSalaryByHour = 0;
                int vCalcSalaryByMinutes = 0;

                #region SalaryByHour & vCalcSalaryByMinutes

                DataTable vdtEmployees = new DataTable();
                string vResult = bGeneral.GetByCondition(callFrom, ref vdtEmployees, "Employees",
                                                         new string[] { "ID" }, new string[] { Overtime_EmployeeID.EditValue.ToString() }, "");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition Employees:\n" + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition Employees");
                    return;
                }
                else
                {
                    if (vdtEmployees.Rows[0]["SalaryByHour"].ToString() == "")
                    {
                        Utilities.Functions.MessageBox("W", Utilities.Parameters.Notification, "Nhân viên này chưa có MỨC LƯƠNG.", 5000);
                        return;
                    }
                    else
                    {
                        if (vdtEmployees.Rows[0]["SalaryByHour"].ToString() != "")
                            vSalaryByHour = decimal.Parse(vdtEmployees.Rows[0]["SalaryByHour"].ToString());

                        if (vdtEmployees.Rows[0]["CalcSalaryByMinutes"].ToString() != "")
                            vCalcSalaryByMinutes = int.Parse(vdtEmployees.Rows[0]["CalcSalaryByMinutes"].ToString());
                    }
                }

                #endregion

                if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu?") != DialogResult.Yes)
                    return;

                #region Assign Data

                _dtOvertime.Rows[0]["WorkingDate"] = new DateTime(Overtime_WorkingDate.DateTime.Year,
                                                                  Overtime_WorkingDate.DateTime.Month,
                                                                  Overtime_WorkingDate.DateTime.Day, 0, 0, 0);

                DateTime vWorkingDate_In = new DateTime(Overtime_WorkingDate.DateTime.Year,
                                                        Overtime_WorkingDate.DateTime.Month,
                                                        Overtime_WorkingDate.DateTime.Day,
                                                        Overtime_WorkingDate_In.DateTime.Hour,
                                                        Overtime_WorkingDate_In.DateTime.Minute, 0);
                _dtOvertime.Rows[0]["WorkingDate_In"] = vWorkingDate_In;

                DateTime vWorkingDate_Out = new DateTime(Overtime_WorkingDate.DateTime.Year,
                                                         Overtime_WorkingDate.DateTime.Month,
                                                         Overtime_WorkingDate.DateTime.Day,
                                                         Overtime_WorkingDate_Out.DateTime.Hour,
                                                         Overtime_WorkingDate_Out.DateTime.Minute, 0);
                _dtOvertime.Rows[0]["WorkingDate_Out"] = vWorkingDate_Out;

                TimeSpan vTS = vWorkingDate_Out - vWorkingDate_In;
                _dtOvertime.Rows[0]["WorkingDate_TotalHours"] = vTS.Hours;

                if (vCalcSalaryByMinutes == 0)
                    _dtOvertime.Rows[0]["WorkingDate_TotalMinutes"] = vTS.Minutes;
                else
                {
                    if (vTS.Minutes < vCalcSalaryByMinutes)
                        _dtOvertime.Rows[0]["WorkingDate_TotalMinutes"] = 0;
                    else
                    {
                        int vTimes = vTS.Minutes / vCalcSalaryByMinutes;
                        _dtOvertime.Rows[0]["WorkingDate_TotalMinutes"] = vTimes * vCalcSalaryByMinutes;
                    }
                }

                _dtOvertime.Rows[0]["SalaryByHour"] = vSalaryByHour;

                decimal vSalaryByMinute = decimal.Parse(_dtOvertime.Rows[0]["SalaryByHour"].ToString()) / 60;
                decimal vTotalHours = decimal.Parse(_dtOvertime.Rows[0]["WorkingDate_TotalHours"].ToString());
                decimal vTotalMinutes = decimal.Parse(_dtOvertime.Rows[0]["WorkingDate_TotalMinutes"].ToString());

                _dtOvertime.Rows[0]["Total"] = ((vTotalHours * 60) + vTotalMinutes) * vSalaryByMinute;
                _dtOvertime.Rows[0]["StatusID"] = (int)Utilities.CategoriesEnum.Overtime_Status.Chưa_duyệt;
                _dtOvertime.Rows[0]["EmployeeID"] = Overtime_EmployeeID.EditValue.ToString();

                #endregion

                string result = "";
                if (int.Parse(_OvertimeID) == 0)
                {
                    _dtOvertime.Rows[0]["CreatedBy"] = Utilities.Parameters.UserLogin.UserID;
                    _dtOvertime.Rows[0]["CreatedDate"] = DateTime.Now;
                    _dtOvertime.AcceptChanges();

                    result = bGeneral.Insert(callFrom, ref _dtOvertime, true);
                }
                else
                {
                    _dtOvertime.Rows[0]["UpdatedBy"] = Utilities.Parameters.UserLogin.UserID;
                    _dtOvertime.Rows[0]["UpdatedDate"] = DateTime.Now;
                    _dtOvertime.AcceptChanges();

                    result = bGeneral.UpdateByID(callFrom, _dtOvertime);
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(_OvertimeID) == 0)
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
                    _OvertimeID = _dtOvertime.Rows[0]["ID"].ToString();
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

        private void Overtime_EmployeeID_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}