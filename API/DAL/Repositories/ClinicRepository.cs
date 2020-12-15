using API.DAL.Exceptions;
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
    public class ClinicRepository : IClinicRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public void Create(Clinic obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO [dbo].[Clinic] ([name], " +
                        "[address], " +
                        "[zipCode], " +
                        "[phoneNo], " +
                        "[description]) " +
                        "VALUES (@name, " +
                        "@address, " +
                        "@zipCode, " +
                        "@phoneNo, " +
                        "@description)";
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

        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM Clinic where id = @id";
                return conn.Execute(sql, new { id }) != 0;
            }
        }

        public IEnumerable<Clinic> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Clinic cl INNER JOIN City c ON c.zipCode = cl.zipCode";

                return conn.Query<Clinic>(sql);
            }
        }

        public Clinic GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Clinic cl INNER JOIN City c ON c.zipCode = cl.zipCode WHERE id = @id";
                return conn.Query<Clinic>(sql, new { id }).SingleOrDefault();
            }
        }

        public void Update(Clinic obj)
        {
            throw new NotImplementedException();
        }
    }
}