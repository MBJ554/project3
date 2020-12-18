namespace API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Clinic { get; set; }
        public string Practitioner { get; set; }
        public string RehabProgram { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public Customer()
        {
        }
    }
}