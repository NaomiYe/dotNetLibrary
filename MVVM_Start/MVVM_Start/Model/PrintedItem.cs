using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Start.Model
{
    public class PrintedItem : BookProduct
    {
        private int _numOfCopied;
        public int NumOfCopied
        {
            get
            {
                return _numOfCopied;
            }
            set
            {
                _numOfCopied = value;
                OnPropertyChanged("NumOfCopied");
            }
        }

        private double _bookWeight;
        public double BookWeight
        {
            get
            {
                return _bookWeight;
            }
            set
            {
                _bookWeight = value;
                OnPropertyChanged("BookWeight");
            }
        }

        private string _isAvilable;
        public string IsAvilable
        {
            get
            {
                return _isAvilable;
            }
            set
            {
                _isAvilable = value;
                OnPropertyChanged("IsAvilable");
            }
        }
    }
}
