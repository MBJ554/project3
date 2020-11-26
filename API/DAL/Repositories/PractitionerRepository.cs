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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Practitioner> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Practitioner";
                return conn.Query<Practitioner>(sql);
            }
        }

        public Practitioner GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Person where id = @id";
                return conn.QuerySingleOrDefault<Practitioner>(sql, new { id });
            }
        }

        public Practitioner Update(Practitioner obj)
        {
            throw new NotImplementedException();
        }
    }
}