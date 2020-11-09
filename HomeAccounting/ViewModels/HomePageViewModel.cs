using HomeAccounting.Models;
using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace HomeAccounting.ViewModels
{
    public class HomePageViewModel : ViewModel
    {
        private ICategoryRepository context;

        public List<string> CategoryList { get; set; }

        public HomePageViewModel()
        {
            context = new CategoryRepository();

            CategoryList = context.GetCategories().Where(c => c.OperationType == "Expense").Select(s => s.CategoryName).ToList();
        }


        //private string _OperationType;

        //public string OperationType
        //{
        //    get => OperationType;
        //    set => Set(ref _OperationType, value);
        //}
    }
}
