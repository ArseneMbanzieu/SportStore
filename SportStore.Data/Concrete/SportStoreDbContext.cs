using SportStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStore.Data.Concrete
{
    class SportStoreDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
