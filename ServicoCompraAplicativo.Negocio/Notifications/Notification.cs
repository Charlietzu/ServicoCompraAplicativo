using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoCompraAplicativo.Negocio.Notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
