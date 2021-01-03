using Emprestimos.Domain.Enum;

namespace Emprestimos.Application.Dto.Request
{
    public class JogoRequest
    {
        public string Nome { get;  set; }
        public GeneroEnum Genero { get;  set; }
        public SituacaoJogo Situacao { get;  set; }
    }
}
