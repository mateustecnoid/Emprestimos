using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Emprestimos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService) => _autenticacaoService = autenticacaoService;

        /// <summary>
        /// Autentica um usuário previamente cadastrado
        /// </summary>
        /// <param name="request">Dados de autenticação</param>
        /// <returns>Usuário autenticado</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Autenticar([FromBody] AutenticacaoRequest request)
        {
            return Ok(await _autenticacaoService.Autenticar(request));
        }
    }
}
