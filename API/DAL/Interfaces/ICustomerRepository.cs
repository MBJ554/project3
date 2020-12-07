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
        bool IsAuthorized(string email, string passwordHashed);
    }
}
