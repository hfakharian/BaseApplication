using Application.Security;
using Contract.Repositories;
using FluentValidation;
using MediatR.Pipeline;

namespace Application.Behaviours
{
    public class AuthenticateValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : IAuthenticatedRequest
    {
        private readonly IEnumerable<IValidator<IAuthenticatedRequest>> _validators;

        public AuthenticateValidationRequestPreProcessor(IEnumerable<IValidator<IAuthenticatedRequest>> validators)
        {
            _validators = validators;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (_validators != null && _validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                if (validationResults != null)
                {
                    var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                    if (failures.Count != 0)
                    {
                        //throw new UnauthorizedAccessException();
                        throw new Exceptions.ValidationException(failures);
                    }
                }
            }
        }
    }
}
