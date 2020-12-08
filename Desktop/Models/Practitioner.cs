using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class Practitioner
    {

        public int Id { get; set; }
        public int PersonTypeId { get; set; }
        public int ClinicId { get; set; }
        public int PractitionerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        private string passwordHash;
        public string PasswordHash { get { return passwordHash; } set { passwordHash = HashPassword(value); } }

        public string Salt { get; private set; }


        public Practitioner(int id_, int personTypeId_, int clinicId_, int practitionerId_, string firstName_, string lastName_, string phoneNo_, string email_, string password_)
        {
            this.Id = id_;
            this.PersonTypeId = 1;
            this.ClinicId = clinicId_;
            this.PractitionerId = practitionerId_;

            this.FirstName = firstName_;
            this.LastName = lastName_;
            this.PhoneNo = phoneNo_;
            this.Email = email_;
            this.PasswordHash = password_;
        }

        private void GenerateSalt()
        {
            var rngCSP = RNGCryptoServiceProvider.Create();

            // Creates a salt
            byte[] random = new byte[256];
            rngCSP.GetNonZeroBytes(random);
            this.Salt = Convert.ToBase64String(random);
        }
      
        private string HashPassword(string password)
        {
            HashAlgorithm hashAlgorithm = SHA512.Create();
            return Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(Salt + password)));
        }

        public Practitioner()
        {
            GenerateSalt();
        }
    }
}
