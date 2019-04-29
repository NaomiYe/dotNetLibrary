using LEABrowser.DataAccessLayer;
using System;
using System.Windows.Forms;

namespace LEABrowser
{
    public partial class AddProductView : Form
    {
        int InvestigationID = -1;

        public AddProductView(int investigationID)
        {
            InitializeComponent();

            lblLengthForCall.Visible = false;
            tbLengthForCall.Visible = false;
            lblPathForCall.Visible = false;
            tbPathForCall.Visible = false;
            lblTextFprSMS.Visible = false;
            tbTextForSMS.Visible = false;

            InvestigationID = investigationID;
        }

        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            long CallLengthConverter = -1;
            bool IsAllFieldsHasVal = true;
            if ((tbSource.Text == "") || (tbDestination.Text == "") || (cbProductType.SelectedItem == null) || (cbProductType.SelectedItem.ToString() == ""))
            {
                IsAllFieldsHasVal = false;
            }
            if (cbProductType.SelectedItem == null)
            {
                IsAllFieldsHasVal = false;
            }
            else
            {
                if (cbProductType.SelectedItem.ToString() == "SMS")
                {
                    if (tbTextForSMS.Text == "")
                    {
                        IsAllFieldsHasVal = false;
                    }
                }
                if (cbProductType.SelectedItem.ToString() == "Call")
                {
                    if ((tbLengthForCall.Text == "") || (tbPathForCall.Text == ""))
                    {
                        IsAllFieldsHasVal = false;
                    }
                    else
                    {
                        try
                        {
                            String[] arr = tbLengthForCall.Text.Split(':');
                            if (arr.Length != 2)
                            {
                                IsAllFieldsHasVal = false;
                            }
                            else
                            {
                                CallLengthConverter = ((long.Parse(arr[0].Trim()) * 60) + long.Parse(arr[1].Trim())) * 1000;
                            }
                        }
                        catch
                        {
                            IsAllFieldsHasVal = false;
                        }
                    }
                }
            }

            if (!IsAllFieldsHasVal)
            {
                MessageBox.Show("Not all fields has values\nor not all values are valid");
            }
            else
            {
                SQLRequests SQLReq = new SQLRequests();
                if(SQLReq.AddProduct(tbSource.Text, tbDestination.Text, cbProductType.SelectedItem.ToString(), tbTextForSMS.Text, CallLengthConverter, tbPathForCall.Text, InvestigationID))
                {
                    MessageBox.Show("Product inserted successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Product failed to insert");
                }
            }
        }

        private void ProductType_SelectionChange(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string SelectedInvestigation = cmb.SelectedItem.ToString();

            if (SelectedInvestigation == "SMS")
            {
                lblLengthForCall.Visible = false;
                tbLengthForCall.Visible = false;
                tbLengthForCall.Text = "";
                lblPathForCall.Visible = false;
                tbPathForCall.Visible = false;
                tbPathForCall.Text = "";
                lblTextFprSMS.Visible = true;
                tbTextForSMS.Visible = true;
            }
            else if (SelectedInvestigation == "Call")
            {
                lblLengthForCall.Visible = true;
                tbLengthForCall.Visible = true;
                lblPathForCall.Visible = true;
                tbPathForCall.Visible = true;
                lblTextFprSMS.Visible = false;
                tbTextForSMS.Visible = false;
                tbTextForSMS.Text = "";
            }
        }
    }
}
