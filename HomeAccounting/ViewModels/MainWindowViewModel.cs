using HomeAccounting.Commands;
using HomeAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace HomeAccounting.ViewModels
{
    class MainWindowViewModel : DependencyObject
    {
        private DataManager dataManager;

        public MainWindowViewModel()
        {
            dataManager = new DataManager();

            var currentBalance = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Income").Select(o => o.Sum).Sum(s => s) -
                dataManager.Operations.GetOperations().Where(o => o.OperationType == "Expense").Select(o => o.Sum).Sum(s => s);

            Balance = currentBalance.ToString();

            CloseWindowCommand = new LambdaCommand(OnCloseWindowCommandExecuted, CanCloseWindowCommandExecute);
        }

        public string Balance
        {
            get { return (string)GetValue(BalanceProperty); }
            set { SetValue(BalanceProperty, value); }
        }

        public static readonly DependencyProperty BalanceProperty =
            DependencyProperty.Register("Balance", typeof(string), typeof(MainWindowViewModel), new PropertyMetadata(null));

        #region Close command

        public ICommand CloseWindowCommand { get; }

        private void OnCloseWindowCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseWindowCommandExecute(object p)
        {
            return true;
        }
        #endregion
    }
}
