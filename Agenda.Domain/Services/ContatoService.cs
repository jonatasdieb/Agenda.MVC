using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;

namespace Agenda.Domain.Services
{
    public class ContatoService : ServiceBase<Contato>, IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository) : base(contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

    }
}
