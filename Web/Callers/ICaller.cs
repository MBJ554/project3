using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Callers
{
    internal interface ICaller<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        TEntity GetById(int id);

        void Delete(int id);

        void Update(TEntity obj);

        void Create(TEntity obj);
    }
}