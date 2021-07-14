using ServicoCompraAplicativo.Dominio.Models;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.Negocio.Services.Interfaces
{
    public interface IClienteService
    {
        Task<bool> SalvarCliente(ClienteModel cliente);
    }
}
