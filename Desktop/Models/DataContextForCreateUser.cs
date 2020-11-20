using Desktop.Callers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class DataContextForCreateUser
    {

        private List<City> cities;

        private List<Clinic> clinics;

        private Customer customer;

        private CityCaller cc;

        private CustomerCaller cuc;

        private ClinicCaller clc;

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

        public List<City> Cities
        {
            get
            {
                return cities;
            }
            set
            {
                cities = value;
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
            }
        }

        public DataContextForCreateUser()
        {

            // TODO: husk at kald retride data
            RetrieveDataSync();
            
        }

        private void RetrieveDataSync() {
            
                customer = new Customer();
                cc = new CityCaller();
                cuc = new CustomerCaller();
                clc = new ClinicCaller();

               

                
                //Clinics = (List<Clinic>)getClinics.Result;

                Clinics = (List<Clinic>)clc.GetAllSync();
            Cities = (List<City>)cc.GetAllSync();

            
        }

        private async Task RetrieveData()
        {
            customer = new Customer();
            cc = new CityCaller();
            cuc = new CustomerCaller();
            clc = new ClinicCaller();
            
            var getClinics = clc.GetAll();
            var getCities = cc.GetAll();

            await Task.WhenAll(getClinics, getCities);
            //Clinics = (List<Clinic>)getClinics.Result;
            
            //Clinics = (List<Clinic>)clc.GetAll1();
            Cities = (List<City>)getCities.Result;

        }

    }
}

