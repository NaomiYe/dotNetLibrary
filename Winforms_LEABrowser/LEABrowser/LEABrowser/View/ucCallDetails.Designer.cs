namespace LEABrowser.View
{
    partial class ucCallDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPlayCall = new System.Windows.Forms.Button();
            this.tbPathVal = new System.Windows.Forms.TextBox();
            this.pbTypeImage = new System.Windows.Forms.PictureBox();
            this.lblLengthVal = new System.Windows.Forms.Label();
            this.lblDestinationVal = new System.Windows.Forms.Label();
            this.lblSourceVal = new System.Windows.Forms.Label();
            this.lblCreationTimeVal = new System.Windows.Forms.Label();
            this.lblTypeVal = new System.Windows.Forms.Label();
            this.lblIDVal = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblCreationTime = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTypeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlayCall
            // 
            this.btnPlayCall.BackgroundImage = global::LEABrowser.Properties.Resources.play;
            this.btnPlayCall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPlayCall.Location = new System.Drawing.Point(278, 34);
            this.btnPlayCall.Name = "btnPlayCall";
            this.btnPlayCall.Size = new System.Drawing.Size(60, 60);
            this.btnPlayCall.TabIndex = 51;
            this.btnPlayCall.UseVisualStyleBackColor = true;
            this.btnPlayCall.Click += new System.EventHandler(this.btnPlayCall_Click);
            // 
            // tbPathVal
            // 
            this.tbPathVal.BackColor = System.Drawing.SystemColors.Control;
            this.tbPathVal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPathVal.Location = new System.Drawing.Point(124, 236);
            this.tbPathVal.Multiline = true;
            this.tbPathVal.Name = "tbPathVal";
            this.tbPathVal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPathVal.Size = new System.Drawing.Size(246, 44);
            this.tbPathVal.TabIndex = 49;
            // 
            // pbTypeImage
            // 
            this.pbTypeImage.Location = new System.Drawing.Point(127, 52);
            this.pbTypeImage.Name = "pbTypeImage";
            this.pbTypeImage.Size = new System.Drawing.Size(20, 20);
            this.pbTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTypeImage.TabIndex = 50;
            this.pbTypeImage.TabStop = false;
            // 
            // lblLengthVal
            // 
            this.lblLengthVal.AutoSize = true;
            this.lblLengthVal.Location = new System.Drawing.Point(124, 200);
            this.lblLengthVal.Name = "lblLengthVal";
            this.lblLengthVal.Size = new System.Drawing.Size(58, 17);
            this.lblLengthVal.TabIndex = 47;
            this.lblLengthVal.Text = "----------";
            // 
            // lblDestinationVal
            // 
            this.lblDestinationVal.AutoSize = true;
            this.lblDestinationVal.Location = new System.Drawing.Point(124, 162);
            this.lblDestinationVal.Name = "lblDestinationVal";
            this.lblDestinationVal.Size = new System.Drawing.Size(58, 17);
            this.lblDestinationVal.TabIndex = 46;
            this.lblDestinationVal.Text = "----------";
            // 
            // lblSourceVal
            // 
            this.lblSourceVal.AutoSize = true;
            this.lblSourceVal.Location = new System.Drawing.Point(124, 126);
            this.lblSourceVal.Name = "lblSourceVal";
            this.lblSourceVal.Size = new System.Drawing.Size(58, 17);
            this.lblSourceVal.TabIndex = 45;
            this.lblSourceVal.Text = "----------";
            // 
            // lblCreationTimeVal
            // 
            this.lblCreationTimeVal.AutoSize = true;
            this.lblCreationTimeVal.Location = new System.Drawing.Point(124, 89);
            this.lblCreationTimeVal.Name = "lblCreationTimeVal";
            this.lblCreationTimeVal.Size = new System.Drawing.Size(58, 17);
            this.lblCreationTimeVal.TabIndex = 44;
            this.lblCreationTimeVal.Text = "----------";
            // 
            // lblTypeVal
            // 
            this.lblTypeVal.AutoSize = true;
            this.lblTypeVal.Location = new System.Drawing.Point(150, 53);
            this.lblTypeVal.Name = "lblTypeVal";
            this.lblTypeVal.Size = new System.Drawing.Size(58, 17);
            this.lblTypeVal.TabIndex = 43;
            this.lblTypeVal.Text = "----------";
            // 
            // lblIDVal
            // 
            this.lblIDVal.AutoSize = true;
            this.lblIDVal.Location = new System.Drawing.Point(124, 20);
            this.lblIDVal.Name = "lblIDVal";
            this.lblIDVal.Size = new System.Drawing.Size(58, 17);
            this.lblIDVal.TabIndex = 42;
            this.lblIDVal.Text = "----------";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(21, 236);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(72, 17);
            this.lblPath.TabIndex = 41;
            this.lblPath.Text = "Call Path: ";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(21, 200);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(60, 17);
            this.lblLength.TabIndex = 40;
            this.lblLength.Text = "Length: ";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(21, 162);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(87, 17);
            this.lblDestination.TabIndex = 39;
            this.lblDestination.Text = "Destination: ";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(21, 126);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(61, 17);
            this.lblSource.TabIndex = 38;
            this.lblSource.Text = "Source: ";
            // 
            // lblCreationTime
            // 
            this.lblCreationTime.AutoSize = true;
            this.lblCreationTime.Location = new System.Drawing.Point(21, 89);
            this.lblCreationTime.Name = "lblCreationTime";
            this.lblCreationTime.Size = new System.Drawing.Size(104, 17);
            this.lblCreationTime.TabIndex = 37;
            this.lblCreationTime.Text = "Creation Time: ";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(21, 53);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(48, 17);
            this.lblType.TabIndex = 36;
            this.lblType.Text = "Type: ";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(21, 20);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(29, 17);
            this.lblID.TabIndex = 35;
            this.lblID.Text = "ID: ";
            // 
            // ucCallDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlayCall);
            this.Controls.Add(this.tbPathVal);
            this.Controls.Add(this.pbTypeImage);
            this.Controls.Add(this.lblLengthVal);
            this.Controls.Add(this.lblDestinationVal);
            this.Controls.Add(this.lblSourceVal);
            this.Controls.Add(this.lblCreationTimeVal);
            this.Controls.Add(this.lblTypeVal);
            this.Controls.Add(this.lblIDVal);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblCreationTime);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblID);
            this.Name = "ucCallDetails";
            this.Size = new System.Drawing.Size(396, 302);
            ((System.ComponentModel.ISupportInitialize)(this.pbTypeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayCall;
        private System.Windows.Forms.TextBox tbPathVal;
        private System.Windows.Forms.PictureBox pbTypeImage;
        private System.Windows.Forms.Label lblLengthVal;
        private System.Windows.Forms.Label lblDestinationVal;
        private System.Windows.Forms.Label lblSourceVal;
        private System.Windows.Forms.Label lblCreationTimeVal;
        private System.Windows.Forms.Label lblTypeVal;
        private System.Windows.Forms.Label lblIDVal;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblCreationTime;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblID;
    }
}
