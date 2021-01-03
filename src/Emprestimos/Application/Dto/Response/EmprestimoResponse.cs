using System;

namespace Emprestimos.Application.Dto.Response
{
    public class EmprestimoResponse
    {
        public long Id { get; set; }
        public AmigoResponse Amigo { get; set; }
        public JogoResponse Jogo { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
