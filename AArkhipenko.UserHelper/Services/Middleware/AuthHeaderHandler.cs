using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AArkhipenko.UserHelper.Services.Middleware;

/// <summary>
/// Средний слой Refit для проброса Authorization.
/// </summary>
internal class AuthHeaderHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<AuthHeaderHandler> _logger;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthHeaderHandler"/> class.
    /// </summary>
    /// <param name="contextAccessor"><see cref="IHttpContextAccessor"/>.</param>
    /// <param name="logger"><see cref="ILogger{AuthHeaderHandler}"/>.</param>
    /// <exception cref="ArgumentNullException">Не задан входной параметр.</exception>
    public AuthHeaderHandler(
        IHttpContextAccessor contextAccessor,
        ILogger<AuthHeaderHandler> logger)
    {
        _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    /// <inheritdoc/>
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string scheme;
        string token;
        
        var authorizationHeader = _contextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
        if (!string.IsNullOrEmpty(authorizationHeader))
        {
            var authHeaderParts = authorizationHeader.Split(' ');
            scheme = authHeaderParts[0];
            token = authHeaderParts[1];
        }
        else
        {
            var message = "No Authorization header found";
            _logger.LogError(message);
            throw new UnauthorizedAccessException(message);
        }

        request.Headers.Authorization = new AuthenticationHeaderValue(scheme, token);

        return base.SendAsync(request, cancellationToken);
    }
}