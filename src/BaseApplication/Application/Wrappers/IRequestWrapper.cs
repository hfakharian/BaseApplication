using Domain.DataTransferObjects.Collection;
using MediatR;

namespace Application.Wrappers
{
    public interface IRequestWrapper<TResponse> : IRequest<CollectionResult<TResponse>> where TResponse : class
    {
    }
}
