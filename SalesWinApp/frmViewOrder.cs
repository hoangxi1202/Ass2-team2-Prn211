using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.Models;
using BusinessObject.DataAccess;
using BusinessObject.Repository;
using System.Text.RegularExpressions;

namespace SalesWinApp
{
    public partial class frmViewOrder : Form
    {
        public IOrderRepository OrderRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Order OrderInfo { get; set; }
        public frmViewOrder()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OrderError errors = new OrderError();
                bool found = false;
                string orderId = txtOrderID.Text;
                string pattern = @"^[0-9.]*$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(orderId) == false || orderId.Trim().Equals("") || int.Parse(orderId) < 0)
                {
                    found = true;
                    errors.orderIdError = "Order ID must be the number format and greater than 0!";
                }

                string memberId = txtMemberID.Text;
                if (regex.IsMatch(memberId) == false || memberId.Trim().Equals("") || int.Parse(memberId) < 0)
                {
                    found = true;
                    errors.memberIdError = "Member ID must be the number format and greater than 0!";
                }

                string freight = txtFreight.Text.Replace(".0000", "");
                if (!string.IsNullOrEmpty(freight))
                {
                    if (regex.IsMatch(freight) == false || int.Parse(freight) < 0)
                    {
                        found = true;
                        errors.freightError = "Freight must be the number format and greater than 0!";

                    }
                }
                else if (freight.Equals("0"))
                {
                    freight = "0";
                }
                else if (freight == null)
                {
                    freight = "";
                }
                string orderDate = dtOrderDate.Text;
                if (string.IsNullOrEmpty(orderDate) || orderDate.Equals(" "))
                {
                    found = true;
                    errors.orderDateError = "Order Date can not be empty";
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

                if (found)
                {
                    MessageBox.Show($"{errors.orderIdError} \n " +
                        $"{errors.memberIdError} \n " +
                        $"{errors.freightError} \n" +
                        $"{errors.orderDateError} \n" +
                        $"{errors.requiredDateError} \n" +
                        $"{errors.shippedDateError}", "Add a new product - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Order order = new Order
                    {
                        OrderId = int.Parse(orderId),
                        MemberId = int.Parse(memberId),
                        Freight = !freight.Equals("") ? decimal.Parse(freight) : null,
                        OrderDate = DateTime.ParseExact(orderDate, "dd/MM/yyyy HH:mm", null),
                        ShippedDate = !shippedDate.Equals(" ") ? DateTime.ParseExact(shippedDate, "dd/MM/yyyy HH:mm", null) : null,
                        RequiredDate = !requiredDate.Equals(" ") ? DateTime.ParseExact(requiredDate, "dd/MM/yyyy HH:mm", null) : null,
                    };
                    if (InsertOrUpdate == false)
                    {
                        OrderRepository.AddNewOrder(order);
                    }
                    else
                    {
                        OrderRepository.UpdateOrder(order);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new order" : "Update a order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmViewOrder_Load(object sender, EventArgs e)
        {
            txtOrderID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtOrderID.Text = OrderInfo.OrderId.ToString();
                txtMemberID.Text = OrderInfo.MemberId.ToString();
                if (OrderInfo.Freight == null)
                {
                    txtFreight.Text = "";
                }
                else
                {
                    txtFreight.Text = OrderInfo.Freight.ToString();
                }
                dtOrderDate.CustomFormat = "dd/MM/yyyy HH:mm";
                dtOrderDate.Text = OrderInfo.OrderDate.ToString();
                if (OrderInfo.RequiredDate == null)
                {
                    dtRequiredDate.CustomFormat = " ";
                }
                else
                {
                    dtRequiredDate.CustomFormat = "dd/MM/yyyy HH:mm";
                    dtRequiredDate.Text = OrderInfo.RequiredDate.Value.ToString();
                }
                if (OrderInfo.ShippedDate == null)
                {
                    dtShippedDate.CustomFormat = " ";
                }
                else
                {
                    dtShippedDate.CustomFormat = "dd/MM/yyyy HH:mm";
                    dtShippedDate.Text = OrderInfo.ShippedDate.Value.ToString();
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void dtRequiredDate_ValueChanged(object sender, EventArgs e)
        {
            dtRequiredDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtShippedDate_ValueChanged(object sender, EventArgs e)
        {
            dtShippedDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtOrderDate_ValueChanged(object sender, EventArgs e)
        {
            dtOrderDate.CustomFormat = "dd/MM/yyyy HH:mm";
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
}
