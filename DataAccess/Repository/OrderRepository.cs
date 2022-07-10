using BusinessObject.Models;
using BusinessObject.DataAccess;

namespace BusinessObject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddNewOrder(Order order) => OrderDAO.Instance.AddNewOrder(order);

        public void DeleteOrder(int orderID) => OrderDAO.Instance.DeleteOrder(orderID);

        public List<Order> GetOrderbyDate(DateTime date1, DateTime date2) => OrderDAO.Instance.GetOrdersByDate(date1, date2);

        public List<Order> GetOrderByMemberID(int memberID) => OrderDAO.Instance.GetOrderByMemberID(memberID);

        public List<Order> GetOrders() => OrderDAO.Instance.GetOrders();

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);
    }
}
