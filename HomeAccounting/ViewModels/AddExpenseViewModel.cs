using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.ViewModels
{
    class AddExpenseViewModel 
    {
        private ICategoryRepository context;

        public List<string> CategoryListExpense { get; set; }

        public AddExpenseViewModel()
        {
            context = new CategoryRepository();

            CategoryListExpense = context.GetCategories().Where(c => c.OperationType == "Expense").Select(s => s.CategoryName).ToList();
        }
    }
}
