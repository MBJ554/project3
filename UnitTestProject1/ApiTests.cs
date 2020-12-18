using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using API;
using API.Controllers;
using API.DAL.Interfaces;
using API.DAL.Models;
using API.Models;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using API.DAL.Exceptions;

namespace UnitTestProject1
{
    [TestClass]
    public class ApiTests
    {

        [ClassInitialize]
        public static void HostWebAPI(TestContext testContext)
        {

        }

        [TestMethod]
        public void GetByIdGoodId()
        {
            //Arrange
            int customerIdGood = 1;

            var mock = new Mock<ICustomerRepository>();
            var customer = new API.DAL.Models.Customer
            {
                Id = 1,
                PersonTypeId = 2,
                ClinicId = 2,
                PractitionerId = 1,
                RehabProgramId = 1,
                FirstName = "Customer",
                LastName = "Jensen",
                PhoneNo = "11111111",
                Email = "admin@admin.desktop",
                PasswordHash = "password",
                Address = "vejen 2",
                ZipCode = "7470",
                CityName = "Karup J",
            };

            mock.Setup(x => x.GetById(customerIdGood)).Returns(customer);
            var customerController = new CustomerController(mock.Object);
            var expectedCustomer = mock.Object.GetById(customerIdGood);
           

            //Act
            var actionResult = customerController.GetById(customerIdGood);

                var result = actionResult as OkNegotiatedContentResult<API.Models.Customer>;




            //Assert
            //Assert.AreEqual(actionResult, (int)HttpStatusCode.OK);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCustomer.Id, result.Content.Id);
        }


