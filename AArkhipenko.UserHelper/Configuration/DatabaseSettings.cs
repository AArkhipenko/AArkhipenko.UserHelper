using System.ComponentModel.DataAnnotations;

namespace AArkhipenko.UserHelper.Configuration
{
    /// <summary>
    /// Настройки подключения к БД
    /// </summary>
    internal class DatabaseSettings
    {
        /// <summary>
        /// Таймаут выполнения запроса
        /// </summary>
        [Required(ErrorMessage = "Обязательно к заполнению")]
        public int CommandTimeout { get; set; }
    }
}
