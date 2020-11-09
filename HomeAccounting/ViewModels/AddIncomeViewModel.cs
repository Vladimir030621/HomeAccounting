using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.ViewModels
{
    class AddIncomeViewModel
    {
        private ICategoryRepository context;

        public List<string> CategoryListIncome { get; set; }

        public AddIncomeViewModel()
        {
            context = new CategoryRepository();

            CategoryListIncome = context.GetCategories()
                .Where(c => c.OperationType == "Income")
                .Select(s => s.CategoryName)
                .ToList();
        }
    }
}
