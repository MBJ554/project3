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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public Exercise Create(Exercise obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Exercise";
                return conn.Query<Exercise>(sql);
            }
        }

        public Exercise GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Exercise WHERE id = @id";
                return conn.QuerySingleOrDefault<Exercise>(sql, new { id });
            }
        }

        public Exercise Update(Exercise obj)
        {
            throw new NotImplementedException();
        }
    }
}