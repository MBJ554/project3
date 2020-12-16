using Desktop.Callers;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class ViewModelCreatePractitioner : INotifyPropertyChanged
    {
        private List<Clinic> clinics;

        private Practitioner practitioner;

        private PractitionerCaller practitionerCalller;

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
                    PasswordErrorMessage = " - Password er for kort";
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

        public Practitioner Practitioner { get { return practitioner; } set { practitioner = value; } }

        
       

        

        public ViewModelCreatePractitioner()
        {
            Practitioner.ClinicId = GlobalLoginInfo.Clinic.Id;
            practitioner = new Practitioner(this);

            practitionerCalller = new PractitionerCaller();
          
        }

       

        public bool Create()
        {
            bool res = false;
            if (FirstNameIsValid & LastNameIsValid & PhoneNoIsValid & EmailIsValid & PasswordIsValid) {
                practitionerCalller.Create(practitioner);
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
            else {
                FirstNameIsValid = false;
            }
        }

        public void checkPassword(string password)
        {
            if (password.Length > 5)
            {
                PasswordIsValid = true;
            }
            else {
                PasswordIsValid = false;
            }
        }

        public void checkLastName(string lastName)
        {
            if (lastName.Length > 1)
            {
                LastNameIsValid = true;
            }
            else {
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

        public bool numbersOnly(String checkString)
        {
            Regex reg = new Regex("^[0-9]+$");
            return reg.IsMatch(checkString);
        }

        public void checkEmail(string email)
        {
            if (email.Length > 6)
            {
                EmailIsValid = true;
            }
            else {
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

