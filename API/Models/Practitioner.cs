﻿namespace API.Models
{
	public class Practitioner
	{
		public int Id { get; set; }
		//public string PersonType { get; set; }
		public string Clinic { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
        public string PhoneNo { get; set; }
        

		public Practitioner(int _id, string _clinic, string _firstName, string _lastName, string _phoneNo, string _email)
		{
			this.Id = _id;
			//this.PersonType = _personType;
			this.Clinic = _clinic;
			this.FirstName = _firstName;
			this.LastName = _lastName;
			this.Email = _email;
			this.PhoneNo = _phoneNo;
		
		}
		public Practitioner()
		{

		}
	}
}