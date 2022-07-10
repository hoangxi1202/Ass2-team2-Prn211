using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DataAccess;

namespace DataAccess.Repository

{
    public class ProductRepository : IProductRepository
    {
        public void CreateProduct(Product product) => ProductDAO.Instance.CreateProduct(product);
        public void DeleteProduct(int productID) => ProductDAO.Instance.DeleteProduct(productID);
        public List<Product> GetListProducts() => ProductDAO.Instance.GetListProducts();
        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);

    }
}
