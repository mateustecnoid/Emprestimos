namespace Emprestimos.Application.Dto.Response
{
    public class AutenticacaoResponse
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
