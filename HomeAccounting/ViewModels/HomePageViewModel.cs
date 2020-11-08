using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.ViewModels
{
    public class HomePageViewModel : ViewModel
    {
        private string _OperationType = "operationType";

        public string OperationType
        {
            get => _OperationType;
            set => Set(ref _OperationType, value);
        }
    }
}
