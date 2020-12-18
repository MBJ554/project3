using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Callers
{
    public interface ICaller<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();

        TEntity GetById(string id);

        void Delete(int id);

        void Update(TEntity obj);

        void Create(TEntity obj);
    }
}