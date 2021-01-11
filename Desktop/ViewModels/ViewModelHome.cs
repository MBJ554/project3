using Desktop.Callers;
using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class ViewModelHome : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private AppointmentCaller appointmentCaller;

        public ObservableCollection<Appointment> appointments { get; set; }

        public ViewModelHome() 
        {
            appointmentCaller = new AppointmentCaller();
            SetupViewModel();
           
        }

        private async void SetupViewModel() {
            appointments = await appointmentCaller.GetAllAppointmentsByPractitionerId(GlobalLoginInfo.UserId);
        }

    }
}
