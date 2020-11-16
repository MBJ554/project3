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
        private readonly IClinicRepository _clinicRepository;
        public ClinicController(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public IHttpActionResult Get()
        {
            var clinicsDAL = _clinicRepository.GetAll();
            var clinics = new List<Clinic>();
            foreach (var clinic in clinicsDAL)
            {
                clinics.Add(buildClinic(clinic));
            }
            if (clinics.Count == 0)
            {
                return NotFound();
            }
           return Ok(clinics);
        }

        // GET: api/City/GetById
        public IHttpActionResult Get(int id)
        {
            var clinicDAL = _clinicRepository.GetById(id);
            if (clinicDAL != null)
            {
                var clinic = buildClinic(clinicDAL);
                return Ok(clinic);
            }
            return NotFound();
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
                conn.Query<Clinic>(sql, new { id }).SingleOrDefault();
                return null;
            }
        }

        private Clinic buildClinic(API.DAL.Models.Clinic clinic)
        {
            return new Clinic
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Address = clinic.Address,
                ZipCode = clinic.ZipCode,
                City = clinic.City,
                PhoneNo = clinic.PhoneNo,
                Description = clinic.Description
            };
        }
    }
}
