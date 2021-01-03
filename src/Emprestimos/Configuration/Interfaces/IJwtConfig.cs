using Emprestimos.Domain.Entities;

namespace Emprestimos.Configuration.Interfaces
{
    public interface IJwtConfig
    {
        string GerarToken(Usuario usuario);
    }
}
