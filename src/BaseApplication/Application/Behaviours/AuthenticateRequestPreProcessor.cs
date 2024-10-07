using Application.Security;
using Contract.Services.Security;
using Domain.DataTransferObjects.User;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    public class AuthenticateRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : IAuthenticatedRequest
    {
        private readonly IAuthenticatedUserService authenticatedUserService;

        public AuthenticateRequestPreProcessor(IAuthenticatedUserService authenticatedUserService)
        {
            this.authenticatedUserService = authenticatedUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var req = request as IAuthenticatedRequest;
            if(req != null)
            {
                req.CurrentUser = authenticatedUserService;
            }
            return Task.CompletedTask;
        }
    }
}
