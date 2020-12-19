using Desktop.Callers;
using Desktop.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
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
            City city = null;
            bool res = false;

            CityCaller cityCaller = new CityCaller("https://dawa.aws.dk");

            //Act
            try
            {
                city = cityCaller.GetByZipCode("1234").Result;
            }
            catch
            {
                res = true;
            }

            //Assert
            Assert.IsNull(city);
            Assert.AreEqual(true, res);
        }
    }
}