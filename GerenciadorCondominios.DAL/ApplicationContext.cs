using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL
{
    //Conexão de BD do Identity. Exige as classes que herdam as interfaces "User" e "Roles" do 
    //Identity, além do tipo da PK de ambos.
    public class ApplicationContext : IdentityDbContext<Usuario, Funcao, string>
    {
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<HistoricoRecursos> HistoricoRecursos { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoPredio> ServicoPredios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Aplica nossas configuração criadas no BD
            builder.ApplyConfiguration(new AluguelMap());
            builder.ApplyConfiguration(new ApartamentoMap());
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new FuncaoMap());
            builder.ApplyConfiguration(new HistoricoRecursosMap());
            builder.ApplyConfiguration(new MesMap());
            builder.ApplyConfiguration(new ServicoMap());
            builder.ApplyConfiguration(new ServicoPrediosMap());
            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new VeiculoMap());
        }
    }
}
