using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace BusinessObject.DataAccess;

public class ProductDAO
{
    private ProductDAO() { }
    private static ProductDAO instance = null;
    private static readonly object instanceLock = new object();

    public static ProductDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
    }
    public List<string> GetProductsName()
    {
        List<string> listProductName = new List<string>();
        try
        {
            FStoreContext DbContext = new FStoreContext();
            List<Product> listProduct = DbContext.Products.ToList();
            foreach (var item in listProduct)
            {
                listProductName.Add(item.ProductName);
            }
        }
        catch (Exception)
        {
            throw new Exception("Get Product Name List unsuccessfully");
        }
        return listProductName;
    }
    public List<Product> GetListProducts()
    {
        List<Product> listProducts = new List<Product>();
        try
        {
            FStoreContext DbContext = new FStoreContext();
            listProducts = DbContext.Products.ToList();
        }
        catch (Exception)
        {
            throw new Exception("Get list fail");
        }
        return listProducts;
    }
    public void CreateProduct(Product product)
    {
        try
        {
            FStoreContext DbContext = new FStoreContext();
            DbContext.Products.Add(product);
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Create product fail");
        }
    }
    public void UpdateProduct(Product product)
    {
        try
        {
            FStoreContext DbContext = new FStoreContext();
            DbContext.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Update product fail");
        }
    }

    public void DeleteProduct(int productID)
    {
        try
        {
            FStoreContext DbContext = new FStoreContext();
            Product? product = DbContext.Products.SingleOrDefault(product => product.ProductId == productID);
            DbContext.Products.Remove(product);
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Delete product fail");
        }
    }
    public Product GetProduct(int id)
    {
        Product? product = null;
        try
        {
            FStoreContext DbContext = new FStoreContext();
            product = DbContext.Products.SingleOrDefault(product => product.ProductId == id);
        }
        catch (Exception)
        {
            throw new Exception("Get Product fail");
        }
        return product;
    }

}
