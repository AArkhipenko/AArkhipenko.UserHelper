namespace AArkhipenko.UserHelper.Configuration;

/// <summary>
/// Разделы конфигурации.
/// </summary>
internal static class ConfigSections
{
    /// <summary>
    /// Раздел с общими конифгурациями для покета.
    /// </summary>
    private static string Common => "UserHelper";
    
    /// <summary>
    /// Раздел с настройками подключения к user-service.
    /// </summary>
    public static string UserService => $"{Common}:UserService";
}