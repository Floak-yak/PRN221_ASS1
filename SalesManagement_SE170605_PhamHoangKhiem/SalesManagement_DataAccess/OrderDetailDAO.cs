using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess
{
    public class OrderDetailDAO
    {
        private AppDbContext _context;
        private static OrderDetailDAO instance = null;

        public OrderDetailDAO()
        {
            _context = new AppDbContext();
        }

        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public OrderDetailObject GetOrderDetailByProductId(int id)
        {
            return _context.OrderDetails.SingleOrDefault(m => m.OrderId == id);
        }
    }
}
