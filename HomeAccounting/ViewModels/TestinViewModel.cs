using HomeAccounting.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using HomeAccounting.Models;

namespace HomeAccounting.ViewModels
{
    public class TestinViewModel : ViewModel
    {
        private DataManager dataManager;

        public List<string> CategoryListIncomeTest { get; set; }

        public TestinViewModel()
        {

            dataManager = new DataManager();

            CategoryListIncomeTest = dataManager.Categories.GetCategories()
                .Where(c => c.OperationType == "Income")
                .Select(s => s.CategoryName)
                .ToList();

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            AddIncomeCommand = new LambdaCommand(OnAddIncomeCommandExecuted, CanAddIncomeCommandExecute);
        }



        private Operation _Operation;
        public Operation Operation
        { 
            get => _Operation; set => 
            Set(ref _Operation, value); 
        }


        private string _stringOperationType;
        public string StringOperationType
        {
            get => _stringOperationType; set =>
            Set(ref _stringOperationType, value);
        }


        #region Close command
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p)
        {
            return true;
        }
        #endregion

        public ICommand AddIncomeCommand { get; }

        private void OnAddIncomeCommandExecuted(object p)
        {
            Operation currentOperation = (Operation)p;
            var operation = new Operation();
            operation.OperationType = currentOperation.OperationType;
            operation.Category = currentOperation.Category;
            operation.Sum = currentOperation.Sum;
            operation.Date = currentOperation.Date;
            operation.Commentary = currentOperation.Commentary;

            dataManager.Operations.AddOperation(operation);
        }

        //private void OnAddIncomeCommandExecuted(object p)
        //{
        //    string str = (string)p;
        //    var operation = new Operation();
        //    operation.OperationType = str;
        //    operation.Sum = 1000;
        //    operation.Date = DateTime.Now;

        //    dataManager.Operations.AddOperation(operation);
        //}

        private bool CanAddIncomeCommandExecute(object p)
        {
            return true;
        }
    }
}
