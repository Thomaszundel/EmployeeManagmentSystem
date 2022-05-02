using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using EmployeeManagmentSystem.Controllers;
using EmployeeManagmentSystem.Models;
using Xunit;
namespace EmpManagmentTestProject1
{
    public class HomeControllersTest
    {
        [Fact]
        public void Can_Use_Repository()
        {
            //arrange

            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.Employees).Returns((new Employee[]
            {
                new Employee {EmployeeID = 1, FirstName = "P1"},
                new Employee {EmployeeID = 2, FirstName = "P2"}
            }).AsQueryable<Employee>());

            HomeController controller = new HomeController(mock.Object);

            //act
            IEnumerable<Employee>? result =
           (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Employee>;

            //Assert
            Employee[] empArray = result?.ToArray() ?? Array.Empty<Employee>();
            Assert.True(empArray.Length == 2);
            Assert.Equal("P1", empArray[0].FirstName);
            Assert.Equal("P2", empArray[1].FirstName);

        }


    }
}