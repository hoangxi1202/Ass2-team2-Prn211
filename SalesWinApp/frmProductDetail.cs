using BusinessObject.Models;
using BusinessObject.DataAccess;
using DataAccess.Repository;
using System.Text.RegularExpressions;

namespace SalesWinApp
{
    public partial class frmProductDetail : Form
    {
        public frmProductDetail()
        {
            InitializeComponent();
        }
        public IProductRepository ProductRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Product ProductInfo { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductError errors = new ProductError();
                bool found = false;
                string productID = txtProductID.Text;
                string pattern = @"^[0-9.]*$";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(productID) == false || productID.Trim().Equals("") || int.Parse(productID) < 0)
                {
                    found = true;
                    errors.productIDError = "Product ID must be the number format and greater than 0!";
                }

                string categoryID = txtCategoryID.Text;
                if (regex.IsMatch(categoryID) == false || categoryID.Trim().Equals("") || int.Parse(categoryID) < 0)
                {
                    found = true;
                    errors.categoryIDError = "Category ID must be the number format and greater than 0!";
                }

                string productName = txtProductName.Text;
                if (string.IsNullOrEmpty(productName) || productName.Equals(" "))
                {
                    found = true;
                    errors.productNameError = "Product name can not be empty";
                }

                string weight = txtWeight.Text;
                if (string.IsNullOrEmpty(weight) || weight.Equals(" "))
                {
                    found = true;
                    errors.weightError = "weight can not be empty";
                }

                string unitPrice = txtUnitPrice.Text;
                if (regex.IsMatch(unitPrice) == false || unitPrice.Trim().Equals("") || decimal.Parse(unitPrice) < 0)
                {
                    found = true;
                    errors.UnitInStockError = "Unit Price  must be the number format and greater than 0!";
                }

                string unitInStock = txtUnitsInStock.Text;
                if (regex.IsMatch(unitInStock) == false || unitInStock.Trim().Equals("") || int.Parse(unitInStock) < 0)
                {
                    found = true;
                    errors.UnitInStockError = "Unit In Stock must be the number format and greater than 0!";
                }


                if (found)
                {
                    MessageBox.Show($"{errors.productIDError} \n " +
                        $"{errors.categoryIDError} \n " +
                        $"{errors.productNameError} \n" +
                        $"{errors.weightError} \n" +
                        $"{errors.UnitPriceErrsor} \n" +
                        $"{errors.UnitInStockError}", "Add a new product - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Product pro = new Product
                    {
                        ProductId = int.Parse(productID),
                        CategoryId = int.Parse(categoryID),
                        ProductName = productName,
                        Weight = weight,
                        UnitPrice = decimal.Parse(unitPrice),
                        UnitsInStock = int.Parse(unitInStock)
                    };
                    if (InsertOrUpdate == false)
                    {
                        ProductRepository.CreateProduct(pro);
                    }
                    else
                    {
                        ProductRepository.UpdateProduct(pro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Product" : "Update a Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtProductID.Text = ProductInfo.ProductId.ToString();
                txtCategoryID.Text = ProductInfo.CategoryId.ToString();
                txtProductName.Text = ProductInfo.ProductName;
                txtWeight.Text = ProductInfo.Weight;
                txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfo.UnitsInStock.ToString();
            }
        }
        public record ProductError()
        {
            public string? productIDError { get; set; }
            public string? categoryIDError { get; set; }
            public string? productNameError { get; set; }
            public string? weightError { get; set; }
            public string? UnitPriceErrsor { get; set; }
            public string? UnitInStockError { get; set; }
        }
    }
}
