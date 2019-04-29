using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LEABrowser.Model;

namespace LEABrowser.View
{
    public partial class ucCallDetails : UserControl
    {
        ProductClass SelectedProduct;

        public ucCallDetails(ProductClass _selectedProduct)
        {
            InitializeComponent();

            SelectedProduct = _selectedProduct;

            lblIDVal.Text = SelectedProduct.ID.ToString();
            lblTypeVal.Text = "Call";
            lblCreationTimeVal.Text = SelectedProduct.CreationDate.ToString("dd/MM/yyyy");
            lblSourceVal.Text = SelectedProduct.Source.ToString();
            lblDestinationVal.Text = SelectedProduct.Destination.ToString();
            lblLengthVal.Text = ConvertMSToText((SelectedProduct as CallClass).CallLengthInMS);
            tbPathVal.Text = (SelectedProduct as CallClass).Path;
            pbTypeImage.Image = SelectedProduct.TypeIcon;
        }

        private string ConvertMSToText(long MSVal)
        {
            string minutesVal = ((MSVal / 1000) / 60).ToString();
            string secondsVal = ((MSVal / 1000) - (int.Parse(minutesVal) * 60)).ToString();
            if (int.Parse(minutesVal) < 10)
            {
                minutesVal = 0 + minutesVal;
            }
            if (int.Parse(secondsVal) < 10)
            {
                secondsVal = 0 + secondsVal;
            }

            return minutesVal + ":" + secondsVal;
        }

        private void btnPlayCall_Click(object sender, EventArgs e)
        {
            if ((SelectedProduct != null) && ((SelectedProduct as CallClass).Path != ""))
            {
                CallPlayer newWin = new CallPlayer((SelectedProduct as CallClass).Path);
                newWin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Media file was not found");
            }
        }
    }
}
