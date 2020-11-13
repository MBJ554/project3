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
        public IEnumerable<City> Get()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM City";

                return conn.Query<City>(sql);
            }
        }


        
        // GET: api/City/GetById
        [HttpGet]
        public City Get(string id)
        {
            var cityDAL = _cityRepository.GetCityByZipCode(id);
            return new City
            {
                zipCode = cityDAL.zipCode,
                city = cityDAL.city
            };
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
    }
}
