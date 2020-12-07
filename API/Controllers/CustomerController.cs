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
        //TODO kig på hvordan det er løst i CityController
        // GET: api/Customer
        public IHttpActionResult GetAll()
        {
            List<Customer> customers = new List<Customer>();
            var customerDAL = _customerRepository.GetAll();
            foreach (var customer in customerDAL)
            {
                if (customer != null)
                {
                    customers.Add(BuildCustomer(customer));
                }
            }
            if (customers.Count == 0)
            {
                return NotFound();
            }
            return Ok(customers);
        }

        // GET: api/Customer/5
        public IHttpActionResult GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer != null)
            {
                return Ok(BuildCustomer(customer));
            }
            return NotFound();
        }

        [HttpPost]
        // POST: api/Customer/email/password
        public bool Post(string email, string password)
        {
            return _customerRepository.IsAuthorized(email, password); 
        }

        // POST: api/Customer
        public void Post([FromBody] API.DAL.Models.Customer customer)
        {
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
                City = customer.CityName,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNo = customer.PhoneNo,
                Email = customer.Email,
                Password = customer.PasswordHash,
                Address = customer.Address,
                ZipCode = customer.ZipCode
            };
        }
    }
}
