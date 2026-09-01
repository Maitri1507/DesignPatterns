using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CRUD.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John Doe", Email = "john@example.com", Salary = 10000 },
                new Employee { Id = 2, Name = "Maitri Rana", Email = "maitri@example.com", Salary = 12000 },
                new Employee { Id = 3, Name = "Sarah Smith", Email = "sarah@example.com", Salary = 11000 }
            );
        }

    }
}
