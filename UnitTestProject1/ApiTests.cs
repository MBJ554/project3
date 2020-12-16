using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using API;
using API.Controllers;
using API.DAL.Interfaces;
using API.DAL.Models;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class ApiTests
    {
        private static string customerEmailGood = "admin@admin.com";
        private static string customerEmailBad = "customer123";
        private static string customerPasswordGood = "password";
        private static string customerPasswordBad = "123";
        private static int customerIdGood = 1;
        private static int customerIdBad = 2;

        [ClassInitialize]
        public static void HostWebAPI(TestContext testContext)
        {

        }

        [TestMethod]
        public void GetByIdGoodId()
        {
            //Arrange
            var mock = new Mock<ICustomerRepository>();
            var customer = new Customer
            {
                Id = 2,
                PersonTypeId = 2,
                ClinicId = 2,
                PractitionerId = 1,
                RehabProgramId = 1,
                FirstName = "Bob",
                LastName = "Bobsen",
                PhoneNo = "50718449",
                Email = "mail@mail.com",
                PasswordHash = "sadasdadwdawdsdadas",
                Address = "vejen 2",
                ZipCode = "7470",
                CityName = "Karup J",
            };
            mock.Setup(x => x.GetById(customerIdGood)).Returns(customer);
            var customerController = new CustomerController(mock.Object);

            //Act

            var actionResult = customerController.GetById(customerIdGood);

            //OkNegotiatedContentResult<Customer> result = Assert.IsInstanceOfType(actionResult , OkNegotiatedContentResult<Customer>);
            var result = actionResult as OkObjectResult;

            //Assert
            //Assert.AreEqual("7470" , actionResult.Content);
       
        }

    }
}
