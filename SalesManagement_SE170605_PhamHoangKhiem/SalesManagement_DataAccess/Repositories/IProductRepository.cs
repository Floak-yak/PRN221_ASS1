using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public interface IProductRepository
    {
        List<ProductObject> GetAll();
        ProductObject GetById(int id);
        bool RemoveProduct (int id);
        bool UpdateProduct (ProductObject product);
        bool CreateProduct (ProductObject product);
    }
}
