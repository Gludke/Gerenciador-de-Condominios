using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mappings
{
    public class ApartamentoMap : IEntityTypeConfiguration<Apartamento>
    {
        public void Configure(EntityTypeBuilder<Apartamento> builder)
        {
            builder.HasKey(a => a.ApartamentoId);
            builder.Property(a => a.Numero).IsRequired();
            builder.Property(a => a.Andar).IsRequired();
            builder.Property(a => a.Foto).IsRequired();
            builder.Property(a => a.MoradorId).IsRequired();
            builder.Property(a => a.ProprietarioId).IsRequired();

            //Relacionamentos:
            builder.HasOne(a => a.Morador).WithMany(m => m.MoradoresApartamentos).HasForeignKey(a => a.MoradorId);
            builder.HasOne(a => a.Proprietario).WithMany(u => u.ProprietariosApartamentos).HasForeignKey(a => a.ProprietarioId);

            builder.ToTable("APARTAMENTOS");
        }
    }

}
