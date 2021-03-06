﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models.Interfaces
{
    public interface IOperationRepository
    {
        IEnumerable<Operation> GetOperations();

        void AddOperation(Operation operation);
    }
}
