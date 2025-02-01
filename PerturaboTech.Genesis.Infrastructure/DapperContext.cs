using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using PerturaboTech.Genesis.Shared.Configurations;

namespace PerturaboTech.Genesis.Infrastructure;

public class DapperContext(IOptions<DatabaseOptions> databaseOptions)
{
    private readonly DatabaseOptions _databaseOptions = databaseOptions.Value;

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_databaseOptions.ConnectionString);
}