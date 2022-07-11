using System.Text.RegularExpressions;
using BusinessObject.Models;
using BusinessObject.Repository;
using DataAccess.Repository;
namespace SalesWinApp;

public partial class frmViewOrderDetail : Form
{
    public IOrderDetailRepository OrderDetailRepository { get; set; }
    public IProductRepository ProductRepository { get; set; }
    public bool InsertOrUpdate { get; set; }
    public OrderDetail OrderDetailInfo { get; set; }
    public string OrderID { get; set; }
    public frmViewOrderDetail()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            OrderDetailError errors = new OrderDetailError();
            bool found = false;
            string orderId = txtOrderID.Text;
            string pattern = @"^[0-9.]*$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(orderId) == false || orderId.Trim().Equals("") || int.Parse(orderId) < 0)
            {
                found = true;
                errors.orderIdError = "Order ID must be the number format and greater than 0!";
            }

            List<Product> listProduct = ProductRepository.GetListProducts();
            int ProductID = -1;
            foreach (var item in listProduct)
            {
                if (item.ProductName.Equals(txtProductID.Text))
                {
                    ProductID = item.ProductId;
                }
            }
            int oldValue = 0;
            if (OrderDetailInfo != null)
            {
                oldValue = OrderDetailInfo.Quantity;
            }
            int stock = ProductRepository.GetProductById(ProductID).UnitsInStock + oldValue;
            string quantity = txtQuantity.Text;
            if (regex.IsMatch(quantity) == false || quantity.Trim().Equals("") || int.Parse(quantity) < 0)
            {
                found = true;
                errors.quantityError = "Quantity ID must be the number format and greater than 0!";
            }
            else if (int.Parse(quantity) > stock)
            {
                throw new Exception("Out of stock!!");
            }

            string discount = txtDiscount.Text;
            if (string.IsNullOrEmpty(discount) || discount.Equals(" "))
            {
                found = true;
                errors.discountError = "Discount can not be empty";
            }
            string price = txtPrice.Text;

            if (found)
            {
                MessageBox.Show($"{errors.orderIdError} \n " +
                    $"{errors.productIdError} \n " +
                    $"{errors.orderIdError} \n" +
                    $"{errors.discountError} \n" +
                    $"{errors.priceError} \n" +
                    $"{errors.quantityError}", "Add a new Order Detail - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    OrderId = int.Parse(orderId),
                    ProductId = ProductID,
                    Quantity = int.Parse(quantity),
                    Discount = float.Parse(discount),
                    UnitPrice = decimal.Parse(txtPrice.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderDetailRepository.AddOrderDetail(orderDetail);
                    ProductRepository.UpdateProduct(ProductRepository.GetProductById(ProductID));
                }
                else
                {
                    OrderDetailRepository.UpdateOrderDetail(orderDetail);
                }


            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new order detail" : "Update a order detail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void frmViewOrderDetail_Load(object sender, EventArgs e)
    {
        txtOrderID.Enabled = false;
        txtProductID.Enabled = !InsertOrUpdate;
        txtProductID.DataSource = ProductRepository.GetProductNames();

        if (InsertOrUpdate == true)
        {
            txtOrderID.Text = OrderDetailInfo.OrderId.ToString();            
            string id = OrderDetailInfo.ProductId.ToString();
            txtProductID.Text = ProductRepository.GetProductById(int.Parse(id)).ProductName;
            txtPrice.Text = OrderDetailInfo.UnitPrice.ToString();
            txtQuantity.Text = OrderDetailInfo.Quantity.ToString();
            txtDiscount.Text = OrderDetailInfo.Discount.ToString();
        }
        else
        {
            txtOrderID.Text = OrderID.ToString();
        }
    }

    private void txtQuantity_TextChanged(object sender, EventArgs e)
    {
    }

    private void txtDiscount_TextChanged(object sender, EventArgs e)
    {
    }

    public record OrderDetailError()
    {
        public string? orderIdError { get; set; }
        public string? productIdError { get; set; }
        public string? priceError { get; set; }
        public string? quantityError { get; set; }
        public string? discountError { get; set; }
    }
}
