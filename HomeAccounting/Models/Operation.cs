using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models
{
    public class Operation
    {
        public int Id { get; set; }

        public string OperationType { get; set; }

        public string Category { get; set; }

        public decimal Sum { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public string Commentary { get; set; }

        public List<string> Categories { get; set; }
    }
}
