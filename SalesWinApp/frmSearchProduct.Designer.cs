namespace SalesWinApp
{
    partial class frmSearchProduct
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbTypeSearch = new System.Windows.Forms.Label();
            this.cmbTypeSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch1 = new System.Windows.Forms.TextBox();
            this.txtsearch2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Location = new System.Drawing.Point(159, 251);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 68);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbTypeSearch
            // 
            this.lbTypeSearch.AutoSize = true;
            this.lbTypeSearch.Location = new System.Drawing.Point(47, 47);
            this.lbTypeSearch.Name = "lbTypeSearch";
            this.lbTypeSearch.Size = new System.Drawing.Size(88, 20);
            this.lbTypeSearch.TabIndex = 1;
            this.lbTypeSearch.Text = "Type Seacrh";
            // 
            // cmbTypeSearch
            // 
            this.cmbTypeSearch.FormattingEnabled = true;
            this.cmbTypeSearch.Items.AddRange(new object[] {
            "Product ID",
            "Product Name",
            "Unit Price",
            "Units in Stock"});
            this.cmbTypeSearch.Location = new System.Drawing.Point(159, 47);
            this.cmbTypeSearch.Name = "cmbTypeSearch";
            this.cmbTypeSearch.Size = new System.Drawing.Size(141, 28);
            this.cmbTypeSearch.TabIndex = 2;
            this.cmbTypeSearch.SelectedIndexChanged += new System.EventHandler(this.cmbTypeSearch_SelectedIndexChanged);
            // 
            // txtSearch1
            // 
            this.txtSearch1.Location = new System.Drawing.Point(54, 123);
            this.txtSearch1.Name = "txtSearch1";
            this.txtSearch1.Size = new System.Drawing.Size(138, 27);
            this.txtSearch1.TabIndex = 3;
            // 
            // txtsearch2
            // 
            this.txtsearch2.Location = new System.Drawing.Point(242, 123);
            this.txtsearch2.Name = "txtsearch2";
            this.txtsearch2.Size = new System.Drawing.Size(138, 27);
            this.txtsearch2.TabIndex = 4;
            // 
            // frmSearchProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 360);
            this.Controls.Add(this.txtsearch2);
            this.Controls.Add(this.txtSearch1);
            this.Controls.Add(this.cmbTypeSearch);
            this.Controls.Add(this.lbTypeSearch);
            this.Controls.Add(this.btnSearch);
            this.Name = "frmSearchProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Product";
            this.Load += new System.EventHandler(this.frmSearchProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSearch;
        private Label lbTypeSearch;
        private ComboBox cmbTypeSearch;
        private TextBox txtSearch1;
        private TextBox txtsearch2;
    }
}