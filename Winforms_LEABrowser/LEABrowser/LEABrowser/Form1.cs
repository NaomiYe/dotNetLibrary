using LEABrowser.DataAccessLayer;
using LEABrowser.Model;
using LEABrowser.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace LEABrowser
{
    public partial class Form1 : Form
    {
        public enum DisplayView { MainView = 1, LoadingView = 2 };
        public enum ItemToDelete { Investigation = 1, Product = 2 };
        public ObservableCollection<InvestigationClass> DisplayInvestigationTable { get; set; }
        public ObservableCollection<ProductClass> DisplayProductTable { get; set; }
        ucLoadingView LoadingView = new ucLoadingView();

        public Form1()
        {
            InitializeComponent();

            LoadOrRefresh();
        }

        private void LoadOrRefresh()
        {
            SetView(DisplayView.LoadingView);

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunCompleted;

            worker.RunWorkerAsync();
        }

        private void InitialDefaultDBTables()
        {
            // Display tables initialize
            DisplayInvestigationTable = new ObservableCollection<InvestigationClass>();
            DisplayProductTable = new ObservableCollection<ProductClass>();
            SQLRequests SQLReq = new SQLRequests();

            DisplayInvestigationTable = SQLReq.GetInvestigations();
            DisplayInvestigationTable.Insert(0, new InvestigationClass { ID = 0, Name = "All Products", CreationDate = new DateTime() });

            InvestigationChooser.DataSource = DisplayInvestigationTable;
            InvestigationChooser.DisplayMember = "Name";
            InvestigationChooser.ValueMember = "Name";
        }

        private void InvestigationChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            InvestigationClass SelectedInvestigation = (InvestigationClass)cmb.SelectedItem;

            SQLRequests SQLReq = new SQLRequests();
            DisplayProductTable.Clear();
            DisplayProductTable = SQLReq.GetProducts(SelectedInvestigation.ID);
            ProductList.DataSource = new BindingSource { DataSource = DisplayProductTable };
            ProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ProductList.Columns[1].Visible = false;
            ProductList.Columns[2].HeaderText = "Type";
            ProductList.Columns[3].HeaderText = "Creation Date";
            ProductList.Columns[6].Visible = false;
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control cntrl in panelProductTypeView.Controls)
            {
                panelProductTypeView.Controls.Remove(cntrl);
            }

            if (ProductList.SelectedRows.Count != 0)
            {
                DataGridViewRow dgv = ProductList.SelectedRows[0];
                ProductClass selectedProduct = DisplayProductTable.Where(f => f.ID == int.Parse(dgv.Cells["ID"].Value.ToString())).FirstOrDefault();

                switch (selectedProduct.Type)
                {
                    case ProductType.Call:
                        ucCallDetails CallDetails = new ucCallDetails(selectedProduct);
                        panelProductTypeView.Controls.Add(CallDetails);
                        break;

                    case ProductType.SMS:
                        ucSMSDetails SMSDetails = new ucSMSDetails(selectedProduct);
                        panelProductTypeView.Controls.Add(SMSDetails);
                        break;
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int ProgressBarValue = 0;
            (sender as BackgroundWorker).ReportProgress(ProgressBarValue);

            BeginInvoke((Action)delegate //Invoke at UI thread
            {
                InitialDefaultDBTables();
            });

            ProgressBarValue = ProgressBarValue + 20;
            (sender as BackgroundWorker).ReportProgress(ProgressBarValue);

            for (int i = 0; i < 4; i++)
            {
                ProgressBarValue = ProgressBarValue + 20;
                (sender as BackgroundWorker).ReportProgress(ProgressBarValue);
                Thread.Sleep(1000);
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LoadingView.pbValue = e.ProgressPercentage;
        }

        private void worker_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetView(DisplayView.MainView);
        }

        private void btnRefreshFromDB_Click(object sender, EventArgs e)
        {
            LoadOrRefresh();
        }

        private void btnAddInvestigation_Click(object sender, EventArgs e)
        {
            AddInvestigationView newWin = new AddInvestigationView();
            newWin.ShowDialog();

            LoadOrRefresh();
        }

        private void btnDelInvestigation_Click(object sender, EventArgs e)
        {
            InvestigationClass InvestigationToDelete = (InvestigationClass)InvestigationChooser.SelectedItem;
            if (InvestigationToDelete.ID == 0)
            {
                MessageBox.Show("Choose investigation to delete");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this investigation?\nThis will delete all the products related to it.", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Thread thread = new Thread(() => DelItemThread(ItemToDelete.Investigation, InvestigationToDelete.ID, -1));
                    thread.Start();
                }
            }
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgv = ProductList.SelectedRows[0];
            ProductClass selectedProduct = DisplayProductTable.Where(f => f.ID == int.Parse(dgv.Cells["ID"].Value.ToString())).FirstOrDefault();

            if (dgv == null)
            {
                MessageBox.Show("Choose product to delete");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this product?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Thread thread = new Thread(() => DelItemThread(ItemToDelete.Product, selectedProduct.ID, (int)selectedProduct.Type));
                    thread.Start();
                }
            }
        }

        private void DelItemThread(ItemToDelete _itemToDelete, int _itemID, int _productType)
        {
            Dictionary<ItemToDelete, string[]> valuesDictionaryByDeleteItemType = new Dictionary<ItemToDelete, string[]>();
            valuesDictionaryByDeleteItemType.Add(ItemToDelete.Investigation, new string[2] { "Investigation deleted successfully", "Failed to delete investigation\nor its products" });
            valuesDictionaryByDeleteItemType.Add(ItemToDelete.Product, new string[2] { "Product deleted successfully", "Failed to delete product" });

            SQLRequests SQLReq = new SQLRequests();
            bool isActionFinished = false;
            switch (_itemToDelete)
            {
                case ItemToDelete.Investigation:
                    if (SQLReq.DeleteInvestigation(_itemID))
                    {
                        isActionFinished = true;
                    }
                    break;

                case ItemToDelete.Product:
                    if (SQLReq.DeleteProduct(_itemID, _productType))
                    {
                        isActionFinished = true;
                    }
                    break;
            }

            if (isActionFinished)
            {
                MessageBox.Show(valuesDictionaryByDeleteItemType[_itemToDelete][0]);
                BeginInvoke((Action)delegate //Invoke at UI thread
                {
                    LoadOrRefresh();
                });
            }
            else
            {
                MessageBox.Show(valuesDictionaryByDeleteItemType[_itemToDelete][1]);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            InvestigationClass InvestigationToDelete = (InvestigationClass)InvestigationChooser.SelectedItem;
            if (InvestigationToDelete.ID == 0)
            {
                MessageBox.Show("Choose investigation to add product to it");
            }
            else
            {
                AddProductView newWin = new AddProductView(InvestigationToDelete.ID);
                newWin.ShowDialog();

                LoadOrRefresh();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            LoadingView.Location = new System.Drawing.Point()
            {
                X = this.Width / 2 - LoadingView.Width / 2,
                Y = this.Height / 2 - LoadingView.Height / 2
            };
        }

        private void SetView(DisplayView ViewToDisplay)
        {
            switch(ViewToDisplay)
            {
                case DisplayView.LoadingView:
                    panelMainView.Visible = false;
                    this.Controls.Add(LoadingView);
                    break;

                case DisplayView.MainView:
                    this.Controls.Remove(LoadingView);
                    panelMainView.Visible = true;
                    break;
            }
        }
    }
}
