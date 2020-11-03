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

        // GET: api/City/5
        public string Get(int id)
        {
            return "value";
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

        // PUT: api/City/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
        }
    }
}
