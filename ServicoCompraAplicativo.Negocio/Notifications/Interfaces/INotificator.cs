using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoCompraAplicativo.Negocio.Notifications.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}
