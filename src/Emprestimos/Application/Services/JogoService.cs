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
using System.Linq;
using System.Threading.Tasks;

namespace Emprestimos.Application.Services
{
    public class JogoService : IJogoService
    {
        private readonly EmprestimosContext _context;
        private readonly NotificationContext _notification;
        private readonly IEntityValidator _entityValidator;
        private readonly IMapper _mapper;

        public JogoService(EmprestimosContext context, NotificationContext notification, IEntityValidator entityValidator, IMapper mapper)
        {
            _context = context;
            _notification = notification;
            _entityValidator = entityValidator;
            _mapper = mapper;
        }

        public async Task<JogoResponse> Inserir(JogoRequest request)
        {
            var jogo = new Jogo(request.Nome, request.Genero, request.Situacao);

            _entityValidator.Validate(new Entity[] { jogo });

            if (_notification.HasNotifications) return null;

            await _context.Jogo.AddAsync(jogo);

            await _context.SaveChangesAsync();

            return _mapper.Map<JogoResponse>(jogo);
        }

        public async Task<JogoResponse> Atualizar(long id, JogoRequest request)
        {
            var jogo = await _context.Jogo.FirstOrDefaultAsync(x => x.Id == id);

            if (jogo == null)
            {
                _notification.AddNotification("Jogo", "Jogo não foi encontrado");
                return null;
            }

            jogo.Atualizar(jogo.Nome, request.Genero, request.Situacao);

            _entityValidator.Validate(new Entity[] { jogo });

            if (_notification.HasNotifications) return null;

            await _context.SaveChangesAsync();

            return _mapper.Map<JogoResponse>(jogo);
        }

        public async Task<List<JogoResponse>> Obter()
        {
            var jogos = await _context.Jogo.ToListAsync();

            return _mapper.Map<List<Jogo>, List<JogoResponse>>(jogos);
        }

        public async Task<JogoResponse> ObterPorId(long id)
        {
            var jogo = await _context.Jogo.FirstOrDefaultAsync(x => x.Id == id);

            if (jogo == null)
            {
                _notification.AddNotification("Jogo", "Jogo não foi encontrado");
                return null;
            }

            return _mapper.Map<JogoResponse>(jogo);
        }

        public async Task Remover(long id)
        {
            var jogo = await _context.Jogo.FirstOrDefaultAsync(x => x.Id == id);

            if (jogo == null)
            {
                _notification.AddNotification("Jogo", "Jogo não foi encontrado");
                return ;
            }

            _context.Remove(jogo);

            await _context.SaveChangesAsync();
        }

        public async Task<List<EnumReponse>> ObterSituacoes()
        {
            return await Task.Run(() => Enum.GetValues(typeof(SituacaoJogo))
                                            .Cast<SituacaoJogo>()
                                            .Select(e => new EnumReponse
                                            {
                                                Codigo = (int)e,
                                                Descricao = e.ToString()
                                            })
                                            .ToList());
        }

        public async Task<List<EnumReponse>> ObterGeneros()
        {
            return await Task.Run(() => Enum.GetValues(typeof(GeneroEnum))
                                            .Cast<GeneroEnum>()
                                            .Select(e => new EnumReponse
                                            {
                                                Codigo = (int)e,
                                                Descricao = e.ToString()
                                            })
                                            .ToList());
        }
    }
}
