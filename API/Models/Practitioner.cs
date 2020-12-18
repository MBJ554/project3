namespace API.Models
{
    public class Practitioner
    {
        public int Id { get; set; }
        public string Clinic { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }

        public Practitioner()
        {
        }
    }
}