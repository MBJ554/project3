using API.DAL.Exceptions;
using API.DAL.Interfaces;
using API.DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace API.DAL.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public void Create(City obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = "INSERT INTO [dbo].[City] ([zipCode], [city]) VALUES (@zipCode, @city)";
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
            throw new NotImplementedException();
        }

        public bool DeleteByZipCode(string zipCode)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM City where zipcode = @zipCode";
                return conn.Execute(sql, new { zipCode }) != 0;
            }
        }

        public IEnumerable<City> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM City";
                return conn.Query<City>(sql);
            };
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public City GetCityByZipCode(string zipCode)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM City Where zipCode = @zipCode";
                return conn.QuerySingleOrDefault<City>(sql, new { zipCode });
            }
        }

        public void Update(City obj)
        {
            throw new NotImplementedException();
        }
    }
}