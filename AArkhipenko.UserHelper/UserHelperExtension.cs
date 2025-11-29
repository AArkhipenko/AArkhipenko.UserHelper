using AArkhipenko.UserHelper.Configuration;
using AArkhipenko.UserHelper.Helpers;
using AArkhipenko.UserHelper.Services;
using AArkhipenko.UserHelper.Services.Middleware;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Refit;

namespace AArkhipenko.UserHelper
{
    /// <summary>
	/// Методы расширешения для определения пользователя.
	/// </summary>
	public static class UserHelperExtension
    {
        /// <summary>
        /// Добавление <see cref="IUserHelper"/>.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddUserHelper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddUserService(configuration);
            services.TryAddSingleton<IUserHelper, Helpers.UserHelper>();
            return services;
        }

        /// <summary>
        /// Добавление интерфейса user-service.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        private static IServiceCollection AddUserService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<UserServiceSettings>()
                .Bind(configuration.GetSection(ConfigSections.UserService));
            services.TryAddScoped<AuthHeaderHandler>();
            services.AddRefitClient<IUserService>()
                .ConfigureHttpClient((serviceProvider, client) =>
                {
                    var options = serviceProvider.GetRequiredService<IOptions<UserServiceSettings>>();
                    client.BaseAddress = new Uri(options.Value.Url);
                })
                .AddHttpMessageHandler<AuthHeaderHandler>();
            return services;
        }
    }
}