        [TestMethod]
        public void GetByIdBadId()
        {
            //Arrange
            int customerIdGood = 1;
            int customerIdBad = 2;

            var mock = new Mock<ICustomerRepository>();
            var customer = new API.DAL.Models.Customer
            {
                Id = 1,
                PersonTypeId = 2,
                ClinicId = 1,
                FirstName = "Admin",
                LastName = "Jensen",
                PhoneNo = "22222222",
                Email = "admin@admin.desktop",
                PasswordHash = "password",
                CityName = "Karup J",
            };

            mock.Setup(x => x.GetById(customerIdGood)).Returns(customer);
            var customerController = new CustomerController(mock.Object);
            var expectedCustomer = mock.Object.GetById(customerIdBad);
           
            //Act
            var actionResult = customerController.GetById(customerIdBad);
            var result = actionResult as OkNegotiatedContentResult<API.Models.Customer>;
            
           

            //Assert
            //Assert.AreEqual(actionResult, (int)HttpStatusCode.OK);
            Assert.IsNull(expectedCustomer);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CustomerLoginSuccess()
        {
            //Arrange
            string customerEmailGood = "admin@admin.desktop";
            string customerPasswordGood = "password";

            var mock = new Mock<ICustomerRepository>();
            var customer = new API.DAL.Models.Customer
            {
                Id = 1,
                PersonTypeId = 2,
                ClinicId = 1,
                FirstName = "Admin",
                LastName = "Jensen",
                PhoneNo = "22222222",
                Email = "admin@admin.desktop",
                PasswordHash = "password",
                CityName = "Karup J",
            };

            mock.Setup(x => x.IsAuthorized(customerEmailGood, customerPasswordGood)).Returns(customer);
            var customerController = new CustomerController(mock.Object);
            var expectedCustomer = mock.Object.IsAuthorized(customerEmailGood, customerPasswordGood);

            //Act

            LoginInfo login = new LoginInfo();
            login.Email = customerEmailGood;
            login.Password = customerPasswordGood;

            var actionResult = customerController.Login(login);
            var result = actionResult as OkNegotiatedContentResult<API.Models.Customer>;
           
            //Assert
            //Assert.AreEqual(actionResult, (int)HttpStatusCode.OK);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCustomer.Id, result.Content.Id);
        }

        [TestMethod]
        public void CustomerLoginFail()
        {
            //Arrange
            string customerEmailGood = "admin@admin.desktop";
            string customerPasswordBad = "badpassword";
            string customerPasswordGood = "password";
            
            var mock = new Mock<ICustomerRepository>();
            var customer = new API.DAL.Models.Customer
            {
                Id = 1,
                PersonTypeId = 2,
                ClinicId = 1,
                FirstName = "Admin",
                LastName = "Jensen",
                PhoneNo = "22222222",
                Email = "admin@admin.desktop",
                PasswordHash = "password",
                CityName = "Karup J",
            };

            mock.Setup(x => x.IsAuthorized(customerEmailGood, customerPasswordGood)).Returns(customer);
            var customerController = new CustomerController(mock.Object);
            var expectedCustomer = mock.Object.IsAuthorized(customerEmailGood, customerPasswordBad);
           
            LoginInfo login = new LoginInfo();
            login.Email = customerEmailGood;
            login.Password = customerPasswordBad;

            //Act      
            var actionResult = customerController.Login(login);
            var result = actionResult as OkNegotiatedContentResult<API.Models.Customer>;
          

            //Assert
            Assert.IsNull(expectedCustomer);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void PractitionerLoginSuccess()
        {
            //Arrange
            string practitionerEmailGood = "admin@admin.desktop";
            string practitionerPasswordGood = "password";
            
            var mock = new Mock<IPractitionerRepository>();
            var practitioner = new API.DAL.Models.Practitioner
            {
                Id = 2,
                PersonTypeId = 2,
                ClinicId = 1,
                FirstName = "Admin",
                LastName = "Jensen",
                PhoneNo = "22222222",
                Email = "admin@admin.desktop",
                PasswordHash = "password",                
            };

            mock.Setup(x => x.IsAuthorized(practitionerEmailGood, practitionerPasswordGood)).Returns(practitioner);
            var practitionerController = new PractitionerController(mock.Object);
            var expectedPractitioner = mock.Object.IsAuthorized(practitionerEmailGood, practitionerPasswordGood);

            LoginInfo login = new LoginInfo();
            login.Email = practitionerEmailGood;
            login.Password = practitionerPasswordGood;
            
            //Act
            var actionResult = practitionerController.Login(login);
            var result = actionResult as OkNegotiatedContentResult<API.Models.Practitioner>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPractitioner.Id, result.Content.Id);
        }

        [TestMethod]
        public void PractitionerLoginFail()
        {
            //Arrange
            string practitionerEmailGood = "admin@admin.desktop";
            string practitionerPasswordGood = "password";
            string practitionerPasswordBad = "badpassword";
            
            var mock = new Mock<IPractitionerRepository>();           
            var practitioner = new API.DAL.Models.Practitioner
            {
                Id = 2,
                PersonTypeId = 2,
                ClinicId = 1,
                FirstName = "Admin",
                LastName = "Jensen",
                PhoneNo = "22222222",
                Email = "admin@admin.desktop",
                PasswordHash = "password",
            };

            mock.Setup(x => x.IsAuthorized(practitionerEmailGood, practitionerPasswordGood)).Returns(practitioner);
            var practitionerController = new PractitionerController(mock.Object);
            var expectedPractitioner = mock.Object.IsAuthorized(practitionerEmailGood, practitionerPasswordBad);

            LoginInfo login = new LoginInfo();
            login.Email = practitionerEmailGood;
            login.Password = practitionerPasswordBad;

            //Act
            var actionResult = practitionerController.Login(login);
            var result = actionResult as OkNegotiatedContentResult<API.Models.Practitioner>;

            //Assert
            Assert.IsNull(expectedPractitioner);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ChooseAppointmentDay()
        {
            //Arrange
            var mock = new Mock<IAppointmentRepository>();
            DateTime appointmentDay = new DateTime(2020, 12, 24);
            int practitionerIdGood = 1;

            List<API.DAL.Models.Appointment> takenAppointments = new List<API.DAL.Models.Appointment>();
            API.DAL.Models.Appointment mockAppointment1 = new API.DAL.Models.Appointment {
                PractitionerId = 1,
                Startdate = new DateTime(2020, 12, 24, 8, 0, 0),
                Enddate = new DateTime(2020, 12, 24, 8, 30, 0)
            };

            API.DAL.Models.Appointment mockAppointment2 = new API.DAL.Models.Appointment
            {
                PractitionerId = 1,
                Startdate = new DateTime(2020, 12, 24, 8, 30, 0),
                Enddate = new DateTime(2020, 12, 24, 9, 0, 0)
            };

            takenAppointments.Add(mockAppointment1);
            takenAppointments.Add(mockAppointment2);

            mock.Setup(x => x.GetAllByPractitionerAndDate(appointmentDay, practitionerIdGood)).Returns(takenAppointments);
            List<API.DAL.Models.Appointment> expectedTakenAppointments = (List<API.DAL.Models.Appointment>)mock.Object.GetAllByPractitionerAndDate(appointmentDay, practitionerIdGood);
            var appointmentController = new AppointmentController(mock.Object);

            //Act
            var actionResult = appointmentController.Get(practitionerIdGood, appointmentDay.ToString());
            var result = actionResult as OkNegotiatedContentResult<IEnumerable<API.Models.Appointment>>;
            IEnumerable<API.Models.Appointment> enumerableList = result.Content;           
            List<API.Models.Appointment> allowedAppointments = enumerableList.ToList();
            

            //Assert
            Assert.AreEqual((14 - expectedTakenAppointments.Count), allowedAppointments.Count);
        }

        //TODO passer altid hvis der ikke bliver kastet en exception, så interfacet skal kaste en exception ved en metode der ikke er 
        //mockAppointment

        [TestMethod]
        public void BookAppointmentSuccess()
        {
            // Arrange

            var mock = new Mock<IAppointmentRepository>();

            API.DAL.Models.Appointment mockAppointment = new API.DAL.Models.Appointment
            {
                PractitionerId = 1,
                Startdate = new DateTime(2020, 12, 24, 8, 0, 0),
                Enddate = new DateTime(2020, 12, 24, 8, 30, 0),
                CustomerId = 2
            };

            //tiden skal rykkes en time da der converteres fra utc til localtime.
            API.Models.Appointment mockAppointment1 = new API.Models.Appointment
            {
                Practitioner = "1",
                Startdate = new DateTime(2020, 12, 24, 7, 0, 0),
                Enddate = new DateTime(2020, 12, 24, 7, 30, 0),
                Customer = "2"
            };


            mock.Setup(x => x.Create(mockAppointment));
            var appointmentController = new AppointmentController(mock.Object);

            // Act
            IHttpActionResult actionResult = appointmentController.Post(mockAppointment1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(System.Web.Http.Results.OkResult));
        }

        //TODO throw exception fungerer ikke

        [TestMethod]
        public void BookAppointmentFail()
        {
            // Arrange

            var mock = new Mock<IAppointmentRepository>();

            API.DAL.Models.Appointment mockAppointment = new API.DAL.Models.Appointment
            {
                PractitionerId = 1,
                Startdate = new DateTime(2020, 12, 24, 8, 0, 0),
                Enddate = new DateTime(2020, 12, 24, 8, 30, 0),
                CustomerId = 2
            };

            API.Models.Appointment mockAppointment1 = new API.Models.Appointment
            {
                Practitioner = "1",
                Startdate = new DateTime(2020, 12, 24, 7, 0, 0),
                Enddate = new DateTime(2020, 12, 24, 7, 30, 0),
                Customer = "2"
            };


            mock.Setup(x => x.Create(mockAppointment)).Throws(new API.DAL.Exceptions.DataAccessException("Der gik noget galt", new Exception()));
            
            var appointmentController = new AppointmentController(mock.Object);

            // Act
            IHttpActionResult actionResult = appointmentController.Post(mockAppointment1);
            
            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(System.Web.Http.Results.ConflictResult));
        }
    }
}
