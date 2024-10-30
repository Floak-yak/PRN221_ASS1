using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public interface IOrderRepository
    {
        List<OrderObject> GetOrderObjects();
        OrderObject GetOrderById(int id);
        bool CreateOrder(OrderObject Order);
        bool UpdateOrder(OrderObject Order);
        bool DeleteOrder(int id);
    }
}
