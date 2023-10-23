using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Mappings
{
    /// <summary>
    /// Classe para mapeamento da entidade Produto no banco de dados
    /// </summary>
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        /// <summary>
        /// Método para mapear a tabela do banco de dados
        /// </summary>
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // nome da tabela
            builder.ToTable("PRODUTO");

            // campo chave primária da tabela
            builder.HasKey(p => p.Id);

            // mapear os campos da tabela
            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();

            builder.Property(p => p.DataHoraUltimaAlteracao)
                .HasColumnName("DATAHORAULTIMACRIACAO")
                .IsRequired();
        }
    }
}
