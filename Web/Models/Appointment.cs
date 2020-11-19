using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Appointment
    {
		public DateTime Startdate { get; set; }
		public DateTime Enddate { get; set; }
		public string StartEndDate { get { return Startdate.ToString() + " - " + Enddate.ToString(); }  }

		public Appointment( DateTime _startdate, DateTime _enddate)
		{
			
			this.Startdate = _startdate;
			this.Enddate = _enddate;
			
		}

		public Appointment() { 
		
		}

	}
}