using Dapper;
using Microsoft.Extensions.Logging;
using ServicoCompraAplicativo.Dados.Repositories.Base;
using ServicoCompraAplicativo.Dados.Repositories.Interfaces;
using ServicoCompraAplicativo.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ServicoCompraAplicativo.Dados.Repositories
{
    public class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(ILogger<ClienteRepository> logger) : base(logger)
        {

        }

        public async Task<bool> BuscarClienteCpf(string cpf)
        {
            string sql = @"
                          SELECT 1 FROM CLIENTE CLI
                          WHERE CLI.CPF = @cpf
                          ";
            try
            {
                using (IDbConnection dbConnection = GetConnection())
                {
                    return (await dbConnection.QueryFirstAsync<bool>(sql, new { cpf }));
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu um erro ao buscar clientes pelo CPF - {Message}", e.Message);
                throw e;
            }
        }

        public async Task SalvarCliente(ClienteModel cliente)
        {
            string sql = @"
                          INSERT INTO CLIENTE
                           (NOME,
                            CPF,
                            DATA_NASCIMENTO,
                            SEXO,
                            ENDERECO)
                          VALUES (
                            @Nome,
                            @Cpf,
                            @DataNascimento,
                            @Sexo,
                            @Endereco
                          )";

            try
            {
                using (IDbConnection dbConnection = GetConnection())
                {
                    await dbConnection.ExecuteAsync(sql,
                        new
                        {
                            cliente.Nome,
                            cliente.Cpf,
                            cliente.DataNascimento,
                            cliente.Sexo,
                            cliente.Endereco
                        });
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
