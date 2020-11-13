using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.DAL.Models
{
    public class ExerciseLine
    {
        public int ExcerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        //TODO fix stave fejl i exercise samme i DB!!
        public ExerciseLine(int excerciseId_, int sets_, int reps_)
        {
            this.ExcerciseId = excerciseId_;
            this.Sets = sets_;
            this.Reps = reps_;
        }
        public ExerciseLine()
        {

        }
    }
}