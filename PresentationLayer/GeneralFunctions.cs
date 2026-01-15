using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace PresentationLayer
{
    public class GeneralFunctions
    {
        public static string GetSizeOfMenu(string MenuID)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;

            BusinessLogicLayer.busMenu bMenu = new BusinessLogicLayer.busMenu();
            DataTable vdtMenu_Size = new DataTable();
            string vResult = bMenu.GetListOfSizes(vCallFrom, ref vdtMenu_Size, MenuID);
            if (vResult != Utilities.Parameters.ResultMessage)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + " -> Menu_Size -> GetListOfSizes:\n" + vResult);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, vResult + "\n" + vCallFrom + " -> Menu_Size -> GetListOfSizes");
                return "";
            }

            if (vdtMenu_Size.Rows.Count == 0)
            {
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, "Món này chưa có kích cỡ.");
                return "";
            }

            if (vdtMenu_Size.Rows.Count == 1)
                return vdtMenu_Size.Rows[0]["SizeID"].ToString();
            else
            {
                List<string> vListOfSizes_ID = new List<string>();
                List<string> vListOfSizes_Name = new List<string>();
                List<string> vListOfSizes_Price = new List<string>();
                foreach (DataRow dr in vdtMenu_Size.Rows)
                {
                    vListOfSizes_ID.Add(dr["SizeID"].ToString());
                    vListOfSizes_Name.Add(dr["Name"].ToString());

                    string vPrice = "";
                    BusinessLogicLayer.busPriceList bPriceList = new BusinessLogicLayer.busPriceList();
                    DataTable vdtPrice = new DataTable();
                    vResult = bPriceList.IsUsing_GetMenu(vCallFrom, ref vdtPrice, MenuID, dr["SizeID"].ToString());
                    if (vResult == Utilities.Parameters.ResultMessage)
                        if (vdtPrice != null && vdtPrice.Rows.Count == 1 && vdtPrice.Rows[0]["Price"].ToString() != "")
                            vPrice = decimal.Parse(vdtPrice.Rows[0]["Price"].ToString()).ToString("n0");

                    vListOfSizes_Price.Add(vPrice);
                }

                pageManagement_groupFunctions_TableAndDish_ChoseSize frmChoseSize = new pageManagement_groupFunctions_TableAndDish_ChoseSize();
                frmChoseSize._ListOfSizes_ID = vListOfSizes_ID;
                frmChoseSize._ListOfSizes_Name = vListOfSizes_Name;
                frmChoseSize._ListOfSizes_Price = vListOfSizes_Price;
                DialogResult dlg = frmChoseSize.ShowDialog();
                if (dlg == DialogResult.OK && frmChoseSize._SizeID != "")
                    return frmChoseSize._SizeID;
            }

            return "";
        }

        private static List<string> CheckMenuNoConfigMaterial(string CallBy, string OrderID)
        {
            List<string> vListMenuName = new List<string>(); 
            string vCallFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                BusinessLogicLayer.busOrder bOrder = new BusinessLogicLayer.busOrder();
                DataTable vdtOrderDetails = new DataTable();
                string vResult = bOrder.GetDetailsByOrderID(vCallFrom, ref vdtOrderDetails, OrderID, false);
                if (vResult != Utilities.Parameters.ResultMessage)
                {
                    Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + " -> GetDetailsByOrderID:\n" + vResult);
                    vListMenuName.Add(vResult);
                    return vListMenuName;
                }

                foreach (DataRow dr in vdtOrderDetails.Rows)
                {
                    int vMenuID = int.Parse(dr["MenuID"].ToString());
                    if (Utilities.Parameters.MenuID_NoConfigMaterial.Contains(vMenuID))
                        vListMenuName.Add(dr["MenuName"].ToString());
                }

                return vListMenuName;
            }
            catch (Exception ex)
            {
                vListMenuName.Add(ex.Message);
                return vListMenuName;
            }
        }

        public static void DisplayMessageMenuNoConfigMaterial(string CallBy, string OrderID)
        {
            List<string> vResult = CheckMenuNoConfigMaterial(CallBy, OrderID);
            if (vResult.Count == 0)
                return;

            pageManagement_groupFunctions_TableAndDish_MessageNoConfigMaterial frm = new pageManagement_groupFunctions_TableAndDish_MessageNoConfigMaterial();
            frm.lstMenuName = vResult;
            frm.ShowDialog();
        }
    }
}
