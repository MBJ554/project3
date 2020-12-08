using API.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DAL.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer IsAuthorized(string email, string password);
    }
}
