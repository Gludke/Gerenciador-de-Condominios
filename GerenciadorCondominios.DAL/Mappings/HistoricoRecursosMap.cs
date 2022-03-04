using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mappings
{
    public class HistoricoRecursosMap : IEntityTypeConfiguration<HistoricoRecursos>
    {
        public void Configure(EntityTypeBuilder<HistoricoRecursos> builder)
        {
            builder.HasKey(hr => hr.HistoricoRecursosId);
            builder.Property(hr => hr.Valor).IsRequired();
            builder.Property(hr => hr.Tipo).IsRequired();
            builder.Property(hr => hr.Dia).IsRequired();
            builder.Property(hr => hr.MesId).IsRequired();
            builder.Property(hr => hr.Ano).IsRequired();

            //Relacionamentos:
            builder.HasOne(hr => hr.Mes).WithMany(m => m.HistoricoRecursos).HasForeignKey(hr => hr.MesId);

            builder.ToTable("HISTORICO_RECURSOS");
        }
    }
}
