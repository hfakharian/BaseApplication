using Application.Features.Request.UserProfile.Commands;
using Contract.PatternValidation;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Application.Features.RequestValidation.UserProfile.Commands
{
    public class UpdateProfileUserCommandRequestValidation : AbstractValidator<UpdateProfileUserCommandRequest>
    {
        public UpdateProfileUserCommandRequestValidation()
        {
            RuleFor(x => x.User)
            .NotNull()
            .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUser_User_Empty);

            When(x => x.User != null,
            () =>
            {
                RuleFor(x => x.User.FirstName)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_FirstName_Empty)
                .Must(x => x.Length > 1)
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_FirstName_Invalid);

                RuleFor(x => x.User.LastName)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_LastName_Empty)
                .Must(x => x.Length > 1)
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_LastName_Invalid);

                RuleFor(x => x.User.Email)
                .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternEmail))
                .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUser_User_Email_Invalid);

                RuleFor(x => x.User.Mobile)
                .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternMobile))
                .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUser_User_Username_Invalid);

            });
        }
    }
}
