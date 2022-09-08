using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // Context: Db tabloları ile proje classlarını bağlamak
    class NorthwindContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=RAMAZANKOSE;Database=Northwind;Trusted_Connection=True");
        }

        // Product nesnesi veritabanındaki Products tablosu ile bağla ilişkilendir
        public DbSet<Product> Products { get; set; }

        // Category nesnesi veritabanındaki Categories tablosu ile bağla ilişkilendir
        public DbSet<Category> Categories { get; set; }

        // Customer nesnesi veritabanındaki Customers tablosu ile bağla ilişkilendir
        public DbSet<Customer> Customers { get; set; }



    }
}
