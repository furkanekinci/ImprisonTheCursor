namespace ImprisonTheCursor
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timMouseTracker = new System.Windows.Forms.Timer(this.components);
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timMouseTracker
            // 
            this.timMouseTracker.Interval = 1;
            this.timMouseTracker.Tick += new System.EventHandler(this.timMouseTracker_Tick);
            // 
            // txtInfo
            // 
            this.txtInfo.Enabled = false;
            this.txtInfo.Location = new System.Drawing.Point(12, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(254, 46);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.Text = "Ctrl + Shift: Toggle Enable/Disable\r\nCtrl + Shift + F4: Exit\r\nCtrl + Alt + Shift:" +
    " Show/Hide Area";
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(9, 67);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(40, 13);
            this.lblRadius.TabIndex = 1;
            this.lblRadius.Text = "Radius";
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(58, 64);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(208, 20);
            this.txtRadius.TabIndex = 2;
            this.txtRadius.Text = "100";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 93);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.txtInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprison The Cursor";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timMouseTracker;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.TextBox txtRadius;
    }
}

