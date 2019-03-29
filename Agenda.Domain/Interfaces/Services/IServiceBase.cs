using System.Collections.Generic;

namespace Agenda.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> Get();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
