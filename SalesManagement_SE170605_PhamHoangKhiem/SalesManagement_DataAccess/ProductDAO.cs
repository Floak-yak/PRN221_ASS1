using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess
{
    public class ProductDAO
    {
        private AppDbContext _context;
        private static ProductDAO instance = null;

        public ProductDAO()
        {
            _context = new AppDbContext();
        }

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }

        public List<ProductObject> GetProducts()
        {
            return _context.Products.ToList();
        }

        public ProductObject GetProductByProductId(int id)
        {
            return _context.Products.SingleOrDefault(m => m.ProductId == id);
        }

        public bool CreateProduct(ProductObject product)
        {
            _context.Products.Add(product); 
            return _context.SaveChanges() > 0;
        }

        public bool UpdateProduct(ProductObject product)
        {
            _context.Products.Update(product);

            return _context.SaveChanges() > 0;
        }

        public bool RemoveProduct(int productId)
        {
            var product = GetProductByProductId(productId);

            if (product != null)
            {
                _context.Products.Remove(product);
            }
            else
            {
                return false;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
