using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return Ok();
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosGetModel), 200)]
        public IActionResult GetById(Guid? id)
        {
            return Ok();
        }
    }
}
