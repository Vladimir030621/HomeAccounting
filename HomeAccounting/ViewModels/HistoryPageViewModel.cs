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
            Operations = CollectionViewSource.GetDefaultView(dataManager.Operations.GetOperations().OrderBy(o => o.Date));
        }

        #region FilterText dependency object property

        /// <summary> FilterText dependency object property </summary>
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(HistoryPageViewModel), new PropertyMetadata("", FilterText_Changed));

        #endregion

        #region FilterText_changed methods

        /// <summary> FilterText_changed method </summary>
        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as HistoryPageViewModel;
            if(current != null)
            {
                current.Operations.Filter = null;
                current.Operations.Filter = current.FilterOperation;
            }
        }

        /// <summary> FilterText_changed method </summary>
        private bool FilterOperation(object obj)
        {
            bool result = true;
            Operation current = obj as Operation;

            if(!string.IsNullOrWhiteSpace(FilterText) 
                && current != null 
                && !current.OperationType.ToLower().Contains(FilterText.ToLower()) 
                && !current.Category.ToLower().Contains(FilterText.ToLower()))
            {
                return false;
            }
            return result;
        }

        #endregion

        #region Operations dependency object property

        /// <summary> Operations dependency object property </summary>
        public ICollectionView Operations
        {
            get { return (ICollectionView)GetValue(OperationsProperty); }
            set { SetValue(OperationsProperty, value); }
        }

        public static readonly DependencyProperty OperationsProperty =
            DependencyProperty.Register("Operations", typeof(ICollectionView), typeof(HistoryPageViewModel), new PropertyMetadata(null));
       
        #endregion

    }
}
