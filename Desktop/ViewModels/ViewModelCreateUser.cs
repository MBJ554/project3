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
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class ViewModelCreateUser : INotifyPropertyChanged
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

        public ViewModelCreateUser()
        {

            // TODO: husk at kald retride data
            //RetrieveDataSync();
            RetrieveData();
            
        }

        public async void RetrieveData()
        {
            customer = new Customer();
            cc = new CityCaller();
            cuc = new CustomerCaller();
            clc = new ClinicCaller();
            
            var clinics = clc.GetAll();
            

            await Task.WhenAll(clinics);

            Clinics = (List<Clinic>)clinics.Result;
          

        }

    }
}

