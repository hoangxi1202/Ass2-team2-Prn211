using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.DataAccess;
using BusinessObject.Models;

namespace BusinessObject.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail)
        => OrderDetailDAO.Instance.AddNewOrderDetail(orderDetail);

        public void DeleteOrderDetail(int orderID, int productID)
        => OrderDetailDAO.Instance.DeleteOrderDetail(orderID, productID);

        public List<OrderDetail>? GetOrderDetails(int orderID)
         => OrderDetailDAO.Instance.GetOrderDetails(orderID);

        public void UpdateOrderDetail(OrderDetail orderDetail)
        => OrderDetailDAO.Instance.UpdateOrderDetail(orderDetail);
    }
}
