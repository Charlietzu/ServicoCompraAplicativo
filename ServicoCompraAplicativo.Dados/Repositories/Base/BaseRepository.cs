using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ServicoCompraAplicativo.Dados.Repositories.Base
{
    public class BaseRepository
    {
        protected readonly ILogger _logger;
        const string connectionString = "";

        protected BaseRepository(ILogger logger)
        {
            _logger = logger;
        }

        internal IDbConnection GetConnection()
        {
            IDbConnection dbConnection = null;

            try
            {
                dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao criar conexão.");
                throw;
            }
            return dbConnection;
        }
    }
}
