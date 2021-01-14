using Desktop.ViewModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Desktop.Models
{
    public class Customer : INotifyPropertyChanged
    {
        //public delegate void PropertyFirstNameChangedEventHandler(Customer source, System.ComponentModel.PropertyChangedEventArgs e);
        
        //public event PropertyFirstNameChangedEventHandler PropertyFirstNameChanged;

        //protected virtual void OnPropertyChangedForViewModel([CallerMemberName] string propertyName = "")
        //{
        //    if (PropertyFirstNameChanged != null) {
        //        PropertyFirstNameChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int Id { get; set; }
        public int PersonTypeId { get; set; }
        public int ClinicId { get; set; }
        public int PractitionerId { get; set; }
        public int RehabProgramId { get; set; }
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
                OnPropertyChanged();                                   
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                passwordHash = value;
                OnPropertyChanged();
                passwordHash = HashPassword(value);               
            }
        }

        public string Salt { get; set; }
        private string address;
        public string Address { 
            get 
            { 
                return address; 
            } 
            set 
            { 
                address = value;
                OnPropertyChanged();

            } 
        }

        private string zipCode;

        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                zipCode = value;
                OnPropertyChanged();

            }           
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged(); }
        }

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

        public Customer()
        {
            GenerateSalt();
        }       
    }
}