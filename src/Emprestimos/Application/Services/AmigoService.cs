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
    public class AmigoService : IAmigoService
    {
        private readonly EmprestimosContext _context;
        private readonly NotificationContext _notification;
        private readonly IEntityValidator _entityValidator;
        private readonly IMapper _mapper;

        public AmigoService(EmprestimosContext context, NotificationContext notification, IEntityValidator entityValidator, IMapper mapper)
        {
            _context = context;
            _notification = notification;
            _entityValidator = entityValidator;
            _mapper = mapper;
        }

        public async Task<AmigoResponse> Inserir(AmigoRequest request)
        {     
            if (await _context.Amigo.AnyAsync(x => x.Apelido == request.Apelido))
            {
                _notification.AddNotification("Amigo", "Amigo já cadastrado");
                return null;
            }

            var amigo = new Amigo(request.Apelido, request.Telefone);

            _entityValidator.Validate(new Entity[] { amigo });

            if (_notification.HasNotifications) return null;

            await _context.Amigo.AddAsync(amigo);

            await _context.SaveChangesAsync();

            return _mapper.Map<AmigoResponse>(amigo);
        }

        public async Task<AmigoResponse> Atualizar(long id, AmigoRequest request)
        {
            var amigo = await _context.Amigo.FirstOrDefaultAsync(x => x.Id == id);

            if (amigo == null)
            {
                _notification.AddNotification("Amigo", "Amigo não foi encontrado");
                return null;
            }

            if (await _context.Amigo.AnyAsync(x => x.Apelido == request.Apelido && x.Id != id))
            {
                _notification.AddNotification("Amigo", "Amigo já cadastrado");
                return null;
            }

            amigo.Atualizar(request.Apelido, request.Telefone);

            _entityValidator.Validate(new Entity[] { amigo });

            if (_notification.HasNotifications) return null;

            await _context.SaveChangesAsync();

            return _mapper.Map<AmigoResponse>(amigo);
        }

        public async Task<List<AmigoResponse>> Obter()
        {
            var amigos = await _context.Amigo.Include(x => x.Emprestimos)
                                             .ToListAsync();

            return _mapper.Map<List<Amigo>, List<AmigoResponse>>(amigos);
        }

        public async Task<AmigoResponse> ObterPorId(long id)
        {
            var amigo = await _context.Amigo.FirstOrDefaultAsync(x => x.Id == id);

            if (amigo == null)
            {
                _notification.AddNotification("Amigo", "Amigo não foi encontrado");
                return null;
            }

            return _mapper.Map<AmigoResponse>(amigo);
        }

        public async Task Remover(long id)
        {
            var amigo = await _context.Amigo.Include(x => x.Emprestimos).ThenInclude(x => x.Jogo)
                                            .FirstOrDefaultAsync(x => x.Id == id);

            if (amigo == null)
            {
                _notification.AddNotification("Amigo", "Amigo não foi encontrado");
                return;
            }

            amigo.FinalizarTodosEmprestimo();

            _context.Remove(amigo);

            await _context.SaveChangesAsync();
        }

        public async Task<AmigoResponse> DevolverTodos(long AmigoId)
        {
            var amigo = await _context.Amigo.Include(x => x.Emprestimos).ThenInclude(y => y.Jogo)
                                            .FirstOrDefaultAsync(x => x.Id == AmigoId);

            if (amigo == null)
            {
                _notification.AddNotification("Amigo", "Amigo não foi encontrado");
                return null;
            }

            _entityValidator.Validate(new Entity[] { amigo });

            if (_notification.HasNotifications) return null;

            amigo.DevolverTodosJogos();

            await _context.SaveChangesAsync();

            return _mapper.Map<AmigoResponse>(amigo);
        }
    }
}
