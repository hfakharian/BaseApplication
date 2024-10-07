using Application.Security;
using Contract.Services.Security;
using MediatR;

namespace Application.Wrappers
{
    public abstract class BaseAuthenticatedRequestWrapper<TResponse> : IAuthenticatedRequest, IRequestWrapper<TResponse> where TResponse : class
    {
        public IAuthenticatedUser CurrentUser { get; set; }
    }

    public abstract class BaseAuthenticatedRequest<TResponse> : IAuthenticatedRequest, IRequest<TResponse> where TResponse : class
    {
        public IAuthenticatedUser CurrentUser { get; set; }
    }
}
