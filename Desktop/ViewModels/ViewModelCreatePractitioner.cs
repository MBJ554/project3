using Desktop.Callers;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class ViewModelCreatePractitioner : INotifyPropertyChanged
    {
        private List<Clinic> clinics;

        private Practitioner practitioner;

        private PractitionerCaller pc;

        private ClinicCaller clc;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public PractitionerCaller PC
        {
            get
            {
                return pc;
            }
            set
            {
                pc = value;
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

        public Practitioner Practitioner
        {
            get
            {
                return practitioner;
            }
            set
            {
                practitioner = value;
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

        public ViewModelCreatePractitioner()
        {

            
            RetrieveData();

        }

        public async void RetrieveData()
        {
            practitioner = new Practitioner();
           
            pc = new PractitionerCaller();
            clc = new ClinicCaller();

            var clinics =  await clc.GetAll();


         
            Clinics = (List<Clinic>)clinics;


        }

    }

}

