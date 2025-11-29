using AArkhipenko.UserHelper.Services.Models;
using Refit;

namespace AArkhipenko.UserHelper.Services;

/// <summary>
/// Интерфейс user-service.
/// </summary>
internal interface IUserService
{
    /// <summary>
    /// Получение информации по пользователю из токена.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><inheritdoc cref="TokenUserDto" path="/summary"/></returns>
    [Post("/users/v10/get-user-by-token")]
    Task<TokenUserDto> GetUserByTokenAsync(CancellationToken cancellationToken);
}