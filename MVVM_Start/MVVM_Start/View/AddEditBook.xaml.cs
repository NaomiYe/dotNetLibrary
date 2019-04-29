using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_Start.View
{
    /// <summary>
    /// Interaction logic for AddEditBook.xaml
    /// </summary>
    public partial class AddEditBook : Window
    {
        public AddEditBook()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public void ExpandWindow(UserControl NewWin)
        {
            while (gridExpansionAddEditWindows.Children.Count > 0)
            {
                gridExpansionAddEditWindows.Children.Remove(gridExpansionAddEditWindows.Children[0] as UIElement);
            }

            if (NewWin != null)
            {
                gridExpansionAddEditWindows.Children.Add(NewWin);
            }
        }
    }
}
