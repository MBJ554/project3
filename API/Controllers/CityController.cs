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
        // GET: api/City
        public IEnumerable<City> Get()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM City";

                return conn.Query<City>(sql);
            }
        }

        // GET: api/City/GetById
        public City Get(int zipCode)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM City Where zipCode = @zipCode";
                Customer c = new Customer();
                return conn.Query<City>(sql, new { zipCode }).SingleOrDefault();
            }
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
        public City Delete(int zipCode)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM City where zipcode = @zipCode";
                //return conn.Execute(sql, city) == 1;
                City c = Get(zipCode);
                conn.Query<City>(sql, new { zipCode }).SingleOrDefault();
                return c;
            }
        }
    }
}
