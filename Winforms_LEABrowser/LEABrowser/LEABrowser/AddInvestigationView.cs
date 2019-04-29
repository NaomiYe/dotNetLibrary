using LEABrowser.DataAccessLayer;
using System;
using System.Windows.Forms;

namespace LEABrowser
{
    public partial class AddInvestigationView : Form
    {
        public AddInvestigationView()
        {
            InitializeComponent();
        }

        private void btnCancelInvestigation_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveInvestigation_Click(object sender, EventArgs e)
        {
            if (tbInestigationToAdd.Text == "")
            {
                MessageBox.Show("Investigation name must have a value");
            }
            else if (tbInestigationToAdd.Text == "All Products")
            {
                MessageBox.Show("Investigation name is invalid");
            }
            else
            {
                SQLRequests SQLReq = new SQLRequests();
                Tuple<string, int> msgForAdd = SQLReq.AddInvestigation(tbInestigationToAdd.Text);

                MessageBox.Show(msgForAdd.Item1);

                if (msgForAdd.Item2 == 1)
                {
                    this.Close();
                }
            }
        }
    }
}
