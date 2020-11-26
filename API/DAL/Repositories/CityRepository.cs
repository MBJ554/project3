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
    public class CityRepository : ICityRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public City Create(City obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
    

        public City Update(City obj)
        {
            throw new NotImplementedException();
        }
    }
}