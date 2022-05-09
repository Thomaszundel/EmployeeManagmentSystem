using EmployeeManagmentSystem.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagmentSystem.Blazor
{
    public partial class Split
    {
        [Inject]
        public EmpManagerDbContext? Context { get; set; }

        public IEnumerable<string> Names => Context?.People.Select(p => p.FirstName) ?? Enumerable.Empty<string>();
    }
}
