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

        private CityCaller cc;

        private CustomerCaller cuc;

        private ClinicCaller clc;
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CityCaller CC
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }

        public CustomerCaller CUC
        {
            get
            {
                return cuc;
            }
            set
            {
                cuc = value;
            }
        }

        public ClinicCaller CLC
        {
            get
            {
                return clc;
            }
            set
            {
                clc = value;
            }
        }

        public Customer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
            }
        }

      

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
            cc = new CityCaller();
            cuc = new CustomerCaller();
            clc = new ClinicCaller();
            
            var clinics = await clc.GetAll();        

            Clinics = (List<Clinic>)clinics;
          

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

        internal City setCity(string zipCode)
        {
            return cc.GetByZipCode(zipCode);
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

        internal bool checkZipCode(string zipCode)
        {
            bool res = false;
            if (zipCode.Length == 4 & numbersOnly(zipCode)) {
                res = true;
                customer.ZipCode = zipCode;
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
            if (email.Length > 6)
            {
                res = true;
                customer.Email = email;
            }
            return res;
        }

        public bool setClinic(Clinic clinic)
        {
            bool res = false;
            if (clinic != null)
            {
                res = true;
                customer.ClinicId = clinic.Id;
            }
            return res;
        }

    }
}

