namespace AArkhipenko.UserHelper.Models
{
	/// <summary>
	/// Модель пользователя из системы.
	/// </summary>
	public record UserModel
	{
		/// <summary>
		/// ИД пользователя.
		/// </summary>
		public int Id { get; init; }

        /// <summary>
        /// ИД пользователя во внешней системе.
        /// </summary>
        public string ExternalId { get; init; }
    }
}
