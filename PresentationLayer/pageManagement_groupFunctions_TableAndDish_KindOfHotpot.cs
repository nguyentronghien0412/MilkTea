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
    public partial class pageManagement_groupFunctions_TableAndDish_KindOfHotpot : DevExpress.XtraEditors.XtraForm
    {
        public List<int> lstID = new List<int>();
        public int vTasteQTy = 0;

        public pageManagement_groupFunctions_TableAndDish_KindOfHotpot()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pageManagement_groupFunctions_TableAndDish_KindOfHotpot_Load(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (lstID.Count > 0)
                {
                    foreach (int id in lstID)
                    {
                        if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Kim_chi)
                            chkKimChi.Checked = true;
                        else if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Thập_cẩm)
                            chkThapCam.Checked = true;
                        else if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Tomyum)
                            chkTomyum.Checked = true;
                        else if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Trường_thọ)
                            chkTruongTho.Checked = true;
                        else if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Tứ_xuyên)
                            chkTuXuyen.Checked = true;
                        else if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Gà_lá_giang)
                            chkGaLaGiang.Checked = true;
                        else if (id == (int)Utilities.CategoriesEnum.KindOfHotpot.Gà_lá_é)
                            chkGaLaE.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string callFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                int count = 0;

                if (chkKimChi.Checked)
                    count = count + 1;
                if (chkThapCam.Checked)
                    count = count + 1;
                if (chkTomyum.Checked)
                    count = count + 1;
                if (chkTruongTho.Checked)
                    count = count + 1;
                if (chkTuXuyen.Checked)
                    count = count + 1;
                if (chkGaLaGiang.Checked)
                    count = count + 1;
                if (chkGaLaE.Checked)
                    count = count + 1;

                if (count == 0)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Vui lòng chọn vị của lẩu.");
                    return;
                }
                if (count > vTasteQTy)
                {
                    Utilities.Functions.MessageBoxOK("W", Utilities.Parameters.Warning, "Chỉ được chọn tối đa "+ vTasteQTy + " vị.");
                    return;
                }

                lstID.Clear();
                if (chkKimChi.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Kim_chi);
                if (chkThapCam.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Thập_cẩm);
                if (chkTomyum.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Tomyum);
                if (chkTruongTho.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Trường_thọ);
                if (chkTuXuyen.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Tứ_xuyên);
                if (chkGaLaGiang.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Gà_lá_giang);
                if (chkGaLaE.Checked)
                    lstID.Add((int)Utilities.CategoriesEnum.KindOfHotpot.Gà_lá_é);

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + callFrom);
            }
        }
    }
}