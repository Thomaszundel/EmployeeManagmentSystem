using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Models
{
    public class EmpManagerDbContext : DbContext
    {
        public EmpManagerDbContext(DbContextOptions<EmpManagerDbContext> opts)
            : base(opts) { }
        public DbSet<Person> People => Set<Person>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Location> Locations => Set<Location>();
    }
}
