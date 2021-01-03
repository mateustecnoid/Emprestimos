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
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService) => _emprestimoService = emprestimoService;

        /// <summary>
        /// Insere um novo Emprestimo
        /// </summary>
        /// <param name="request">Dados de cadastro do Emprestimo</param>
        /// <returns>Emprestimo cadastrado</returns>
        [HttpPost]
        [Produces(typeof(EmprestimoResponse))]
        public async Task<IActionResult> Inserir([FromBody] EmprestimoRequest request)
        {
            return Ok(await _emprestimoService.Inserir(request));
        }

        /// <summary>
        /// Obtem um Emprestimo por Id
        /// </summary>
        /// <param name="id">Id do Emprestimo</param>
        /// <returns>Emprestimo obtido</returns>
        [HttpGet("{id}")]
        [Produces(typeof(EmprestimoResponse))]
        public async Task<IActionResult> ObterPorId(long id)
        {
            return Ok(await _emprestimoService.ObterPorId(id));
        }

        /// <summary>
        /// Obtem todos os Emprestimos
        /// </summary>
        /// <returns>Todos os Emprestimos</returns>
        [HttpGet]
        [Produces(typeof(EmprestimoResponse))]
        public async Task<IActionResult> Obter()
        {
            return Ok(await _emprestimoService.Obter());
        }

        /// <summary>
        /// Atualiza um Emprestimo
        /// </summary>
        /// <param name="id">Id do Emprestimo</param>
        /// <param name="request">Dados de cadastro do Emprestimo</param>
        /// <returns>Emprestimo atualizado</returns>
        [HttpPut("{id}")]
        [Produces(typeof(EmprestimoResponse))]
        public async Task<IActionResult> Atualizar(long id, [FromBody] EmprestimoRequest request)
        {
            return Ok(await _emprestimoService.Atualizar(id, request));
        }

        /// <summary>
        /// Remove um Emprestimo cadastrado
        /// </summary>
        /// <param name="id">Id do Emprestimo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            await _emprestimoService.Remover(id);

            return Ok();
        }

        /// <summary>
        /// Devolve um jogo
        /// </summary>
        /// <param name="id">Id do emprestimo</param>
        /// <returns>emprestimo finalizado</returns>
        [HttpPatch("{id}/devolver")]
        [Produces(typeof(EmprestimoResponse))]
        public async Task<IActionResult> Devolver(long id)
        {
            return Ok(await _emprestimoService.Devolver(id));
        }
    }
}
