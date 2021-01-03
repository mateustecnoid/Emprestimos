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
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService) => _jogoService = jogoService;

        /// <summary>
        /// Insere um novo jogo
        /// </summary>
        /// <param name="request">Dados de cadastro do jogo</param>
        /// <returns>jogo cadastrado</returns>
        [HttpPost]
        [Produces(typeof(JogoResponse))]
        public async Task<IActionResult> Inserir([FromBody] JogoRequest request)
        {
            return Ok(await _jogoService.Inserir(request));
        }

        /// <summary>
        /// Obtem um jogo por Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns>jogo obtido</returns>
        [HttpGet("{id}")]
        [Produces(typeof(JogoResponse))]
        public async Task<IActionResult> ObterPorId(long id)
        {
            return Ok(await _jogoService.ObterPorId(id));
        }

        /// <summary>
        /// Obtem todos os jogos
        /// </summary>
        /// <returns>Todos os jogos</returns>
        [HttpGet]
        [Produces(typeof(JogoResponse))]
        public async Task<IActionResult> Obter()
        {
            return Ok(await _jogoService.Obter());
        }

        /// <summary>
        /// Atualiza um jogo
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <param name="request">Dados de cadastro do jogo</param>
        /// <returns>jogo atualizado</returns>
        [HttpPut("{id}")]
        [Produces(typeof(JogoResponse))]
        public async Task<IActionResult> Atualizar(long id, [FromBody] JogoRequest request)
        {
            return Ok(await _jogoService.Atualizar(id, request));
        }

        /// <summary>
        /// Remove um jogo cadastrado
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            await _jogoService.Remover(id);

            return Ok();
        }

        /// <summary>
        /// Obtem todos as situações dos jogos
        /// </summary>
        /// <returns>Situações dos jogos</returns>
        [HttpGet("situacoes")]
        [Produces(typeof(EnumReponse))]
        public async Task<IActionResult> ObterSituacoes()
        {
            return Ok(await _jogoService.ObterSituacoes());
        }

        /// <summary>
        /// Obtem todos os generos dos jogos
        /// </summary>
        /// <returns>Generos dos jogos</returns>
        [HttpGet("generos")]
        [Produces(typeof(EnumReponse))]
        public async Task<IActionResult> ObterGeneros()
        {
            return Ok(await _jogoService.ObterGeneros());
        }
    }
}
