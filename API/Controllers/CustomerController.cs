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
    public class CustomerController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        // GET: api/Customer
        public IEnumerable<Customer> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person";

                return conn.Query<Customer>(sql);
            }
        }

        // GET: api/Customer/5
        public string GetById(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[Person] " +
                    "([type], " +
                    "[clinicId], " +
                    "[practitionerId], " +
                    "[rehabProgramId]," +
                    "[firstName]," +
                    "[lastName]," +
                    "[phoneNo]," +
                    "[email]," +
                    "[password]," +
                    "[address]," +
                    "[zipCode])" +
                    "VALUES (@type, @clinicId, @practitionerId, @rehabProgramId, @firstName, @lastName, @phoneNo, @email, @password, @address, @zipCode)";
                conn.Execute(sql, customer);
            }
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
