using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services.Interfaces
{
    public interface IEmprestimoService
    {
        Task<EmprestimoResponse> Inserir(EmprestimoRequest request);
        Task<List<EmprestimoResponse>> Obter();
        Task<EmprestimoResponse> ObterPorId(long id);
        Task<EmprestimoResponse> Atualizar(long id, EmprestimoRequest request);
        Task Remover(long id);
        Task<EmprestimoResponse> Devolver(long id);
    }
}
