using ProdutosApp.Data.Contexts;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    /// <summary>
    /// Classe para implementar as operações em banco de dados com Produto
    /// </summary>
    public class ProdutoRepository
    {
        /// <summary>
        /// Método para inserir um produto no banco de dados
        /// </summary>
        public void Add(Produto produto)
        {
            // abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Produto.Add(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar um produto no banco de dados
        /// </summary>
        public void Update(Produto produto)
        {
            // abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Produto.Update(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir um produto no banco de dados
        /// </summary>
        public void Delete(Produto produto)
        {
            // abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                dataContext.Produto.Remove(produto);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para consulta todos os produto no banco de dados
        /// </summary>
        public List<Produto> GetAll()
        {
            // abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                return dataContext.Produto
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }

        /// <summary>
        /// Método para consulta UM produto no banco de dados por ID
        /// </summary>
        public Produto? GetById(Guid? id)
        {
            // abrindo conexão com o banco de dados
            using (var dataContext = new DataContext())
            {
                return dataContext.Produto.Find(id);
            }
        }
    }
}
