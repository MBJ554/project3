using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
	public class Appointment
	{
		public int Id { get; set; }
		public DateTime Startdate { get; set; }
		public DateTime Enddate { get; set; }
		public int CustomerId { get; set; }
		public int PractionerId { get; set; }

		public Appointment(int _Id, DateTime _startDate, DateTime _endDate, int _customerId, int _practionerId)
		{
			this.Id = _Id;
			this.Startdate = _startDate;
			this.Enddate = _endDate;
			this.CustomerId = _customerId;
			this.PractionerId = _practionerId;
		}
		public Appointment()
		{

		}

	}
}