using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(EmpManagerDbContext context)
        {
            context.Database.Migrate();
            
            if (context.People.Count() == 0 && context.Departments.Count() == 0 && context.Locations.Count() == 0)
            {
                Department d1 = new Department { Name = "Intern" };
                Department d2 = new Department { Name = "IT" };
                Department d3 = new Department { Name = "Manufacturer" };
                Department d4 = new Department { Name = "Secratary" };

                context.Departments.AddRange(d1, d2, d3, d4);
                context.SaveChanges();

                Location l1 = new Location { City = "Chehalis", State = "WA" };
                Location l2 = new Location { City = "Centrilia", State = "WA" };
                Location l3 = new Location { City = "New York", State = "NY" };
                context.Locations.AddRange(l1, l2, l3);


                context.People.AddRange(
                    new Person { FirstName = "Jim", LastName = "Davis", Department =d1, Location = l2 },
                    new Person { FirstName = "John", LastName = "Schmitt", Department = d1, Location = l3 },
                    new Person { FirstName = "Jordan", LastName = "Neal", Department = d2, Location = l2 },
                    new Person { FirstName = "Rebecca", LastName = "Schnider", Department = d4, Location = l2 },
                    new Person { FirstName = "Yolanda", LastName = "Fredrick", Department = d3, Location = l1 },
                    new Person { FirstName = "Tina", LastName = "Gurtner", Department = d3, Location = l3 },
                    new Person { FirstName = "Freddy", LastName = "Rico", Department = d3, Location = l3 },
                    new Person { FirstName = "Chelsea", LastName = "Mendez", Department = d4, Location = l1 },
                    new Person { FirstName = "Thomas", LastName = "Zundel", Department = d2, Location = l1 }
                    );
                context.SaveChanges();
            }
        }
    }
}
