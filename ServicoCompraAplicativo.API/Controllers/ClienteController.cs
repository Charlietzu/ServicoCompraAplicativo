using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServicoCompraAplicativo.API.Controllers.Main;
using ServicoCompraAplicativo.API.Requests;
using ServicoCompraAplicativo.Dominio.Models;
using ServicoCompraAplicativo.Negocio.Notifications.Interfaces;
using ServicoCompraAplicativo.Negocio.Services.Interfaces;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.API.Controllers
{
    [ApiController]
    public class ClienteController : MainController
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(INotificator notificator, IClienteService clienteService) : base(notificator)
        {
            _clienteService = clienteService;
        }

        public async Task<ActionResult<ClienteRequest>> SalvarCliente(ClienteRequest clienteRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.SalvarCliente(_mapper.Map<ClienteModel>(clienteRequest));

            return CustomResponse(clienteRequest);
        }
    }
}
