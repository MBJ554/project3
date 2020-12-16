using System;
using System.Collections.Generic;

namespace API.Models
{
    public class RehabProgram
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ExerciseLine> ExerciseLines { get; set; }

        public RehabProgram()
        {
        }
    }
}