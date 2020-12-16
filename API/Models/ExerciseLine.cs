namespace API.Models
{
    public class ExerciseLine
    {
        public Exercise Exercise { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        public ExerciseLine()
        {
        }
    }
}