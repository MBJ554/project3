using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Customer
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string UserName { get; set; }

        public Customer(string email, string password) {
            this.Email = email;
            this.Password = password;

        }

        public Customer() { 
        
        }

    }
}