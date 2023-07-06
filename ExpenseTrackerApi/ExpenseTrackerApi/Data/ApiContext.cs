using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApi.Models;


namespace ExpenseTrackerApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {

        }
    }
}
