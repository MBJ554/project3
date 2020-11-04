using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public DateTime Startdate { get; set; }
		public DateTime Enddate { get; set; }
		public int CustomerId { get; set; }
		public int PractionerId { get; set; }

		public Appointment(int Id_, DateTime startdate_, DateTime enddate_, int customerId_, int practionerId_)
		{
			this.Id = Id_;
			this.Startdate = startdate_;
			this.Enddate = enddate_;
			this.CustomerId = customerId_;
			this.PractionerId = practionerId_;
		}
		public Appointment()
        {

        }

	}

}