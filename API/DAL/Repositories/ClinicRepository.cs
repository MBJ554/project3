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
        public Clinic Create(Clinic obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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

        public Clinic Update(Clinic obj)
        {
            throw new NotImplementedException();
        }
    }
}