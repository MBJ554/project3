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
		public string PasswordHash { get; set; }
		public string Salt { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
		public string CityName { get; set; }

		public Customer(int _id, int _personTypeId, int _clinicId, int _practitionerId, int _rehabProgramId, string _firstName, string _lastName, string _phoneNo, string _email, string _passwordHash, string _address, string _zipCode, string _cityName)
		{
			this.Id = _id;
			this.PersonTypeId = _personTypeId;
			this.ClinicId = _clinicId;
			this.PractitionerId = _practitionerId;
			this.RehabProgramId = _rehabProgramId;
			this.FirstName = _firstName;
			this.LastName = _lastName;
			this.PhoneNo = _phoneNo;
			this.Email = _email;
			this.PasswordHash = _passwordHash;
			this.Address = _address;
			this.ZipCode = _zipCode;
			this.CityName = _cityName;
		}

		public Customer()
		{

		}
	}
}