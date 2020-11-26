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
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        private readonly ICityRepository _cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

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


        
        // GET: api/City/GetById
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var cityDAL = _cityRepository.GetCityByZipCode(id);
            if (cityDAL != null)
            {
                return Ok(BuildCity(cityDAL));
            }
            return NotFound();
        }

        // POST: api/City
        public void Post([FromBody]City city)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[City] ([zipCode], [city]) VALUES (@zipCode, @city)";
                conn.Execute(sql, city);
            }
        }

        // DELETE: api/City/5
        public City Delete(string zipCode)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM City where zipcode = @zipCode";
                return conn.Query<City>(sql, new { zipCode }).SingleOrDefault();

            }
        }

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
