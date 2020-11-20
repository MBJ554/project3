using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllByPractitionerAndDate(DateTime date, int practitionerId);

    }
}
