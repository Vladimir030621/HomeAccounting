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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public HistoryPage()
        {
            InitializeComponent();

            DataContext = new HistoryPageViewModel();
            //Loaded += HistoryPage_Loaded;
        }

        //private void HistoryPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    DataContext = new HistoryPageViewModel();
        //}
    }
}
