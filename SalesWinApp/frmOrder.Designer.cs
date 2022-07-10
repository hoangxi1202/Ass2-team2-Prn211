namespace SalesWinApp
{
    partial class frmOrder
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
            this.lbOrderID = new System.Windows.Forms.Label();
            this.lbMemberID = new System.Windows.Forms.Label();
            this.lbFreight = new System.Windows.Forms.Label();
            this.lbOrderDate = new System.Windows.Forms.Label();
            this.lbRequiredDate = new System.Windows.Forms.Label();
            this.lbShippedDate = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.MaskedTextBox();
            this.txtMemberID = new System.Windows.Forms.MaskedTextBox();
            this.txtFreight = new System.Windows.Forms.MaskedTextBox();
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtOrderDate = new System.Windows.Forms.DateTimePicker();
            this.dtRequiredDate = new System.Windows.Forms.DateTimePicker();
            this.dtShippedDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOrderID
            // 
            this.lbOrderID.AutoSize = true;
            this.lbOrderID.Location = new System.Drawing.Point(34, 35);
            this.lbOrderID.Name = "lbOrderID";
            this.lbOrderID.Size = new System.Drawing.Size(66, 20);
            this.lbOrderID.TabIndex = 0;
            this.lbOrderID.Text = "Order ID";
            // 
            // lbMemberID
            // 
            this.lbMemberID.AutoSize = true;
            this.lbMemberID.Location = new System.Drawing.Point(34, 77);
            this.lbMemberID.Name = "lbMemberID";
            this.lbMemberID.Size = new System.Drawing.Size(84, 20);
            this.lbMemberID.TabIndex = 1;
            this.lbMemberID.Text = "Member ID";
            // 
            // lbFreight
            // 
            this.lbFreight.AutoSize = true;
            this.lbFreight.Location = new System.Drawing.Point(34, 119);
            this.lbFreight.Name = "lbFreight";
            this.lbFreight.Size = new System.Drawing.Size(55, 20);
            this.lbFreight.TabIndex = 2;
            this.lbFreight.Text = "Freight";
            // 
            // lbOrderDate
            // 
            this.lbOrderDate.AutoSize = true;
            this.lbOrderDate.Location = new System.Drawing.Point(412, 35);
            this.lbOrderDate.Name = "lbOrderDate";
            this.lbOrderDate.Size = new System.Drawing.Size(83, 20);
            this.lbOrderDate.TabIndex = 3;
            this.lbOrderDate.Text = "Order Date";
            // 
            // lbRequiredDate
            // 
            this.lbRequiredDate.AutoSize = true;
            this.lbRequiredDate.Location = new System.Drawing.Point(412, 77);
            this.lbRequiredDate.Name = "lbRequiredDate";
            this.lbRequiredDate.Size = new System.Drawing.Size(105, 20);
            this.lbRequiredDate.TabIndex = 4;
            this.lbRequiredDate.Text = "Required Date";
            // 
            // lbShippedDate
            // 
            this.lbShippedDate.AutoSize = true;
            this.lbShippedDate.Location = new System.Drawing.Point(412, 119);
            this.lbShippedDate.Name = "lbShippedDate";
            this.lbShippedDate.Size = new System.Drawing.Size(100, 20);
            this.lbShippedDate.TabIndex = 5;
            this.lbShippedDate.Text = "Shipped Date";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(153, 32);
            this.txtOrderID.Mask = "000";
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.PromptChar = ' ';
            this.txtOrderID.Size = new System.Drawing.Size(201, 27);
            this.txtOrderID.TabIndex = 6;
            this.txtOrderID.Text = "0";
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(153, 74);
            this.txtMemberID.Mask = "000";
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.PromptChar = ' ';
            this.txtMemberID.Size = new System.Drawing.Size(201, 27);
            this.txtMemberID.TabIndex = 7;
            this.txtMemberID.Text = "0";
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(153, 116);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(201, 27);
            this.txtFreight.TabIndex = 8;
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Location = new System.Drawing.Point(12, 200);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.ReadOnly = true;
            this.dgvOrderList.RowHeadersWidth = 51;
            this.dgvOrderList.RowTemplate.Height = 29;
            this.dgvOrderList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderList.Size = new System.Drawing.Size(776, 214);
            this.dgvOrderList.TabIndex = 12;
            this.dgvOrderList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_CellClick);
            this.dgvOrderList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrderList_CellDoubleClick);
            this.dgvOrderList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderList_RowEnter);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(35, 165);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(662, 165);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(346, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 29);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtOrderDate
            // 
            this.dtOrderDate.CustomFormat = " ";
            this.dtOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOrderDate.Location = new System.Drawing.Point(529, 32);
            this.dtOrderDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtOrderDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtOrderDate.Name = "dtOrderDate";
            this.dtOrderDate.Size = new System.Drawing.Size(227, 27);
            this.dtOrderDate.TabIndex = 19;
            this.dtOrderDate.ValueChanged += new System.EventHandler(this.dtOrderDate_ValueChanged);
            this.dtOrderDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtOrderDate_KeyDown);
            // 
            // dtRequiredDate
            // 
            this.dtRequiredDate.CustomFormat = " ";
            this.dtRequiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRequiredDate.Location = new System.Drawing.Point(529, 74);
            this.dtRequiredDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtRequiredDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtRequiredDate.Name = "dtRequiredDate";
            this.dtRequiredDate.Size = new System.Drawing.Size(227, 27);
            this.dtRequiredDate.TabIndex = 20;
            this.dtRequiredDate.ValueChanged += new System.EventHandler(this.dtRequiredDate_ValueChanged);
            this.dtRequiredDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtRequiredDate_KeyDown);
            // 
            // dtShippedDate
            // 
            this.dtShippedDate.CustomFormat = " ";
            this.dtShippedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShippedDate.Location = new System.Drawing.Point(529, 114);
            this.dtShippedDate.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtShippedDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtShippedDate.Name = "dtShippedDate";
            this.dtShippedDate.Size = new System.Drawing.Size(227, 27);
            this.dtShippedDate.TabIndex = 21;
            this.dtShippedDate.ValueChanged += new System.EventHandler(this.dtShippedDate_ValueChanged);
            this.dtShippedDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtShippedDate_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(466, 165);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 22;
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.Location = new System.Drawing.Point(240, 165);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(94, 29);
            this.btnViewDetail.TabIndex = 23;
            this.btnViewDetail.Text = "View Detail";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // frmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtShippedDate);
            this.Controls.Add(this.dtRequiredDate);
            this.Controls.Add(this.dtOrderDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dgvOrderList);
            this.Controls.Add(this.txtFreight);
            this.Controls.Add(this.txtMemberID);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.lbShippedDate);
            this.Controls.Add(this.lbRequiredDate);
            this.Controls.Add(this.lbOrderDate);
            this.Controls.Add(this.lbFreight);
            this.Controls.Add(this.lbMemberID);
            this.Controls.Add(this.lbOrderID);
            this.Name = "frmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Management";
            this.Load += new System.EventHandler(this.frmOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbOrderID;
        private Label lbMemberID;
        private Label lbFreight;
        private Label lbOrderDate;
        private Label lbRequiredDate;
        private Label lbShippedDate;
        private MaskedTextBox txtOrderID;
        private MaskedTextBox txtMemberID;
        private MaskedTextBox txtFreight;
        private DataGridView dgvOrderList;
        private Button btnLoad;
        private Button btnDelete;
        private Button btnClose;
        private DateTimePicker dtOrderDate;
        private DateTimePicker dtRequiredDate;
        private DateTimePicker dtShippedDate;
        private Button btnAdd;
        private Button btnViewDetail;
    }
}