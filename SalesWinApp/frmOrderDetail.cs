using BusinessObject.Repository;
using BusinessObject.Models;
using DataAccess.Repository;

namespace SalesWinApp;

public partial class frmOrderDetail : Form
{
    public IProductRepository productRepository = new ProductRepository();
    public IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
    public BindingSource source;
    public Order OrderInfo { get; set; }
    public frmOrderDetail()
    {
        InitializeComponent();
    }
    private void LoadOrderDetailList()
    {
        var orderDetails = orderDetailRepository.GetOrderDetails(OrderInfo.OrderId);
        try
        {
            source = new BindingSource();
            source.DataSource = orderDetails;
            if (orderDetails == null)
            {
                dgvOrderDetails.DataSource = source;
                throw new Exception("The Order Detail List is Empty!!!");
            }
            else
            {
                dgvOrderDetails.DataSource = source;
                dgvOrderDetails.Columns[5].Visible = false;
                dgvOrderDetails.Columns[6].Visible = false;
            }
            if (orderDetails.Count() == 0)
            {
                ClearText();
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
            cbProduct.DataSource = productRepository.GetProductNames();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Order Detail Management - Load List Order Detail",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void frmOrderDetail_Load(object sender, EventArgs e)
    {

    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void btnNew_Click(object sender, EventArgs e)
    {
        frmViewOrderDetail frmViewOrderDetail = new frmViewOrderDetail
        {
            Text = "Add a order",
            InsertOrUpdate = false,
            OrderDetailRepository = orderDetailRepository,
            ProductRepository = productRepository,
            OrderID = OrderInfo.OrderId.ToString()
        };
        if (frmViewOrderDetail.ShowDialog() == DialogResult.OK)
        {
            LoadOrderDetailList();
            source.Position = source.Count - 1;
        }
    }
    private void btnDelete_Click(object sender, EventArgs e)
    {
        int orderID = int.Parse(txtOrderID.Text);
        int productID = int.Parse(cbProduct.Text);
        try
        {
            orderDetailRepository.DeleteOrderDetail(orderID, productID);
            LoadOrderDetailList();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete a order detail - Error ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        btnDelete.Enabled = true;
        dgvOrderDetails.CellDoubleClick += DgvOrderDetails_CellDoubleClick;
        LoadOrderDetailList();

    }

    private OrderDetail GetOrderDetailObject()
    {
        OrderDetail? orderDetail = null;
        try
        {
            int orderID;
            dynamic check = int.TryParse(txtOrderID.Text, out orderID);
            List<Product> listProduct = productRepository.GetListProducts();
            int ProductID = -1;
            foreach (var item in listProduct)
            {
                if (item.ProductName.Equals(cbProduct.Text))
                {
                    ProductID = item.ProductId;
                }
            }
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;
            string discount = txtDiscount.Text;
            decimal priceCheck;
            bool found = decimal.TryParse(price, out priceCheck);

            orderDetail = new OrderDetail
            {
                OrderId = orderID,
                ProductId = ProductID,
                UnitPrice = priceCheck,
                Quantity = int.Parse(quantity),
                Discount = float.Parse(discount)
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Get order Detail");
        }
        return orderDetail;
    }
    private void DgvOrderDetails_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        frmViewOrderDetail frmViewOrderDetail = new frmViewOrderDetail
        {
            Text = "Update a order detail",
            InsertOrUpdate = true,
            OrderDetailInfo = GetOrderDetailObject(),
            OrderDetailRepository = orderDetailRepository,
            ProductRepository = productRepository,

        };
        if (frmViewOrderDetail.ShowDialog() == DialogResult.OK)
        {
            LoadOrderDetailList();
            source.Position = source.Count - 1;
        }
    }

    private void dgvOrderDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        int index = e.RowIndex;
        txtOrderID.Clear();
        txtPrice.Clear();
        txtDiscount.Clear();
        txtQuantity.Clear();
        cbProduct.Text = "";
        txtOrderID.Text = dgvOrderDetails.Rows[index].Cells[0].Value.ToString();
        cbProduct.Text = productRepository.GetProductById(int.Parse(dgvOrderDetails.Rows[index].Cells[1].Value.ToString())).ProductName;
        txtDiscount.Text = dgvOrderDetails.Rows[index].Cells[4].Value.ToString();
        txtQuantity.Text = dgvOrderDetails.Rows[index].Cells[3].Value.ToString();
        txtPrice.Text = dgvOrderDetails.Rows[index].Cells[2].Value.ToString();
    }
    private void ClearText()
    {
        txtOrderID.Text = string.Empty;
        txtPrice.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        txtDiscount.Text = string.Empty;

    }

    private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
