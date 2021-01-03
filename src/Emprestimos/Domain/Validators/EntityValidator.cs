using Emprestimos.Application.Notify;
using Emprestimos.Domain.Base;

namespace Emprestimos.Domain.Validators
{
    public class EntityValidator : IEntityValidator
    {
        private readonly NotificationContext _notification;

        public EntityValidator(NotificationContext notification)
        {
            _notification = notification;
        }

        public void Validate(params Entity[] entities)
        {
            foreach (var entity in entities)
            {
                bool resultValidation = entity.Validar();
                if (!resultValidation)
                {
                    _notification.AddNotifications(entity.ValidationResult);
                }
            }
        }
    }
}
