namespace SalesWinApp
{
    partial class frmReport
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
            
            this.lbStartDate = new System.Windows.Forms.Label();
            this.lbEndDate = new System.Windows.Forms.Label();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbTotalSales = new System.Windows.Forms.Label();
            this.lbTotalOrders = new System.Windows.Forms.Label();
            this.lbTotalCustomers = new System.Windows.Forms.Label();
            this.lbTotalProducts = new System.Windows.Forms.Label();
            this.txtTotalSales = new System.Windows.Forms.TextBox();
            this.txtTotalOrders = new System.Windows.Forms.TextBox();
            this.txtTotalCustomers = new System.Windows.Forms.TextBox();
            this.txtTotalProducts = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 

            // 
            // lbStartDate
            // 
            this.lbStartDate.AutoSize = true;
            this.lbStartDate.Location = new System.Drawing.Point(42, 30);
            this.lbStartDate.Name = "lbStartDate";
            this.lbStartDate.Size = new System.Drawing.Size(76, 20);
            this.lbStartDate.TabIndex = 0;
            this.lbStartDate.Text = "Start Date";
            // 
            // lbEndDate
            // 
            this.lbEndDate.AutoSize = true;
            this.lbEndDate.Location = new System.Drawing.Point(338, 36);
            this.lbEndDate.Name = "lbEndDate";
            this.lbEndDate.Size = new System.Drawing.Size(70, 20);
            this.lbEndDate.TabIndex = 1;
            this.lbEndDate.Text = "End Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDate.Location = new System.Drawing.Point(136, 31);
            this.dtStartDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtStartDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(196, 27);
            this.dtStartDate.TabIndex = 1;
            this.dtStartDate.ValueChanged += new System.EventHandler(this.dtStartDate_ValueChanged);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtEndDate.Location = new System.Drawing.Point(455, 29);
            this.dtEndDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtEndDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(196, 27);
            this.dtEndDate.TabIndex = 2;
            this.dtEndDate.ValueChanged += new System.EventHandler(this.dtEndDate_ValueChanged);
            // 
            // btnCreateReport
            // 
            this.btnCreateReport.Location = new System.Drawing.Point(657, 22);
            this.btnCreateReport.Name = "btnCreateReport";
            this.btnCreateReport.Size = new System.Drawing.Size(121, 36);
            this.btnCreateReport.TabIndex = 3;
            this.btnCreateReport.Text = "Create Report";
            this.btnCreateReport.UseVisualStyleBackColor = true;
            this.btnCreateReport.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(42, 180);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 29;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(736, 211);
            this.dgvReport.TabIndex = 4;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(177, 397);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 46);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(498, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 46);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbTotalSales
            // 
            this.lbTotalSales.AutoSize = true;
            this.lbTotalSales.Location = new System.Drawing.Point(42, 84);
            this.lbTotalSales.Name = "lbTotalSales";
            this.lbTotalSales.Size = new System.Drawing.Size(80, 20);
            this.lbTotalSales.TabIndex = 7;
            this.lbTotalSales.Text = "Total Sales";
            // 
            // lbTotalOrders
            // 
            this.lbTotalOrders.AutoSize = true;
            this.lbTotalOrders.Location = new System.Drawing.Point(42, 119);
            this.lbTotalOrders.Name = "lbTotalOrders";
            this.lbTotalOrders.Size = new System.Drawing.Size(90, 20);
            this.lbTotalOrders.TabIndex = 8;
            this.lbTotalOrders.Text = "Total Orders";
            // 
            // lbTotalCustomers
            // 
            this.lbTotalCustomers.AutoSize = true;
            this.lbTotalCustomers.Location = new System.Drawing.Point(338, 84);
            this.lbTotalCustomers.Name = "lbTotalCustomers";
            this.lbTotalCustomers.Size = new System.Drawing.Size(115, 20);
            this.lbTotalCustomers.TabIndex = 9;
            this.lbTotalCustomers.Text = "Total Customers";
            // 
            // lbTotalProducts
            // 
            this.lbTotalProducts.AutoSize = true;
            this.lbTotalProducts.Location = new System.Drawing.Point(338, 119);
            this.lbTotalProducts.Name = "lbTotalProducts";
            this.lbTotalProducts.Size = new System.Drawing.Size(103, 20);
            this.lbTotalProducts.TabIndex = 10;
            this.lbTotalProducts.Text = "Total Products";
            // 
            // txtTotalSales
            // 
            this.txtTotalSales.Location = new System.Drawing.Point(136, 77);
            this.txtTotalSales.Name = "txtTotalSales";
            this.txtTotalSales.Size = new System.Drawing.Size(196, 27);
            this.txtTotalSales.TabIndex = 11;
            // 
            // txtTotalOrders
            // 
            this.txtTotalOrders.Location = new System.Drawing.Point(136, 116);
            this.txtTotalOrders.Name = "txtTotalOrders";
            this.txtTotalOrders.Size = new System.Drawing.Size(196, 27);
            this.txtTotalOrders.TabIndex = 12;
            // 
            // txtTotalCustomers
            // 
            this.txtTotalCustomers.Location = new System.Drawing.Point(455, 77);
            this.txtTotalCustomers.Name = "txtTotalCustomers";
            this.txtTotalCustomers.Size = new System.Drawing.Size(196, 27);
            this.txtTotalCustomers.TabIndex = 13;
            // 
            // txtTotalProducts
            // 
            this.txtTotalProducts.Location = new System.Drawing.Point(455, 116);
            this.txtTotalProducts.Name = "txtTotalProducts";
            this.txtTotalProducts.Size = new System.Drawing.Size(196, 27);
            this.txtTotalProducts.TabIndex = 14;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.txtTotalProducts);
            this.Controls.Add(this.txtTotalCustomers);
            this.Controls.Add(this.txtTotalOrders);
            this.Controls.Add(this.txtTotalSales);
            this.Controls.Add(this.lbTotalProducts);
            this.Controls.Add(this.lbTotalCustomers);
            this.Controls.Add(this.lbTotalOrders);
            this.Controls.Add(this.lbTotalSales);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnCreateReport);
            this.Controls.Add(this.dtEndDate);
            this.Controls.Add(this.dtStartDate);
            this.Controls.Add(this.lbEndDate);
            this.Controls.Add(this.lbStartDate);
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Sales";
            this.Load += new System.EventHandler(this.frmReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbStartDate;
        private Label lbEndDate;
        private DateTimePicker dtStartDate;
        private DateTimePicker dtEndDate;
        private Button btnCreateReport;
        private DataGridView dgvReport;
        private Button btnPrint;
        private Button btnCancel;
        private Label lbTotalSales;
        private Label lbTotalOrders;
        private Label lbTotalCustomers;
        private Label lbTotalProducts;
        private TextBox txtTotalSales;
        private TextBox txtTotalOrders;
        private TextBox txtTotalCustomers;
        private TextBox txtTotalProducts;
    }
}