using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("DBConnection")
        {

        }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
