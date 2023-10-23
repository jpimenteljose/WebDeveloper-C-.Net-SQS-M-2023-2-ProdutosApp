using Microsoft.EntityFrameworkCore;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Contexts
{
    /// <summary>
    /// Classe para conexão do EntityFramework com o banco de dados do projeto
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para conexão com o bando de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProdutosApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        /// <summary>
        /// Propriedade para acessar as operações de CRUD para cada entidade
        /// </summary>
        public DbSet<Produto> Produto { get; set; }
    }
}
