namespace LEABrowser.View
{
    partial class ucLoadingView
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
            this.label5 = new System.Windows.Forms.Label();
            this.pbWaitBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(108, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(471, 39);
            this.label5.TabIndex = 11;
            this.label5.Text = "P L E A S E        W A I T     . . .";
            // 
            // pbWaitBar
            // 
            this.pbWaitBar.Location = new System.Drawing.Point(27, 30);
            this.pbWaitBar.Name = "pbWaitBar";
            this.pbWaitBar.Size = new System.Drawing.Size(631, 23);
            this.pbWaitBar.TabIndex = 10;
            // 
            // ucLoadingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbWaitBar);
            this.Name = "ucLoadingView";
            this.Size = new System.Drawing.Size(685, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar pbWaitBar;
    }
}
