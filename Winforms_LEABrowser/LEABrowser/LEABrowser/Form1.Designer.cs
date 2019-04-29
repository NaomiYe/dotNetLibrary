namespace LEABrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMainView = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.seperator1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.seperator3 = new System.Windows.Forms.Label();
            this.panelControlPanel = new System.Windows.Forms.Panel();
            this.btnDelInvestigation = new System.Windows.Forms.Button();
            this.btnAddInvestigation = new System.Windows.Forms.Button();
            this.btnDelProduct = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnRefreshFromDB = new System.Windows.Forms.Button();
            this.panelProductTypeView = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.seperator2 = new System.Windows.Forms.Label();
            this.panelProductListHeader = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelInvestigationChooser = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InvestigationChooser = new System.Windows.Forms.ComboBox();
            this.panelProductList = new System.Windows.Forms.Panel();
            this.ProductList = new System.Windows.Forms.DataGridView();
            this.panelMainView.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelControlPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelProductListHeader.SuspendLayout();
            this.panelInvestigationChooser.SuspendLayout();
            this.panelProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMainView
            // 
            this.panelMainView.Controls.Add(this.tableLayoutPanel1);
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 0);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(1003, 457);
            this.panelMainView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.seperator1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 457);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // seperator1
            // 
            this.seperator1.AutoSize = true;
            this.seperator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seperator1.Location = new System.Drawing.Point(600, 5);
            this.seperator1.Margin = new System.Windows.Forms.Padding(2, 5, 2, 5);
            this.seperator1.MaximumSize = new System.Drawing.Size(2, 0);
            this.seperator1.MinimumSize = new System.Drawing.Size(2, 0);
            this.seperator1.Name = "seperator1";
            this.seperator1.Size = new System.Drawing.Size(2, 447);
            this.seperator1.TabIndex = 0;
            this.seperator1.Text = "........";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.seperator3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panelControlPanel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panelProductTypeView, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(607, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(393, 451);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // seperator3
            // 
            this.seperator3.AutoSize = true;
            this.seperator3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperator3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seperator3.Location = new System.Drawing.Point(5, 335);
            this.seperator3.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.seperator3.MaximumSize = new System.Drawing.Size(0, 2);
            this.seperator3.MinimumSize = new System.Drawing.Size(0, 2);
            this.seperator3.Name = "seperator3";
            this.seperator3.Size = new System.Drawing.Size(383, 2);
            this.seperator3.TabIndex = 0;
            this.seperator3.Text = "........";
            // 
            // panelControlPanel
            // 
            this.panelControlPanel.Controls.Add(this.btnDelInvestigation);
            this.panelControlPanel.Controls.Add(this.btnAddInvestigation);
            this.panelControlPanel.Controls.Add(this.btnDelProduct);
            this.panelControlPanel.Controls.Add(this.btnAddProduct);
            this.panelControlPanel.Controls.Add(this.btnRefreshFromDB);
            this.panelControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlPanel.Location = new System.Drawing.Point(3, 342);
            this.panelControlPanel.Name = "panelControlPanel";
            this.panelControlPanel.Size = new System.Drawing.Size(387, 106);
            this.panelControlPanel.TabIndex = 1;
            // 
            // btnDelInvestigation
            // 
            this.btnDelInvestigation.Location = new System.Drawing.Point(140, 56);
            this.btnDelInvestigation.Name = "btnDelInvestigation";
            this.btnDelInvestigation.Size = new System.Drawing.Size(161, 23);
            this.btnDelInvestigation.TabIndex = 43;
            this.btnDelInvestigation.Text = "Delete Investigation";
            this.btnDelInvestigation.UseVisualStyleBackColor = true;
            this.btnDelInvestigation.Click += new System.EventHandler(this.btnDelInvestigation_Click);
            // 
            // btnAddInvestigation
            // 
            this.btnAddInvestigation.Location = new System.Drawing.Point(140, 27);
            this.btnAddInvestigation.Name = "btnAddInvestigation";
            this.btnAddInvestigation.Size = new System.Drawing.Size(161, 23);
            this.btnAddInvestigation.TabIndex = 42;
            this.btnAddInvestigation.Text = "Add Investigation";
            this.btnAddInvestigation.UseVisualStyleBackColor = true;
            this.btnAddInvestigation.Click += new System.EventHandler(this.btnAddInvestigation_Click);
            // 
            // btnDelProduct
            // 
            this.btnDelProduct.Location = new System.Drawing.Point(8, 56);
            this.btnDelProduct.Name = "btnDelProduct";
            this.btnDelProduct.Size = new System.Drawing.Size(125, 23);
            this.btnDelProduct.TabIndex = 41;
            this.btnDelProduct.Text = "Delete Product";
            this.btnDelProduct.UseVisualStyleBackColor = true;
            this.btnDelProduct.Click += new System.EventHandler(this.btnDelProduct_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(8, 27);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(125, 23);
            this.btnAddProduct.TabIndex = 40;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRefreshFromDB
            // 
            this.btnRefreshFromDB.Location = new System.Drawing.Point(309, 12);
            this.btnRefreshFromDB.Name = "btnRefreshFromDB";
            this.btnRefreshFromDB.Size = new System.Drawing.Size(69, 81);
            this.btnRefreshFromDB.TabIndex = 39;
            this.btnRefreshFromDB.Text = "Refresh Data From DB";
            this.btnRefreshFromDB.UseVisualStyleBackColor = true;
            this.btnRefreshFromDB.Click += new System.EventHandler(this.btnRefreshFromDB_Click);
            // 
            // panelProductTypeView
            // 
            this.panelProductTypeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductTypeView.Location = new System.Drawing.Point(3, 3);
            this.panelProductTypeView.Name = "panelProductTypeView";
            this.panelProductTypeView.Size = new System.Drawing.Size(387, 327);
            this.panelProductTypeView.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.seperator2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panelProductListHeader, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelInvestigationChooser, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelProductList, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(592, 451);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // seperator2
            // 
            this.seperator2.AutoSize = true;
            this.seperator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperator2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seperator2.Location = new System.Drawing.Point(5, 100);
            this.seperator2.Margin = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.seperator2.MaximumSize = new System.Drawing.Size(0, 2);
            this.seperator2.MinimumSize = new System.Drawing.Size(0, 2);
            this.seperator2.Name = "seperator2";
            this.seperator2.Size = new System.Drawing.Size(582, 2);
            this.seperator2.TabIndex = 0;
            this.seperator2.Text = ".........";
            // 
            // panelProductListHeader
            // 
            this.panelProductListHeader.Controls.Add(this.label3);
            this.panelProductListHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductListHeader.Location = new System.Drawing.Point(3, 107);
            this.panelProductListHeader.Name = "panelProductListHeader";
            this.panelProductListHeader.Size = new System.Drawing.Size(586, 44);
            this.panelProductListHeader.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Choose product to display its content";
            // 
            // panelInvestigationChooser
            // 
            this.panelInvestigationChooser.Controls.Add(this.label2);
            this.panelInvestigationChooser.Controls.Add(this.label1);
            this.panelInvestigationChooser.Controls.Add(this.InvestigationChooser);
            this.panelInvestigationChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvestigationChooser.Location = new System.Drawing.Point(3, 3);
            this.panelInvestigationChooser.Name = "panelInvestigationChooser";
            this.panelInvestigationChooser.Size = new System.Drawing.Size(586, 92);
            this.panelInvestigationChooser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Investigation: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Choose investigation to display its products";
            // 
            // InvestigationChooser
            // 
            this.InvestigationChooser.FormattingEnabled = true;
            this.InvestigationChooser.Location = new System.Drawing.Point(232, 53);
            this.InvestigationChooser.Name = "InvestigationChooser";
            this.InvestigationChooser.Size = new System.Drawing.Size(175, 24);
            this.InvestigationChooser.TabIndex = 15;
            this.InvestigationChooser.SelectedIndexChanged += new System.EventHandler(this.InvestigationChooser_SelectedIndexChanged);
            // 
            // panelProductList
            // 
            this.panelProductList.Controls.Add(this.ProductList);
            this.panelProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductList.Location = new System.Drawing.Point(20, 174);
            this.panelProductList.Margin = new System.Windows.Forms.Padding(20);
            this.panelProductList.Name = "panelProductList";
            this.panelProductList.Size = new System.Drawing.Size(552, 257);
            this.panelProductList.TabIndex = 3;
            // 
            // ProductList
            // 
            this.ProductList.AllowUserToAddRows = false;
            this.ProductList.AllowUserToOrderColumns = true;
            this.ProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProductList.Location = new System.Drawing.Point(0, 0);
            this.ProductList.MultiSelect = false;
            this.ProductList.Name = "ProductList";
            this.ProductList.ReadOnly = true;
            this.ProductList.RowTemplate.Height = 24;
            this.ProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductList.Size = new System.Drawing.Size(552, 257);
            this.ProductList.TabIndex = 12;
            this.ProductList.SelectionChanged += new System.EventHandler(this.ProductList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 457);
            this.Controls.Add(this.panelMainView);
            this.MinimumSize = new System.Drawing.Size(1021, 504);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panelMainView.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelControlPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelProductListHeader.ResumeLayout(false);
            this.panelProductListHeader.PerformLayout();
            this.panelInvestigationChooser.ResumeLayout(false);
            this.panelInvestigationChooser.PerformLayout();
            this.panelProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label seperator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label seperator3;
        private System.Windows.Forms.Panel panelControlPanel;
        private System.Windows.Forms.Button btnDelInvestigation;
        private System.Windows.Forms.Button btnAddInvestigation;
        private System.Windows.Forms.Button btnDelProduct;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnRefreshFromDB;
        private System.Windows.Forms.Panel panelProductTypeView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label seperator2;
        private System.Windows.Forms.Panel panelProductListHeader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelInvestigationChooser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox InvestigationChooser;
        private System.Windows.Forms.Panel panelProductList;
        private System.Windows.Forms.DataGridView ProductList;
    }
}

