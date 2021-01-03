using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services.Interfaces
{
    public interface IAutenticacaoService
    {
        Task<AutenticacaoResponse> Autenticar(AutenticacaoRequest request);
    }
}
