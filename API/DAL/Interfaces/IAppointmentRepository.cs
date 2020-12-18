using API.DAL.Models;
using System;
using System.Collections.Generic;

namespace API.DAL.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        IEnumerable<Appointment> GetAllByPractitionerAndDate(DateTime date, int practitionerId);
    }
}