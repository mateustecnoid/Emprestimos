using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResponse> Inserir(UsuarioRequest request);
        Task<List<UsuarioResponse>> Obter();
        Task<UsuarioResponse> ObterPorId(long id);
        Task<UsuarioResponse> Atualizar(long id, UsuarioRequest request);
        Task Remover(long id);

    }
}
