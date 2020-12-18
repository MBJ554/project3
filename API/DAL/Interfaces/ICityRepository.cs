using API.DAL.Models;

namespace API.DAL.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        City GetCityByZipCode(string zipCode);

        bool DeleteByZipCode(string zipCode);
    }
}