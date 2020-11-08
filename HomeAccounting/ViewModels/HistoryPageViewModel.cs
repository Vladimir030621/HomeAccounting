using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.ViewModels
{
    public class HistoryPageViewModel : ViewModel
    {
        private string _Title = "Hello";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
