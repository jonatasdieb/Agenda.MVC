using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModels
{
    public class PessoaViewModel
    {

        public PessoaViewModel()
        {
            Contatos = new List<ContatoViewModel>();
            Enderecos = new List<EnderecoViewModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O marcador é obrigatório.")]
        public int MarcadorId { get; set; }
       
        [Required(ErrorMessage ="O nome da pessoa é obrigatório.")]
        public string Nome { get; set; }

        public List<ContatoViewModel> Contatos { get; set; }

        public List<EnderecoViewModel> Enderecos { get; set; }

        public PessoaMarcadorViewModel Marcador { get; set; }

        public ContatoViewModel Contato { get; set; }
              
        public EnderecoViewModel Endereco { get; set; }

       
    }
}
