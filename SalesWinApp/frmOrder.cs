using System.Data;
using BusinessObject.Models;
using BusinessObject.Repository;

namespace SalesWinApp
{
    public partial class frmOrder : Form
    {
        public IOrderRepository orderRepository = new OrderRepository();
        public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        public BindingSource? source;
        public frmOrder()
        {
            InitializeComponent();
        }
        public frmOrder(bool isAdmin)
        {
            InitializeComponent();
            IsAdmin = isAdmin;
        }
        public frmOrder(bool isAdmin, Member mem)
        {
            InitializeComponent();
            IsAdmin = isAdmin;
            Mem = mem;
        }
        public bool IsAdmin { get; set; }
        public Member Mem { get; set; }
        void authen()
        {
            btnLoad.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void LoadOrderList()
        {
            try
            {
                var orders = orderRepository.GetOrders().OrderByDescending(x => x.OrderId);
                source = new BindingSource();
                List<Order> listOrders = orderRepository.GetOrders();
                source.DataSource = orders;
                dgvOrderList.DataSource = source;
                dgvOrderList.Columns[6].Visible = false;
                dgvOrderList.Columns[7].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Management - Load List Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadOrderListByMemberID()
        {
            try
            {

                source = new BindingSource();
                List<Order> listOrders = orderRepository.GetOrderByMemberID(Mem.MemberId);
                source.DataSource = listOrders;
                dgvOrderList.DataSource = source;
                dgvOrderList.Columns[6].Visible = false;
                dgvOrderList.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Management - Load List Order",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            dgvOrderList.CellDoubleClick += DgvOrderList_CellDoubleClick;
            LoadOrderList();
        }

        private void DgvOrderList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmViewOrder frmViewOrder = new frmViewOrder
            {
                Text = "Update a order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderObject(),
                OrderRepository = orderRepository
            };
            if (frmViewOrder.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
        }
        private Order GetOrderObject()
        {
            Order? order = null;
            try
            {
                int orderID;
                dynamic check = int.TryParse(txtOrderID.Text, out orderID);
                int memberID;
                check = int.TryParse(txtMemberID.Text, out memberID);
                string freight = txtFreight.Text;
                if (!string.IsNullOrEmpty(freight))
                {
                }
                else if (freight.Equals("0"))
                {
                    freight = "0";
                }
                else if (freight == null)
                {
                    freight = "";
                }
                string requiredDate = dtRequiredDate.Text;
                if (string.IsNullOrEmpty(requiredDate))
                {
                    requiredDate = " ";
                }
                string shippedDate = dtShippedDate.Text;
                if (string.IsNullOrEmpty(shippedDate))
                {
                    shippedDate = " ";
                }
                decimal freightCheck;
                bool found = decimal.TryParse(freight, out freightCheck);

                order = new Order
                {
                    OrderId = orderID,
                    MemberId = memberID,
                    Freight = freightCheck,
                    OrderDate = DateTime.ParseExact(dtOrderDate.Text, "dd/MM/yyyy HH:mm", null),
                    RequiredDate = (!requiredDate.Equals(" ")) ? DateTime.ParseExact(requiredDate, "dd/MM/yyyy HH:mm", null) : null,
                    ShippedDate = (!shippedDate.Equals(" ")) ? DateTime.ParseExact(shippedDate, "dd/MM/yyyy HH:mm", null) : null
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get order");
            }
            return order;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int orderID = int.Parse(txtOrderID.Text);
            try
            {
                orderRepository.DeleteOrder(orderID);
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a order - Error ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void frmOrder_Load(object sender, EventArgs e)
        {

            if (IsAdmin)
            {
                LoadOrderList();
            }
            else
            {
                authen();
                LoadOrderListByMemberID();
            }
        }

        private void dgvOrderList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtOrderID.Clear();
            txtMemberID.Clear();
            txtFreight.Clear();
            txtOrderID.Text = dgvOrderList.Rows[index].Cells[0].Value.ToString();
            txtMemberID.Text = dgvOrderList.Rows[index].Cells[1].Value.ToString();
            if (dgvOrderList.Rows[index].Cells[5].Value == null)
            {
                txtFreight.Text = "";
            }
            else
            {
                txtFreight.Text = dgvOrderList.Rows[index].Cells[5].Value.ToString();
            }
            dtOrderDate.Text = dgvOrderList.Rows[index].Cells[2].Value.ToString();
            if (dgvOrderList.Rows[index].Cells[3].Value == null)
            {
                dtRequiredDate.CustomFormat = " ";
            }
            else
            {
                dtRequiredDate.CustomFormat = "dd/MM/yyyy HH:mm";
                dtRequiredDate.Text = dgvOrderList.Rows[index].Cells[3].Value.ToString();
            }

            if (dgvOrderList.Rows[index].Cells[4].Value == null)
            {
                dtShippedDate.CustomFormat = " ";
            }
            else
            {
                dtShippedDate.CustomFormat = "dd/MM/yyyy HH:mm";
                dtShippedDate.Text = dgvOrderList.Rows[index].Cells[4].Value.ToString();
            }
        }

        private void dtOrderDate_ValueChanged(object sender, EventArgs e)
        {
            dtOrderDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtRequiredDate_ValueChanged(object sender, EventArgs e)
        {
            dtRequiredDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtShippedDate_ValueChanged(object sender, EventArgs e)
        {
            dtShippedDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtOrderDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtOrderDate.CustomFormat = " ";
            }
        }

        private void dtRequiredDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtRequiredDate.CustomFormat = " ";
            }
        }

        private void dtShippedDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Back) || (e.KeyCode == Keys.Delete))
            {
                dtShippedDate.CustomFormat = " ";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmViewOrder frmViewOrder = new frmViewOrder
            {
                Text = "Add a order",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (frmViewOrder.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
        }

        private void dgvOrderList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewDetail.Enabled = true;
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail
            {
                Text = "View order details",
                OrderInfo = GetOrderObject()
            };

            if (frmOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }

        }
    }
    public record OrderError()
    {
        public string? orderIdError { get; set; }
        public string? memberIdError { get; set; }
        public string? freightError { get; set; }
        public string? orderDateError { get; set; }
        public string? requiredDateError { get; set; }
        public string? shippedDateError { get; set; }
    }
}
