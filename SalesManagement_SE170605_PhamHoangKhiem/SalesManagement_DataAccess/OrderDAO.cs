using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess
{
    public class OrderDAO
    {
        private AppDbContext _context;
        private static OrderDAO instance = null;

        public OrderDAO()
        {
            _context = new AppDbContext();
        }

        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public OrderObject GetOrderById(int id)
        {
            return _context.Orders.SingleOrDefault(m => m.OrderId == id);
        }

        public List<OrderObject> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public bool CreateOrder(OrderObject order)
        {
            _context.Orders.Add(order);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteOrder(int id)
        {
            _context.Orders.Remove(GetOrderById(id));
            return _context.SaveChanges() > 0;
        }

        public bool UpdateOrder(OrderObject order)
        {
            _context.Orders.Update(order);
            return _context.SaveChanges() > 0;
        }
    }
}
