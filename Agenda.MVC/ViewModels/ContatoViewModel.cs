using System.ComponentModel.DataAnnotations;

namespace Agenda.MVC.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public int Id { get; set; }

        public int PessoaId { get; set; }

        public string Descricao { get; set; }       

        public int? TipoId { get; set; }     
        
        public virtual ContatoTipoViewModel Tipo { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }

    }
}
