using API.DAL.Exceptions;
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
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //TODO fix return
        public Appointment Create(Appointment obj)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO [dbo].[Appointment] " +
                        "([startdate], " +
                        "[enddate], " +
                        "[customerId], " +
                        "[practitionerId]) VALUES " +
                        "(@startdate, " +
                        "@enddate, " +
                        "@customerId, " +
                        "@practitionerId)";
                    conn.Execute(sql, obj);
                    return null;
                }
            }
            catch (SqlException e)
            {

                if (e.Number == 2627)
                {
                    throw new DataAccessException("Den valgte tid er ikke længere tilgængelig. Prøv igen", e);
                }
                else
                {
                    throw new DataAccessException("Der gik noget galt, prøv igen", e);
                }
            }
        }
        //TODO FIX return
        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM Appointment where id = @id";
                conn.Query<Appointment>(sql, new { id }).SingleOrDefault();
                return true;
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment";

                return conn.Query<Appointment>(sql);
            }
        }

        public IEnumerable<Appointment> GetAllByPractitionerAndDate(DateTime date, int practitionerId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                // TODO: Fix stavefejl i database med practitioner
                string sql = "SELECT * FROM Appointment WHERE (SELECT CONVERT (date , startdate)) = @date  AND practitionerId = @practitionerId";
                return conn.Query<Appointment>(sql, new { date.Date, practitionerId } );
            }
        }

        public Appointment GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment Where id = @id";
                return conn.Query<Appointment>(sql, new { id }).SingleOrDefault();
            }
        }

        public Appointment Update(Appointment obj)
        {
            throw new NotImplementedException();
        }
    }
}