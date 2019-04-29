namespace LEABrowser
{
    partial class AddProductView
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
            this.btnCancelProduct = new System.Windows.Forms.Button();
            this.btnSaveProduct = new System.Windows.Forms.Button();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.tbTextForSMS = new System.Windows.Forms.TextBox();
            this.lblTextFprSMS = new System.Windows.Forms.Label();
            this.tbPathForCall = new System.Windows.Forms.TextBox();
            this.lblPathForCall = new System.Windows.Forms.Label();
            this.tbLengthForCall = new System.Windows.Forms.TextBox();
            this.lblLengthForCall = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelProduct
            // 
            this.btnCancelProduct.Location = new System.Drawing.Point(205, 325);
            this.btnCancelProduct.Name = "btnCancelProduct";
            this.btnCancelProduct.Size = new System.Drawing.Size(75, 23);
            this.btnCancelProduct.TabIndex = 7;
            this.btnCancelProduct.Text = "Cancel";
            this.btnCancelProduct.UseVisualStyleBackColor = true;
            // 
            // btnSaveProduct
            // 
            this.btnSaveProduct.Location = new System.Drawing.Point(96, 325);
            this.btnSaveProduct.Name = "btnSaveProduct";
            this.btnSaveProduct.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProduct.TabIndex = 6;
            this.btnSaveProduct.Text = "Save";
            this.btnSaveProduct.UseVisualStyleBackColor = true;
            this.btnSaveProduct.Click += new System.EventHandler(this.btnSaveProduct_Click);
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(118, 28);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(239, 22);
            this.tbSource.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source: ";
            // 
            // tbDestination
            // 
            this.tbDestination.Location = new System.Drawing.Point(118, 72);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.Size = new System.Drawing.Size(239, 22);
            this.tbDestination.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destination: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Type: ";
            // 
            // cbProductType
            // 
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Items.AddRange(new object[] {
            "SMS",
            "Call"});
            this.cbProductType.Location = new System.Drawing.Point(119, 120);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(121, 24);
            this.cbProductType.TabIndex = 11;
            this.cbProductType.SelectedIndexChanged += new System.EventHandler(this.ProductType_SelectionChange);
            // 
            // tbTextForSMS
            // 
            this.tbTextForSMS.BackColor = System.Drawing.SystemColors.Window;
            this.tbTextForSMS.Location = new System.Drawing.Point(119, 173);
            this.tbTextForSMS.Multiline = true;
            this.tbTextForSMS.Name = "tbTextForSMS";
            this.tbTextForSMS.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTextForSMS.Size = new System.Drawing.Size(246, 100);
            this.tbTextForSMS.TabIndex = 23;
            // 
            // lblTextFprSMS
            // 
            this.lblTextFprSMS.AutoSize = true;
            this.lblTextFprSMS.Location = new System.Drawing.Point(29, 173);
            this.lblTextFprSMS.Name = "lblTextFprSMS";
            this.lblTextFprSMS.Size = new System.Drawing.Size(43, 17);
            this.lblTextFprSMS.TabIndex = 22;
            this.lblTextFprSMS.Text = "Text: ";
            // 
            // tbPathForCall
            // 
            this.tbPathForCall.BackColor = System.Drawing.SystemColors.Window;
            this.tbPathForCall.Location = new System.Drawing.Point(118, 173);
            this.tbPathForCall.Multiline = true;
            this.tbPathForCall.Name = "tbPathForCall";
            this.tbPathForCall.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPathForCall.Size = new System.Drawing.Size(246, 44);
            this.tbPathForCall.TabIndex = 25;
            // 
            // lblPathForCall
            // 
            this.lblPathForCall.AutoSize = true;
            this.lblPathForCall.Location = new System.Drawing.Point(28, 173);
            this.lblPathForCall.Name = "lblPathForCall";
            this.lblPathForCall.Size = new System.Drawing.Size(72, 17);
            this.lblPathForCall.TabIndex = 24;
            this.lblPathForCall.Text = "Call Path: ";
            // 
            // tbLengthForCall
            // 
            this.tbLengthForCall.Location = new System.Drawing.Point(118, 248);
            this.tbLengthForCall.Name = "tbLengthForCall";
            this.tbLengthForCall.Size = new System.Drawing.Size(239, 22);
            this.tbLengthForCall.TabIndex = 27;
            // 
            // lblLengthForCall
            // 
            this.lblLengthForCall.AutoSize = true;
            this.lblLengthForCall.Location = new System.Drawing.Point(28, 251);
            this.lblLengthForCall.Name = "lblLengthForCall";
            this.lblLengthForCall.Size = new System.Drawing.Size(87, 17);
            this.lblLengthForCall.TabIndex = 26;
            this.lblLengthForCall.Text = "Call Length: ";
            // 
            // AddProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 366);
            this.Controls.Add(this.tbLengthForCall);
            this.Controls.Add(this.lblLengthForCall);
            this.Controls.Add(this.tbPathForCall);
            this.Controls.Add(this.lblPathForCall);
            this.Controls.Add(this.tbTextForSMS);
            this.Controls.Add(this.lblTextFprSMS);
            this.Controls.Add(this.cbProductType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDestination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelProduct);
            this.Controls.Add(this.btnSaveProduct);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.label1);
            this.Name = "AddProductView";
            this.Text = "AddProductView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelProduct;
        private System.Windows.Forms.Button btnSaveProduct;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.TextBox tbTextForSMS;
        private System.Windows.Forms.Label lblTextFprSMS;
        private System.Windows.Forms.TextBox tbPathForCall;
        private System.Windows.Forms.Label lblPathForCall;
        private System.Windows.Forms.TextBox tbLengthForCall;
        private System.Windows.Forms.Label lblLengthForCall;
    }
}