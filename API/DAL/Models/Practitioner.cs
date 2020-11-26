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
		public string Email { get; set; }
		public string Password { get; set; }

		public Practitioner(int id_, int personTypeId_, int clinicId_, string firstName_, string lastName_, string email_, string password_)
		{
			this.Id = id_;
			this.PersonTypeId = personTypeId_;
			this.ClinicId = clinicId_;
			this.FirstName = firstName_;
			this.LastName = lastName_;
			this.Email = email_;
			this.Password = password_;
		}
		public Practitioner()
		{

		}
	}
}