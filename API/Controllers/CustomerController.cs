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
using System.Web.Http.Controllers;

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
        public Customer GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person Where id = @id";
                return conn.Query<Customer>(sql, new { id }).SingleOrDefault();
            }
        }

        // POST: api/Customer
        public void Post([FromBody]Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[Person] " +
                    "([personTypeId], " +
                    "[clinicId], " +
                    "[firstName]," +
                    "[lastName]," +
                    "[phoneNo]," +
                    "[email]," +
                    "[password]," +
                    "[address]," +
                    "[zipCode])" +
                    "VALUES (@PersonTypeId, @clinicId, @firstName, @lastName, @phoneNo, @email, @password, @address, @zipCode)";
                conn.Execute(sql, customer);
            }
        }

        // PUT: api/Customer/5
        public void Put(int id,[FromBody]Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE [dbo].[Person] SET [clinicId] = @ClinicId " +
                    ",[practitionerId] = @PractitionerId " +
                    ",[rehabProgramId] = @RehabProgramId " +
                    ",[firstName] = @FirstName " +
                    ",[lastName] = @LastName" +
                    ",[phoneNo] = @PhoneNo" +
                    ",[email] = @Email ," +
                    "[password] = @Password ," +
                    "[address] = @Address ," +
                    "[zipCode] = @ZipCode WHERE id = @Id";
                conn.Execute(sql, customer);
            }
        }

        // DELETE: api/Customer/5
        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Person where id = @Id";
                
                return conn.Execute(sql, id) == 1;
            }
        }
    }
}
