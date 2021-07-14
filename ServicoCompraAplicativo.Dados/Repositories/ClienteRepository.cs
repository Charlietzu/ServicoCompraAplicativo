using Dapper;
using Microsoft.Extensions.Logging;
using ServicoCompraAplicativo.Dados.Repositories.Base;
using ServicoCompraAplicativo.Dados.Repositories.Interfaces;
using ServicoCompraAplicativo.Dominio.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.Dados.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(ILogger<ClienteRepository> logger) : base(logger)
        {

        }
        public async Task SalvarCliente(ClienteModel cliente)
        {
            string sql = @"";

            try
            {
                using (IDbConnection dbConnection = GetConnection())
                {
                    await dbConnection.ExecuteAsync(sql, new { });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu um erro ao cadastrar o cliente - {Message}", e.Message);
                throw e;
            }
        }
    }
}
