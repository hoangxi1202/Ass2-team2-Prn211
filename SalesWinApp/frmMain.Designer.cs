namespace SalesWinApp
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMember = new System.Windows.Forms.ToolStripMenuItem();
            this.mnProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnMember,
            this.mnProduct,
            this.mnOrder,
            this.mnReport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(224, 26);
            this.mnExit.Text = "Exit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnMember
            // 
            this.mnMember.Name = "mnMember";
            this.mnMember.Size = new System.Drawing.Size(79, 24);
            this.mnMember.Text = "Member";
            this.mnMember.Click += new System.EventHandler(this.mnMember_Click);
            // 
            // mnProduct
            // 
            this.mnProduct.Name = "mnProduct";
            this.mnProduct.Size = new System.Drawing.Size(74, 24);
            this.mnProduct.Text = "Product";
            this.mnProduct.Click += new System.EventHandler(this.mnProduct_Click);
            // 
            // mnOrder
            // 
            this.mnOrder.Name = "mnOrder";
            this.mnOrder.Size = new System.Drawing.Size(61, 24);
            this.mnOrder.Text = "Order";
            this.mnOrder.Click += new System.EventHandler(this.mnOrder_Click);
            // 
            // mnReport
            // 
            this.mnReport.Name = "mnReport";
            this.mnReport.Size = new System.Drawing.Size(68, 24);
            this.mnReport.Text = "Report";
            this.mnReport.Click += new System.EventHandler(this.mnReport_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mnExit;
        private ToolStripMenuItem mnMember;
        private ToolStripMenuItem mnProduct;
        private ToolStripMenuItem mnOrder;
        private ToolStripMenuItem mnReport;
    }
}