using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities
{
    public class Multi
    {
        public static string LoadDefinition(DataTable dtDefinition)
        {
            try
            {
                foreach (DataRow dr in dtDefinition.Rows)
                {
                    string vValue = dr["Value"].ToString();
                    if (dr["Code"].ToString() == Parameters.Definition_COLOR_REQUIRED)
                        Parameters.Definition.COLOR_REQUIRED = System.Drawing.ColorTranslator.FromHtml(vValue);
                    else if (dr["Code"].ToString() == Parameters.Definition_USER_DEFAULT_PASSWORD)
                        Parameters.Definition.USER_DEFAULT_PASSWORD = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_COMPANY_NAME)
                        Parameters.Definition.COMPANY_NAME = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_COMPANY_ADDRESS)
                        Parameters.Definition.COMPANY_ADDRESS = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_COMPANY_PHONE)
                        Parameters.Definition.COMPANY_PHONE = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_COMPANY_EMAIL)
                        Parameters.Definition.COMPANY_EMAIL = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_COMPANY_FACE)
                        Parameters.Definition.COMPANY_FACE = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_COMPANY_ZALO)
                        Parameters.Definition.COMPANY_ZALO = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_BILL_PREFIX)
                        Parameters.Definition.BILL_PREFIX = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_WAREHOUSE)
                        Parameters.Definition.WAREHOUSE = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_BRANCH_NAME)
                        Parameters.Definition.BRANCH_NAME = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_ENABLE)
                        Parameters.Definition.SMTP_GG_ENABLE = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_HOST)
                        Parameters.Definition.SMTP_GG_HOST = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_PORT)
                        Parameters.Definition.SMTP_GG_PORT = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_SSL)
                        Parameters.Definition.SMTP_GG_SSL = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_CREDENTIALS)
                        Parameters.Definition.SMTP_GG_CREDENTIALS = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_METHOD)
                        Parameters.Definition.SMTP_GG_METHOD = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_USERNAME)
                        Parameters.Definition.SMTP_GG_USERNAME = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SMTP_GG_PASSWORD)
                        Parameters.Definition.SMTP_GG_PASSWORD = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_AUTO_REPORT_EMAIL)
                        Parameters.Definition.AUTO_REPORT_EMAIL = vValue;
                    else if (dr["Code"].ToString() == Parameters.Definition_SUMMARY_OF_REVENUE)
                        Parameters.Definition.SUMMARY_OF_REVENUE = vValue;
                }

                return Parameters.ResultMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static void ChangeBackColor_RequiredControl(string CallBy, Control Container, string Tag, Color ColorToChange)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Container.Tag != null && Container.Tag.ToString() == Tag)
                    Container.BackColor = ColorToChange;
                if (Container.GetType() == typeof(DevExpress.XtraLayout.LayoutControl))
                {
                    DevExpress.XtraLayout.LayoutControl lc = (DevExpress.XtraLayout.LayoutControl)Container;
                    foreach (var item in lc.Items)
                    {
                        if (item.GetType() == typeof(DevExpress.XtraLayout.LayoutControlItem))
                            if (((DevExpress.XtraLayout.LayoutControlItem)item).Text.Contains("*"))
                                ((DevExpress.XtraLayout.LayoutControlItem)item).Control.BackColor = ColorToChange;
                    }
                }

                foreach (Control f in Container.Controls)
                    ChangeBackColor_RequiredControl(CallBy, f, Tag, ColorToChange);
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Functions.MessageBoxOK("E", Parameters.Error, "Lỗi : " + ex.Message + "\n" + callFrom);
            }
        }

        public static bool CheckDataInputIsEmpty(string CallBy, Control Container, string Tag)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                if (Container.Tag != null && Container.Tag.ToString() == Tag)
                {
                    if (Container.GetType() == typeof(DevExpress.XtraEditors.LabelControl) && ((LabelControl)Container).Text.Trim() == string.Empty)
                    {
                        #region LabelControl

                        ((LabelControl)Container).Focus();
                        return false;

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.TextEdit) && ((TextEdit)Container).Text.Trim() == string.Empty)
                    {
                        #region TextEdit

                        ((TextEdit)Container).Focus();
                        ((TextEdit)Container).SelectAll();
                        return false;

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                    {
                        #region LookUpEdit

                        if (((LookUpEdit)Container).EditValue == null || ((LookUpEdit)Container).EditValue.ToString() == "")
                        {
                            ((LookUpEdit)Container).Focus();
                            return false;
                        }

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                    {
                        #region GridLookUpEdit

                        if (((GridLookUpEdit)Container).EditValue == null || ((GridLookUpEdit)Container).EditValue.ToString() == "")
                        {
                            ((GridLookUpEdit)Container).Focus();
                            return false;
                        }

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.SearchLookUpEdit))
                    {
                        #region SearchLookUpEdit

                        if (((SearchLookUpEdit)Container).EditValue == null || ((SearchLookUpEdit)Container).EditValue.ToString() == "")
                        {
                            ((SearchLookUpEdit)Container).Focus();
                            return false;
                        }

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.TreeListLookUpEdit))
                    {
                        #region TreeListLookUpEdit

                        if (((TreeListLookUpEdit)Container).EditValue == null || ((TreeListLookUpEdit)Container).EditValue.ToString() == "")
                        {
                            ((TreeListLookUpEdit)Container).Focus();
                            return false;
                        }

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                    {
                        #region DateEdit

                        if (((DateEdit)Container).EditValue == null || ((DateEdit)Container).EditValue.ToString() == "" || ((DateEdit)Container).Text == "")
                        {
                            ((DateEdit)Container).Focus();
                            return false;
                        }

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.PictureEdit) && ((PictureEdit)Container).Image == null)
                    {
                        #region PictureEdit

                        ((PictureEdit)Container).Focus();
                        return false;

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.CheckEdit) && ((CheckEdit)Container).CheckState == CheckState.Indeterminate)
                    {
                        #region CheckEdit

                        ((CheckEdit)Container).Focus();
                        return false;

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.ButtonEdit) && ((ButtonEdit)Container).Text.Trim() == string.Empty)
                    {
                        #region ButtonEdit

                        ((ButtonEdit)Container).Focus();
                        ((ButtonEdit)Container).SelectAll();
                        return false;

                        #endregion
                    }
                    else if (Container.GetType() == typeof(DevExpress.XtraEditors.CheckedComboBoxEdit))
                    {
                        #region CheckedComboBoxEdit

                        if (((CheckedComboBoxEdit)Container).Properties.GetCheckedItems() == null || 
                            ((CheckedComboBoxEdit)Container).Properties.GetCheckedItems().ToString() == "")
                        {
                            ((CheckedComboBoxEdit)Container).Focus();
                            return false;
                        }

                        #endregion
                    }
                }

                foreach (Control f in Container.Controls)
                {
                    bool rs = CheckDataInputIsEmpty(CallBy, f, Tag);
                    if (!rs)
                        return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Functions.MessageBoxOK("E", Parameters.Error, "Lỗi : " + ex.Message + "\n" + callFrom);

                return false;
            }
        }

        public static bool IsFocusForm(Type type, Form frmParent, DevExpress.XtraBars.BarEditItem txtCurrentForm)
        {
            if (frmParent == null)
                return false;

            foreach (Form frm in frmParent.MdiChildren)
            {
                if (frm.Name == type.Name)
                {
                    if (frm.MinimizeBox)
                        frm.WindowState = FormWindowState.Maximized;

                    txtCurrentForm.EditValue = frm.Text;
                    frm.Focus();

                    return true;
                }
            }

            return false;
        }

        public static int GetIndexArray(string PermissionCode)
        {
            if (Parameters.UserLogin.dtPermission == null || Parameters.UserLogin.dtPermission.Rows.Count == 0)
                return -1;

            foreach (DataRow dr in Parameters.UserLogin.dtPermission.Rows)
                if (dr["Code"].ToString() == PermissionCode)
                    return int.Parse(dr["IndexForPermission"].ToString());

            return -1;
        }

        public static void Populate_LookUpEdit(object Control, DataTable dtSource, string ValueMember, string DisplayMember)
        {
            if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.LookUpEdit)))
            {
                DevExpress.XtraEditors.LookUpEdit lk = (DevExpress.XtraEditors.LookUpEdit)Control;
                lk.Properties.ValueMember = ValueMember;
                lk.Properties.DisplayMember = DisplayMember;
                lk.Properties.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.GridLookUpEdit)))
            {
                DevExpress.XtraEditors.GridLookUpEdit glk = (DevExpress.XtraEditors.GridLookUpEdit)Control;
                glk.Properties.ValueMember = ValueMember;
                glk.Properties.DisplayMember = DisplayMember;
                glk.Properties.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.SearchLookUpEdit)))
            {
                DevExpress.XtraEditors.SearchLookUpEdit slk = (DevExpress.XtraEditors.SearchLookUpEdit)Control;
                slk.Properties.ValueMember = ValueMember;
                slk.Properties.DisplayMember = DisplayMember;
                slk.Properties.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)))
            {
                DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlk = (DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)Control;
                rlk.ValueMember = ValueMember;
                rlk.DisplayMember = DisplayMember;
                rlk.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)))
            {
                DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslk = (DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)Control;
                rslk.ValueMember = ValueMember;
                rslk.DisplayMember = DisplayMember;
                rslk.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)))
            {
                DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit rglk = (DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)Control;
                rglk.ValueMember = ValueMember;
                rglk.DisplayMember = DisplayMember;
                rglk.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.TreeListLookUpEdit)))
            {
                DevExpress.XtraEditors.TreeListLookUpEdit tl = (DevExpress.XtraEditors.TreeListLookUpEdit)Control;
                tl.Properties.ValueMember = ValueMember;
                tl.Properties.DisplayMember = DisplayMember;
                tl.Properties.DataSource = dtSource;
            }
            else if (Control.GetType().IsAssignableFrom(typeof(DevExpress.XtraEditors.CheckedComboBoxEdit)))
            {
                DevExpress.XtraEditors.CheckedComboBoxEdit chk = (DevExpress.XtraEditors.CheckedComboBoxEdit)Control;
                chk.Properties.ValueMember = ValueMember;
                chk.Properties.DisplayMember = DisplayMember;
                chk.Properties.DataSource = dtSource;
            }
        }

        private static string GetColumnName(DataRow dr, string ControlName, string CallBy)
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string TableName = dr.Table.TableName + "_";
                if (ControlName.Length <= TableName.Length)
                    return "";

                string ColumnName = ControlName.Substring(0, TableName.Length);
                if (TableName == ColumnName)
                {
                    ColumnName = ControlName.Substring(TableName.Length);
                    if (dr.Table.Columns.Contains(ColumnName))
                        return ColumnName;
                }

                return "";
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                MessageBox.Show("Lỗi : " + ex.Message + "\n" + callFrom, Parameters.Notification, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private static object GetValue(DataRow dr, string ControlName)
        {
            foreach (DataColumn col in dr.Table.Columns)
                if (dr.Table.TableName + "_" + col.ColumnName == ControlName)
                    return dr[col.ColumnName];
            return null;
        }

        public static void AssignData_RowToForm(DataRow dr, Control Container, string CallBy)//Bổ sung thêm control nếu phát sinh
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                object value;
                string ColumnName;

                if (Container.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {
                    #region LabelControl

                    DevExpress.XtraEditors.LabelControl lb = (DevExpress.XtraEditors.LabelControl)Container;
                    ColumnName = GetColumnName(dr, lb.Name, callFrom);
                    if (ColumnName != "")
                    {
                        value = GetValue(dr, lb.Name);
                        if (value == null)
                            lb.Text = "";
                        else
                            lb.Text = value.ToString();
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    #region TextEdit

                    DevExpress.XtraEditors.TextEdit txt = (DevExpress.XtraEditors.TextEdit)Container;
                    ColumnName = GetColumnName(dr, txt.Name, callFrom);
                    if (ColumnName != "")
                    {
                        value = GetValue(dr, txt.Name);
                        if (value == null)
                            txt.Text = "";
                        else
                            txt.Text = value.ToString();
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    #region LookUpEdit

                    DevExpress.XtraEditors.LookUpEdit lk = (DevExpress.XtraEditors.LookUpEdit)Container;
                    ColumnName = GetColumnName(dr, lk.Name, callFrom);
                    if (ColumnName != "")
                        lk.EditValue = GetValue(dr, lk.Name);

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    #region GridLookUpEdit

                    DevExpress.XtraEditors.GridLookUpEdit glk = (DevExpress.XtraEditors.GridLookUpEdit)Container;
                    ColumnName = GetColumnName(dr, glk.Name, callFrom);
                    if (ColumnName != "")
                        glk.EditValue = GetValue(dr, glk.Name);

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.SearchLookUpEdit))
                {
                    #region SearchLookUpEdit

                    DevExpress.XtraEditors.SearchLookUpEdit slk = (DevExpress.XtraEditors.SearchLookUpEdit)Container;
                    ColumnName = GetColumnName(dr, slk.Name, callFrom);
                    if (ColumnName != "")
                        slk.EditValue = GetValue(dr, slk.Name);

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.TreeListLookUpEdit))
                {
                    #region TreeListLookUpEdit

                    DevExpress.XtraEditors.TreeListLookUpEdit tl = (DevExpress.XtraEditors.TreeListLookUpEdit)Container;
                    ColumnName = GetColumnName(dr, tl.Name, callFrom);
                    if (ColumnName != "")
                        tl.EditValue = GetValue(dr, tl.Name);

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    #region DateEdit

                    DevExpress.XtraEditors.DateEdit date = (DevExpress.XtraEditors.DateEdit)Container;
                    ColumnName = GetColumnName(dr, date.Name, callFrom);
                    if (ColumnName != "")
                        date.EditValue = GetValue(dr, date.Name);

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.PictureEdit))
                {
                    #region PictureEdit

                    DevExpress.XtraEditors.PictureEdit pic = (DevExpress.XtraEditors.PictureEdit)Container;
                    ColumnName = GetColumnName(dr, pic.Name, callFrom);
                    if (ColumnName != "")
                    {
                        object obj = GetValue(dr, pic.Name);
                        Image img = null;
                        if (obj != null && obj.ToString() != "")
                        {
                            byte[] bt = (byte[])obj;
                            img = Utilities.Functions.ByteArrayToImage(bt);
                        }

                        pic.Image = img;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    #region CheckEdit

                    DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)Container;
                    ColumnName = GetColumnName(dr, chk.Name, callFrom);
                    if (ColumnName != "")
                    {
                        object obj = GetValue(dr, chk.Name);
                        if (obj == null || obj.ToString() == "")
                            chk.Checked = false;
                        else
                        {
                            if (obj.ToString() == "0")
                                chk.Checked = false;
                            else if (obj.ToString() == "1") 
                                chk.Checked = true;
                            else
                                chk.Checked = bool.Parse(obj.ToString());
                        }
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.ButtonEdit))
                {
                    #region ButtonEdit

                    DevExpress.XtraEditors.ButtonEdit btn = (DevExpress.XtraEditors.ButtonEdit)Container;
                    ColumnName = GetColumnName(dr, btn.Name, callFrom);
                    if (ColumnName != "")
                    {
                        value = GetValue(dr, btn.Name);
                        if (value == null)
                            btn.Text = "";
                        else
                            btn.Text = value.ToString();
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(System.Windows.Forms.RichTextBox))
                {
                    #region RichTextBox

                    System.Windows.Forms.RichTextBox txt = (System.Windows.Forms.RichTextBox)Container;
                    ColumnName = GetColumnName(dr, txt.Name, callFrom);
                    if (ColumnName != "")
                    {
                        value = GetValue(dr, txt.Name);
                        if (value == null)
                            txt.Text = "";
                        else
                            txt.Text = value.ToString();
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    #region ComboBoxEdit

                    DevExpress.XtraEditors.ComboBoxEdit cmb = (DevExpress.XtraEditors.ComboBoxEdit)Container;
                    ColumnName = GetColumnName(dr, cmb.Name, callFrom);
                    if (ColumnName != "")
                        cmb.EditValue = GetValue(dr, cmb.Name);

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.MemoEdit))
                {
                    #region MemoEdit

                    DevExpress.XtraEditors.MemoEdit mm = (DevExpress.XtraEditors.MemoEdit)Container;
                    ColumnName = GetColumnName(dr, mm.Name, callFrom);
                    if (ColumnName != "")
                    {
                        value = GetValue(dr, mm.Name);
                        if (value == null)
                            mm.Text = "";
                        else
                            mm.Text = value.ToString();
                    }

                    #endregion
                }

                foreach (Control f in Container.Controls)
                    AssignData_RowToForm(dr, f, CallBy);
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Functions.MessageBoxOK("E", Parameters.Error, "Lỗi : " + ex.Message + "\n" + callFrom);
            }
        }

        public static void AssignData_FormToRow(DataRow dr, Control Container, string CallBy)//Bổ sung thêm control nếu phát sinh
        {
            string callFrom = CallBy + " -> " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                string ColumnName = "";
                if (Container.GetType() == typeof(DevExpress.XtraEditors.LabelControl))
                {
                    #region LabelControl

                    DevExpress.XtraEditors.LabelControl lb = (DevExpress.XtraEditors.LabelControl)Container;
                    ColumnName = GetColumnName(dr, lb.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (lb.Text.Trim() == string.Empty)
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = lb.Text.Trim();
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.TextEdit))
                {
                    #region TextEdit

                    DevExpress.XtraEditors.TextEdit txt = (DevExpress.XtraEditors.TextEdit)Container;
                    ColumnName = GetColumnName(dr, txt.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (txt.Text.Trim() == string.Empty)
                            dr[ColumnName] = DBNull.Value;
                        else
                        {
                            if (dr[ColumnName].GetType() == typeof(string))
                                dr[ColumnName] = txt.Text;
                            else
                            {
                                try
                                {
                                    dr[ColumnName] = txt.Text;
                                }
                                catch (Exception)
                                {
                                    dr[ColumnName] = decimal.Parse(txt.Text);
                                }
                            }

                        }
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
                {
                    #region LookUpEdit

                    DevExpress.XtraEditors.LookUpEdit lk = (DevExpress.XtraEditors.LookUpEdit)Container;
                    ColumnName = GetColumnName(dr, lk.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (lk.EditValue == null || lk.EditValue.ToString() == "")
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = lk.EditValue;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.GridLookUpEdit))
                {
                    #region GridLookUpEdit

                    DevExpress.XtraEditors.GridLookUpEdit glk = (DevExpress.XtraEditors.GridLookUpEdit)Container;
                    ColumnName = GetColumnName(dr, glk.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (glk.EditValue == null || glk.EditValue.ToString() == "")
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = glk.EditValue;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.SearchLookUpEdit))
                {
                    #region SearchLookUpEdit

                    DevExpress.XtraEditors.SearchLookUpEdit slk = (DevExpress.XtraEditors.SearchLookUpEdit)Container;
                    ColumnName = GetColumnName(dr, slk.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (slk.EditValue == null || slk.EditValue.ToString() == "")
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = slk.EditValue;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.TreeListLookUpEdit))
                {
                    #region TreeListLookUpEdit

                    DevExpress.XtraEditors.TreeListLookUpEdit tl = (DevExpress.XtraEditors.TreeListLookUpEdit)Container;
                    ColumnName = GetColumnName(dr, tl.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (tl.EditValue == null || tl.EditValue.ToString() == "")
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = tl.EditValue;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.DateEdit))
                {
                    #region DateEdit

                    DevExpress.XtraEditors.DateEdit date = (DevExpress.XtraEditors.DateEdit)Container;
                    ColumnName = GetColumnName(dr, date.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (date.DateTime.Year == 1)
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = date.EditValue;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.PictureEdit))
                {
                    #region PictureEdit

                    DevExpress.XtraEditors.PictureEdit pic = (DevExpress.XtraEditors.PictureEdit)Container;
                    ColumnName = GetColumnName(dr, pic.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (pic.Image == null)
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = Functions.ImageToByteArray(pic.Image, 100);
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.CheckEdit))
                {
                    #region CheckEdit

                    DevExpress.XtraEditors.CheckEdit chk = (DevExpress.XtraEditors.CheckEdit)Container;
                    ColumnName = GetColumnName(dr, chk.Name, callFrom);
                    if (ColumnName != "")
                        dr[ColumnName] = chk.Checked;

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.ButtonEdit))
                {
                    #region ButtonEdit

                    DevExpress.XtraEditors.ButtonEdit btn = (DevExpress.XtraEditors.ButtonEdit)Container;
                    ColumnName = GetColumnName(dr, btn.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (btn.Text.Trim() == string.Empty)
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = btn.Text;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(System.Windows.Forms.RichTextBox))
                {
                    #region RichTextBox

                    System.Windows.Forms.RichTextBox txt = (System.Windows.Forms.RichTextBox)Container;
                    ColumnName = GetColumnName(dr, txt.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (txt.Text.Trim() == string.Empty)
                            dr[ColumnName] = DBNull.Value;
                        else
                        {
                            if (dr[ColumnName].GetType() == typeof(string))
                                dr[ColumnName] = txt.Text;
                            else
                            {
                                try
                                {
                                    dr[ColumnName] = txt.Text;
                                }
                                catch (Exception)
                                {
                                    dr[ColumnName] = decimal.Parse(txt.Text);
                                }
                            }

                        }
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.ComboBoxEdit))
                {
                    #region ComboBoxEdit

                    DevExpress.XtraEditors.ComboBoxEdit cmb = (DevExpress.XtraEditors.ComboBoxEdit)Container;
                    ColumnName = GetColumnName(dr, cmb.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (cmb.EditValue == null || cmb.EditValue.ToString() == "")
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = cmb.EditValue;
                    }

                    #endregion
                }
                else if (Container.GetType() == typeof(DevExpress.XtraEditors.MemoEdit))
                {
                    #region MemoEdit

                    DevExpress.XtraEditors.MemoEdit mm = (DevExpress.XtraEditors.MemoEdit)Container;
                    ColumnName = GetColumnName(dr, mm.Name, callFrom);
                    if (ColumnName != "")
                    {
                        if (mm.Text.Trim() == string.Empty)
                            dr[ColumnName] = DBNull.Value;
                        else
                            dr[ColumnName] = mm.Text;
                    }

                    #endregion
                }

                foreach (Control f in Container.Controls)
                    AssignData_FormToRow(dr, f, CallBy);
            }
            catch (Exception ex)
            {
                Functions.WriteLog(Parameters.LogErrorPath, callFrom + ":\n" + ex.Message);
                Functions.MessageBoxOK("E", Parameters.Error, "Lỗi : " + ex.Message + "\n" + callFrom);
            }
        }

        public static bool CheckRight_PermissionDetail(string PermissionDetailCode)
        {
            foreach (DataRow dr in Parameters.UserLogin.dtPermissionDetail.Rows)
                if (dr["Code"].ToString() == PermissionDetailCode)
                    return true;
            return false;
        }

        public static bool CheckRight_PermissionByCode(string PermissionCode, string PermissionDetailCode)
        {
            if (Parameters.UserLogin.dtPermissionDetail == null || Parameters.UserLogin.dtPermissionDetail.Rows.Count == 0)
                return false;

            foreach (DataRow dr in Parameters.UserLogin.dtPermissionDetail.Rows)
                if (dr["PermissionCode"].ToString() == PermissionCode && dr["Code"].ToString() == PermissionDetailCode)
                    return true;
            return false;
        }

        public static string CreateBillNo(string Prefix)
        {
            string _No = DateTime.Now.ToString("yyyyMMddHHmmss");
            return Prefix + _No;
        }
    }
}
