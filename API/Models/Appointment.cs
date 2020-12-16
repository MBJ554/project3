using System;

namespace API.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Customer { get; set; }
        public string Practitioner { get; set; }

        public Appointment()
        {
        }
    }
}