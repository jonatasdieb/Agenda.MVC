using Agenda.Domain.Entities;
using Agenda.MVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda.MVC.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<PessoaMarcadorViewModel, PessoaMarcador>();           
           
            CreateMap<ContatoViewModel, Contato>();
            CreateMap<ContatoTipoViewModel, ContatoTipo>();
            //CreateMap<List<ContatoViewModel>, List<Contato>>();

            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<EnderecoTipoViewModel, EnderecoTipo>();
           // CreateMap<List<EnderecoViewModel>, List<Endereco>>();


        }
    }
}