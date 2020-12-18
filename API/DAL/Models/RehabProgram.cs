using System;

namespace API.DAL.Models
{
    public class RehabProgram
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public RehabProgram()
        {
        }
    }
}