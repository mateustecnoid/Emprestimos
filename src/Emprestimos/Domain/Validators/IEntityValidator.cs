using Emprestimos.Domain.Base;

namespace Emprestimos.Domain.Validators
{
    public interface IEntityValidator
    {
        void Validate(params Entity[] entities);
    }
}
