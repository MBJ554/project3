using API.DAL.Models;

namespace API.DAL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer IsAuthorized(string email, string password);
    }
}