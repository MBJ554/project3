using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
	public class Practitioner
	{
		public int Id { get; set; }
		public int PersonTypeId { get; set; }
		public int ClinicId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
		public string Password { get; set; }

		public Practitioner(int _id, int _personTypeId, int _clinicId, string _firstName, string _lastName, string _phoneNo, string _email, string _password)
		{
			this.Id = _id;
			this.PersonTypeId = _personTypeId;
			this.ClinicId = _clinicId;
			this.FirstName = _firstName;
			this.LastName = _lastName;
			this.PhoneNo = _phoneNo;
			this.Email = _email;
			this.Password = _password;
		}
		public Practitioner()
		{

		}
	}
}