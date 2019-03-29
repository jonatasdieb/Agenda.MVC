using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Agenda.Domain.Services
{
    public class PessoaMarcadorService : ServiceBase<PessoaMarcador>, IPessoaMarcadorService
    {
        private readonly IPessoaMarcadorRepository _pessoaMarcadorRepository;

        public PessoaMarcadorService(IPessoaMarcadorRepository pessoaMarcadorRepository) : base(pessoaMarcadorRepository)
        {
            _pessoaMarcadorRepository = pessoaMarcadorRepository;
        }

    }
}
