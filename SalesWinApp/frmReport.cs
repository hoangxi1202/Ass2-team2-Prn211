
using System.Data;
using BusinessObject.Models;
using DataAccess.Repository;
using BusinessObject.Repository;

namespace SalesWinApp
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }
        public IOrderRepository orderRepository = new OrderRepository();
        public List<Order> OrderList { get; set; }
        public BindingSource? source;

        private void frmReport_Load(object sender, EventArgs e)
        {

        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtStartDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtEndDate.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            try
            {
                ReportError errors = new ReportError();
                bool found = false;

                string startDate = dtStartDate.Text;
                if (string.IsNullOrEmpty(startDate) || startDate.Equals(" "))
                {
                    found = true;
                    errors.dateError += "Start Date can not be empty";
                }
                string endDate = dtEndDate.Text;
                if (string.IsNullOrEmpty(endDate) || endDate.Equals(" "))
                {
                    found = true;
                    errors.dateError += "End Date can not be empty";
                }

                if (found)
                {
                    MessageBox.Show($"{errors.dateError} \n ", "Add a new product - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DateTime date1 = DateTime.ParseExact(dtStartDate.Text, "dd/MM/yyyy HH:mm", null);
                    DateTime date2 = DateTime.ParseExact(dtEndDate.Text, "dd/MM/yyyy HH:mm", null);
                    OrderList = GetListByDate(date1, date2);
                    LoadOrderList(OrderList);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
        private void ClearText()
        {
            txtTotalCustomers.Text = string.Empty;
            txtTotalOrders.Text = string.Empty;
            txtTotalProducts.Text = string.Empty;
            txtTotalSales.Text = string.Empty;
        }
        private List<Order> GetListByDate(DateTime startDate, DateTime endDate)
        {
            List<Order> orders = new List<Order>();
            try
            {

                orders = orderRepository.GetOrderbyDate(startDate, endDate);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return orders;
        }
        private void LoadOrderList(List<Order> order)
        {

            try
            {
                source = new BindingSource();
                source.DataSource = order;
                txtTotalCustomers.DataBindings.Clear();
                txtTotalOrders.DataBindings.Clear();
                txtTotalProducts.DataBindings.Clear();
                txtTotalSales.DataBindings.Clear();

                txtTotalCustomers.Enabled = false;
                txtTotalOrders.Enabled = false;
                txtTotalProducts.Enabled = false;
                txtTotalSales.Enabled = false;

                decimal? totalSales = 0;
                int totalProducts = 0;
                int totalCustomers = (from x in order
                                      select x.MemberId).Distinct().Count();
                int totalOders = order.Count;
                foreach (Order o in order)
                {
                    if (o.Freight != null)
                    {
                        totalSales += o.Freight;
                    }
                }

                txtTotalCustomers.Text = totalCustomers.ToString();
                txtTotalSales.Text = totalSales.ToString();
                txtTotalProducts.Text = totalProducts.ToString();
                txtTotalOrders.Text = totalOders.ToString();

                dgvReport.DataSource = null;
                dgvReport.DataSource = source;
                if (order.Count() == 0)
                {
                    ClearText();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public record ReportError()
        {
            public string? dateError { get; set; }

        }
    }
}
