using FluentValidation;
using MediatR;
using MediatR.Pipeline;

namespace Application.Behaviours
{
    public class ValidationRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : IBaseRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationRequestPreProcessor(IEnumerable<IValidator<TRequest>> validators)
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
                        throw new Exceptions.ValidationException(failures);
                }
            }
        }
    }
}
