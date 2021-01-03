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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;

        /// <summary>
        /// Insere um novo usuário
        /// </summary>
        /// <param name="request">Dados de cadastro do usuário</param>
        /// <returns>Usuário cadastrado</returns>
        [HttpPost]
        [AllowAnonymous]
        [Produces(typeof(UsuarioResponse))]
        public async Task<IActionResult> Inserir([FromBody] UsuarioRequest request)
        {
            return Ok(await _usuarioService.Inserir(request));
        }

        /// <summary>
        /// Obtem um usuário por Id
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>Usuário obtido</returns>
        [HttpGet("{id}")]
        [Produces(typeof(UsuarioResponse))]
        public async Task<IActionResult> ObterPorId(long id)
        {
            return Ok(await _usuarioService.ObterPorId(id));
        }

        /// <summary>
        /// Obtem todos os usuários
        /// </summary>
        /// <returns>Todos os usuários</returns>
        [HttpGet]
        [Produces(typeof(UsuarioResponse))]
        public async Task<IActionResult> Obter()
        {
            return Ok(await _usuarioService.Obter());
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <param name="request">Dados de cadastro do usuário</param>
        /// <returns>Usuário atualizado</returns>
        [HttpPut("{id}")]
        [Produces(typeof(UsuarioResponse))]
        public async Task<IActionResult> Atualizar(long id, [FromBody] UsuarioRequest request)
        {
            return Ok(await _usuarioService.Atualizar(id, request));
        }

        /// <summary>
        /// Remove um usuário cadastrado
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            await _usuarioService.Remover(id);

            return Ok();
        }

    }
}
