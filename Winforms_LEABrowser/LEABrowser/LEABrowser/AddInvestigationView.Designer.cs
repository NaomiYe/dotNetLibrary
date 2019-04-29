namespace LEABrowser
{
    partial class AddInvestigationView
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbInestigationToAdd = new System.Windows.Forms.TextBox();
            this.btnSaveInvestigation = new System.Windows.Forms.Button();
            this.btnCancelInvestigation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Investigation Name: ";
            // 
            // tbInestigationToAdd
            // 
            this.tbInestigationToAdd.Location = new System.Drawing.Point(170, 22);
            this.tbInestigationToAdd.Name = "tbInestigationToAdd";
            this.tbInestigationToAdd.Size = new System.Drawing.Size(239, 22);
            this.tbInestigationToAdd.TabIndex = 1;
            // 
            // btnSaveInvestigation
            // 
            this.btnSaveInvestigation.Location = new System.Drawing.Point(123, 81);
            this.btnSaveInvestigation.Name = "btnSaveInvestigation";
            this.btnSaveInvestigation.Size = new System.Drawing.Size(75, 23);
            this.btnSaveInvestigation.TabIndex = 2;
            this.btnSaveInvestigation.Text = "Save";
            this.btnSaveInvestigation.UseVisualStyleBackColor = true;
            this.btnSaveInvestigation.Click += new System.EventHandler(this.btnSaveInvestigation_Click);
            // 
            // btnCancelInvestigation
            // 
            this.btnCancelInvestigation.Location = new System.Drawing.Point(232, 81);
            this.btnCancelInvestigation.Name = "btnCancelInvestigation";
            this.btnCancelInvestigation.Size = new System.Drawing.Size(75, 23);
            this.btnCancelInvestigation.TabIndex = 3;
            this.btnCancelInvestigation.Text = "Cancel";
            this.btnCancelInvestigation.UseVisualStyleBackColor = true;
            this.btnCancelInvestigation.Click += new System.EventHandler(this.btnCancelInvestigation_Click);
            // 
            // AddInvestigationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 133);
            this.Controls.Add(this.btnCancelInvestigation);
            this.Controls.Add(this.btnSaveInvestigation);
            this.Controls.Add(this.tbInestigationToAdd);
            this.Controls.Add(this.label1);
            this.Name = "AddInvestigationView";
            this.Text = "AddInvestigationView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInestigationToAdd;
        private System.Windows.Forms.Button btnSaveInvestigation;
        private System.Windows.Forms.Button btnCancelInvestigation;
    }
}