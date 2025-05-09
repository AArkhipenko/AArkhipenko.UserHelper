using AArkhipenko.Core.Exceptions;
using AArkhipenko.UserHelper.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Security.Claims;

namespace AArkhipenko.UserHelper.Providers
{
    /// <summary>
    /// Реализация <see cref="IUserProvider"/>
    /// </summary>
    internal class UserProvider : IUserProvider
    {
        private readonly IDbConnectionProvider _connectionProvider;
        private readonly IHttpContextAccessor _contextAccessor;

        private UserModel? _user = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProvider"/> class.
        /// </summary>
        /// <param name="connectionProvider"><see cref="IDbConnectionProvider"/></param>
        /// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
        public UserProvider(
            IDbConnectionProvider connectionProvider,
            IHttpContextAccessor contextAccessor)
        {
            _connectionProvider = connectionProvider ??
                throw new ArgumentNullException(nameof(connectionProvider));

            _contextAccessor = contextAccessor ??
                throw new ArgumentNullException(nameof(contextAccessor));
        }

        /// <inheritdoc/>
        public async Task<UserModel> GetUserAsync(CancellationToken cancellationToken)
        {
            if (this._user is not null)
            {
                return this._user;
            }

            if (this._contextAccessor.HttpContext is null)
            {
                throw new HttpRequestException("Не задан контекст запроса");
            }
            else if (!this._contextAccessor.HttpContext.User.HasClaim(x => x.Type == Consts.ClaimUserId))
            {
                throw new AuthorizationException($"Identity не содержит информации о {Consts.ClaimUserId}");
            }

            var externalId = this._contextAccessor.HttpContext.User.FindFirstValue(Consts.ClaimUserId);
            if (string.IsNullOrEmpty(externalId))
            {
                throw new AuthorizationException($"{Consts.ClaimUserId} не задан");
            }

            using (var connection = this._connectionProvider.CreateConnection())
            {
                connection.Open();

                if (connection.State != ConnectionState.Open)
                {
                    throw new ApplicationException("Соединение не открыто");
                }

                var sqlStr = @"
SELECT ""id""
FROM public.users
WHERE external_id = @externalId
";
                var command = new CommandDefinition(
                    sqlStr,
                    new { externalId },
                    commandTimeout: TimeSpan.FromMilliseconds(this._connectionProvider.CommandTimeout).Seconds,
                    commandType: CommandType.Text,
                    cancellationToken: cancellationToken);

                var userDb = await connection.QueryFirstOrDefaultAsync<QueryUserModel>(command);
                if (userDb is null)
                {
                    throw new NotFoundException($"Не найден пользователь с внешним ИД = {externalId}");
                }

                this._user = new UserModel(userDb.Id, externalId);

                connection.Close();
            }

            return _user;
        }
    }
}
