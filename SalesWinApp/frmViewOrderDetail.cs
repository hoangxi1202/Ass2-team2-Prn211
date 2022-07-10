using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.DataAccess;
using BusinessObject.Models;
using BusinessObject.Repository;

namespace SalesWinApp;

public partial class frmViewOrderDetail : Form
{
    public IOrderDetailRepository OrderDetailRepository { get; set; }
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

            string productId = txtProductID.Text;
            if (regex.IsMatch(productId) == false || productId.Trim().Equals("") || int.Parse(productId) < 0)
            {
                found = true;
                errors.productIdError = "Product ID must be the number format and greater than 0!";
            }

            string quantity = txtQuantity.Text;
            if (regex.IsMatch(quantity) == false || quantity.Trim().Equals("") || int.Parse(quantity) < 0)
            {
                found = true;
                errors.quantityError = "Quantity ID must be the number format and greater than 0!";
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
                    ProductId = int.Parse(productId),
                    Quantity = int.Parse(quantity),
                    Discount = float.Parse(discount),
                    UnitPrice = decimal.Parse(txtPrice.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderDetailRepository.AddOrderDetail(orderDetail);
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

        if (InsertOrUpdate == true)
        {
            txtOrderID.Text = OrderDetailInfo.OrderId.ToString();
            txtProductID.Text = OrderDetailInfo.ProductId.ToString();
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
