using Contract.Repositories;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace Application.Security
{
    public class AuthenticateValidation : AbstractValidator<IAuthenticatedRequest>
    {
        public AuthenticateValidation([NotNull] IUnitOfWork unitOfWork)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CurrentUser).NotNull().NotEmpty().WithMessage("Authenticate_CurrentUser_Empty");
            When(x => x.CurrentUser != null, () =>
            {

                RuleFor(x => x.CurrentUser.AuthUserId)
                .GreaterThan(0)
                .WithMessage("Authenticate_CurrentUser_AuthUserId_Invalid");

                RuleFor(x => x.CurrentUser.AuthUnitId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Authenticate_CurrentUser_AuthUnitId_Invalid");

                RuleFor(x => x.CurrentUser.AuthUserName)
                .NotEmpty()
                .WithMessage("Authenticate_CurrentUser_AuthUserName_Invalid");

                RuleFor(x => x.CurrentUser.AuthTokenId)
                .NotEmpty()
                .WithMessage("Authenticate_CurrentUser_AuthTokenId_Invalid");

                RuleFor(x => x.CurrentUser.ClientIpAddress)
                .NotNull()
                .NotEmpty()
                .WithMessage("Authenticate_CurrentUser_ClientIpAddress_Empty");

            });

        }
    }
}
