using API.DAL.Interfaces;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CityController : ApiController
    { 
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        /// <summary>
        /// Gets all cities
        /// </summary>
        /// <returns>List of all cities</returns>
        // GET: api/City
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<City> cities = new List<City>();
            var citiesDAL = _cityRepository.GetAll();
            if (citiesDAL.Count() == 0)
            {
                return NotFound();
            }
            foreach (var city in citiesDAL)
            {
                cities.Add(BuildCity(city));
            }
            return Ok(cities);
        }

        /// <summary>
        /// Gets a specific city from an zipcode
        /// </summary>
        /// <param name="zipcode">The zipcode of the city to get </param>
        /// <returns>A city</returns>
        // GET: api/City/5
        [HttpGet]
        public IHttpActionResult Get(string zipcode)
        {
            var cityDAL = _cityRepository.GetCityByZipCode(zipcode);
            if (cityDAL != null)
            {
                return Ok(BuildCity(cityDAL));
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a new city
        /// </summary>
        /// <param name="city">The city that is being created</param>
        // POST: api/City
        [HttpPost]
        public void Post([FromBody]API.DAL.Models.City city)
        {
            _cityRepository.Create(city);
        }

        /// <summary>
        /// Deletes a specific city
        /// </summary>
        /// <param name="zipCode">The zipcode of the city</param>
        /// <returns>OkResult if the city is deleted</returns>
        // DELETE: api/City/5
        [HttpDelete]
        public IHttpActionResult Delete(string zipCode)
        {
            if (_cityRepository.DeleteByZipCode(zipCode))
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Converts city DAL model to customer API model
        /// </summary>
        /// <param name="city">City to convert</param>
        /// <returns>Converted city</returns>
        private City BuildCity(API.DAL.Models.City city)
        {
            return new City
            {
                ZipCode = city.ZipCode,
                CityName = city.CityName
            };
        }
    }
}
