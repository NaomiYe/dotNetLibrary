using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Start.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        #region PropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string _sPropertyChanged)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_sPropertyChanged));
            }
        }

        #endregion PropertyChange
    }
}
