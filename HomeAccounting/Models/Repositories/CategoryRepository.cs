using HomeAccounting.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDBContext context;

        public CategoryRepository()
        {
            context = new AppDBContext();
        }

        /// <summary> Return all categories </summary>
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        /// <summary> Save category </summary>
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
