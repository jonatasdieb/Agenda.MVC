using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        int Create(Pessoa pessoa);
    }
}
