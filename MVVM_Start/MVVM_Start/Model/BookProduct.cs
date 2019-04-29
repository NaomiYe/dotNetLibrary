using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM_Start.Model
{
    public enum BookType { Printed = 1, EBook = 2, None = 3 };
    public class BookProduct : ModelBase
    {
        private int _bookID;
        public int BookID
        {
            get
            {
                return _bookID;
            }
            set
            {
                _bookID = value;
                OnPropertyChanged("BookID");
            }
        }

        private BookType _bookType;
        public BookType BookType
        {
            get
            {
                return _bookType;
            }
            set
            {
                _bookType = value;

                switch(_bookType)
                {
                    case BookType.EBook:
                        BookTypeIcon = "pack://application:,,,/MVVM_Start;component/Images/Ebook.png";
                        break;

                    case BookType.Printed:
                        BookTypeIcon = "pack://application:,,,/MVVM_Start;component/Images/Printed.png";
                        break;
                }

                OnPropertyChanged("BookType");
            }
        }

        private string _bookName;
        public string BookName
        {
            get
            {
                return _bookName;
            }
            set
            {
                _bookName = value;
                OnPropertyChanged("BookName");
            }
        }

        private string _bookWriter;
        public string BookWriter
        {
            get
            {
                return _bookWriter;
            }
            set
            {
                _bookWriter = value;
                OnPropertyChanged("BookWriter");
            }
        }

        private int _publishYear;
        public int PublishYear
        {
            get
            {
                return _publishYear;
            }
            set
            {
                _publishYear = value;
                OnPropertyChanged("PublishYear");
            }
        }

        private string _bookTypeIcon;
        public string BookTypeIcon
        {
            get
            {
                return _bookTypeIcon;
            }
            set
            {
                _bookTypeIcon = value;
                OnPropertyChanged("BookTypeIcon");
            }
        }
    }
}
