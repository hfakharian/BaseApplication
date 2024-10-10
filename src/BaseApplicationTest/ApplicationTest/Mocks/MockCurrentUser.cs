using Contract.Services.Security;

namespace ApplicationTest.Mocks
{
    public class MockCurrentUser : IAuthenticatedUserService
    {

        public MockCurrentUser()
        {
            IsAuthenticated = false;
            AuthTokenId = Guid.Empty;
            AuthUnitId = 1;
            AuthUserId = 1;
            AuthUserName = "hossein";

            ClientIpAddress = "127.0.0.1";
            ServerIpAddress = "127.0.0.1";
        }
        public bool IsAuthenticated { get; init; }
        public Guid AuthTokenId { get; init; }
        public int AuthUserId { get; init; }
        public int AuthUnitId { get; init; }
        public string AuthUserName { get; init; }
        public string ClientIpAddress { get; init; }
        public string ServerIpAddress { get; init; }
    }
}
