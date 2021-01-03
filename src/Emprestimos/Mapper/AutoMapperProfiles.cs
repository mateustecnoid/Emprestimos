using AutoMapper;
using Emprestimos.Application.Dto.Response;
using Emprestimos.Domain.Entities;
using System.Linq;

namespace Emprestimos.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioResponse>();
            CreateMap<Jogo, JogoResponse>();
            CreateMap<Amigo, AmigoResponse>()
                .ForMember(x => x.QuantidadeDeJogosEmprestados, y => y.MapFrom(z => z.Emprestimos.Where(e => !e.DataDevolucao.HasValue).Count()));
            CreateMap<Emprestimo, EmprestimoResponse>();
        }
    }
}
