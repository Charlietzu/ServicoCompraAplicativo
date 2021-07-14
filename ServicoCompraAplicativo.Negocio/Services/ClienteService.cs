using ServicoCompraAplicativo.Dados.Repositories;
using ServicoCompraAplicativo.Dados.Repositories.Interfaces;
using ServicoCompraAplicativo.Dominio.Models;
using ServicoCompraAplicativo.Dominio.Models.Validations;
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
        public async Task<bool> SalvarCliente(ClienteModel cliente)
        {
            if (!ExecuteValidation(new ClienteValidation(), cliente)) return false;

            if(await _clienteRepository.BuscarClienteCpf(cliente.Cpf))
            {
                Notificate("Já existe um cliente com este Cpf informado.");
                return false;
            }

            await _clienteRepository.SalvarCliente(cliente);
            return true;
        }
    }
}
