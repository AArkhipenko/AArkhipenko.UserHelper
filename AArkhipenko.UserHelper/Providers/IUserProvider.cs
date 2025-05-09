using AArkhipenko.UserHelper.Models;

namespace AArkhipenko.UserHelper.Providers
{
	/// <summary>
	/// Интерфейс провайдера для поиска пользователя
	/// </summary>
	public interface IUserProvider
	{
		/// <summary>
		/// Получение пользователя
		/// </summary>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns><see cref="UserModel"/></returns>
		Task<UserModel> GetUserAsync(CancellationToken cancellationToken);
	}
}
