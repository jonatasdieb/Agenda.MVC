using Agenda.Domain.Entities;
using Agenda.MVC.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace Agenda.MVC.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<PessoaMarcador, PessoaMarcadorViewModel>();           

            CreateMap<Contato, ContatoViewModel>();
            CreateMap<ContatoTipo, ContatoTipoViewModel>();           
          
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<EnderecoTipo, EnderecoTipoViewModel>();
           
        }
    }
}