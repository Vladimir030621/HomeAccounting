using HomeAccounting.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private AppDBContext context;

        public OperationRepository()
        {
            context = new AppDBContext();
        }

        public IEnumerable<Operation> GetOperations()
        {
            return context.Operations.ToList();
        }

        public void AddOperation(Operation operation)
        {
            context.Operations.Add(operation);
            context.SaveChanges();
        }
    }
}
