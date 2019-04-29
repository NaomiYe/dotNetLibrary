using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEABrowser.View
{
    public partial class ucLoadingView : UserControl
    {
        private int _pbValue;
        public int pbValue
        {
            get
            {
                return _pbValue;
            }
            set
            {
                _pbValue = value;
                pbWaitBar.Value = _pbValue;
            }
        }

        public ucLoadingView()
        {
            InitializeComponent();
        }
    }
}
