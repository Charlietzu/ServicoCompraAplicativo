using ServicoCompraAplicativo.Negocio.Notifications.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ServicoCompraAplicativo.Negocio.Notifications
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;
        public Notificator()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notificacao)
        {
            _notifications.Add(notificacao);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
