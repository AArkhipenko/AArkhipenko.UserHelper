using AArkhipenko.UserHelper.Models;

namespace AArkhipenko.UserHelper.Helpers;

/// <summary>
/// Интерфейс программы опредления пользователя.
/// </summary>
public interface IUserHelper
{
    /// <summary>
    /// Получение информации о пользователе.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><inheritdoc cref="UserModel" path="/summary"/></returns>
    /// <remarks>
    /// Информация получается из user-service по токену со входа.
    /// </remarks>
    Task<UserModel> GetUserAsync(CancellationToken cancellationToken);
}