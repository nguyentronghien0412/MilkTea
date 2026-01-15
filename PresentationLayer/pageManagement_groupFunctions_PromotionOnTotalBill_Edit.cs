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
    public partial class pageManagement_groupFunctions_PromotionOnTotalBill_Edit : DevExpress.XtraEditors.XtraForm
    {
        public string vPromotionID = "";
        public DataTable vdtPromotionOnTotalBill = null;

        BusinessLogicLayer.busGeneralFunctions bGeneral = new BusinessLogicLayer.busGeneralFunctions();

        public pageManagement_groupFunctions_PromotionOnTotalBill_Edit()
        {
            InitializeComponent();
        }

        private void chkPromotionOnTotalBill_ProPercent_CheckedChanged(object sender, EventArgs e)
        {
            PromotionOnTotalBill_ProPercent.Text = "";
            PromotionOnTotalBill_ProPercent.Enabled = chkPromotionOnTotalBill_ProPercent.Checked;
            if (chkPromotionOnTotalBill_ProPercent.Checked)
                chkPromotionOnTotalBill_ProAmount.Checked = false;
            else
                chkPromotionOnTotalBill_ProAmount.Checked = true;
        }

        private void chkPromotionOnTotalBill_ProAmount_CheckedChanged(object sender, EventArgs e)
        {
            PromotionOnTotalBill_ProAmount.Text = "";
            PromotionOnTotalBill_ProAmount.Enabled = chkPromotionOnTotalBill_ProAmount.Checked;
            if (chkPromotionOnTotalBill_ProAmount.Checked)
                chkPromotionOnTotalBill_ProPercent.Checked = false;
            else
                chkPromotionOnTotalBill_ProPercent.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
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

                Utilities.Multi.Populate_LookUpEdit(lk, dtTemp, "ID", "Name");
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> " + TableName + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom + " -> " + TableName);
                this.Close();
            }
        }

        private void pageManagement_groupFunctions_PromotionOnTotalBill_Edit_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            Utilities.Multi.ChangeBackColor_RequiredControl(callFrom, this, "*", Utilities.Parameters.Definition.COLOR_REQUIRED);
            try
            {
                if (vPromotionID == "")
                {
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Không tìm thấy mã Chương trình khuyến mãi.");
                    return;
                }

                Populate_LookUpEdit(PromotionOnTotalBill_StatusID, "StatusOfPromotion");
                PromotionOnTotalBill_StartDate.DateTime = DateTime.Now;
                PromotionOnTotalBill_StopDate.DateTime = DateTime.Now;

                vdtPromotionOnTotalBill = new DataTable();
                string _Result = bGeneral.GetByCondition(callFrom, ref vdtPromotionOnTotalBill, "PromotionOnTotalBill", new string[] { "ID" }, new string[] { vPromotionID }, null);
                if (_Result != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + _Result);
                    Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, _Result + "\n" + callFrom + " -> GetByCondition");
                }

                if (int.Parse(vPromotionID) == 0)
                {
                    this.Text = "Chương trình khuyến mãi - Tạo mới";

                    DataRow _drPromotion = vdtPromotionOnTotalBill.NewRow();
                    _drPromotion["StatusID"] = (int)Utilities.CategoriesEnum.StatusOfPromotion.Chưa_có_hiệu_lực;
                    vdtPromotionOnTotalBill.Rows.Add(_drPromotion);

                    PromotionOnTotalBill_StatusID.ReadOnly = true;
                }
                else
                {
                    this.Text = "Chương trình khuyến mãi - Cập nhật";
                }

                Utilities.Multi.AssignData_RowToForm(vdtPromotionOnTotalBill.Rows[0], this, callFrom);

                if (int.Parse(vPromotionID) > 0)
                {
                    if (vdtPromotionOnTotalBill.Rows[0]["ProPercent"].ToString() != "")
                    {
                        chkPromotionOnTotalBill_ProPercent.Checked = true;
                        PromotionOnTotalBill_ProPercent.Text = vdtPromotionOnTotalBill.Rows[0]["ProPercent"].ToString();
                    }
                    else
                    {
                        chkPromotionOnTotalBill_ProAmount.Checked = true;
                        PromotionOnTotalBill_ProAmount.Text = vdtPromotionOnTotalBill.Rows[0]["ProAmount"].ToString();
                    }
                }
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

                if ((PromotionOnTotalBill_ProPercent.Text == "" || int.Parse(PromotionOnTotalBill_ProPercent.Text) == 0) &&
                    (PromotionOnTotalBill_ProAmount.Text == "" || int.Parse(PromotionOnTotalBill_ProAmount.Text) == 0))
                    return "Vui lòng nhập 'Phần trăm' hoặc 'Tiền mặt' khuyến mãi.";

                DataTable dtCheck = new DataTable();
                if (int.Parse(vPromotionID) > 0)
                {
                    if (int.Parse(PromotionOnTotalBill_StatusID.EditValue.ToString()) == (int)Utilities.CategoriesEnum.StatusOfPromotion.Đang_có_hiệu_lực)
                    {
                        string result = bGeneral.GetByCondition(callFrom, ref dtCheck, "PromotionOnTotalBill",
                                                                new string[] { "StatusID", "ID" },
                                                                new string[] { "=", "<>" },
                                                                new string[] { ((int)Utilities.CategoriesEnum.StatusOfPromotion.Đang_có_hiệu_lực).ToString(), vPromotionID }, null);
                        if (result != Utilities.Parameters.ResultMessage)
                        {
                            Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + " -> GetByCondition:\n" + result);
                            return result + "\n" + callFrom + " -> GetByCondition";
                        }
                        if (dtCheck != null && dtCheck.Rows.Count > 0)
                            return "Không thể cập nhật trạng thái.\nVì '"+dtCheck.Rows[0]["Name"].ToString() + "' đang có hiệu lực.";
                    }
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

                Utilities.Multi.AssignData_FormToRow(vdtPromotionOnTotalBill.Rows[0], this, callFrom);

                string result = "";
                if (int.Parse(vPromotionID) == 0)
                {
                    vdtPromotionOnTotalBill.Rows[0]["CreatedDate"] = DateTime.Now;
                    vdtPromotionOnTotalBill.Rows[0]["CreatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);

                    result = bGeneral.Insert(callFrom, ref vdtPromotionOnTotalBill, true);
                }
                else
                {
                    vdtPromotionOnTotalBill.Rows[0]["UpdatedDate"] = DateTime.Now;
                    vdtPromotionOnTotalBill.Rows[0]["UpdatedBy"] = int.Parse(Utilities.Parameters.UserLogin.UserID);

                    result = bGeneral.UpdateByID(callFrom, vdtPromotionOnTotalBill);
                }

                if (result != Utilities.Parameters.ResultMessage)
                {
                    if (int.Parse(vPromotionID) == 0)
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
                    vPromotionID = vdtPromotionOnTotalBill.Rows[0]["ID"].ToString();
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
    }
}