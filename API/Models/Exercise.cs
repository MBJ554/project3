namespace API.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Exercise(int id_, string name_, string description_)
        {
            this.Id = id_;
            this.Name = name_;
            this.Description = description_;
        }
        public Exercise()
        {

        }
    }
}