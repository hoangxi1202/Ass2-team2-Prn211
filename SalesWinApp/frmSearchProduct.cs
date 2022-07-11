using BusinessObject.Repository;
using BusinessObject.Models;
using DataAccess.Repository;
using System.Text.RegularExpressions;

namespace SalesWinApp
{
    public partial class frmSearchProduct : Form
    {
        public frmSearchProduct()
        {
            InitializeComponent();
        }
        public IProductRepository productRepository = new ProductRepository();
        public List<Product> Products { get; set; }
        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            txtSearch1.Hide();
            txtsearch2.Hide();
        }
        private int Choose()
        {
            switch (cmbTypeSearch.Text)
            {
                case "Product ID":
                    return 1;
                case "Product Name":
                    return 2;
                case "Unit Price":
                    return 3;
                case "Units in Stock":
                    return 4;
            }
            return 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchError errors = new SearchError();
                bool found = false;
                string pattern = @"^[0-9.]*$";
                Regex regex = new Regex(pattern);
                switch (Choose())
                {
                    case 1:
                        string memberId = txtSearch1.Text;
                        if (regex.IsMatch(memberId) == false || memberId.Trim().Equals("") || int.Parse(memberId) < 0)
                        {
                            found = true;
                            errors.memberIdError = "Member ID must be the number format and greater than 0!";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.memberIdError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = new List<Product>();
                            Products.Add(productRepository.GetProductById(Convert.ToInt32(memberId)));
                        }
                        break;
                    case 2:
                        string name = txtSearch1.Text;
                        if (string.IsNullOrEmpty(name) || name.Equals(" "))
                        {
                            found = true;
                            errors.MemberNameError = "name can not be empty";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.MemberNameError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = productRepository.GetProductsByName(name);
                        }
                        break;
                    case 3:
                        string price1 = txtSearch1.Text;
                        string price2 = txtsearch2.Text;
                        if (regex.IsMatch(price1) == false || price1.Trim().Equals("") || decimal.Parse(price1) < 0)
                        {
                            found = true;
                            errors.UnitPriceError += "price 1 must be the number format and greater than 0!";
                        }
                        if (regex.IsMatch(price2) == false || price2.Trim().Equals("") || decimal.Parse(price2) < 0)
                        {
                            found = true;
                            errors.UnitPriceError += "price 2 must be the number format and greater than 0!";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.UnitPriceError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = productRepository.GetProductByUnitPrice(Convert.ToDecimal(price1), Convert.ToDecimal(price2));
                        }
                        break;
                    case 4:
                        string units1 = txtSearch1.Text;
                        string units2 = txtsearch2.Text;
                        if (regex.IsMatch(units1) == false || units1.Trim().Equals("") || int.Parse(units1) < 0)
                        {
                            found = true;
                            errors.UnitsInStockError += "units 1 must be the number format and greater than 0!";
                        }
                        if (regex.IsMatch(units2) == false || units2.Trim().Equals("") || int.Parse(units2) < 0)
                        {
                            found = true;
                            errors.UnitsInStockError += "units 2 must be the number format and greater than 0!";
                        }
                        if (found)
                        {
                            MessageBox.Show($"{errors.UnitsInStockError} \n ", "Search - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Products = productRepository.GetProductByUnitInStock(Convert.ToInt32(units1), Convert.ToInt32(units2));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Choose() == 1 || Choose() == 2)
            {
                txtSearch1.Show();
                txtsearch2.Hide();
            }
            else if (Choose() == 3 || Choose() == 4)
            {
                txtSearch1.Show();
                txtsearch2.Show();
            }
        }

        public record SearchError()
        {
            public string? memberIdError { get; set; }
            public string? MemberNameError { get; set; }
            public string? UnitPriceError { get; set; }
            public string? UnitsInStockError { get; set; }

        }

    }
}
