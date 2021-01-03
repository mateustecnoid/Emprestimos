using Emprestimos.Domain.Base;
using Emprestimos.Domain.Validators;

namespace Emprestimos.Domain.Entities
{
    public class Usuario : Entity
    {
        protected Usuario() { }

        public Usuario(string nome, string senha, string email)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Validar();
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }

        public void Atualizar(string nome, string senha, string email)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            Validar();
        }

        public override bool Validar()
        {
            return Validate(this, new UsuarioValidator());
        }
    }
}
