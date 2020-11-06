using API.DAL.Interfaces;
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
    public class ClinicController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        // GET: api/Clinic
        private readonly IGenericRepository<Clinic> _clinicRepository;
        public ClinicController(IGenericRepository<Clinic> clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public IEnumerable<Clinic> Get()
        {
            //using (var conn = new SqlConnection(connectionString))
            //{
            //    string sql = "SELECT * FROM Clinic";

            //    return conn.Query<Clinic>(sql);
            //}

            return _clinicRepository.GetAll();
        }

        // GET: api/City/GetById
        public Clinic Get(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Clinic Where id = @id";
                return conn.Query<Clinic>(sql, new { id }).SingleOrDefault();
            }
        }

        // POST: api/City
        public void Post([FromBody] Clinic clinic)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[Clinic] ([name], " +
                    "[address], " +
                    "[zipCode], " +
                    "[phoneNo], " +
                    "[description]) " +
                    "VALUES (@name, " +
                    "@address, " +
                    "@zipCode, " +
                    "@phoneNo, " +
                    "@description)";
                conn.Execute(sql, clinic);
            }
        }

        // DELETE: api/City/5
        public Clinic Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM Clinic where id = @id";
                //return conn.Execute(sql, city) == 1;
                Clinic c = Get(id);
                conn.Query<Clinic>(sql, new { id }).SingleOrDefault();
                return c;
            }
        }
    }
}
