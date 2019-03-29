namespace Agenda.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Descricao { get; set; }
        public int TipoId { get; set; }       

        public virtual ContatoTipo Tipo { get; set; }        
        
    }
}
