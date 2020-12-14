using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Customer
    {
        /// <summary>
        /// Users ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Users Clinic set as relative API URL
        /// </summary>
        public string Clinic { get; set; }
        /// <summary>
        /// Users Practioner as relative API URL
        /// </summary>
        public string Practitioner { get; set; }
        /// <summary>
        /// Users RehabProgram as relative API URL
        /// </summary>
        public string RehabProgram { get; set; }
        /// <summary>
        /// Users first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Users last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Users phone number
        /// </summary>
        public string PhoneNo { get; set; }
        /// <summary>
        /// Users email
        /// Set method will be appended when frontend/system supports feature 'user change email'. 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Users password - hash
        /// Set method will be appended when frontend/system supports feature 'user change password'.
        /// </summary>
        public string Password { get; }
        /// <summary>
        /// User Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Users ZipCode / Postal code
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Users city of resendens
        /// </summary>
        public string City { get; set; }

        public Customer() 
        { 
        
        }
    }
}