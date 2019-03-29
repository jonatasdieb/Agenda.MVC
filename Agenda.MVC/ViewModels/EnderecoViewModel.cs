using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public int Id { get; set; }

        public int PessoaId { get; set; }
           
        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }       

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public int? TipoId { get; set; }

        public virtual EnderecoTipoViewModel Tipo { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }

    }
}
