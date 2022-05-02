namespace EmployeeManagmentSystem.Models
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private EmpManagerDbContext context;

        public EFEmployeeRepository(EmpManagerDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Employee> Employees => context.Employees;

    }
}
