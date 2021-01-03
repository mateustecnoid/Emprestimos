using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using Emprestimos.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emprestimos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmigoController : ControllerBase
    {
        private readonly IAmigoService _amigoService;
        public AmigoController(IAmigoService amigoService) => _amigoService = amigoService;

        /// <summary>
        /// Insere um novo Amigo
        /// </summary>
        /// <param name="request">Dados de cadastro do Amigo</param>
        /// <returns>Amigo cadastrado</returns>
        [HttpPost]
        [Produces(typeof(AmigoResponse))]
        public async Task<IActionResult> Inserir([FromBody] AmigoRequest request)
        {
            return Ok(await _amigoService.Inserir(request));
        }

        /// <summary>
        /// Obtem um Amigo por Id
        /// </summary>
        /// <param name="id">Id do Amigo</param>
        /// <returns>Amigo obtido</returns>
        [HttpGet("{id}")]
        [Produces(typeof(AmigoResponse))]
        public async Task<IActionResult> ObterPorId(long id)
        {
            return Ok(await _amigoService.ObterPorId(id));
        }

        /// <summary>
        /// Obtem todos os Amigos
        /// </summary>
        /// <returns>Todos os Amigos</returns>
        [HttpGet]
        [Produces(typeof(AmigoResponse))]
        public async Task<IActionResult> Obter()
        {
            return Ok(await _amigoService.Obter());
        }

        /// <summary>
        /// Atualiza um Amigo
        /// </summary>
        /// <param name="id">Id do Amigo</param>
        /// <param name="request">Dados de cadastro do Amigo</param>
        /// <returns>Amigo atualizado</returns>
        [HttpPut("{id}")]
        [Produces(typeof(AmigoResponse))]
        public async Task<IActionResult> Atualizar(long id, [FromBody] AmigoRequest request)
        {
            return Ok(await _amigoService.Atualizar(id, request));
        }

        /// <summary>
        /// Remove um Amigo cadastrado
        /// </summary>
        /// <param name="id">Id do Amigo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            await _amigoService.Remover(id);

            return Ok();
        }

        /// <summary>
        /// Devolve todos os jogos de um amigo
        /// </summary>
        /// <param name="id">Id do amigo</param>
        /// <returns>Amigo</returns>
        [HttpPatch("{id}/devolver-todos-jogos")]
        [Produces(typeof(AmigoResponse))]
        public async Task<IActionResult> DevolverTodos(long id)
        {
            return Ok(await _amigoService.DevolverTodos(id));
        }
    }
}
