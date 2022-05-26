using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentSystem.Models
{
    public class Person
    {
        public long PersonId { get; set; }
        [Required(ErrorMessage = "A firstname is required")]
        [MinLength(3, ErrorMessage ="Firstnames must be 3 or more characters")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "A lastname is required")]
        [MinLength(3, ErrorMessage = "Lastnames must be 3 or more characters")]
        public string LastName { get; set; } = String.Empty;

        [Range (1,long.MaxValue, ErrorMessage ="A department must be selected")]
        public long DepartmentId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "A location must be selected")]
        public long LocationId { get; set; }

        public Department? Department { get; set; }
        public Location? Location { get; set; }
    }
}
