using HomeAccounting.Models;
using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using HomeAccounting.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeAccounting.Views
{
    /// <summary>
    /// Логика взаимодействия для AddIncomePage.xaml
    /// </summary>
    public partial class AddIncomePage : Page
    {
        private DataManager dataManager;

        public AddIncomePage()
        {
            InitializeComponent();

            DataContext = new AddIncomeViewModel();

            dataManager = new DataManager();

        }

        #region Add Income operation

        /// <summary> Add income operation </summary>

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            bool IsParsed = false;
            Operation currentOperation = new Operation();

            if (!CheckNotNullOrWhiteSpace(Category.Text) || !CheckNotNullOrWhiteSpace(Sum.Text))
            {
                MessageBox.Show("Fill in all required fields, please");
            }

            if (decimal.TryParse(Sum.Text, out decimal sumParsed))
            {
                currentOperation.Sum = sumParsed;
                IsParsed = true;
            }
            else
            {
                MessageBox.Show("Incorrect 'Sum' Input");
            }        

            if (!CheckNotNullOrWhiteSpace(Date.SelectedDate.ToString()))
            {
                MessageBox.Show("Choose a Date");
            }
            else if (Date.SelectedDate is DateTime)
            {
                currentOperation.Date = (DateTime)Date.SelectedDate;
            }
            else
            {
                MessageBox.Show("Incorrect 'Date' input");
            }


            decimal currentBalance = dataManager.Operations.GetOperations().Where(o => o.OperationType == "Income").Select(o => o.Sum).Sum(s => s) -
            dataManager.Operations.GetOperations().Where(o => o.OperationType == "Expense").Select(o => o.Sum).Sum(s => s);


            currentOperation.OperationType = "Income";
            currentOperation.Category = Category.Text;
            currentOperation.Commentary = Commentary.Text;
            currentOperation.Total = currentBalance + currentOperation.Sum;


            if (IsParsed && CheckNotNullOrWhiteSpace(Category.Text) && CheckNotNullOrWhiteSpace(Sum.Text) && CheckNotNullOrWhiteSpace(Date.SelectedDate.ToString()))
            {
                dataManager.Operations.AddOperation(currentOperation);

                SuccessNotification();

                Category.Text = "";
                Sum.Text = "";
                Date.SelectedDate = null;
                Commentary.Text = "";
            }
        }

        #endregion

        /// <summary> Show messageBox if succeeded </summary>
        private void SuccessNotification()
        {
            IncomeSuccessNotification.Text = "Operation completed successfully";
        }

        /// <summary> Checking for a null </summary>
        private bool CheckNotNullOrWhiteSpace(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary> Open add category window </summary>
        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            AddIncomeCategoryWindow addIncomeCategoryWindow = new AddIncomeCategoryWindow();
            addIncomeCategoryWindow.Show();
        }
    }
}
