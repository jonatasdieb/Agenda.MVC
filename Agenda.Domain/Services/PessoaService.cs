using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Agenda.Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa>, IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) : base(pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public int Create(Pessoa pessoa)
        {
            return _pessoaRepository.Create(pessoa);
        }
    }
}
