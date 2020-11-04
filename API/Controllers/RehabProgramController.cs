using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RehabProgramController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        // GET: api/RehabProgram
        public IEnumerable<RehabProgram> Get()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * RehabProgram";

                return conn.Query<RehabProgram>(sql);
            }
        }

        // GET: api/RehabProgram/GetById
        public RehabProgram Get(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM RehabProgram Where id = @id";
                return conn.Query<RehabProgram>(sql, new { id }).SingleOrDefault();
            }
        }

        // POST: api/RehabProgram
        public void Post([FromBody] RehabProgram rehabProgram)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[RehabProgram] ([description], [startDate], [endDate]) VALUES (@description, @startDate, @EndDate)";
                conn.Execute(sql, rehabProgram);
            }
        }

        // DELETE: api/RehabProgram/5
        public RehabProgram Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM RehabProgram where id = @id";
                RehabProgram r = Get(id);
                conn.Query<City>(sql, new { id }).SingleOrDefault();
                return r;
            }
        }
    }
}

