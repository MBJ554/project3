using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Appointment
    {
		/// <summary>
		/// Startdate and time for the appointment.
		/// </summary>
		public DateTime Startdate { get; set; }
		/// <summary>
		/// Enddate and time for the appointment.
		/// </summary>
		public DateTime Enddate { get; set; }
		public string Customer { get; set; }
		public string Practitioner { get; set; }

		public Appointment(DateTime _startdate, DateTime _enddate)
		{
			this.Startdate = _startdate;
			this.Enddate = _enddate;
		}

		public Appointment() 
		{ 
		
		}

		public string StartTimeDisplay()
        {
			return Startdate.TimeOfDay.ToString();
        }

		public string EndTimeDisplay()
		{
			return Enddate.TimeOfDay.ToString();
		}
	}
}