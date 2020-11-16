using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
	public class Clinic
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string ZipCode { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
		public string Description { get; set; }

		public Clinic(int id_, string name_, string address_, string zipCode_, string city_, string phoneNo_, string description_)
		{
			this.Id = id_;
			this.Name = name_;
			this.Address = address_;
			this.ZipCode = zipCode_;
			this.City = city_;
			this.PhoneNo = phoneNo_;
			this.Description = description_;
		}

		public Clinic()
		{

		}
	}
}