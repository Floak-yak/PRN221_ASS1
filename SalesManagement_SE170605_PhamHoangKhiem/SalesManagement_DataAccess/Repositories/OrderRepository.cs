using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public bool CreateOrder(OrderObject Order)
        {
            return OrderDAO.Instance.CreateOrder(Order);
        }

        public bool DeleteOrder(int id)
        {
            return OrderDAO.Instance.DeleteOrder(id);
        }

        public OrderObject GetOrderById(int id)
        {
            return OrderDAO.Instance.GetOrderById(id);
        }

        public List<OrderObject> GetOrderObjects()
        {
            return OrderDAO.Instance.GetAllOrders();
        }

        public bool UpdateOrder(OrderObject Order)
        {
            return OrderDAO.Instance.UpdateOrder(Order);
        }
    }
}
