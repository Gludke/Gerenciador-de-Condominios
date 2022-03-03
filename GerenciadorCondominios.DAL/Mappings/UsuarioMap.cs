using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mappings
{
    class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();
            
            builder.Property(u => u.CPF).IsRequired().HasMaxLength(30);
            builder.HasIndex(u => u.CPF).IsUnique();//define que não pode haver CPFs iguais

            builder.Property(u => u.Foto).IsRequired();
            builder.Property(u => u.PrimeiroAcesso).IsRequired();
            builder.Property(u => u.Status).IsRequired();

            //Configurações dos Relacionamentos:
            builder.HasMany(u => u.ProprietariosApartamentos).WithOne(a => a.Proprietario);
            builder.HasMany(u => u.MoradoresApartamentos).WithOne(a => a.Morador);

            builder.HasMany(u => u.Veiculos).WithOne(v => v.Usuario);

            builder.HasMany(u => u.Eventos).WithOne(v => v.Usuario);

            builder.HasMany(u => u.Pagamentos).WithOne(v => v.Usuario);

            builder.HasMany(u => u.Servicos).WithOne(v => v.Usuario);

            builder.ToTable("USUARIOS");
        }
    }
}
