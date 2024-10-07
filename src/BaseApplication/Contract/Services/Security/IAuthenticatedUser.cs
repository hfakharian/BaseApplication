namespace Contract.Services.Security
{
    public interface IAuthenticatedUser
    {
        bool IsAuthenticated { get; init; }
        Guid AuthTokenId { get; init; }
        int AuthUserId { get; init; }
        int AuthUnitId { get; init; }
        string AuthUserName { get; init; }
        string ClientIpAddress { get; init; }
        string ServerIpAddress { get; init; }
    }
}
