namespace API.Models
{
    public class Injury
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int InjuryTypeId { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }

        public Injury()
        {
        }
    }
}