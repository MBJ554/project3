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

        public void Create(Appointment obj)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
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
                        conn.Execute(sql, obj, transaction: transaction);
                        transaction.Commit();
                    }
                    catch (SqlException e)
                    {
                        transaction.Rollback();
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
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "Delete FROM Appointment where id = @id";
                //TODO: tjek om det her virker og lav alt andet om til denne måde både return og id
                return conn.Execute(sql, new { id = id }) == 1; 
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
                string sql = "SELECT * FROM Appointment WHERE (SELECT CONVERT (date , startdate)) = @date  AND practitionerId = @practitionerId";
                return conn.Query<Appointment>(sql, new { date = date.Date, practitionerId = practitionerId } );
            }
        }

        public Appointment GetById(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Appointment Where id = @id";
                return conn.Query<Appointment>(sql, new {  id = id }).SingleOrDefault();
            }
        }

        public void Update(Appointment obj)
        {
            throw new NotImplementedException();
        }
    }
}