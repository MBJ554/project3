using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class Practitioner
	{
		public int Id { get; set; }
		//id er en int 

		public string Clinic { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNo { get; set; }
		public string Password { get; set; }

		public Practitioner(int _id, string _clinic, string _firstName, string _lastName, string _phoneNo, string _email, string _password)
		{
			this.Id = _id;
			this.Clinic = _clinic;
			this.FirstName = _firstName;
			this.LastName = _lastName;
			this.Email = _email;
			this.PhoneNo = _phoneNo;
			this.Password = _password;
		}
		public Practitioner()
		{

		}
	}
}