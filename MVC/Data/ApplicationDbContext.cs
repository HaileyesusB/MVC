using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options ) : base( options )
        {

        }
        public DbSet<Item> Items { get; set; }

        public DbSet<Expense> Expense { get; set; }

        public DbSet <ExpenseType> ExpenseType { get; set; }
    }
}
