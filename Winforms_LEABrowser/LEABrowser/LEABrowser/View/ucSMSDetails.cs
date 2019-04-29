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
    public partial class ucSMSDetails : UserControl
    {
        public ucSMSDetails(ProductClass SelectedProduct)
        {
            InitializeComponent();

            lblIDVal.Text = SelectedProduct.ID.ToString();
            lblTypeVal.Text = "SMS";
            lblCreationTimeVal.Text = SelectedProduct.CreationDate.ToString("dd/MM/yyyy");
            lblSourceVal.Text = SelectedProduct.Source.ToString();
            lblDestinationVal.Text = SelectedProduct.Destination.ToString();
            tbSMSText.Text = (SelectedProduct as SMSClass).Text;
            pbTypeImage.Image = SelectedProduct.TypeIcon;
        }
    }
}
