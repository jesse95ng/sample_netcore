using Microsoft.EntityFrameworkCore;
using sample_netcore.Models.Entities;

namespace sample_netcore.Models.Context
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
        {

        }
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<DishCategory> DishCategories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Table> Tables { get; set; }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(ord => new { ord.OrderId, ord.DishId });
            modelBuilder.Entity<Employee>().HasIndex(e => e.EmpName);
        }
    }
}
