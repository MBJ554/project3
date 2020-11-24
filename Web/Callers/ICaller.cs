using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Callers
{
    interface ICaller<TEntity>
    {

        Task<IEnumerable<TEntity>> GetAll();

        TEntity GetById(int id);


        void Delete(int id);

        void Update(TEntity obj);

        void Create(TEntity obj);


    }
}
