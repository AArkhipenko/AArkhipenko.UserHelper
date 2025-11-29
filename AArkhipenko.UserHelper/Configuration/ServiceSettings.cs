namespace AArkhipenko.UserHelper.Configuration;

/// <summary>
/// Настройки доступа к сервисам
/// </summary>
internal abstract class ServiceSettings
{
    /// <summary>
    /// Ссылка на сервис
    /// </summary>
    public string Url { get; set; }
}