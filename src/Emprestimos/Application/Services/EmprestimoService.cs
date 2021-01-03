using AutoMapper;
using Emprestimos.Application.Dto.Request;
using Emprestimos.Application.Dto.Response;
using Emprestimos.Application.Notify;
using Emprestimos.Application.Services.Interfaces;
using Emprestimos.Data;
using Emprestimos.Domain.Base;
using Emprestimos.Domain.Entities;
using Emprestimos.Domain.Enum;
using Emprestimos.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly EmprestimosContext _context;
        private readonly NotificationContext _notification;
        private readonly IEntityValidator _entityValidator;
        private readonly IMapper _mapper;

        public EmprestimoService(EmprestimosContext context, NotificationContext notification, IEntityValidator entityValidator, IMapper mapper)
        {
            _context = context;
            _notification = notification;
            _entityValidator = entityValidator;
            _mapper = mapper;
        }

        public async Task<EmprestimoResponse> Inserir(EmprestimoRequest request)
        {
            var amigo = await _context.Amigo.Include(x => x.Emprestimos).ThenInclude(y => y.Jogo)
                                            .FirstOrDefaultAsync(x => x.Id == request.AmigoId);

            if (amigo == null)
            {
                _notification.AddNotification("Amigo", "Amigo não foi encontrado");
                return null;
            }

            var jogo = await _context.Jogo.FirstOrDefaultAsync(x => x.Id == request.JogoId);

            if (jogo == null)
            {
                _notification.AddNotification("Jogo", "Jogo não foi encontrado");
                return null;
            }

            if (jogo.Situacao == SituacaoJogo.Indisponivel)
            {
                _notification.AddNotification("Jogo", "Já existe um emprestimo para esse jogo");
                return null;
            }

            var emprestimo = new Emprestimo(amigo, jogo);

            amigo.AddEmprestimo(emprestimo);

            _entityValidator.Validate(new Entity[] { emprestimo, amigo });

            if (_notification.HasNotifications) return null;

            await _context.SaveChangesAsync();

            return _mapper.Map<EmprestimoResponse>(emprestimo);
        }

        public Task<EmprestimoResponse> Atualizar(long id, EmprestimoRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EmprestimoResponse>> Obter()
        {
            var emprestimo = await _context.Emprestimo.Include(x => x.Jogo)
                                                      .Include(x => x.Amigo)
                                                      .ToListAsync();

            return _mapper.Map<List<Emprestimo>, List<EmprestimoResponse>>(emprestimo);
        }

        public async Task<EmprestimoResponse> ObterPorId(long id)
        {
            var emprestimo = await _context.Emprestimo.Include(x => x.Jogo)
                                                      .Include(x => x.Amigo)
                                                      .FirstOrDefaultAsync(x => x.Id == id);
            if (emprestimo == null)
            {
                _notification.AddNotification("Emprestimo", "Emprestimo não foi encontrado");
                return null;
            }

            return _mapper.Map<EmprestimoResponse>(emprestimo);
        }

        public async Task Remover(long id)
        {
            var emprestimo = await _context.Emprestimo.Include(x => x.Jogo)
                                                      .Include(x => x.Amigo)
                                                      .FirstOrDefaultAsync(x => x.Id == id);
            if (emprestimo == null)
            {
                _notification.AddNotification("Emprestimo", "Emprestimo não foi encontrado");
                return;
            }

            emprestimo.Jogo.Disponibilizar();

            _context.Remove(emprestimo);

            await _context.SaveChangesAsync();
        }

        public async Task<EmprestimoResponse> Devolver(long id)
        {
            var emprestimo = await _context.Emprestimo.Include(x => x.Jogo)
                                                      .Include(x => x.Amigo)
                                                      .FirstOrDefaultAsync(x => x.Id == id);
            if (emprestimo == null)
            {
                _notification.AddNotification("Emprestimo", "Emprestimo não foi encontrado");
                return null;
            }

            if (emprestimo.DataDevolucao.HasValue)
            {
                _notification.AddNotification("Emprestimo", "Emprestimo já foi devolvido");
                return null;
            }

            emprestimo.Devolver();

            _entityValidator.Validate(new Entity[] { emprestimo });

            if (_notification.HasNotifications) return null;

            await _context.SaveChangesAsync();

            return _mapper.Map<EmprestimoResponse>(emprestimo);
        }
    }
}
