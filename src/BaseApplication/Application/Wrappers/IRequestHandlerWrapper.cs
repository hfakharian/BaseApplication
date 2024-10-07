using Domain.DataTransferObjects.Collection;
using MediatR;

namespace Application.Wrappers
{
    public interface IRequestHandlerWrapper<TRequest,TResponse> : IRequestHandler<TRequest, CollectionResult<TResponse>>
        where TRequest : IRequestWrapper<TResponse> 
        where TResponse : class
    {
    }
}
