namespace API.Models
{
    public class ExerciseLine
    {
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        public ExerciseLine(Exercise exercise_, int sets_, int reps_)
        {
            this.Exercise = exercise_;
            this.Sets = sets_;
            this.Reps = reps_;
        }
        public ExerciseLine()
        {

        }
    }
}