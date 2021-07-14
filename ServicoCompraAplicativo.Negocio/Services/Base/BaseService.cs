using FluentValidation;
using FluentValidation.Results;
using ServicoCompraAplicativo.Dominio.Models;
using ServicoCompraAplicativo.Negocio.Notifications;
using ServicoCompraAplicativo.Negocio.Notifications.Interfaces;

namespace ServicoCompraAplicativo.Negocio.Services.Base
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificate(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificate(error.ErrorMessage);
            }
        }

        protected void Notificate(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notificate(validator);

            return false;
        }
    }
}
