using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace Agenda.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {

        public int Create(Pessoa pessoa)
        {
            Db.Set<Pessoa>().Add(pessoa);
            Db.SaveChanges();

            return pessoa.Id;
        }

    }
}
