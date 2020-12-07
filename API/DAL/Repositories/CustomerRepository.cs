using API.DAL.Interfaces;
using API.DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Customer Create(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[Person] " +
                    "([personTypeId], " +
                    "[clinicId]," +
                    "[firstName]," +
                    "[lastName]," +
                    "[phoneNo]," +
                    "[email]," +
                    "[password]," +
                    "[address]," +
                    "[zipCode])" +
                    "VALUES ((SELECT id FROM PersonType WHERE type = 'Customer')" +
                    ", @clinicId" +
                    ", @firstName" +
                    ", @lastName" +
                    ", @phoneNo" +
                    ", @email" +
                    ", @password" +
                    ", @address" +
                    ", @zipCode)";
                if (conn.Execute(sql, customer) > 0)
                {
                    return customer;
                }
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Person where id = @id";

                return conn.Execute(sql, new { id }) == 1;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person p INNER JOIN City c ON c.zipCode = p.zipCode WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Customer')";
                return conn.Query<Customer>(sql);
            }
        }
        // TODO City ikke nødvendig som vi gær det nu, dog skal vi mpske stadig populate vores database med zipcode sådan at vi ikke er afhængige af dawas
        public Customer GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person p INNER JOIN City c ON c.zipCode = p.zipCode WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Customer') AND id = @id ";
                return conn.QuerySingleOrDefault<Customer>(sql, new { id });
            }
        }

        public bool IsAuthorized(string email, string passwordHashed)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customer)
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
                if (conn.Execute(sql, customer) > 0)
                {
                    return customer;
                }
                return null;
            }
        }
    }
}