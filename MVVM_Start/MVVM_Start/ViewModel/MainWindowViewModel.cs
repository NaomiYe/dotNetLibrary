using MVVM_Start.Model;
using MVVM_Start.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Start.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            AllBooks = new ObservableCollection<BookProduct>()
            {
                new PrintedItem() { BookID = 1, BookType = BookType.Printed, BookName = "Book 1", BookWriter = "Writer of book 1", PublishYear = 1991, NumOfCopied = 10000, BookWeight = 1.03, IsAvilable = "Yes" },
                new PrintedItem() { BookID = 2, BookType = BookType.Printed, BookName = "Book 2", BookWriter = "Writer of book 2", PublishYear = 2010, NumOfCopied = 10000, BookWeight = 1.03, IsAvilable = "No" },
                new EbookItem() { BookID = 3, BookType = BookType.EBook, BookName = "Book 3", BookWriter = "Writer of book 3", PublishYear = 2000, NumOfDownloads = 127893, LanguagesTranslations = new ObservableCollection<string>() { "Hebrew", "English" } },
                new PrintedItem() { BookID = 4, BookType = BookType.Printed, BookName = "Book 4", BookWriter = "Writer of book 4", PublishYear = 1974, NumOfCopied = 10000, BookWeight = 1.03, IsAvilable = "Yes" },
                new EbookItem() { BookID = 5, BookType = BookType.EBook, BookName = "Book 5", BookWriter = "Writer of book 5", PublishYear = 1919, NumOfDownloads = 45821, LanguagesTranslations = new ObservableCollection<string>() { "Spanish", "English", "Rusian", "Portugese", "Chinese" } },
                new EbookItem() { BookID = 6, BookType = BookType.EBook, BookName = "Book 6", BookWriter = "Writer of book 6", PublishYear = 2018, NumOfDownloads = 736123, LanguagesTranslations = new ObservableCollection<string>() { "Hebrew", "English", "Chinese", "Korean", "Japanese" } }
            };
        }

        private ObservableCollection<BookProduct> _allBooks = new ObservableCollection<BookProduct>();
        public ObservableCollection<BookProduct> AllBooks
        {
            get
            {
                return _allBooks;
            }
            set
            {
                _allBooks = value;
                OnPropertyChanged("AllBooks");
            }
        }

        private BookProduct _selectedBook = new BookProduct();
        public BookProduct SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;

                if ((SelectedBook == null) || (string.IsNullOrEmpty(SelectedBook.BookName)))
                {
                    ((MainWindow)Application.Current.MainWindow).ExpandWindow(null);
                }
                else
                {
                    switch (_selectedBook.BookType)
                    {
                        case BookType.Printed:
                            ucPrintedBookExpander newPrintedUserControl = new ucPrintedBookExpander();
                            newPrintedUserControl.DataContext = _selectedBook;
                            ((MainWindow)Application.Current.MainWindow).ExpandWindow(newPrintedUserControl);
                            break;

                        case BookType.EBook:
                            ucEBookExpander newEBookUserControl = new ucEBookExpander();
                            newEBookUserControl.DataContext = _selectedBook;
                            ((MainWindow)Application.Current.MainWindow).ExpandWindow(newEBookUserControl);
                            break;
                    }
                }

                OnPropertyChanged("SelectedBook");
            }
        }

        //*************************************** C O M M A N D S ****************************************************
        // Override method for returning the needed commands from buttons in the application
        protected override Dictionary<string, RelayCommand> CreateCommands()
        {
            return new Dictionary<string, RelayCommand>
            {
                {"AddBook", new RelayCommand(param => this.AddBook()) },
                {"EditBook", new RelayCommand(param => this.EditBook(), param => this.EditBookCanExecute()) },
                {"DeleteBook", new RelayCommand(param => this.DeleteBook(), param => this.DeleteBookCanExecute()) },
                {"MoveUp", new RelayCommand(param => this.MoveUp(), param => this.MoveUpCanExecute()) },
                {"MoveDown", new RelayCommand(param => this.MoveDown(), param => this.MoveDownCanExecute()) }
            };
        }

        void AddBook()
        {
            AddEditBookViewModel newBook = new AddEditBookViewModel("Add", BookType.None);
            AddEditBook newWin = new AddEditBook();
            newWin.DataContext = newBook;
            newWin.ShowDialog();

            if (newWin.DialogResult == true)
            {
                BookProduct bookToAdd = new BookProduct();
                bookToAdd.BookID = AllBooks.Count + 1;
                bookToAdd.BookType = newBook.AddEditItem.BookType;
                bookToAdd.BookName = newBook.AddEditItem.BookName;
                bookToAdd.BookWriter = newBook.AddEditItem.BookWriter;
                bookToAdd.PublishYear = newBook.AddEditItem.PublishYear;
                switch (newBook.AddEditItem.BookType)
                {
                    case BookType.EBook:
                        (bookToAdd as EbookItem).NumOfDownloads = (newBook.AddEditItem as EbookItem).NumOfDownloads;
                        foreach (var item in (newBook.AddEditItem as EbookItem).LanguagesTranslations)
                        {
                            (bookToAdd as EbookItem).LanguagesTranslations.Add(item);
                        }
                        break;

                    case BookType.Printed:
                        (bookToAdd as PrintedItem).NumOfCopied = (newBook.AddEditItem as PrintedItem).NumOfCopied;
                        (bookToAdd as PrintedItem).BookWeight = (newBook.AddEditItem as PrintedItem).BookWeight;
                        (bookToAdd as PrintedItem).IsAvilable = (newBook.AddEditItem as PrintedItem).IsAvilable;
                        break;
                }
                AllBooks.Add(bookToAdd);
            }
        }

        void EditBook()
        {
            AddEditBookViewModel tempBook = new AddEditBookViewModel("Edit", SelectedBook.BookType);

            // The item to work on
            tempBook.AddEditItem.BookType = SelectedBook.BookType;
            tempBook.AddEditItem.BookName = SelectedBook.BookName;
            tempBook.AddEditItem.BookWriter = SelectedBook.BookWriter;
            tempBook.AddEditItem.PublishYear = SelectedBook.PublishYear;
            switch(SelectedBook.BookType)
            {
                case BookType.EBook:
                    tempBook.SelectedBookType = "E-Book";
                    (tempBook.AddEditItem as EbookItem).NumOfDownloads = (SelectedBook as EbookItem).NumOfDownloads;
                    foreach (var item in (SelectedBook as EbookItem).LanguagesTranslations)
                    {
                        (tempBook.AddEditItem as EbookItem).LanguagesTranslations.Add(item);
                    }
                    break;

                case BookType.Printed:
                    tempBook.SelectedBookType = "Printed";
                    (tempBook.AddEditItem as PrintedItem).NumOfCopied = (SelectedBook as PrintedItem).NumOfCopied;
                    (tempBook.AddEditItem as PrintedItem).BookWeight = (SelectedBook as PrintedItem).BookWeight;
                    (tempBook.AddEditItem as PrintedItem).IsAvilable = (SelectedBook as PrintedItem).IsAvilable;
                    break;
            }

            // The item for cancel
            tempBook.OldItem.BookType = SelectedBook.BookType;
            tempBook.OldItem.BookName = SelectedBook.BookName;
            tempBook.OldItem.BookWriter = SelectedBook.BookWriter;
            tempBook.OldItem.PublishYear = SelectedBook.PublishYear;
            switch (SelectedBook.BookType)
            {
                case BookType.EBook:
                    tempBook.SelectedBookType = "E-Book";
                    (tempBook.OldItem as EbookItem).NumOfDownloads = (SelectedBook as EbookItem).NumOfDownloads;
                    foreach (var item in (SelectedBook as EbookItem).LanguagesTranslations)
                    {
                        (tempBook.OldItem as EbookItem).LanguagesTranslations.Add(item);
                    }
                    break;

                case BookType.Printed:
                    tempBook.SelectedBookType = "Printed";
                    (tempBook.OldItem as PrintedItem).NumOfCopied = (SelectedBook as PrintedItem).NumOfCopied;
                    (tempBook.OldItem as PrintedItem).BookWeight = (SelectedBook as PrintedItem).BookWeight;
                    (tempBook.OldItem as PrintedItem).IsAvilable = (SelectedBook as PrintedItem).IsAvilable;
                    break;
            }

            AddEditBook newWin = new AddEditBook();
            switch (SelectedBook.BookType)
            {
                case BookType.EBook:
                    ucAddEBookFields newEBookUserControlFields = new ucAddEBookFields();
                    newEBookUserControlFields.DataContext = tempBook;
                    foreach (var wnd in Application.Current.Windows)
                    {
                        if (wnd is View.AddEditBook)
                        {
                            (wnd as View.AddEditBook).ExpandWindow(newEBookUserControlFields);
                            break;
                        }
                    }
                    break;

                case BookType.Printed:
                    ucAddPrintedBookFields newPrintedBookUserControlFields = new ucAddPrintedBookFields();
                    newPrintedBookUserControlFields.DataContext = tempBook;
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
            newWin.DataContext = tempBook;
            newWin.ShowDialog();

            if (newWin.DialogResult == true)
            {
                SelectedBook.BookType = tempBook.AddEditItem.BookType;
                SelectedBook.BookName = tempBook.AddEditItem.BookName;
                SelectedBook.BookWriter = tempBook.AddEditItem.BookWriter;
                SelectedBook.PublishYear = tempBook.AddEditItem.PublishYear;
                switch (SelectedBook.BookType)
                {
                    case BookType.EBook:
                        (SelectedBook as EbookItem).NumOfDownloads = (tempBook.AddEditItem as EbookItem).NumOfDownloads;
                        (SelectedBook as EbookItem).LanguagesTranslations.Clear();
                        foreach (var item in (tempBook.AddEditItem as EbookItem).LanguagesTranslations)
                        {
                            (SelectedBook as EbookItem).LanguagesTranslations.Add(item);
                        }
                        break;

                    case BookType.Printed:
                        (SelectedBook as PrintedItem).NumOfCopied = (tempBook.AddEditItem as PrintedItem).NumOfCopied;
                        (SelectedBook as PrintedItem).BookWeight = (tempBook.AddEditItem as PrintedItem).BookWeight;
                        (SelectedBook as PrintedItem).IsAvilable = (tempBook.AddEditItem as PrintedItem).IsAvilable;
                        break;
                }
            }
            else
            {
                if (tempBook.isWindowClosedFromXButton)
                {
                    tempBook.CancelAddEditBook();
                }

                SelectedBook.BookType = tempBook.OldItem.BookType;
                SelectedBook.BookName = tempBook.OldItem.BookName;
                SelectedBook.BookWriter = tempBook.OldItem.BookWriter;
                SelectedBook.PublishYear = tempBook.OldItem.PublishYear;
                switch (SelectedBook.BookType)
                {
                    case BookType.EBook:
                        (SelectedBook as EbookItem).NumOfDownloads = (tempBook.OldItem as EbookItem).NumOfDownloads;
                        (SelectedBook as EbookItem).LanguagesTranslations.Clear();
                        foreach (var item in (tempBook.OldItem as EbookItem).LanguagesTranslations)
                        {
                            (SelectedBook as EbookItem).LanguagesTranslations.Add(item);
                        }
                        break;

                    case BookType.Printed:
                        (SelectedBook as PrintedItem).NumOfCopied = (tempBook.OldItem as PrintedItem).NumOfCopied;
                        (SelectedBook as PrintedItem).BookWeight = (tempBook.OldItem as PrintedItem).BookWeight;
                        (SelectedBook as PrintedItem).IsAvilable = (tempBook.OldItem as PrintedItem).IsAvilable;
                        break;
                }
            }
        }

        public bool EditBookCanExecute()
        {
            if ((SelectedBook == null) || (string.IsNullOrEmpty(SelectedBook.BookName)))
                return false;
            return true;
        }

        void DeleteBook()
        {
            AllBooks.Remove(SelectedBook);
        }

        public bool DeleteBookCanExecute()
        {
            if ((SelectedBook == null) || (string.IsNullOrEmpty(SelectedBook.BookName)))
                return false;
            return true;
        }

        void MoveUp()
        {
            int itemIndex = AllBooks.IndexOf(SelectedBook);
            AllBooks.Move(itemIndex - 1, itemIndex);
            SelectedBook.BookID--;
            AllBooks[itemIndex].BookID++;
        }

        public bool MoveUpCanExecute()
        {
            if (SelectedBook == null)
            {
                return false;
            }
            if (AllBooks.IndexOf(SelectedBook) == 0)
            {
                return false;
            }
            return true;
        }

        void MoveDown()
        {
            int itemIndex = AllBooks.IndexOf(SelectedBook);
            AllBooks.Move(itemIndex + 1, itemIndex);
            SelectedBook.BookID++;
            AllBooks[itemIndex].BookID--;
        }

        public bool MoveDownCanExecute()
        {
            if (SelectedBook == null)
            {
                return false;
            }
            if (AllBooks.IndexOf(SelectedBook) == AllBooks.Count - 1)
            {
                return false;
            }
            return true;
        }

        //*************************************** E N D     O F     C O M M A N D S ******************************************
    }
}
