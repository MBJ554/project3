using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
	public class Customer : INotifyPropertyChanged
	{

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int Id { 
            get; 
            set; }
		public int PersonTypeId {
            get;
            set; }
		public int ClinicId { 
            get; 
            set; }
		public int PractitionerId {
            get; 
            set; }
		public int RehabProgramId { 
            get;
            set; }
		public string FirstName { 
            get;
            set; }
        public string LastName
        {
            get;
            set;
        }
        public string PhoneNo
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;

        }
        public string Salt { get; set; }

        public string Address
        {
            get;
            set;
        }
        public string ZipCode
        {
            get;
            set;
        }
        private string city;

        public event PropertyChangedEventHandler PropertyChanged;

        public string City {
            get
            { 
                return city; 
            }
            set 
            { 
                city = value;
                OnPropertyChanged();
            }
        
        }


		public Customer(int id_, int personTypeId_, int clinicId_, int practitionerId_, int rehabProgramId_, string firstName_, string lastName_, string phoneNo_, string email_, string password_, string address_, string zipCode_)
		{
			this.Id = id_;
			this.PersonTypeId = 1;
			this.ClinicId = clinicId_;
			this.PractitionerId = practitionerId_;
			this.RehabProgramId = rehabProgramId_;
			this.FirstName = firstName_;
			this.LastName = lastName_;
			this.PhoneNo = phoneNo_;
			this.Email = email_;
            this.Salt = GenerateSalt();
            this.Password = HashPassword(password_);
			this.Address = address_;
			this.ZipCode = zipCode_;


		}

        private string GenerateSalt()
        {
            var rngCSP = RNGCryptoServiceProvider.Create();

            // Creates a salt
            byte[] random = new byte[256];
            rngCSP.GetNonZeroBytes(random);
            return Convert.ToBase64String(random);
        }

        private string HashPassword(string password)
        {
            HashAlgorithm hashAlgorithm = SHA512.Create();
            return Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(Salt + password)));
        }

        public Customer() { 
		
		}

		

	}
}
