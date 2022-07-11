using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;

namespace BusinessObject.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail>? GetOrderDetails(int orderID);
        public void AddOrderDetail(OrderDetail orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(int orderID, int productID);
    }
}
