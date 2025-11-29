namespace AArkhipenko.UserHelper.Services.Models;

/// <summary>
/// Пользователь из токена.
/// </summary>
internal record TokenUserDto
{
    /// <summary>
    /// ИД пользователя.
    /// </summary>
    public int Id { get; init; }
		
    /// <summary>
    /// ИД пользователя во внешней системе.
    /// </summary>
    public string ExternalId { get; init; }

    /// <summary>
    /// ИД типа пользователя.
    /// </summary>
    public int UserTypeId { get; init; }
}