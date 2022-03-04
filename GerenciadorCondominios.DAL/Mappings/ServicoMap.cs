using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mappings
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(s => s.ServicoId);
            builder.Property(s => s.Nome).IsRequired().HasMaxLength(50);
            builder.Property(s => s.Valor).IsRequired();
            builder.Property(s => s.Status).IsRequired();
            builder.Property(s => s.UsuarioId).IsRequired();

            //Relacionamentos:
            builder.HasOne(s => s.Usuario).WithMany(u => u.Servicos).HasForeignKey(s => s.UsuarioId);
            builder.HasMany(s => s.ServicoPredios).WithOne(sp => sp.Servico);

            builder.ToTable("SERVICOS");
        }
    }
}
