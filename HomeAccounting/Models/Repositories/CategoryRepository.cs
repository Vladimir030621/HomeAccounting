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

        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
