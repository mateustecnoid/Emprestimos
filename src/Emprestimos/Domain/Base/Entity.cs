using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emprestimos.Domain.Base
{
    public abstract class Entity
    {
        public long Id { get; set; }

        public abstract bool Validar();

        [NotMapped]
        public bool Valid { get; private set; }
        [NotMapped]
        public bool Invalid => !Valid;

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public void AddValidationResult(string propriedade, string mensagem)
        {
            var validacao = new ValidationResult();
            validacao.Errors.Add(new ValidationFailure(propriedade, mensagem));
            Valid = false;
            ValidationResult = validacao;
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
