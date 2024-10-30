using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryObject> GetCategoryObjects();
        CategoryObject GetCategoryById(int id);
        bool CreateCategory(CategoryObject categoryObject);
        bool UpdateCategory(CategoryObject categoryObject);
        bool DeleteCategory(int id);
    }
}
