using Emprestimos.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Emprestimos.Test.Unit.Entities
{
    public class UsuarioTest
    {
        private const string nome = "Mateus Viana";
        private const string email = "mateus.viana@teste.com";
        private const string pass = "123456";

        [Fact]
        public void DeveCriarUsuarioValido()
        {
            var usuario = new Usuario(nome, pass, email);
            usuario.Should().NotBeNull();
            usuario.Valid.Should().BeTrue();
            usuario.Nome.Should().Be(nome);
            usuario.Email.Should().Be(email);
            usuario.Senha.Should().Be(pass);
        }

        [Fact]
        public void DeveCriarUsuarioComNomeVazioInvalido()
        {
            var usuario = new Usuario(string.Empty, pass, email);
            usuario.Should().NotBeNull();
            usuario.Valid.Should().BeFalse();
            usuario.Nome.Should().Be(string.Empty);
            usuario.Email.Should().Be(email);
            usuario.Senha.Should().Be(pass);
        }

        [Fact]
        public void DeveCriarUsuarioComEmailVazioInvalido()
        {
            var usuario = new Usuario(nome, pass, string.Empty);
            usuario.Should().NotBeNull();
            usuario.Valid.Should().BeFalse();
            usuario.Nome.Should().Be(nome);
            usuario.Email.Should().Be(string.Empty);
            usuario.Senha.Should().Be(pass);
        }

        [Fact]
        public void DadoUmUsuarioValidoDeveAtualizar()
        {
            var usuario = new Usuario(nome, pass, email);
            usuario.Should().NotBeNull();
            usuario.Valid.Should().BeTrue();

            usuario.Atualizar("Trocou o nome", "trocou-senha", "trocouemail@test.com");
            usuario.Nome.Should().NotBe(nome);
            usuario.Email.Should().NotBe(email);
            usuario.Senha.Should().NotBe(pass);
        }
    }
}
