using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new HistoryPage();
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddIncomePage();
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AddExpensePage();
        }

        private void GoToTest_Click(object sender, RoutedEventArgs e)
        {
            TestinWindow testin = new TestinWindow();
            testin.Show();
        }
    }
}

