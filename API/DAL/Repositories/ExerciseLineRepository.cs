using API.DAL.Interfaces;
using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace API.DAL.Repositories
{
    public class ExerciseLineRepository : IExerciseLineRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public void Create(ExerciseLine obj)
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
            throw new NotImplementedException();
        }

        public ExerciseLine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ExerciseLine obj)
        {
            throw new NotImplementedException();
        }
    }
}