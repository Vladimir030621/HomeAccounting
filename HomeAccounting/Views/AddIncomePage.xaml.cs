﻿using HomeAccounting.Models;
using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using HomeAccounting.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
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

            currentOperation.OperationType = "Income";
            currentOperation.Category = Category.Text;
            currentOperation.Date = Date.DisplayDate;
            currentOperation.Commentary = Commentary.Text;

            if(IsParsed && CheckNotNullOrWhiteSpace(Category.Text) && CheckNotNullOrWhiteSpace(Sum.Text))
            {
                dataManager.Operations.AddOperation(currentOperation);

                SuccessNotification();
            }  
        }

        private void SuccessNotification()
        {
            IncomeSuccessNotification.Text = "Operation completed successfully";
        }

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
    }
}