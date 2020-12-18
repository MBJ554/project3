using API.DAL.Models;

namespace API.DAL.Interfaces
{
    public interface IPractitionerRepository : IGenericRepository<Practitioner>
    {
        Practitioner IsAuthorized(string email, string password);
    }
}