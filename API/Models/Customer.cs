using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string PersonType { get { return "Customer"; } }
		//public Clinic Clinic { get; set; }
		public string Clinic { get; set; }
		//public Practitioner Practitioner { get; set; }
		public string Practitioner { get; set; }
		//public RehabProgram RehabProgram { get; set; }
		public string RehabProgram { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNo { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
        public string City { get; set; }

        public Customer(int id_, string clinic_, string practitioner_, string rehabProgram_, string firstName_, string lastName_, string phoneNo_, string email_, string password_, string address_, string zipCode_, string city_)
		{
			this.Id = id_;
			//this.PersonTypeId = personTypeId_;
			this.Clinic = clinic_;
			this.Practitioner = practitioner_;
			this.RehabProgram = rehabProgram_;
			this.FirstName = firstName_;
			this.LastName = lastName_;
			this.PhoneNo = phoneNo_;
			this.Email = email_;
			this.Password = password_;
			this.Address = address_;
			this.ZipCode = zipCode_;
			this.City = city_;
		}
        public Customer()
        {

        }
	}
}