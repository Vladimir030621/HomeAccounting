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
    class AddIncomeViewModel : DependencyObject
    {
        private DataManager dataManager;

        public AddIncomeViewModel()
        {
            dataManager = new DataManager();

            CategoryListIncome = dataManager.Categories.GetCategories()
                .Where(c => c.OperationType == "Income")
                .Select(s => s.CategoryName)
                .ToList();

            RefreshCategoriesCommand = new LambdaCommand(OnRefreshCategoriesCommandExecuted, CanRefreshCategoriesCommandExecute);
        }

        #region CategoryListIncome dependency object property

        /// <summary> CategoryListIncome dependency object property </summary>
        public List<string> CategoryListIncome
        {
            get { return (List<string>)GetValue(CategoryListIncomeProperty); }
            set { SetValue(CategoryListIncomeProperty, value); }
        }

        public static readonly DependencyProperty CategoryListIncomeProperty =
            DependencyProperty.Register("CategoryListIncome", typeof(List<string>), typeof(AddIncomeViewModel), new PropertyMetadata(null));

        #endregion

        #region Refresh categories command

        public ICommand RefreshCategoriesCommand { get; }

        private void OnRefreshCategoriesCommandExecuted(object p)
        {
            CategoryListIncome = dataManager.Categories.GetCategories()
            .Where(c => c.OperationType == "Income")
            .Select(s => s.CategoryName)
            .ToList();
        }

        private bool CanRefreshCategoriesCommandExecute(object p)
        {
            return true;
        }

        #endregion
    }
}
