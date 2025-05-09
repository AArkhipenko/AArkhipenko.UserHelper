namespace AArkhipenko.UserHelper.Models
{
	/// <summary>
	/// Модель пользователя из системы
	/// </summary>
	public class UserModel
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="UserModel"/> class.
        /// </summary>
        /// <param name="id"><inheritdoc cref="Id" path="/summary"/></param>
        /// <param name="externalId"><inheritdoc cref="ExternalId" path="/summary"/></param>
        public UserModel(int id, string externalId)
		{
			this.Id = id;
			this.ExternalId = externalId;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int Id { get; }

        /// <summary>
        /// ИД пользователя во внешней системе
        /// </summary>
        public string ExternalId { get; }
    }
}
