using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Interfaces.IGenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity obj);
        Task<TEntity> Delete(int id);
        Task<TEntity> GetByName(Func<TEntity, bool> name);
    }
}