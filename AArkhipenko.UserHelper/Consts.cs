namespace AArkhipenko.UserHelper
{
    /// <summary>
    /// Константы
    /// </summary>
    public class Consts
    {
        /// <summary>
        /// Строка подключения к БД, в которой хранится информация о пользователях
        /// </summary>
        internal static string ConnectionString => "UserDb";

        /// <summary>
        /// Раздел с настройками подключенеия к БД
        /// </summary>
        internal static string DatabaseSettingsSection => "DatabaseSettings";

        /// <summary>
        /// Название раздела в Claim, который содержит информацию о ИД пользователя во внешней системе
        /// </summary>
        internal static string ClaimUserId => "UserId";
    }
}
