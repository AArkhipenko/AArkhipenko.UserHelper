using AArkhipenko.UserHelper.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace AArkhipenko.UserHelper
{
    /// <summary>
	/// Методы расширешения для работы с keycloak
	/// </summary>
	public static class UserHelperExtension
    {
        /// <summary>
        /// Добавление провайдера для работы с пользователем (PostgreSQL)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddNpgsqlUserProvider(this IServiceCollection services)
            => services
            .AddHttpContextAccessor()
            .AddScoped<IDbConnectionProvider, NpgsqlConnectionProvider>()
            .AddUserProvider();

        /// <summary>
        /// Добавление провайдера для работы с пользователем 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddUserProvider(this IServiceCollection services)
            => services
            .AddScoped<IUserProvider, UserProvider>();
    }
}
