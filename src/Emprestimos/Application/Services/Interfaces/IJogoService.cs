using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services.Interfaces
{
    public interface IJogoService
    {
        Task<JogoResponse> Inserir(JogoRequest request);
        Task<List<JogoResponse>> Obter();
        Task<JogoResponse> ObterPorId(long id);
        Task<JogoResponse> Atualizar(long id, JogoRequest request);
        Task Remover(long id);
        Task<List<EnumReponse>> ObterSituacoes();
        Task<List<EnumReponse>> ObterGeneros();
    }
}
