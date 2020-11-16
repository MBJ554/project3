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
    class DataContextForCreateUser
    {


        private List<City> cities;
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

        public DataContextForCreateUser()
        {

            //CityCaller cc = new CityCaller();

            //Task t1 = Task.Run(() => Cities = (List<City>)cc.GetAll());
            //t1.Wait();

        }




    }
}

