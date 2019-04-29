using MVVM_Start.Model;
using MVVM_Start.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Start.ViewModel
{
    public class AddEditBookViewModel : ViewModelBase
    {
        private BookProduct _addEditItem = new BookProduct();
        public BookProduct AddEditItem
        {
            get
            {
                return _addEditItem;
            }
            set
            {
                _addEditItem = value;
                OnPropertyChanged("AddEditItem");
            }
        }

        private BookProduct _oldItem = new BookProduct();
        public BookProduct OldItem
        {
            get
            {
                return _oldItem;
            }
            set
            {
                _oldItem = value;
                OnPropertyChanged("OldItem");
            }
        }

        private string _selectedBookType;
        public string SelectedBookType
        {
            get
            {
                return _selectedBookType;
            }
            set
            {
                _selectedBookType = value;

                if (string.IsNullOrEmpty(_selectedBookType))
                {
                    AddEditItem.BookType = BookType.None;
                    foreach (var wnd in Application.Current.Windows)
                    {
                        if (wnd is View.AddEditBook)
                        {
                            (wnd as View.AddEditBook).ExpandWindow(null);
                            break;
                        }
                    }
                }
                else
                {
                    switch (_selectedBookType)
                    {
                        case "E-Book":
                            AddEditItem.BookType = BookType.EBook;

                            ucAddEBookFields newEBookUserControlFields = new ucAddEBookFields();
                            newEBookUserControlFields.DataContext = AddEditItem;
                            foreach (var wnd in Application.Current.Windows)
                            {
                                if (wnd is View.AddEditBook)
                                {
                                    (wnd as View.AddEditBook).ExpandWindow(newEBookUserControlFields);
                                    break;
                                }
                            }
                            break;

                        case "Printed":
                            AddEditItem.BookType = BookType.Printed;

                            ucAddPrintedBookFields newPrintedBookUserControlFields = new ucAddPrintedBookFields();
                            newPrintedBookUserControlFields.DataContext = AddEditItem;
                            foreach (var wnd in Application.Current.Windows)
                            {
                                if (wnd is View.AddEditBook)
                                {
                                    (wnd as View.AddEditBook).ExpandWindow(newPrintedBookUserControlFields);
                                    break;
                                }
                            }
                            break;
                    }
                }

                OnPropertyChanged("SelectedBookType");
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged("SelectedLanguage");
            }
        }

        private string _languageToAdd;
        public string LanguageToAdd
        {
            get
            {
                return _languageToAdd;
            }
            set
            {
                _languageToAdd = value;
                OnPropertyChanged("LanguageToAdd");
            }
        }

        private string _okButtonText = string.Empty;
        public string OKButtonText
        {
            get
            {
                return _okButtonText;
            }
            set
            {
                _okButtonText = value;
                OnPropertyChanged("OKButtonText");
            }
        }

        public bool isWindowClosedFromXButton = true;

        private ObservableCollection<string> _allBooksTypes = new ObservableCollection<string>();
        public ObservableCollection<string> AllBooksTypes
        {
            get
            {
                return _allBooksTypes;
            }
            set
            {
                _allBooksTypes = value;
                OnPropertyChanged("AllBooksTypes");
            }
        }

        private ObservableCollection<string> _allAvilablesTypes = new ObservableCollection<string>();
        public ObservableCollection<string> AllAvilablesTypes
        {
            get
            {
                return _allAvilablesTypes;
            }
            set
            {
                _allAvilablesTypes = value;
                OnPropertyChanged("AllAvilablesTypes");
            }
        }

        public AddEditBookViewModel(string _commandText, BookType _bookType)
        {
            OKButtonText = _commandText;

            switch(_bookType)
            {
                case BookType.EBook:
                    AddEditItem = new EbookItem();
                    OldItem = new EbookItem();
                    break;

                case BookType.Printed:
                    AddEditItem = new PrintedItem();
                    OldItem = new PrintedItem();
                    break;
            }

            foreach (string item in ApplicationGlobal.ApplicationGlobalInstance.BooksTypes)
            {
                AllBooksTypes.Add(item);
            }

            foreach (string item in ApplicationGlobal.ApplicationGlobalInstance.AvilableTypes)
            {
                AllAvilablesTypes.Add(item);
            }
        }

        #region Commands
        //*************************************** C O M M A N D S ****************************************************
        // Override method for returning the needed commands from buttons in the application
        protected override Dictionary<string, RelayCommand> CreateCommands()
        {
            return new Dictionary<string, RelayCommand>
            {
                {"AddEditBook", new RelayCommand(param => this.AddEditBook()) },
                {"CancelAddEditBook", new RelayCommand(param => this.CancelAddEditBook()) },
                {"AddLanguage", new RelayCommand(param => this.AddLanguage(), param => this.AddLanguageCanExecute()) },
                {"DelLanguage", new RelayCommand(param => this.DelLanguage(), param => this.DelLanguageCanExecute()) }
            };
        }

        void AddEditBook()
        {
            var IsItemCorrect = CheckIfItemToAddCorrect();

            if (IsItemCorrect.Item1)
            {
                isWindowClosedFromXButton = false;

                foreach (var wnd in System.Windows.Application.Current.Windows)
                {
                    if (wnd is View.AddEditBook)
                    {
                        (wnd as View.AddEditBook).DialogResult = true; //Close window and return true in DialogResult
                    }
                }
            }
            else
            {
                string logToErrorAddingEditingMsg = "Book can't be added.\nfix those issues and try to add again:" + Environment.NewLine + Environment.NewLine;
                foreach (string item in IsItemCorrect.Item2)
                {
                    logToErrorAddingEditingMsg = logToErrorAddingEditingMsg + "  * " + item + "." + Environment.NewLine;
                }

                MessageBox.Show(logToErrorAddingEditingMsg);
            }
        }

        public void CancelAddEditBook()
        {
            isWindowClosedFromXButton = false;
        }

        void AddLanguage()
        {
            (AddEditItem as EbookItem).LanguagesTranslations.Add(LanguageToAdd);
            LanguageToAdd = "";
        }

        bool AddLanguageCanExecute()
        {
            if (string.IsNullOrEmpty(LanguageToAdd))
                return false;
            return true;
        }

        void DelLanguage()
        {
            (AddEditItem as EbookItem).LanguagesTranslations.Remove(SelectedLanguage);
        }

        bool DelLanguageCanExecute()
        {
            if (string.IsNullOrEmpty(SelectedLanguage))
                return false;
            return true;
        }

        //*************************************** E N D     O F     C O M M A N D S ******************************************
        #endregion Commands

        private Tuple<bool, List<string>> CheckIfItemToAddCorrect()
        {
            bool isValidToAddEdit = true;
            List<string> logToErrorAddingEditing = new List<string>();

            if ((AddEditItem.BookType == BookType.None) || AddEditItem.BookType == 0)
            {
                isValidToAddEdit = false;
                logToErrorAddingEditing.Add("Book must have a type. Plaease choose one.");
            }
            if (string.IsNullOrEmpty(AddEditItem.BookName))
            {
                isValidToAddEdit = false;
                logToErrorAddingEditing.Add("Book must have a name. Plaease fill a name.");
            }
            if (string.IsNullOrEmpty(AddEditItem.BookWriter))
            {
                isValidToAddEdit = false;
                logToErrorAddingEditing.Add("Book must have a writer. Plaease fill a writer name.");
            }
            if (AddEditItem.PublishYear < 1)
            {
                isValidToAddEdit = false;
                logToErrorAddingEditing.Add("Book must have a publish year. Plaease fill the publish year.");
            }
            switch (AddEditItem.BookType)
            {
                case BookType.EBook:
                    if ((AddEditItem as EbookItem).NumOfDownloads < 0)
                    {
                        isValidToAddEdit = false;
                        logToErrorAddingEditing.Add("E-Book must have number of downloads value. Plaease fill it.");
                    }
                    if ((AddEditItem as EbookItem).LanguagesTranslations.Count < 1)
                    {
                        isValidToAddEdit = false;
                        logToErrorAddingEditing.Add("E-Book must have at least one language. Plaease fill it.");
                    }
                    break;

                case BookType.Printed:
                    if ((AddEditItem as PrintedItem).NumOfCopied < 0)
                    {
                        isValidToAddEdit = false;
                        logToErrorAddingEditing.Add("Printed book must have number copies value. Plaease fill it.");
                    }
                    if ((AddEditItem as PrintedItem).BookWeight < 0)
                    {
                        isValidToAddEdit = false;
                        logToErrorAddingEditing.Add("Printed book must have book wight value. Plaease fill it.");
                    }
                    if (string.IsNullOrEmpty((AddEditItem as PrintedItem).IsAvilable))
                    {
                        isValidToAddEdit = false;
                        logToErrorAddingEditing.Add("Printed book must have avilability value. Plaease fill it.");
                    }
                    break;
            }

            var tuple = new Tuple<bool, List<string>>(isValidToAddEdit, logToErrorAddingEditing);
            return tuple;
        }
    }
}
