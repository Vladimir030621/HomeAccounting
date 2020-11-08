using HomeAccounting.Models;
using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using HomeAccounting.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private IOperationRepository context;

        public HomePage()
        {
            InitializeComponent();

            context = new OperationRepository();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            //Operation currentOperation = new Operation();
            //HomePageViewModel homePageViewModel = new HomePageViewModel();
            //currentOperation.OperationType = homePageViewModel.OperationType;

       
            //context.AddOperation(currentOperation);
        }
    }
}
