using SalesManagement_BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_DataAccess
{
    public class CategoryDAO
    {
        private AppDbContext _context;
        private static CategoryDAO instance = null;

        public CategoryDAO()
        {
            _context = new AppDbContext();
        }

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        public List<CategoryObject> GetAllCategory()
        {
            return _context.Categories.ToList();
        }

        public CategoryObject GetCategoryByCategoryId(int id)
        {
            return _context.Categories.SingleOrDefault(m => m.CategoryId == id);
        }

        public bool CreateCategory (CategoryObject category)
        {
            _context.Categories.Add(category);
            return _context.SaveChanges() > 0;
        }

        public bool DeleteCategory (int id)
        {
            _context.Categories.Remove(GetCategoryByCategoryId(id));
            return _context.SaveChanges() > 0;
        }

        public bool UpdateCategory(CategoryObject categoryObject)
        {
            _context.Categories.Update(categoryObject);
            return _context.SaveChanges() > 0;
        }
    }
}
