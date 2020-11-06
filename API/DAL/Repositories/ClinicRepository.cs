using API.DAL.Interfaces;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.DAL.Repositories
{
    public class ClinicRepository : IGenericRepository<Clinic>
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        public Clinic Create(Clinic obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Clinic obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Clinic> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Clinic";

                return conn.Query<Clinic>(sql);
            }
        }

        public Clinic GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Clinic Update(Clinic obj)
        {
            throw new NotImplementedException();
        }
    }
}