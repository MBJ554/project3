using Desktop.ViewModels;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Desktop.Models
{
    public class Practitioner
    {
        public int Id { get; set; }
        public int PersonTypeId { get; set; }
        public int ClinicId { get; set; }
        public string Clinic { get; set; }
        public Clinic CurrentClinic { get; set; }
        private ViewModelCreatePractitioner viewModelCreatePractitioner;

        private string firstName;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                viewModelCreatePractitioner?.checkFirstName(value);
            }
        }

        private string lastName;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                viewModelCreatePractitioner?.checkLastName(value);
            }
        }

        private string phoneNo;

        public string PhoneNo
        {
            get
            {
                return phoneNo;
            }
            set
            {
                phoneNo = value;
                viewModelCreatePractitioner?.checkPhoneNo(value);
            }
        }

        private string email;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                viewModelCreatePractitioner?.checkEmail(value);
            }
        }

        private string passwordHash;

        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }
            set
            {
                passwordHash = HashPassword(value);
                viewModelCreatePractitioner?.checkPassword(value);
            }
        }

        public string Salt { get; private set; }

        public void GenerateSalt()
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

        public Practitioner(ViewModelCreatePractitioner viewModelCreatePractitioner)
        {
            this.viewModelCreatePractitioner = viewModelCreatePractitioner;
            GenerateSalt();
        }

        public Practitioner()
        {
        }
    }
}