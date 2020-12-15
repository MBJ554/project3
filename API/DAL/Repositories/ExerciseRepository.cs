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

        public void Create(Exercise obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetAll()
        {
            throw new NotImplementedException();
        }

        public Exercise GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Exercise obj)
        {
            throw new NotImplementedException();
        }
    }
}