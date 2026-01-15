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
    public partial class pageManagement_groupSalaryManagement_Payroll_ChangeShift : DevExpress.XtraEditors.XtraForm
    {
        public string _EmployeeID = "";
        public string _EmployeeID_ChangeShift = "";

        public pageManagement_groupSalaryManagement_Payroll_ChangeShift()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageManagement_groupSalaryManagement_Payroll_ChangeShift_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (_EmployeeID == "")
                {

                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Không có thông tin nhân viên đổi ca.");
                    btnSave.Enabled = false;
                    return;
                }

                BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();
                DataTable dtEmployees = new DataTable();
                string result = bGeneral.GetByCondition(callFrom, ref dtEmployees, "Employees",
                                                        new string[] { "StatusID", "ID" },
                                                        new string[] { "=", "NOT IN" },
                                                        new string[] { ((int)Utilities.CategoriesEnum.Status.Đang_hoạt_động).ToString(),
                                                                       "(" + ((int)Utilities.CategoriesEnum.Employees.Administrator).ToString() + "," + _EmployeeID+ ")" },
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
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (slkChangeShift.EditValue == null || slkChangeShift.EditValue.ToString() == "")
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn nhân viên sẽ được đổi ca.");
                    return;
                }

                _EmployeeID_ChangeShift = slkChangeShift.EditValue.ToString();

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}