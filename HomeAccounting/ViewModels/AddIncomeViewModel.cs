using HomeAccounting.Models;
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
        //private ICategoryRepository context;
        private DataManager dataManager;

        public List<string> CategoryListIncome { get; set; }

        public AddIncomeViewModel()
        {
            dataManager = new DataManager();

            //context = new CategoryRepository();

            CategoryListIncome = dataManager.Categories.GetCategories()
                .Where(c => c.OperationType == "Income")
                .Select(s => s.CategoryName)
                .ToList();
        }
    }
}
