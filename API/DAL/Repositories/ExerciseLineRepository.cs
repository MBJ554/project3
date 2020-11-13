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
    public class ExerciseLineRepository : IExerciseLineRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public ExerciseLine Create(ExerciseLine obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseLine> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseLine> GetAllByRehabProgramId(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM ExerciseLine WHERE rehabProgramId = @id";
                return conn.Query<ExerciseLine>(sql, new { id });
            };
        }

        public ExerciseLine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ExerciseLine Update(ExerciseLine obj)
        {
            throw new NotImplementedException();
        }
    }
}