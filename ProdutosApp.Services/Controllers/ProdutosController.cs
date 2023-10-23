using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;
using ProdutosApp.Services.Models;

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
        /// Método para serviço de edição de produtos:
        /// PUT /api/produtos
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Put([FromBody] ProdutosPutModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Método para serviço de exclusão de produtos:
        /// DELETE /api/produtos
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult Delete(Guid? id)
        {
            return Ok();
        }
        
        /// <summary>
        /// Método para serviço de consulta de produtos:
        /// GET /api/produtos
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ProdutosGetModel>), 200)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        /// <summary>
        /// Método para serviço de consulta de UM produto por ID:
        /// GET /api/produtos
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            return Ok();
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
