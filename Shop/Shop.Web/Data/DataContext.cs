using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
    }
}
