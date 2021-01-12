using Desktop.Callers;
using Desktop.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Desktop.ViewModels
{
    public class ViewModelCreateCustomer : INotifyPropertyChanged
    {
        private List<Clinic> clinics;

        private Customer customer;

        private CityCaller cityCaller;

        private CustomerCaller customerCaller;

        private ClinicCaller clinicCaller;

        public event PropertyChangedEventHandler PropertyChanged;

        private string firstNameErrorMessage;
        public string FirstNameErrorMessage { get { return firstNameErrorMessage; } set { firstNameErrorMessage = value; OnPropertyChanged(); } }
        private bool firstNameIsValid;

        public bool FirstNameIsValid
        {
            get
            {
                return firstNameIsValid;
            }
            set
            {
                firstNameIsValid = value;
                if (firstNameIsValid == true)
                {
                    FirstNameErrorMessage = "";
                }
                else
                {
                    FirstNameErrorMessage = " - Fornavnet er for kort";
                }
                OnPropertyChanged();
            }
        }

        private string lastNameErrorMessage;
        public string LastNameErrorMessage { get { return lastNameErrorMessage; } set { lastNameErrorMessage = value; OnPropertyChanged(); } }
        private bool lastNameIsValid;

        public bool LastNameIsValid
        {
            get
            {
                return lastNameIsValid;
            }
            set
            {
                lastNameIsValid = value;
                if (value == true)
                {
                    LastNameErrorMessage = "";
                }
                else
                {
                    LastNameErrorMessage = " - Efternavn er for kort";
                }
                OnPropertyChanged();
            }
        }

        private string passwordErrorMessage;
        public string PasswordErrorMessage { get { return passwordErrorMessage; } set { passwordErrorMessage = value; OnPropertyChanged(); } }
        private bool passwordIsValid;

        public bool PasswordIsValid
        {
            get
            {
                return passwordIsValid;
            }
            set
            {
                passwordIsValid = value;
                if (passwordIsValid == true)
                {
                    PasswordErrorMessage = "";
                }
                else
                {
                    PasswordErrorMessage = " _ Password er for kort";
                }
                OnPropertyChanged();
            }
        }

        private string phoneNoErrorMessage;
        public string PhoneNoErrorMessage { get { return phoneNoErrorMessage; } set { phoneNoErrorMessage = value; OnPropertyChanged(); } }
        private bool phoneNoIsValid;

        public bool PhoneNoIsValid
        {
            get
            {
                return phoneNoIsValid;
            }
            set
            {
                phoneNoIsValid = value;
                if (phoneNoIsValid == true)
                {
                    PhoneNoErrorMessage = "";
                }
                else
                {
                    PhoneNoErrorMessage = " - Telefonnummeret skal være 8 cifre langt";
                }
                OnPropertyChanged();
            }
        }

        private string emailErrorMessage;
        public string EmailErrorMessage { get { return emailErrorMessage; } set { emailErrorMessage = value; OnPropertyChanged(); } }
        private bool emailIsValid;

        public bool EmailIsValid
        {
            get
            {
                return emailIsValid;
            }
            set
            {
                emailIsValid = value;
                if (emailIsValid == true)
                {
                    EmailErrorMessage = "";
                }
                else
                {
                    EmailErrorMessage = " - Email er for kort";
                }
                OnPropertyChanged();
            }
        }

        private string zipCodeErrorMessage;
        public string ZipCodeErrorMessage { get { return zipCodeErrorMessage; } set { zipCodeErrorMessage = value; OnPropertyChanged(); } }
        private bool zipCodeIsValid;

        public bool ZipCodeIsValid
        {
            get
            {
                return zipCodeIsValid;
            }
            set
            {
                zipCodeIsValid = value;
                if (zipCodeIsValid == true)
                {
                    ZipCodeErrorMessage = "";
                }
                else
                {
                    ZipCodeErrorMessage = " - Postnummeret findes ikke";
                }
                OnPropertyChanged();
            }
        }

        private string addressErrorMessage;
        public string AddressErrorMessage { get { return addressErrorMessage; } set { addressErrorMessage = value; OnPropertyChanged(); } }
        private bool addressIsValid;

        public bool AddressIsValid
        {
            get
            {
                return addressIsValid;
            }
            set
            {
                addressIsValid = value;
                if (addressIsValid)
                {
                    AddressErrorMessage = "";
                }
                else
                {
                    AddressErrorMessage = " - Addresse er for kort";
                }
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Customer Customer { get { return customer; } set { customer = value; } }

        public ViewModelCreateCustomer()
        {
            customer = new Customer(this);
            cityCaller = new CityCaller();
            customerCaller = new CustomerCaller();
        }

        public bool Create()
        {
            bool res = false;
            if (FirstNameIsValid & LastNameIsValid & AddressIsValid & ZipCodeIsValid & EmailIsValid & PhoneNoIsValid & PasswordIsValid)
            {
                customer.PractitionerId = GlobalLoginInfo.UserId;
                customer.ClinicId = GlobalLoginInfo.Clinic.Id;
                customerCaller.Create(customer);
                res = true;
            }
            return res;
        }

        public void checkFirstName(string firstName)
        {
            if (firstName.Length > 1)
            {
                FirstNameIsValid = true;
            }
            else
            {
                FirstNameIsValid = false;
            }
        }

        public void checkPassword(string password)
        {
            if (password.Length > 5)
            {
                PasswordIsValid = true;
            }
            else
            {
                PasswordIsValid = false;
            }
        }

        public void checkLastName(string lastName)
        {
            if (lastName.Length > 2)
            {
                LastNameIsValid = true;
            }
            else
            {
                LastNameIsValid = false;
            }
        }

        public void checkPhoneNo(string mobil)
        {
            if (numbersOnly(mobil) & mobil.Length == 8)
            {
                PhoneNoIsValid = true;
            }
            else
            {
                PhoneNoIsValid = false;
            }
        }

        public async void checkZipCode(string zipCode)
        {
            City city = new City();
            
            if (zipCode.Length == 4 & numbersOnly(zipCode))
            {
                city = await cityCaller.GetByZipCode(zipCode);
                if (city != null & city.ZipCode != null & city.CityName != null)
                {
                    ZipCodeIsValid = true;
                    customer.City = city.CityName;
                }
                else
                {
                    ZipCodeIsValid = false;
                    Customer.City = "";
                }
            }
            else
            {
                ZipCodeIsValid = false;
                Customer.City = "";
            }         
        }

        public bool numbersOnly(string checkString)
        {
            Regex reg = new Regex("^[0-9]+$");
            return reg.IsMatch(checkString);
        }

        public void CheckEmailIsValid(string email)
        {
            if (email.Length > 6)
            {
                EmailIsValid = true;
            }
            else
            {
                EmailIsValid = false;
            }
        }

        public void checkAddress(string address)
        {
            if (address.Length > 6)
            {
                AddressIsValid = true;
            }
            else
            {
                AddressIsValid = false;
            }
        }
    }
}