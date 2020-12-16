using API.ApiHelpers;
using API.DAL.Exceptions;
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

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <returns>List of all Customers</returns>
        // GET: api/Customer
        public IHttpActionResult GetAll()
        {
            List<Customer> customers = new List<Customer>();
            var customerDAL = _customerRepository.GetAll();
            if (customerDAL.Count() == 0)
            {
                return NotFound();
            }
            foreach (var customer in customerDAL)
            {
                    customers.Add(BuildCustomer(customer));
            }
            return Ok(customers);
        }

        /// <summary>
        /// Gets a specific customer from an id
        /// </summary>
        /// <param name="id">The id of the customer to get</param>
        /// <returns>A customer</returns>
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

        /// <summary>
        /// Gets a customer from email and password
        /// </summary>
        /// <param name="login">contains the email and password</param>
        /// <returns>The customer who logged in</returns>
        [HttpPost]
        [Route("api/customer/login")]
        public IHttpActionResult Login([FromBody] LoginInfo login)
        {
            var customer = _customerRepository.IsAuthorized(login.Email, login.Password);
            if (customer != null)
            {
                return Ok(BuildCustomer(customer));
            }
            return NotFound();
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="customer">The customer that is being created</param>
        // POST: api/Customer
        public IHttpActionResult Post([FromBody] API.DAL.Models.Customer customer)
        {
            try
            {
                _customerRepository.Create(customer);
            }
            catch (DataAccessException)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Updates a specific customer
        /// </summary>
        /// <param name="customer">The customer to be updated</param>
        // PUT: api/Customer/5
        [HttpPut]
        public void Put([FromBody] API.DAL.Models.Customer customer)
        {
            _customerRepository.Update(customer);
        }

        /// <summary>
        /// Deletes a specific customer
        /// </summary>
        /// <param name="id">The id of the customer</param>
        /// <returns>OkResult if the customer is deleted</returns>
        // DELETE: api/Customer/5
        public IHttpActionResult Delete(int id)
        {
            if (_customerRepository.Delete(id))
            {
                return Ok();
            }
            return NotFound();
        }
       
        /// <summary>
        /// Converts customer DAL model to  customer API model, and adds api urls instead of ids
        /// </summary>
        /// <param name="customer">Customer to convert</param>
        /// <returns>Converted Customer</returns>
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
                Address = customer.Address,
                ZipCode = customer.ZipCode 
            };
        }
    }
}
