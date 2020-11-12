using HomeAccounting.Commands;
using HomeAccounting.Models;
using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeAccounting.ViewModels
{
    class AddExpenseViewModel : DependencyObject
    {
        private DataManager dataManager;

        public AddExpenseViewModel()
        {
            dataManager = new DataManager();

            CategoryListExpense = dataManager.Categories.GetCategories()
                .Where(c => c.OperationType == "Expense")
                .Select(s => s.CategoryName)
                .ToList();

            RefreshExpenseCategoriesCommand = new LambdaCommand(OnRefreshExpenseCategoriesCommandExecuted, CanRefreshExpenseCategoriesCommandExecute);
        }

        #region CategoryListExpense dependency object property

        public List<string> CategoryListExpense
        {
            get { return (List<string>)GetValue(CategoryListExpenseProperty); }
            set { SetValue(CategoryListExpenseProperty, value); }
        }

        public static readonly DependencyProperty CategoryListExpenseProperty =
            DependencyProperty.Register("CategoryListExpense", typeof(List<string>), typeof(AddExpenseViewModel), new PropertyMetadata(null));

        #endregion

        #region Refresh expense catogories command

        public ICommand RefreshExpenseCategoriesCommand { get; }

        private void OnRefreshExpenseCategoriesCommandExecuted(object p)
        {
            CategoryListExpense = dataManager.Categories.GetCategories()
            .Where(c => c.OperationType == "Expense")
            .Select(s => s.CategoryName)
            .ToList();
        }

        private bool CanRefreshExpenseCategoriesCommandExecute(object p)
        {
            return true;
        }

        #endregion
    }
}
