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
    public partial class pageManagement_groupFunctions_TableAndDish_ChoseSize : DevExpress.XtraEditors.XtraForm
    {
        public List<string> _ListOfSizes_ID = new List<string>();
        public List<string> _ListOfSizes_Name = new List<string>();
        public List<string> _ListOfSizes_Price = new List<string>();
        public string _SizeID = "";

        public pageManagement_groupFunctions_TableAndDish_ChoseSize()
        {
            InitializeComponent();
        }

        private void pageManagement_groupFunctions_TableAndDish_ChoseSize_Load(object sender, EventArgs e)
        {
            string vCallFrom = Utilities.Parameters.ComputerName + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " -> " + System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                pn1_1.Visible = false;
                pn1_2.Visible = false;

                pn2_1.Visible = false;
                pn2_2.Visible = false;

                pn3_1.Visible = false;
                pn3_2.Visible = false;

                pn4_1.Visible = false;
                pn4_2.Visible = false;

                pn5_1.Visible = false;
                pn5_2.Visible = false;

                pn6_1.Visible = false;
                pn6_2.Visible = false;

                this.Height = this.Height - (pn1_1.Height + pn1_2.Height +
                                             pn2_1.Height + pn2_2.Height +
                                             pn3_1.Height + pn3_2.Height +
                                             pn4_1.Height + pn4_2.Height +
                                             pn5_1.Height + pn5_2.Height +
                                             pn6_1.Height + pn6_2.Height);
                if (_ListOfSizes_ID.Count > 0)
                {
                    pn1_1.Visible = true;
                    pn1_2.Visible = true;
                    this.Height = this.Height + pn1_1.Height + pn1_2.Height;

                    btnSize1.Tag = _ListOfSizes_ID[0];
                    btnSize1.Text = _ListOfSizes_Name[0];
                    lbSize1.Text = _ListOfSizes_Price[0];
                }
                
                if (_ListOfSizes_ID.Count > 1)
                {
                    pn2_1.Visible = true;
                    pn2_2.Visible = true;
                    this.Height = this.Height + pn2_1.Height + pn2_2.Height;

                    btnSize2.Tag = _ListOfSizes_ID[1];
                    btnSize2.Text = _ListOfSizes_Name[1];
                    lbSize2.Text = _ListOfSizes_Price[1];
                }

                if (_ListOfSizes_ID.Count > 2)
                {
                    pn3_1.Visible = true;
                    pn3_2.Visible = true;
                    this.Height = this.Height + pn3_1.Height + pn3_2.Height;

                    btnSize3.Tag = _ListOfSizes_ID[2];
                    btnSize3.Text = _ListOfSizes_Name[2];
                    lbSize3.Text = _ListOfSizes_Price[2];
                }

                if (_ListOfSizes_ID.Count > 3)
                {
                    pn4_1.Visible = true;
                    pn4_2.Visible = true;
                    this.Height = this.Height + pn4_1.Height + pn4_2.Height;

                    btnSize4.Tag = _ListOfSizes_ID[3];
                    btnSize4.Text = _ListOfSizes_Name[3];
                    lbSize4.Text = _ListOfSizes_Price[3];
                }

                if (_ListOfSizes_ID.Count > 4)
                {
                    pn5_1.Visible = true;
                    pn5_2.Visible = true;
                    this.Height = this.Height + pn5_1.Height + pn5_2.Height;

                    btnSize5.Tag = _ListOfSizes_ID[4];
                    btnSize5.Text = _ListOfSizes_Name[4];
                    lbSize5.Text = _ListOfSizes_Price[4];
                }

                if (_ListOfSizes_ID.Count > 5)
                {
                    pn6_1.Visible = true;
                    pn6_2.Visible = true;
                    this.Height = this.Height + pn6_1.Height + pn6_2.Height;

                    btnSize6.Tag = _ListOfSizes_ID[5];
                    btnSize6.Text = _ListOfSizes_Name[5];
                    lbSize6.Text = _ListOfSizes_Price[5];
                }
            }
            catch (Exception ex)
            {
                Utilities.Functions.WriteLog(Utilities.Parameters.LogErrorPath, vCallFrom + ":\n" + ex.Message);
                Utilities.Functions.MessageBoxOK("E", Utilities.Parameters.Error, ex.Message + "\n" + vCallFrom);
            }
        }

        private void ChoseValue(SimpleButton btn)
        {
            _SizeID = btn.Tag.ToString();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSize1_Click(object sender, EventArgs e)
        {
            ChoseValue(btnSize1);
        }

        private void btnSize2_Click(object sender, EventArgs e)
        {
            ChoseValue(btnSize2);
        }

        private void btnSize3_Click(object sender, EventArgs e)
        {
            ChoseValue(btnSize3);
        }

        private void btnSize4_Click(object sender, EventArgs e)
        {
            ChoseValue(btnSize4);
        }

        private void btnSize5_Click(object sender, EventArgs e)
        {
            ChoseValue(btnSize5);
        }

        private void btnSize6_Click(object sender, EventArgs e)
        {
            ChoseValue(btnSize6);
        }
    }
}