using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Customer
	{
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

        public Customer(int _id, string _clinic, string _practitioner, string _rehabProgram, string _firstName, string _lastName, string _phoneNo, string _email, string _address, string _zipCode, string _city)
		{
			this.Id = _id;
			//this.PersonTypeId = personTypeId_;
			this.Clinic = _clinic;
			this.Practitioner = _practitioner;
			this.RehabProgram = _rehabProgram;
			this.FirstName = _firstName;
			this.LastName = _lastName;
			this.PhoneNo = _phoneNo;
			this.Email = _email;
			//this.Password = _password;
			this.Address = _address;
			this.ZipCode = _zipCode;
			this.City = _city;
		}
        public Customer()
        {

        }
	}
}