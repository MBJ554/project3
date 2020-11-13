using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public int PersonTypeId { get; set; }
		public int ClinicId { get; set; }
		public int PractitionerId { get; set; }
		public int RehabProgramId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNo { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
		public string City { get; set; }

		public Customer(int id_, int personTypeId_, int clinicId_, int practitionerId_, int rehabProgramId_, string firstName_, string lastName_, string phoneNo_, string email_, string password_, string address_, string zipCode_, string city_)
		{
			this.Id = id_;
			this.PersonTypeId = personTypeId_;
			this.ClinicId = clinicId_;
			this.PractitionerId = practitionerId_;
			this.RehabProgramId = rehabProgramId_;
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