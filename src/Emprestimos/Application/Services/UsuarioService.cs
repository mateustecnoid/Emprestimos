using AutoMapper;
using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using Emprestimos.Application.Notify;
using Emprestimos.Application.Services.Interfaces;
using Emprestimos.Data;
using Emprestimos.Domain.Base;
using Emprestimos.Domain.Entities;
using Emprestimos.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly EmprestimosContext _context;
        private readonly NotificationContext _notification;
        private readonly IEntityValidator _entityValidator;
        private readonly IMapper _mapper;

        public UsuarioService(EmprestimosContext context, NotificationContext notification, IEntityValidator entityValidator, IMapper mapper)
        {
            _context = context;
            _notification = notification;
            _entityValidator = entityValidator;
            _mapper = mapper;
        }

        public async Task<UsuarioResponse> Inserir(UsuarioRequest request)
        {
            if(await _context.Usuario.AnyAsync(x => x.Email == request.Email))
            {
                _notification.AddNotification("Usuário", "Já existe um usuário cadastrado com esse e-mail");
                return null;
            }

            var usuario = new Usuario(request.Nome, request.Senha, request.Email);

            _entityValidator.Validate(new Entity[] { usuario });

            if (_notification.HasNotifications) return null;

            await _context.Usuario.AddAsync(usuario);

            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioResponse>(usuario);

        }

        public async Task<UsuarioResponse> Atualizar(long id, UsuarioRequest request)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            if(usuario == null)
            {
                _notification.AddNotification("Usuário", "Usuário não foi encontrado");
                return null;
            }

            usuario.Atualizar(request.Nome, request.Senha, request.Email);

            _entityValidator.Validate(new Entity[] { usuario });

            if (_notification.HasNotifications) return null;

            await _context.SaveChangesAsync();

            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task<List<UsuarioResponse>> Obter()
        {
            var usuarios = await _context.Usuario.ToListAsync();

            return _mapper.Map<List<Usuario>, List<UsuarioResponse>>(usuarios);
        }

        public async Task<UsuarioResponse> ObterPorId(long id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                _notification.AddNotification("Usuário", "Usuário não foi encontrado");
                return null;
            }

            return _mapper.Map<UsuarioResponse>(usuario);
        }

        public async Task Remover(long id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);

            if (usuario == null)
            {
                _notification.AddNotification("Usuário", "Usuário não foi encontrado");
                return;
            }

            _context.Remove(usuario);

            await _context.SaveChangesAsync();
        }
    }
}
