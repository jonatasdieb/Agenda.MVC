using System.Collections.Generic;

namespace Agenda.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            Contatos = new List<Contato>();
            Enderecos = new List<Endereco>();
        }

        public int Id { get; set; }

        public int MarcadorId { get; set; }

        public string Nome { get; set; }

        public virtual List<Contato> Contatos { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }

        public virtual PessoaMarcador Marcador { get; set; }
        
    }
}
