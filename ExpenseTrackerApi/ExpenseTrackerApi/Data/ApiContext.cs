using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApi.Models;


namespace ExpenseTrackerApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {

        }
    }
}
