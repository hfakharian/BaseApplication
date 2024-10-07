using Contract.Services.Security;

namespace Application.Security
{
    public interface IAuthenticatedRequest
    {
        public IAuthenticatedUser CurrentUser { get; set; }
    }
}
