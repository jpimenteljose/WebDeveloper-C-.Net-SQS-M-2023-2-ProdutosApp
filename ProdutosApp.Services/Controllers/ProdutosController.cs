using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;
using System.Net.NetworkInformation;

namespace ProdutosApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        /// <summary>
        /// Método para serviço de cadastro de produtos:
        /// POST /api/produtos
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Post([FromBody] ProdutosPostModel model)
        {
            try
            {
                // criando um objeto da classe Produto
                var produto = new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Quantidade = model.Quantidade,
                    DataHoraCriacao = DateTime.Now,
                    DataHoraUltimaAlteracao = DateTime.Now
                };

                // gravar no banco de dados
                var produtoRepository = new ProdutoRepository();
                produtoRepository.Add(produto);

                // copiando os dados do produto para a classe ProdutosGetModel
                var result = EntityToModel(produto);

                // retornar 200 (ok)
                return StatusCode(200, result);
            }
            catch(Exception e)
            {
                // retornar erro 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Método para serviço de edição de produtos: PUT /api/produtos
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put([FromBody] ProdutosPutModel model)
        {
            try
            {
                // consultar o produto no banco de dados através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(model.Id);

                // verificar se o produto foi encontrado
                if(produto != null)
                {
                    // atualizar os dados do produto
                    produto.Nome = model.Nome;
                    produto.Preco = model.Preco;
                    produto.Quantidade = model.Quantidade;
                    produto.DataHoraUltimaAlteracao = DateTime.Now;

                    produtoRepository.Update(produto);

                    // copiando os dados do Produto para a classe ProdutoGetModel
                    var result = EntityToModel(produto);

                    // retornar 200 (Ok)
                    return StatusCode(200, result);
                }
                else
                {
                    // retornar erro 400 (BAD REQUEST)
                    return StatusCode(400, new { mensagem = "Produto inválido. Verifique o ID informado." });
                }
            }
            catch(Exception e)
            {
                // retornar erro 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Método para serviço de exclusão de produtos:
        /// DELETE /api/produtos
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid? id)
        {
            try
            {
                // buscar o produto através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id);

                // verificar se o produto foi encontrado
                if (produto != null)
                {
                    // excluindo o produto no banco de dados
                    produtoRepository.Delete(produto);

                    // copiando os dados do Produto para a classe ProdutosGetModel
                    var result = EntityToModel(produto);

                    // retornar 200 (Ok)
                    return StatusCode(200, result);
                }
                else
                {
                    // retornar erro 400 (BAD REQUEST)
                    return StatusCode(400, new { mensagem = "Produto inválido. Verifique o ID informado." });
                }
            }
            catch(Exception e)
            {
                // retornar erro 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message});
            }
        }
        
        /// <summary>
        /// Método para serviço de consulta de produtos:
        /// GET /api/produtos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                // criando uma lista de objetos para retornar a consulta
                var lista = new List<ProdutosGetModel>();

                // acessar o banco de dados e consultar todos os produtos cadastrados
                var produtoRepository = new ProdutoRepository();

                foreach (var item in produtoRepository.GetAll())
                {
                    // adiconando cada produto obtido na lista
                    lista.Add(EntityToModel(item));
                }

                if (lista.Count > 0)
                {
                    // retornando a lista com todos os produtos
                    return StatusCode(200, lista);
                }
                else
                {
                    // retornando erro 204 (NO CONTENT) 
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                // retornando erro 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Método para serviço de consulta de UM produto por ID:
        /// GET /api/produtos
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            try
            {
                // consultar o produto no banco de dados através do ID
                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(id);

                // verificar se o produto foi encontrato
                if (produto != null)
                {
                    // copiando os dados do Produto para a classe ProdutoGetModel
                    var result = EntityToModel(produto);

                    // retornar 200 (Ok)
                    return StatusCode(200, result);
                }
                else
                {
                    // retornar 204 (NO CONTENT)
                    return StatusCode(204);
                }
            }
            catch(Exception e)
            {
                // retornar erro 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { e.Message });
            }
        }
    
        /// <summary>
        /// Método auxiliar para copiar os dados de um objeto da classe Produto para um objeto da classe ProdutosGetModel
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        private ProdutosGetModel EntityToModel(Produto produto)
        {
            // copiando os dados do Produto para a classe ProdutoGetModel
            return new ProdutosGetModel
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = produto.Preco * produto.Quantidade,
                DataHoraCriacao = produto.DataHoraCriacao,
                DataHoraUltimaAlteracao = produto.DataHoraUltimaAlteracao
            };
        }
    }
}
