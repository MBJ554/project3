using Desktop.Callers;
using Desktop.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Customer Customer { get { return customer; } set { customer = value; } }

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

        public ViewModelCreateCustomer()
        {
            RetrieveData();
        }

        public async void RetrieveData()
        {
            customer = new Customer();
            cityCaller = new CityCaller();
            customerCaller = new CustomerCaller();
            clinicCaller = new ClinicCaller();

            var clinics = await clinicCaller.GetAll();

            Clinics = (List<Clinic>)clinics;
        }

        public void Create()
        {
            customerCaller.Create(customer);
        }

        public bool checkFirstName(string firstName)
        {
            bool res = false;
            if (firstName.Length > 2)
            {
                res = true;
                customer.FirstName = firstName;
            }
            return res;
        }

        public bool checkPassword(string password)
        {
            bool res = false;
            if (password.Length > 5)
            {
                res = true;
            }
            return res;
        }

       

        public bool checkLastName(string lastName)
        {
            bool res = false;
            if (lastName.Length > 2)
            {
                res = true;
                customer.LastName = lastName;
            }
            return res;
        }

        internal bool checkPhoneNo(string mobil)
        {
            bool res = false;
            if (numbersOnly(mobil) & mobil.Length == 8)
            {
                res = true;
                customer.PhoneNo = mobil;
            }
            return res;
        }

        public async Task<bool> checkZipCode(string zipCode)
        {
            bool res = false;
            City city = new City();
            try
            {
                if (zipCode.Length == 4 & numbersOnly(zipCode))
                    {
                    city = await cityCaller.GetByZipCode(zipCode);
                    if (city.ZipCode != null & city.CityName != null) {
                        res = true;
                        customer.ZipCode = city.ZipCode;
                        customer.City = city.CityName;
                    }
                    
                }
               
            }
            catch { 
                
                
            }
            
           
            return res;
        }

        public bool numbersOnly(String checkString)
        {
            Regex reg = new Regex("^[0-9]+$");
            return reg.IsMatch(checkString);
        }

        public bool CheckEmailIsValid(string email)
        {
            bool res = false;
            if (email.Length > 6)
            {
                res = true;
                customer.Email = email;
            }
            return res;
        }

        public bool CheckEmailIsTaken(string email) {
            bool res = false;
            if (customerCaller.GetByEmail(email) != null) {
                res = true;
            }
            return res;
        }


     
    }
}

