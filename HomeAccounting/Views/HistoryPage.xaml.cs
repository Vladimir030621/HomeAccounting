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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private IOperationRepository context;

        public HistoryPage()
        {
            InitializeComponent();

            context = new OperationRepository();

            Loaded += List_Loaded;
        }


        private void List_Loaded(object sender, RoutedEventArgs e)
        {
            lbOperation.ItemsSource = context.GetOperations();
        }
    }
}
