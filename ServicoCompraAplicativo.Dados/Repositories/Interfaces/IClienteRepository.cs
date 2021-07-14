using ServicoCompraAplicativo.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.Dados.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task SalvarCliente(ClienteModel cliente);
        Task<bool> BuscarClienteCpf(string cpf);
    }
}
