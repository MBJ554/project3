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
    public class PractitionerRepository : IPractitionerRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public Practitioner Create(Practitioner obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    string sql = "INSERT INTO[dbo].[Person] " +
                    "([personTypeId], " +
                    "[clinicId]," +
                    "[firstName]," +
                    "[lastName]," +
                    "[phoneNo]," +
                    "[email]," +
                    "[password])" +
                    "VALUES ((SELECT id FROM PersonType WHERE type = 'Practitioner')" +
                    ", @clinicId" +
                    ", @firstName" +
                    ", @lastName" +
                    ", @phoneNo" +
                    ", @email" +
                    ", @password)";

                    //TODO Kig på error codes fra api da den ikke returner customer
                    var rowsAffected = conn.Execute(sql, obj, transaction:transaction);
                    transaction.Commit();
                    if (rowsAffected > 0)
                    {
                        return obj;
                    }
                    return null;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Person WHERE id = @id";

                return conn.Execute(sql, new { id }) == 1;
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
                return conn.QuerySingleOrDefault<Practitioner>(sql, new { id });
            }
        }

        public Practitioner Update(Practitioner obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var transaction = conn.BeginTransaction())
                {
                    string sql = "UPDATE [dbo].[Person] SET [clinicId] = @ClinicId " +
                    ",[firstName] = @FirstName " +
                    ",[lastName] = @LastName" +
                    ",[phoneNo] = @PhoneNo" +
                    ",[email] = @Email ," +
                    "[password] = @Password WHERE id = @Id";

                    var rowsAffected = conn.Execute(sql, obj);
                    transaction.Commit();
                    if (rowsAffected > 0)
                    {
                        return obj;
                    }
                    return null;
                }
            }
        }
    }
}