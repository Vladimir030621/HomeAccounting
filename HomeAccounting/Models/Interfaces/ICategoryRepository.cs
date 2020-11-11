using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();

        void AddCategory(Category category);
    }
}
