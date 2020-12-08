using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Customer
    {
      
        public string Password { get; set; }

        public int Id { get; set; }

        //TODO kig på hvad der sker her
        public string PersonType { get { return "Customer"; } }
        public string Clinic { get; set; }
        public string Practitioner { get; set; }
        public string RehabProgram { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }


        public Customer(string email, string password) {
            this.Email = email;
            this.Password = password;

        }

        public Customer() { 
        
        }

    }
}