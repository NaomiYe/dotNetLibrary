using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MagalFileCopier.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<string> _fromFiles = new ObservableCollection<string>();
        public ObservableCollection<string> FromFiles
        {
            get
            {
                return _fromFiles;
            }
            set
            {
                _fromFiles = value;
                OnPropertyChanged("FromFiles");
            }
        }

        private string _selectedFile;
        public string SelectedFile
        {
            get
            {
                return _selectedFile;
            }
            set
            {
                _selectedFile = value;
                OnPropertyChanged("SelectedFile");
            }
        }

        private string _toPath;
        public string ToPath
        {
            get
            {
                return _toPath;
            }
            set
            {
                _toPath = value;
                OnPropertyChanged("ToPath");
            }
        }

        private int _progressBarValue;
        public int ProgressBarValue
        {
            get
            {
                return _progressBarValue;
            }
            set
            {
                _progressBarValue = value;
                OnPropertyChanged("ProgressBarValue");
            }
        }

        private string _filesCopiedNotification;
        public string FilesCopiedNotification
        {
            get
            {
                return _filesCopiedNotification;
            }
            set
            {
                _filesCopiedNotification = value;
                OnPropertyChanged("FilesCopiedNotification");
            }
        }


        //*************************************** C O M M A N D S ****************************************************
        // Override method for returning the needed commands from buttons in the application
        protected override Dictionary<string, RelayCommand> CreateCommands()
        {
            return new Dictionary<string, RelayCommand>
            {
                {"Browse", new RelayCommand(param => this.Browse(param.ToString())) },
                {"RemoveFromList", new RelayCommand(param => this.RemoveFromList(), param => this.RemoveFromListCanExecute()) },
                {"ClearToPath", new RelayCommand(param => this.ClearToPath(), param => this.ClearToPathCanExecute()) },
                {"CopyFiles", new RelayCommand(param => this.CopyFiles(), param => this.CopyFilesCanExecute()) },
                {"CancelCommand", new RelayCommand(param => this.CancelCommand()) }
            };
        }

        void Browse(string fieldSelect)
        {
            if (fieldSelect == "1")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Multiselect = true;
                if (dlg.ShowDialog() == true)
                {
                    foreach (String file in dlg.FileNames)
                    {
                        FromFiles.Add(file);
                    }
                }
            }

            else if (fieldSelect == "2")
            {
                CommonOpenFileDialog dlg = new CommonOpenFileDialog();
                dlg.IsFolderPicker = true;
                if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    ToPath = dlg.FileName;
                }
            }
        }

        void RemoveFromList()
        {
            FromFiles.Remove(SelectedFile);
        }

        public bool RemoveFromListCanExecute()
        {
            if ((SelectedFile == "") || (SelectedFile == null))
                return false;
            return true;
        }

        void ClearToPath()
        {
            ToPath = "";
        }

        public bool ClearToPathCanExecute()
        {
            if ((ToPath == "") || (ToPath == null))
                return false;
            return true;
        }

        void CopyFiles()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;

            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int fileIndexNumber = 0;
            foreach (var file in FromFiles)
            {
                String[] arr = file.Split('\\');
                string fileName = arr[arr.Length - 1].ToString();

                File.Copy(file, ToPath + "\\" + fileName, true);

                fileIndexNumber++;
                FilesCopiedNotification = fileIndexNumber + " / " + FromFiles.Count + " files were copied";
                ProgressBarValue = (int)((double)fileIndexNumber / FromFiles.Count * 100);

                (sender as BackgroundWorker).ReportProgress(ProgressBarValue);

                //System.Threading.Thread.Sleep(1000);
            }

            MessageBox.Show("All files copied successfully.");
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarValue = e.ProgressPercentage;
        }

        public bool CopyFilesCanExecute()
        {
            if ((FromFiles.Count == 0) || ((ToPath == "") || (ToPath == null)))
                return false;
            return true;
        }

        void CancelCommand()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
