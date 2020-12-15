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

        public void Create(RehabProgram obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RehabProgram> GetAll()
        {
            throw new NotImplementedException();
        }

        public RehabProgram GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RehabProgram obj)
        {
            throw new NotImplementedException();
        }
    }
}