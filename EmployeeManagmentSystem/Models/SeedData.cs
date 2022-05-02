using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            EmpManagerDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<EmpManagerDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee { FirstName = "Jim", LastName = "Davis", Position = "Intern" },
                    new Employee { FirstName = "John", LastName = "Schmitt", Position = "Intern" },
                    new Employee { FirstName = "Jordan", LastName = "Neal", Position = "IT" },
                    new Employee { FirstName = "Rebecca", LastName = "Schnider", Position = "HR" },
                    new Employee { FirstName = "Yolanda", LastName = "Fredrick", Position = "Manufacturer" },
                    new Employee { FirstName = "Tina", LastName = "Gurtner", Position = "Manufacturer" },
                    new Employee { FirstName = "Freddy", LastName = "Rico", Position = "Manufacturer" },
                    new Employee { FirstName = "Chelsea", LastName = "Mendez", Position = "Secratary" },
                    new Employee { FirstName = "Thomas", LastName = "Zundel", Position = "IT" }
                    );
                context.SaveChanges();
            }
        }
    }
}
