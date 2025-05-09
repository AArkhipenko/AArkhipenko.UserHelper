using AArkhipenko.UserHelper.Configuration;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace AArkhipenko.UserHelper.Providers
{
    /// <summary>
    /// Реализация <see cref="IDbConnectionProvider"/>
    /// </summary>
    internal abstract class DbConnectionProvider : IDbConnectionProvider
    {
        protected readonly DatabaseSettings _databaseSettings;
        protected readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProvider"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/></param>
        public DbConnectionProvider(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString(Consts.ConnectionString) ??
                throw new ApplicationException($"Не задана строка подключения к БД с пользователями. " +
                    $"Раздел ConnectionStrings:{Consts.ConnectionString}.");

            this._databaseSettings = configuration.GetRequiredSection(Consts.DatabaseSettingsSection).Get<DatabaseSettings>() ??
                throw new ApplicationException("Не заданы настройки подключения к БД.");
        }

        /// <inheritdoc/>
        public int CommandTimeout => this._databaseSettings.CommandTimeout;

        /// <inheritdoc/>
        public abstract IDbConnection CreateConnection();
    }
}
