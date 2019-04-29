namespace LEABrowser
{
    partial class CallPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallPlayer));
            this.wmpCallPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.wmpCallPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // wmpCallPlayer
            // 
            this.wmpCallPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmpCallPlayer.Enabled = true;
            this.wmpCallPlayer.Location = new System.Drawing.Point(0, 0);
            this.wmpCallPlayer.Name = "wmpCallPlayer";
            this.wmpCallPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpCallPlayer.OcxState")));
            this.wmpCallPlayer.Size = new System.Drawing.Size(282, 45);
            this.wmpCallPlayer.TabIndex = 0;
            // 
            // CallPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 45);
            this.Controls.Add(this.wmpCallPlayer);
            this.MaximumSize = new System.Drawing.Size(300, 92);
            this.MinimumSize = new System.Drawing.Size(300, 92);
            this.Name = "CallPlayer";
            this.Text = "CallPlayer";
            ((System.ComponentModel.ISupportInitialize)(this.wmpCallPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmpCallPlayer;
    }
}