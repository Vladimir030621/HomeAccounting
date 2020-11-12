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
using System.Windows.Shapes;

namespace HomeAccounting.Views
{
    /// <summary>
    /// Логика взаимодействия для AddExpenseCategoryWindow.xaml
    /// </summary>
    public partial class AddExpenseCategoryWindow : Window
    {
        public AddExpenseCategoryWindow()
        {
            InitializeComponent();

            AddExpenseCategoryViewModel vm = new AddExpenseCategoryViewModel();
            this.DataContext = vm;
            if (vm.CloseAction == null)
                vm.CloseAction = new Action(this.Close);
        }

        /// <summary> Close window </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
