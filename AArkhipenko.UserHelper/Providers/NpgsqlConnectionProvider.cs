using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace AArkhipenko.UserHelper.Providers
{
    /// <summary>
    /// Провайдер подключения к БД PostgreSQL
    /// </summary>
    internal class NpgsqlConnectionProvider : DbConnectionProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProvider"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public NpgsqlConnectionProvider(IConfiguration configuration)
            : base(configuration)
        { }

        /// <inheritdoc/>
        public override IDbConnection CreateConnection()
            => new NpgsqlConnection(base._connectionString);
    }
}
