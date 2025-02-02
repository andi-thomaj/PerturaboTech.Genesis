using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using PerturaboTech.Genesis.WebApi.Helpers.Options;

namespace PerturaboTech.Genesis.WebApi.Data;

public class DapperContext(IOptions<DatabaseOptions> databaseOptions)
{
    private readonly DatabaseOptions _databaseOptions = databaseOptions.Value;

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(_databaseOptions.ConnectionString);
}