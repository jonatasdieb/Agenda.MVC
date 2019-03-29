using Agenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Data.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext()
            : base("name=AgendaContext")
        {
            //Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<ContatoTipo> ContatoTipos { get; set; }
        public DbSet<PessoaMarcador> PessoaMarcadores { get; set; }
        public DbSet<EnderecoTipo> EnderecoTipos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();            
        }


    }
}
