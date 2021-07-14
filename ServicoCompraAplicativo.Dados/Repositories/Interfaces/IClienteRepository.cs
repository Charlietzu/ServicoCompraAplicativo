using ServicoCompraAplicativo.Dominio.Models;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.Dados.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task SalvarCliente(ClienteModel cliente);
    }
}
