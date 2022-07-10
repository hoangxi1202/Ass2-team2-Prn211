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
        public Product GetProductById(int productID) => ProductDAO.Instance.GetProductById(productID);
        public List<Product> GetProductByUnitInStock(int p1, int p2) => ProductDAO.Instance.GetProductsByUnitsInStock(p1, p2);
        public List<Product> GetProductByUnitPrice(decimal p1, decimal p2) => ProductDAO.Instance.GetProductsByUnitPrice(p1, p2);
        public List<Product> GetProductsByName(string name) => ProductDAO.Instance.GetProductsByName(name);
        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);

    }
}
