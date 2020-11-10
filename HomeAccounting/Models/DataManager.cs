using HomeAccounting.Models.Interfaces;
using HomeAccounting.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models
{
    public class DataManager
    {
        private IOperationRepository operationRepository;
        private ICategoryRepository categoryRepository;

        public DataManager()
        {
            operationRepository = new OperationRepository();
            categoryRepository = new CategoryRepository();
        }

        public IOperationRepository Operations { get { return operationRepository; } }

        public ICategoryRepository Categories { get { return categoryRepository; } }
    }
}
