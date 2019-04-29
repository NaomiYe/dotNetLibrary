using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Start.Model
{
    public class EbookItem : BookProduct
    {
        private int _numOfDownloades;
        public int NumOfDownloads
        {
            get
            {
                return _numOfDownloades;
            }
            set
            {
                _numOfDownloades = value;
                OnPropertyChanged("NumOfDownloads");
            }
        }

        private ObservableCollection<string> _languagesTranslations = new ObservableCollection<string>();
        public ObservableCollection<string> LanguagesTranslations
        {
            get
            {
                return _languagesTranslations;
            }
            set
            {
                _languagesTranslations = value;
                OnPropertyChanged("LanguagesTranslations");
            }
        }
    }
}
