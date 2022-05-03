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
            mock.Setup(m => m.Employees).Returns((new Person[]
            {
                new Person {EmployeeID = 1, FirstName = "P1"},
                new Person {EmployeeID = 2, FirstName = "P2"}
            }).AsQueryable<Person>());

            HomeController controller = new HomeController(mock.Object);

            //act
            IEnumerable<Person>? result =
           (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Person>;

            //Assert
            Person[] empArray = result?.ToArray() ?? Array.Empty<Person>();
            Assert.True(empArray.Length == 2);
            Assert.Equal("P1", empArray[0].FirstName);
            Assert.Equal("P2", empArray[1].FirstName);

        }


    }
}