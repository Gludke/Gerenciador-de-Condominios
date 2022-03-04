using GerenciadorCondominios.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Mappings
{
    public class FuncaoMap : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            //gera valor automátivo ao add no BD
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Descricao).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Funcao
                {//criando a função MORADOR
                    Id = Guid.NewGuid().ToString(),
                    Name = "Morador",
                    NormalizedName = "MORADOR",//Essa é a prop que será comparada em caso de add ou exclusão de Moradores
                    Descricao = "Morador do prédio"
                },
                new Funcao
                {//criando a função SINDICO
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sindico",
                    NormalizedName = "SINDICO",
                    Descricao = "Síndico do prédio"
                },
                new Funcao
                {//criando a função SINDICO
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR",
                    Descricao = "Administrador do prédio"
                }
            );

            builder.ToTable("FUNCOES");
        }
    }
}
