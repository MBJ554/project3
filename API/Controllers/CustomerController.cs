using API.ApiHelpers;
using API.DAL.Interfaces;
using API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;


namespace API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/Customer
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            var customerDAL = _customerRepository.GetAll();
            foreach (var customer in customerDAL)
            {
                customers.Add(BuildCustomer(customer));
            }
            return customers;
        }

        // GET: api/Customer/5
        public Customer GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer != null)
            {
                return BuildCustomer(customer);
            }
            return null;
        }

        // POST: api/Customer
        public void Post([FromBody] API.DAL.Models.Customer customer)
        {
            //var c = new API.DAL.Models.Customer
            //{
            //    ClinicId = Convert.ToInt32(customer.Clinic),
            //    PractitionerId = Convert.ToInt32(customer.Practitioner),
            //    RehabProgramId = Convert.ToInt32(customer.RehabProgram),
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    PhoneNo = customer.PhoneNo,
            //    Email = customer.Email,
            //    Password = customer.Password,
            //    Address = customer.Address,
            //    ZipCode = customer.ZipCode,
            //};
            _customerRepository.Create(customer);
        }

        // PUT: api/Customer/5
        [HttpPut]
        public void Put([FromBody] API.DAL.Models.Customer customer)
        {
            _customerRepository.Update(customer);
        }

        // DELETE: api/Customer/5
        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }
       
        private Customer BuildCustomer(API.DAL.Models.Customer customer)
        {  
            return new Customer
            {
                Id = customer.Id,
                Clinic = customer.ClinicId != 0 ? ApiHelper.BuildClinicURL(customer.ClinicId) : null,
                Practitioner = customer.PractitionerId != 0 ? ApiHelper.BuildPractitionerURL(customer.PractitionerId) : null,
                RehabProgram = customer.RehabProgramId != 0 ? ApiHelper.BuildRehabProgramURL(customer.RehabProgramId) : null,
                City = customer.City,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNo = customer.PhoneNo,
                Email = customer.Email,
                Password = customer.Password,
                Address = customer.Address,
                ZipCode = customer.ZipCode
            };
        }

        //private RehabProgram buildRehabProgram(int id)
        //{
        //    var rehabProgram = _rehabProgramRepository.GetById(id);
        //    return new RehabProgram
        //    {
        //        Id = rehabProgram.Id,
        //        Description = rehabProgram.Description,
        //        StartDate = rehabProgram.StartDate,
        //        EndDate = rehabProgram.EndDate,
        //        ExerciseLines = buildExerciseLines(rehabProgram.Id)
        //    };
        //}

        //private List<ExerciseLine> buildExerciseLines(int id)
        //{
        //    List<ExerciseLine> res = new List<ExerciseLine>();
        //    var exerciseLines = _exerciseLineRepository.GetAllByRehabProgramId(id);
        //    foreach (var exerciseLine in exerciseLines)
        //    {
        //        res.Add(new ExerciseLine
        //        {
        //            Exercise = buildExercise(exerciseLine.ExcerciseId),
        //            Sets = exerciseLine.Sets,
        //            Reps = exerciseLine.Reps
        //        });
        //    }
        //    return res;
        //}

        //private Exercise buildExercise(int Id)
        //{
        //    var exercise = _exerciseRepository.GetById(Id);
        //    return new Exercise
        //    {
        //        Id = exercise.Id,
        //        Name = exercise.Name,
        //        Description = exercise.Description
        //    };
        //}

        //private Clinic buildClinic(int id)
        //{
        //    var clinic = _clinicRepository.GetById(id);
        //    return new Clinic
        //    {
        //        Id = clinic.Id,
        //        Name = clinic.Name,
        //        Address = clinic.Address,
        //        ZipCode = clinic.ZipCode,
        //        City = _cityRepository.GetCityByZipCode(clinic.ZipCode).city,
        //        PhoneNo = clinic.PhoneNo,
        //        Description = clinic.Description
        //    };
        //}

        //private Practitioner buildPractitioner(int id)
        //{
        //    var practitioner = _practitionerRepository.GetById(id);
        //    return new Practitioner
        //    {
        //        Id = practitioner.Id,
        //        Clinic = buildClinic(practitioner.ClinicId),
        //        FirstName = practitioner.FirstName,
        //        LastName = practitioner.LastName,
        //        Email = practitioner.Email,
        //        Password = practitioner.Password
        //    };
        //}
    }
}
