using HomeAccounting.Commands;
using HomeAccounting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeAccounting.ViewModels
{
    class AddExpenseCategoryViewModel : ViewModel
    {
        private DataManager dataManager;

        public Action CloseAction { get; set; }

        public AddExpenseCategoryViewModel()
        {
            dataManager = new DataManager();

            SaveExpenseCategoryCommand =
                new LambdaCommand(OnSaveExpenseCategoryCommandExecuted, CanSaveExpenseCategoryCommandExecute);
        }

        #region CategoryExpenseToSave property

        /// <summary> CategoryExpenseToSave viewmodel property</summary>
        private string _CategoryExpenseToSave;
        public string CategoryExpenseToSave
        {
            get => _CategoryExpenseToSave;
            set => Set(ref _CategoryExpenseToSave, value);
        }

        #endregion

        #region Save expense category command

        public ICommand SaveExpenseCategoryCommand { get; }

        private void OnSaveExpenseCategoryCommandExecuted(object p)
        {
            string currentCategory = (string)p;

            if (string.IsNullOrWhiteSpace(nameof(currentCategory)))
            {
                throw new ArgumentNullException("Category name cannot be empty", nameof(currentCategory));
            }

            Category category = new Category();
            category.CategoryName = currentCategory;
            category.OperationType = "Expense";

            if (currentCategory != null)
            {
                dataManager.Categories.AddCategory(category);
                CloseAction();
            }
        }

        private bool CanSaveExpenseCategoryCommandExecute(object p)
        {
            string currentCategory = (string)p;

            if (string.IsNullOrWhiteSpace(nameof(currentCategory)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
