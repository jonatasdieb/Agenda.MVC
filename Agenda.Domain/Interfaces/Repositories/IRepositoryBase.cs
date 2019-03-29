using System.Collections.Generic;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
