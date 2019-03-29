using Agenda.Domain.Entities;

namespace Agenda.Domain.Interfaces.Services
{
    public interface IPessoaService : IServiceBase<Pessoa>
    {
        int Create(Pessoa pessoa);
    }
}
