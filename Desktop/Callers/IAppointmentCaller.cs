using Desktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Callers
{
    interface IAppointmentCaller
    {
        Task<ObservableCollection<Appointment>> GetAllAppointmentsByPractitionerId(int Id);

    }
}
