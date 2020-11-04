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
    public class AppointmentController : ApiController
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
        // GET: api/Appointment
        public IEnumerable<Appointment> Get()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment";

                return conn.Query<Appointment>(sql);
            }
        }

        // GET: api/Appointment/GetById
        public Appointment Get(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment Where id = @id";     
                return conn.Query<Appointment>(sql, new { id }).SingleOrDefault();
            }
        }

        // POST: api/Appointment
        public void Post([FromBody] Appointment appointment)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO [dbo].[Appointment] ([startdate], [enddate], [customerId], [practitionerId]) VALUES (@startdate, @enddate, @customerId, @practitionerId)";
                conn.Execute(sql, appointment);
            }
        }

        // DELETE: api/Appointment/5
        public Appointment Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM Appointment where id = @id";
                
                Appointment a = Get(id);
                conn.Query<Appointment>(sql, new { id }).SingleOrDefault();
                return a;
            }
        }
    }
}
