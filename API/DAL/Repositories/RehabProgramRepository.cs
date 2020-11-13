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
    public class RehabProgramRepository : IRehabProgramRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public RehabProgram Create(RehabProgram obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RehabProgram> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM RehabProgram";
                return conn.Query<RehabProgram>(sql);
            }
        }

        public RehabProgram GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM RehabProgram WHERE id = @id";
                return conn.QuerySingleOrDefault<RehabProgram>(sql, new { id });
            }
        }

        public RehabProgram Update(RehabProgram obj)
        {
            throw new NotImplementedException();
        }
    }
}