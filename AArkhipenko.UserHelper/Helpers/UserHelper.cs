using AArkhipenko.UserHelper.Models;
using AArkhipenko.UserHelper.Services;

namespace AArkhipenko.UserHelper.Helpers;

/// <summary>
/// Реализация <see cref="IUserHelper"/>.
/// </summary>
internal class UserHelper: IUserHelper
{
    private readonly IUserService _userService;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="UserHelper"/> class.
    /// </summary>
    /// <param name="userService"><see cref="IUserService"/></param>
    /// <exception cref="ArgumentNullException"></exception>
    public UserHelper(
        IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }
    
    /// <inheritdoc/>
    public async Task<UserModel> GetUserAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
            
        var user = await _userService.GetUserByTokenAsync(cancellationToken);

        return new UserModel
        {
            Id = user.Id,
            ExternalId = user.ExternalId,
        };
    }
}