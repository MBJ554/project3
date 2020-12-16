using System.Collections.Generic;

namespace API.DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Create(TEntity obj);

        void Update(TEntity obj);

        bool Delete(int id);
    }
}