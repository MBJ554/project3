using API.DAL.Exceptions;
using API.DAL.Interfaces;
using API.DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace API.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public void Create(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO [dbo].[Person] " +
                            "([personTypeId], " +
                            "[clinicId]," +
                            "[firstName]," +
                            "[lastName]," +
                            "[phoneNo]," +
                            "[email]," +
                            "[passwordHash]," +
                            "[salt]," +
                            "[address]," +
                            "[zipCode])" +
                            "VALUES ((SELECT id FROM PersonType WHERE type = 'Customer')" +
                            ", @clinicId" +
                            ", @firstName" +
                            ", @lastName" +
                            ", @phoneNo" +
                            ", @email" +
                            ", @passwordHash" +
                            ", @salt" +
                            ", @address" +
                            ", @zipCode)";
                        conn.Execute(sql, customer, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
                        throw new DataAccessException("Der gik noget galt, prøv igen.", e);
                    }
                }
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

        public Customer GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person p INNER JOIN City c ON c.zipCode = p.zipCode WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Customer') AND id = @id ";
                return conn.QuerySingleOrDefault<Customer>(sql, new { id });
            }
        }

        public Customer IsAuthorized(string email, string password)
        {
            using (var conn  = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person p WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Customer') AND email = @email";
                var customer = conn.QuerySingleOrDefault<Customer>(sql, new { email });
                if (customer != null)
                {
                    HashAlgorithm hashAlgorithm = SHA512.Create();
                    var passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(customer.Salt + password)));

                    if (passwordHash == customer.PasswordHash)
                    {
                        return customer;
                    }
                }
            }
            return null;
        }

        public void Update(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
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
                        conn.Execute(sql, customer, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
                        throw new DataAccessException("Der gik noget galt prøv igen", e);
                    }
                }
            }
        }
    }
}