using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Agenda.Domain.Services
{
    public class ContatoTipoService : ServiceBase<ContatoTipo>, IContatoTipoService
    {
        private readonly IContatoTipoRepository _contatoTipoRepository;

        public ContatoTipoService(IContatoTipoRepository contatoTipoRepository) : base(contatoTipoRepository)
        {
            _contatoTipoRepository = contatoTipoRepository;
        }

    }
}
