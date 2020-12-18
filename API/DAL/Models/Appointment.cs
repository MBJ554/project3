using System;

namespace API.DAL.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public int CustomerId { get; set; }
        public int PractitionerId { get; set; }

        public Appointment()
        {
        }
    }
}