namespace API.DAL.Models
{
    public class Practitioner
    {
        public int Id { get; set; }
        public int PersonTypeId { get; set; }
        public int ClinicId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }

        public Practitioner()
        {
        }
    }
}