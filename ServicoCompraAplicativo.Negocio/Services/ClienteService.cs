using ServicoCompraAplicativo.Dados.Repositories;
using ServicoCompraAplicativo.Dados.Repositories.Interfaces;
using ServicoCompraAplicativo.Dominio.Models;
using ServicoCompraAplicativo.Negocio.Notifications.Interfaces;
using ServicoCompraAplicativo.Negocio.Services.Base;
using ServicoCompraAplicativo.Negocio.Services.Interfaces;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.Negocio.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(INotificator notificator, ClienteRepository clienteRepository) : base(notificator)
        {
            _clienteRepository = clienteRepository;
        }
        public Task<bool> SalvarCliente(ClienteModel cliente)
        {
            throw new System.NotImplementedException();
        }
    }
}
