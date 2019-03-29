using Agenda.Domain.Entities;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Agenda.Domain.Services
{
    public class EnderecoTipoService : ServiceBase<EnderecoTipo>, IEnderecoTipoService
    {
        private readonly IEnderecoTipoRepository _enderecoTipoRepository;

        public EnderecoTipoService(IEnderecoTipoRepository enderecoTipoRepository) : base(enderecoTipoRepository)
        {
            _enderecoTipoRepository = enderecoTipoRepository;
        }

    }
}
