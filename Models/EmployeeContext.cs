using Microsoft.EntityFrameworkCore;
using WebApi.Maps;

namespace WebApi.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            new EmployeeMap(modelBuilder.Entity<Employee>());
        }
    }
}
