using HomeAccounting.Models;
using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace HomeAccounting.ViewModels
{
    public class HistoryPageViewModel : DependencyObject
    {
        private DataManager dataManager;
        
        public HistoryPageViewModel()
        {
            dataManager = new DataManager();
            Operations = CollectionViewSource.GetDefaultView(dataManager.Operations.GetOperations());
        }

        public ICollectionView Operations
        {
            get { return (ICollectionView)GetValue(OperationsProperty); }
            set { SetValue(OperationsProperty, value); }
        }

        public static readonly DependencyProperty OperationsProperty =
            DependencyProperty.Register("Operations", typeof(ICollectionView), typeof(HistoryPageViewModel), new PropertyMetadata(null));

    }
}
