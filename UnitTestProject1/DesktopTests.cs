using System;
using Desktop.Callers;
using Desktop.Models;
using Desktop.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DesktopTests
    {
        [TestMethod]
        public void CityApiSuccess()
        {
            //Arrange
            City city;
            CityCaller cityCaller = new CityCaller("https://dawa.aws.dk");

            //Act
            city = cityCaller.GetByZipCode("7470").Result;

            //Assert
            Assert.AreEqual("Karup J", city.CityName);
        }


        [TestMethod]
        public void CityApiFail()
        {
            //Arrange
            City city;
            CityCaller cityCaller = new CityCaller("https://dawa.aws.dk");
            bool res = false;


            //Act
            try
            {
                city = cityCaller.GetByZipCode("1234").Result;
                
            }
            catch (Exception e)
            {
                res = true;
            }

            //Assert
            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void CustomerViewViewModel()
        {
            //Arrange
            ViewModelCreateCustomer vievModelCreateCustomer = new ViewModelCreateCustomer();
            vievModelCreateCustomer.Customer.Address = "vejen 2";
            vievModelCreateCustomer.Customer.City = "Karup J";
            vievModelCreateCustomer.Customer.ClinicId = 1;
            bool res = false;
            //Act
            

            //Assert
            Assert.AreEqual(true, res);
        }

    }
}
