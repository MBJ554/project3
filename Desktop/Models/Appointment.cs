using Desktop.Callers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class Appointment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

        private CustomerCaller customerCaller;

        private Customer customerObj
        {
            get 
            {
                return customerCaller.GetById(customer);
            }
        }

        public string FirstName
        {
            get
            {
                return customerObj.FirstName;
            }
        }

        private string customer;
        public string Customer { 
            get
            {
                return customer;
            } 
            set 
            { 
                customer = value;
                OnPropertyChanged();
            } 
        }
        public string Practitioner { get; set; }

        public Appointment()
        {
            customerCaller = new CustomerCaller();
        }
    }
}
