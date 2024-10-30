using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public bool CreateProduct(ProductObject product)
        {
            return ProductDAO.Instance.CreateProduct(product);
        }

        public List<ProductObject> GetAll()
        {
            return ProductDAO.Instance.GetProducts();
        }

        public ProductObject GetById(int id)
        {
            return ProductDAO.Instance.GetProductByProductId(id);
        }

        public bool RemoveProduct(int id)
        {
            return ProductDAO.Instance.RemoveProduct(id);
        }

        public bool UpdateProduct(ProductObject product)
        {
            return ProductDAO.Instance.UpdateProduct(product);
        }
    }
}
