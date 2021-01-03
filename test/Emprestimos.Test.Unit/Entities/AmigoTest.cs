using Emprestimos.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Emprestimos.Test.Unit.Entities
{
    public class AmigoTest
    {
        private string apelido = "Apelido do Amigo";
        private string telefone = "(27)99999-9999";

        [Fact]
        public void DeveInstaciarAmigoValido()
        {
            var amigo = new Amigo(apelido, telefone);
            amigo.Should().NotBeNull();
            amigo.Valid.Should().BeTrue();
            amigo.Apelido.Should().Be(apelido);
            amigo.Telefone.Should().Be(telefone);
        }

        [Fact]
        public void DadoUmAmigoValidoDeveAtualizar()
        {
            var amigo = new Amigo(apelido, telefone);
            amigo.Should().NotBeNull();
            amigo.Valid.Should().BeTrue();

            amigo.Atualizar("Outro Apelido", "11111111");

            amigo.Should().NotBeNull();
            amigo.Valid.Should().BeTrue();
            amigo.Apelido.Should().NotBe(apelido);
            amigo.Telefone.Should().NotBe(telefone);
        }

        [Fact]
        public void DeveInstaciarAmigoInvalidoComApelidoVazio()
        {
            var amigo = new Amigo(string.Empty, telefone);
            amigo.Should().NotBeNull();
            amigo.Valid.Should().BeFalse();
            amigo.Apelido.Should().Be(string.Empty);
            amigo.Telefone.Should().Be(telefone);
        }

        [Fact]
        public void DeveInstaciarAmigoInvalidoComTelefoneVazio()
        {
            var amigo = new Amigo(apelido, string.Empty);
            amigo.Should().NotBeNull();
            amigo.Valid.Should().BeFalse();
            amigo.Apelido.Should().Be(apelido);
            amigo.Telefone.Should().Be(string.Empty);
        }
    }
}
