using API.DAL.Exceptions;
using API.DAL.Interfaces;
using API.DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace API.DAL.Repositories
{
    public class PractitionerRepository : IPractitionerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public void Create(Practitioner obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO[dbo].[Person] " +
                        "([personTypeId], " +
                        "[clinicId]," +
                        "[firstName]," +
                        "[lastName]," +
                        "[phoneNo]," +
                        "[email]," +
                        "[passwordHash]," +
                        "[salt])" +
                        "VALUES ((SELECT id FROM PersonType WHERE type = 'Practitioner')" +
                        ", @clinicId" +
                        ", @firstName" +
                        ", @lastName" +
                        ", @phoneNo" +
                        ", @email" +
                        ", @passwordHash" +
                        ", @salt)";

                        conn.Execute(sql, obj, transaction: transaction);
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
                string sql = "DELETE FROM Person WHERE id = @id AND personTypeId = (SELECT id FROM PersonType WHERE type = 'Practitioner')";
                return conn.Execute(sql, new { id = id }) == 1;
            }
        }

        public IEnumerable<Practitioner> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Practitioner')";
                return conn.Query<Practitioner>(sql);
            }
        }

        public Practitioner GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Practitioner') AND id = @id";
                return conn.QuerySingleOrDefault<Practitioner>(sql, new { id = id });
            }
        }

        public Practitioner IsAuthorized(string email, string password)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person p WHERE personTypeId = (SELECT id FROM PersonType WHERE type = 'Practitioner') AND email = @email";
                var practitioner = conn.QuerySingleOrDefault<Practitioner>(sql, new { email });
                if (practitioner != null)
                {
                    HashAlgorithm hashAlgorithm = SHA512.Create();
                    var passwordHash = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(practitioner.Salt + password)));

                    if (passwordHash == practitioner.PasswordHash)
                    {
                        return practitioner;
                    }
                }
            }
            return null;
        }

        public void Update(Practitioner obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "UPDATE [dbo].[Person] SET [clinicId] = @ClinicId " +
                        ",[firstName] = @FirstName " +
                        ",[lastName] = @LastName" +
                        ",[phoneNo] = @PhoneNo" +
                        ",[email] = @Email ," +
                        "[password] = @Password WHERE id = @Id AND personTypeId = (SELECT id FROM PersonType WHERE type = 'Practitioner')";

                        conn.Execute(sql, obj, transaction: transaction);
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