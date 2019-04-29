using System.Windows.Forms;

namespace LEABrowser
{
    public partial class CallPlayer : Form
    {
        public CallPlayer(string PathToCallFile)
        {
            InitializeComponent();

            wmpCallPlayer.URL = PathToCallFile;
        }
    }
}
