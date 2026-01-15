using BusinessLogicLayer;
using DevExpress.XtraEditors;
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
    public partial class pageManagement_groupSalaryManagement_Timekeeping : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtUserInfo = new DataTable();
        public pageManagement_groupSalaryManagement_Timekeeping()
        {
            InitializeComponent();
        }

        private void Populate_LookUpEdit(object lk, string TableName)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                DataTable dtTemp = new DataTable();
                BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageManagement_groupSalaryManagement_Timekeeping_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Utilities.Parameters.Definition == null)
                    Utilities.Parameters.Definition = new DataObject.dtoDefinition();

                if (Utilities.Parameters.Definition.COLOR_REQUIRED == null ||
                    (Utilities.Parameters.Definition.COLOR_REQUIRED.A == 0 &&
                     Utilities.Parameters.Definition.COLOR_REQUIRED.R == 0 &&
                     Utilities.Parameters.Definition.COLOR_REQUIRED.G == 0 &&
                     Utilities.Parameters.Definition.COLOR_REQUIRED.B == 0))
                    Utilities.Parameters.Definition.COLOR_REQUIRED = System.Drawing.ColorTranslator.FromHtml("#70e9b6");

                Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);

                txtFullName.Text = Utilities.Parameters.UserLogin.EmployeesName;
                Populate_LookUpEdit(lkRecordTypeID, "AttendanceData_RecordType");

                #region ChangeShift

                busGeneralFunctions bGeneral = new busGeneralFunctions();
                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees",
                                                        new string[] { "StatusID", "ID" },
                                                        new string[] { "=", "NOT IN" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(),
                                                                       "(" + ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString() + "," + Utilities.Parameters.UserLogin.EmployeesID + ")" },
                                                        "FullName asc");
                if (result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> Employees -> GetByCondition:\n" + result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, result + "\n" + callFrom + " -> Employees -> GetByCondition");
                }
                else
                {
                    slkChangeShift.Properties.ValueMember = "ID";
                    slkChangeShift.Properties.DisplayMember = "FullName";
                    slkChangeShift.Properties.DataSource = dtEmployees;
                }

                #endregion

                #region Load record type

                DateTime vFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0);
                DateTime vTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

                DataTable vdtAttendanceData = new DataTable();
                string vResult = bGeneral.GetByCondition(callFrom, ref vdtAttendanceData, "AttendanceData",
                                                        new string[] { "EmployeeID", "AttendanceTime", "AttendanceTime", "StatusID" },
                                                        new string[] { "=", ">=", "<=", "<>" },
                                                        new string[] { Utilities.Parameters.UserLogin.EmployeesID,
                                                                       "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                                       "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                                       ((int)Utilities.CategoriesEnum.AttendanceData_Status.Đã_hủy).ToString()},
                                                        "AttendanceTime ASC");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n GetByCondition -> " + vResult);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "GetByCondition -> " + vResult + "\n" + callFrom);
                }
                else
                {
                    if (vdtAttendanceData.Rows.Count == 0)
                    {
                        lkRecordTypeID.EditValue = (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào;
                    }
                    else
                    {
                        int vType = int.Parse(vdtAttendanceData.Rows[vdtAttendanceData.Rows.Count - 1]["RecordTypeID"].ToString());
                        if (vType == (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào)
                            lkRecordTypeID.EditValue = (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_ra;
                        else
                            lkRecordTypeID.EditValue = (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào;
                    }
                }

                #endregion

                dateCreatedDate.DateTime = DateTime.Now;
                dateAttendanceTime_Day.DateTime = DateTime.Now;
                dateAttendanceTime_Time.DateTime = DateTime.Now;
                
                timer_CountTime.Enabled = true;
                timer_CountTime.Interval = 1000;
                timer_CountTime.Start();

                dateAttendanceTime_Time.Focus();
                dateAttendanceTime_Time.SelectAll();
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

            if (txtFullName.Text == "")
            {
                txtFullName.Focus();
                return "Vui lòng nhập Họ và Tên.";
            }
            
            if (lkRecordTypeID.EditValue == null || lkRecordTypeID.EditValue.ToString() == "")
            {
                lkRecordTypeID.Focus();
                return "Vui lòng chọn Loại chấm công.";
            }
            
            if (!Utilities.Multi.CheckDataInputIsEmpty(callFrom, this, "*"))
                return "Vui lòng nhập đầy đủ những trường dữ liệu bắt buộc.";

            DataTable vdtUser = new DataTable();
            busGeneralFunctions bGeneral = new busGeneralFunctions();
            string vResult = bGeneral.GetByCondition(callFrom, ref vdtUser, "Users",
                                                    new string[] { "ID" }, new string[] { Utilities.Parameters.UserLogin.UserID }, "");
            if (vResult != Utilities.Parameters.ResultMessage)
                return vResult + "\n" + callFrom + " -> GetByCondition";

            if (vdtUser == null || vdtUser.Rows.Count == 0)
                return "Không tìm thấy thông tin của nhân viên chấm công.";

            if (chkChangeShift.Checked)
                if (slkChangeShift.EditValue == null || slkChangeShift.EditValue.ToString() == "")
                    return "Vui lòng nhập nhân viên đổi ca.";

            //string vPassword = vdtUser.Rows[0]["Password"].ToString();
            //vPassword = Utilities.Functions.DecryptByRC2(vPassword, Utilities.Parameters.KEY_PasswordUser, Utilities.Parameters.IV_PasswordUser);
            //if (vPassword != txtPassword.Text)
            //    return "Sai mật khẩu";

            return "";
        }

        private bool CheckRecordExistToInsert(string CallBy, DateTime DateToCheck, string EmployeeID, string RecordTypeID, ref bool IsConfirm)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            IsConfirm = false;

            DateTime vFrom = new DateTime(DateToCheck.Year, DateToCheck.Month, DateToCheck.Day, 0, 0, 0);
            DateTime vTo = new DateTime(DateToCheck.Year, DateToCheck.Month, DateToCheck.Day, 23, 59, 59);

            DataTable vdtAttendanceData = new DataTable();
            busGeneralFunctions bGeneral = new busGeneralFunctions();
            string vResult = bGeneral.GetByCondition(callFrom, ref vdtAttendanceData, "AttendanceData",
                                                    new string[] { "EmployeeID", "AttendanceTime", "AttendanceTime", "RecordTypeID", "StatusID" },
                                                    new string[] { "=", ">=", "<=", "=", "<>" },
                                                    new string[] { EmployeeID,
                                                                   "'" + vFrom.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                                   "'" + vTo.ToString("yyyy-MM-dd HH:mm:ss") + "'",
                                                                   RecordTypeID.ToString(),
                                                                   ((int)Utilities.CategoriesEnum.AttendanceData_Status.Đã_hủy).ToString()},
                                                    "");
            if (vResult != Utilities.Parameters.ResultMessage)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n GetByCondition -> " + vResult);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult);
                return false;
            }

            if (vdtAttendanceData == null || vdtAttendanceData.Rows.Count == 0)
                return true;
            else
            {
                string msg= "Đã có dữ liệu chấm công GIỜ VÀO ngày " + DateToCheck.ToString("dd/MM/yyyy") + ".\nBạn vẫn muốn thêm dữ liệu chấm công?";
                if (int.Parse(RecordTypeID) == (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_ra)
                    msg = "Đã có dữ liệu chấm công GIỜ RA ngày " + DateToCheck.ToString("dd/MM/yyyy") + ".\nBạn vẫn muốn thêm dữ liệu chấm công?";

                IsConfirm = true;
                if (Utilities.Functions.MessageBoxYesNo(msg) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string _CheckValid = CheckValid(callFrom);
                if (_CheckValid != "")
                {
                    Utilities.Functions.MessageBox("W", Utilities.Parameters.Warning, _CheckValid, 5000);
                    return;
                }

                bool IsConfirm = false;
                if (!CheckRecordExistToInsert(callFrom, DateTime.Now, Utilities.Parameters.UserLogin.EmployeesID, lkRecordTypeID.EditValue.ToString(), ref IsConfirm))
                    return;

                if (!IsConfirm)
                    if (Utilities.Functions.MessageBoxYesNo("Bạn muốn lưu dữ liệu chấm công?") != DialogResult.Yes)
                        return;

                DataTable vdtAttendanceData = new DataTable();
                busGeneralFunctions bGeneral = new busGeneralFunctions();
                string vResult = bGeneral.GetByCondition(callFrom, ref vdtAttendanceData, "AttendanceData",
                                                        new string[] { "ID" }, new string[] { "0" }, "");
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.MessageBox("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> GetByCondition", 5000);
                    return;
                }

                DateTime vAttendanceTime = new DateTime(dateAttendanceTime_Day.DateTime.Year,
                                                        dateAttendanceTime_Day.DateTime.Month,
                                                        dateAttendanceTime_Day.DateTime.Day,
                                                        dateAttendanceTime_Time.DateTime.Hour,
                                                        dateAttendanceTime_Time.DateTime.Minute,
                                                        0);

                DataRow vdrAttendanceData = vdtAttendanceData.NewRow();

                vdrAttendanceData["CreatedDate"] = DateTime.Now;
                vdrAttendanceData["CreatedBy"] = Utilities.Parameters.UserLogin.UserID;
                vdrAttendanceData["EmployeeID"] = Utilities.Parameters.UserLogin.EmployeesID;
                vdrAttendanceData["AttendanceTime"] = vAttendanceTime;
                vdrAttendanceData["StatusID"] = (int)Utilities.CategoriesEnum.AttendanceData_Status.Chưa_tính_lương;
                vdrAttendanceData["RecordTypeID"] = lkRecordTypeID.EditValue;

                if (chkChangeShift.Checked)
                    if (slkChangeShift.EditValue != null && slkChangeShift.EditValue.ToString() != "")
                        vdrAttendanceData["EmployeeID_ChangeShift"] = slkChangeShift.EditValue;

                vdtAttendanceData.Rows.Add(vdrAttendanceData);
                vdtAttendanceData.AcceptChanges();

                vResult = bGeneral.Insert(callFrom, ref vdtAttendanceData, true);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + callFrom + " -> Insert");
                    return;
                }
                else
                {
                    Utilities.Functions.MessageBoxOK("N", Utilities.Parameters.Notification, "Chấm công thành công.");
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

        private void timer_CountTime_Tick(object sender, EventArgs e)
        {
            dateCreatedDate.DateTime = DateTime.Now;
        }

        private void chkChangeShift_CheckedChanged(object sender, EventArgs e)
        {
            slkChangeShift.EditValue = null;
            if (chkChangeShift.Checked)
                slkChangeShift.ReadOnly = false;
            else
                slkChangeShift.ReadOnly = true;
        }

        private void slkEmployee_gv_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void lkRecordTypeID_EditValueChanged(object sender, EventArgs e)
        {
            if (lkRecordTypeID.EditValue == null || lkRecordTypeID.EditValue.ToString() == "")
                return;

            if (int.Parse(lkRecordTypeID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.AttendanceData_RecordType.Giờ_vào)
            {
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                chkChangeShift.Checked = false;
                slkChangeShift.EditValue = null;
            }
        }
    }
}