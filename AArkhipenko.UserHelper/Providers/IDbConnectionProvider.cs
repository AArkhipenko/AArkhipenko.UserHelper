using AArkhipenko.UserHelper.Models;
using System.Data;

namespace AArkhipenko.UserHelper.Providers
{
	/// <summary>
	/// Интерфейс провайдера подключения к БД
	/// </summary>
	public interface IDbConnectionProvider
    {
        /// <summary>
        /// Таймаут выполнения команды
        /// </summary>
        int CommandTimeout { get; }

        /// <summary>
        /// Создание подключения к БД
        /// </summary>
        /// <returns><see cref="IDbConnection"/></returns>
        IDbConnection CreateConnection();
	}
}
