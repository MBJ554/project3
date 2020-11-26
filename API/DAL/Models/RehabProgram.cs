using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
    public class RehabProgram
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

        public RehabProgram(int id_, string description_, DateTime startDate_, DateTime endDate_)
        {
            Id = id_;
            Description = description_;
            StartDate = startDate_;
            EndDate = endDate_;
        }
        public RehabProgram()
        {

        }
    }
}