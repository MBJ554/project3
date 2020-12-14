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

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Practitioner Practitioner { get { return practitioner; } set { practitioner = value; } }

        
       

        public List<Clinic> Clinics
        {
            get
            {
                return clinics;
            }
            set
            {
                clinics = value;
                OnPropertyChanged();
            }
        }

        public ViewModelCreatePractitioner()
        {
            
            RetrieveData();
        }

        public async void RetrieveData()
        {
            practitioner = new Practitioner();
           
            practitionerCalller = new PractitionerCaller();
            clinicCaller = new ClinicCaller();

            var clinics =  await clinicCaller.GetAll();

            Clinics = (List<Clinic>)clinics;
        }

        public void Create()
        {
            practitionerCalller.Create(practitioner);
        }

        public bool CheckEmailIsTaken(string email)
        {
            bool res = false;
            if (practitionerCalller.GetByEmail(email) != null)
            {
                res = true;
            }
            return res;
        }

        public bool checkFirstName(string firstName)
        {
            bool res = false;
            if (firstName.Length > 1)
            {
                res = true;
                practitioner.FirstName = firstName;
            }
            return res;
        }

        public bool checkPassword(string password)
        {
            bool res = false;
            if (password.Length > 5) {
                res = true;
            }
            return res;
        }

        public bool checkLastName(string lastName)
        {
            bool res = false;
            if (lastName.Length > 1)
            {
                res = true;
                practitioner.LastName = lastName;
            }
            return res;
        }

        internal bool checkPhoneNo(string mobil)
        {
            bool res = false;
            if (numbersOnly(mobil) & mobil.Length == 8)
            {
                res = true;
                practitioner.PhoneNo = mobil;
            }
            return res;
        }

        public bool numbersOnly(String checkString)
        {
            Regex reg = new Regex("^[0-9]+$");
            return reg.IsMatch(checkString);
        }

        public bool checkEmail(string email)
        {
            bool res = false;
            if (email.Length > 6) {
                res = true;
                practitioner.Email = email;
            }
            return res;
        }

      

    }

}

