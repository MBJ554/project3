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
		public string Customer { get; set; }
		public string Practioner { get; set; }

		public Appointment(int _Id, DateTime _startDate, DateTime _endDate, string _customer, string _practioner)
		{
			this.Id = _Id;
			this.Startdate = _startDate;
			this.Enddate = _endDate;
			this.Customer = _customer;
			this.Practioner = _practioner;
		}
		public Appointment()
        {

        }

	}

}