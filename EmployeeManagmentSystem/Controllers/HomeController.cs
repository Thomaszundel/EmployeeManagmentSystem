using EmployeeManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private EmpManagerDbContext context;
        
        public HomeController(EmpManagerDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index([FromQuery]string selectedCity)
        {
            return View(new PeopleListViewModel
            {
                People = context.People.Include(p => p.Department).Include(p => p.Location),
                Cities = context.Locations.Select(l => l.City).Distinct(),
                SelectedCity = selectedCity
            });
        }
    }

    public class PeopleListViewModel
    {
        public IEnumerable<Person> People { get; set; } = Enumerable.Empty<Person>();
        public IEnumerable<string> Cities { get; set; } = Enumerable.Empty<string>();
        public string SelectedCity { get; set; } = string.Empty;

        public string GetClass(string? city) => SelectedCity == city ? "bg-info text-white" : "";
    }
}
