using Microsoft.AspNetCore.Mvc;
using EmployeeManagmentSystem.Models;

namespace EmployeeManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository repository;
        public HomeController(IEmployeeRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index() => View(repository.Employees);
    }
}
