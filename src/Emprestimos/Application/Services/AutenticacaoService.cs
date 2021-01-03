using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using Emprestimos.Application.Notify;
using Emprestimos.Application.Services.Interfaces;
using Emprestimos.Configuration.Interfaces;
using Emprestimos.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly EmprestimosContext _context;
        private readonly NotificationContext _notification;
        private readonly IJwtConfig _jwtConfig;

        public AutenticacaoService(EmprestimosContext context, NotificationContext notification, IJwtConfig jwtConfig)
        {
            _context = context;
            _notification = notification;
            _jwtConfig = jwtConfig;
        }

        public async Task<AutenticacaoResponse> Autenticar(AutenticacaoRequest request)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == request.Email && x.Senha == request.Senha);

            if (usuario == null)
            {
                _notification.AddNotification("Usuário", "Usuário não foi encontrado");
                return null;
            }

            var token = _jwtConfig.GerarToken(usuario);

            return new AutenticacaoResponse { Id = usuario.Id, Email = usuario.Email, Nome = usuario.Nome, Token = token };
        }
    }
}
