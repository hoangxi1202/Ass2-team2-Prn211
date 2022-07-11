using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetListProducts();
        public List<string> GetProductNames();
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productID);
        public Product GetProductById(int id);

    }
}
