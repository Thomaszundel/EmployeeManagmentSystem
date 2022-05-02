using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Models
{
    public class EmpManagerDbContext : DbContext
    {
        public EmpManagerDbContext(DbContextOptions<EmpManagerDbContext> options)
            : base(options) { }
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
