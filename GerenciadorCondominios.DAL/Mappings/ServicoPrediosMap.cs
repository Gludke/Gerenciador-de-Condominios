using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mappings
{
    public class ServicoPrediosMap : IEntityTypeConfiguration<ServicoPredio>
    {
        public void Configure(EntityTypeBuilder<ServicoPredio> builder)
        {
            builder.HasKey(s => s.ServicoPredioId);
            builder.Property(s => s.ServicoId).IsRequired();
            builder.Property(s => s.DataExecucao).IsRequired();

            //Relacionamentos:
            builder.HasOne(sp => sp.Servico).WithMany(s => s.ServicoPredios).HasForeignKey(sp => sp.ServicoId);

            builder.ToTable("SERVICO_PREDIOS");
        }
    }
}
