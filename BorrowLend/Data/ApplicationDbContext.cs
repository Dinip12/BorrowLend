using BorrowLend.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace BorrowLend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=DbContext;Trusted_Connection=True;")
        {
            Items = this.Set<Item>();

        }
    }
}
