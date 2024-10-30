using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool CreateCategory(CategoryObject categoryObject)
        {
            return CategoryDAO.Instance.CreateCategory(categoryObject);
        }

        public bool DeleteCategory(int id)
        {
            return CategoryDAO.Instance.DeleteCategory(id);
        }

        public CategoryObject GetCategoryById(int id)
        {
            return CategoryDAO.Instance.GetCategoryByCategoryId(id);
        }

        public List<CategoryObject> GetCategoryObjects()
        {
            return CategoryDAO.Instance.GetAllCategory();
        }

        public bool UpdateCategory(CategoryObject categoryObject)
        {
            return CategoryDAO.Instance.UpdateCategory(categoryObject);
        }
    }
}
