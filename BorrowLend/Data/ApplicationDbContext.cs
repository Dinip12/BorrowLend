using BorrowLend.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace BorrowLend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpensesType { get; set; }
        public ApplicationDbContext() : base("Server=(localdb)\\mssqllocaldb;Database=DbContext;Trusted_Connection=True;")
        {
            Items = this.Set<Item>();
            Expenses = this.Set<Expense>();
            ExpensesType = this.Set<ExpenseType>();
        }
    }
}
