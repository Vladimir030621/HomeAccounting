﻿using HomeAccounting.Commands;
using HomeAccounting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeAccounting.ViewModels
{
    class AddIncomeCategoryViewModel : ViewModel
    {
        private DataManager dataManager;

        public Action CloseAction { get; set; }

        public AddIncomeCategoryViewModel()
        {
            dataManager = new DataManager();

            SaveIncomeCategoryCommand =
                new LambdaCommand(OnSaveIncomeCategoryCommandExecuted, CanSaveIncomeCategoryCommandExecute);         
        }

        #region CatogoryToSave viewmodel property

        /// <summary> CatogoryToSave viewmodel property </summary>
        private string _CategoryToSave;
        public string CategoryToSave
        {
            get => _CategoryToSave; 
            set => Set(ref _CategoryToSave, value); 
        }

        #endregion

        #region Save Income Catogory command

        public ICommand SaveIncomeCategoryCommand { get; }

        private void OnSaveIncomeCategoryCommandExecuted(object p)
        {
            string currentCategory = (string)p;
            if (string.IsNullOrWhiteSpace(nameof(currentCategory)))
            {
                throw new ArgumentNullException("Category name cannot be empty", nameof(currentCategory));
            }

            Category category = new Category();
            category.CategoryName = currentCategory;
            category.OperationType = "Income";

            if(currentCategory != null)
            {
                dataManager.Categories.AddCategory(category);
                CloseAction();
            }    
        }

        private bool CanSaveIncomeCategoryCommandExecute(object p)
        {
            string currentCategory = (string)p;

            if (string.IsNullOrWhiteSpace(nameof(currentCategory)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

    }
}
