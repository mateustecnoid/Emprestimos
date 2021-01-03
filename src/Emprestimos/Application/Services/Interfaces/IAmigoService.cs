using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services.Interfaces
{
    public interface IAmigoService
    {
        Task<AmigoResponse> Inserir(AmigoRequest request);
        Task<List<AmigoResponse>> Obter();
        Task<AmigoResponse> ObterPorId(long id);
        Task<AmigoResponse> Atualizar(long id, AmigoRequest request);
        Task Remover(long id);
        Task<AmigoResponse> DevolverTodos(long AmigoId);
    }
}
