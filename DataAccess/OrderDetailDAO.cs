using BusinessObject.Models;

namespace BusinessObject.DataAccess;

public class OrderDetailDAO
{
    private OrderDetailDAO() { }
    private static OrderDetailDAO instance = null;
    private static readonly object instanceLock = new object();
    public static OrderDetailDAO Instance
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }
    }

    public List<OrderDetail>? GetOrderDetails(int orderID)
    {
        List<OrderDetail>? listOrders = new List<OrderDetail>();
        try
        {
            FStoreContext DbContext = new FStoreContext();
            listOrders = DbContext.OrderDetails.Where(s => s.OrderId == orderID).ToList();
            if (listOrders.Count == 0)
                listOrders = null;
        }
        catch (Exception)
        {
            throw new Exception("Get list order details unsuccessfully");
        }
        return listOrders;
    }
    public int CountProduct(int orderID)
    {
        List<OrderDetail>? listOrders = new List<OrderDetail>();
        int count = 0;
        try
        {
            FStoreContext DbContext = new FStoreContext();
            listOrders = DbContext.OrderDetails.Where(s => s.OrderId == orderID).ToList();
            if (listOrders.Count == 0)
                listOrders = null;
            else {
                foreach (OrderDetail o in listOrders) {
                    count += o.Quantity;
                }

            }
        }
        catch (Exception)
        {
            throw new Exception("Get count Product details unsuccessfully");
        }
        return count;
    }

    public void AddNewOrderDetail(OrderDetail orderDetails)
    {
        try
        {
            FStoreContext DbContext = new FStoreContext();
            DbContext.OrderDetails.Add(orderDetails);
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Add a new order detail unsuccessfully (Order ID already exist or MemberID does not exist)");
        }
    }

    public void DeleteOrderDetail(int orderID, int productID)
    {
        try
        {
            FStoreContext DbContext = new FStoreContext();
            OrderDetail? orderDetail = DbContext.OrderDetails.
                SingleOrDefault(orderDetail => (orderDetail.OrderId == orderID && orderDetail.ProductId == productID));
            DbContext.OrderDetails.Remove(orderDetail);
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Delete a order detail unsuccessfully");
        }
    }

    public void UpdateOrderDetail(OrderDetail orderDetail)
    {
        try
        {
            FStoreContext DbContext = new FStoreContext();
            DbContext.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Update a order detail unsuccessfully");
        }
    }
}
