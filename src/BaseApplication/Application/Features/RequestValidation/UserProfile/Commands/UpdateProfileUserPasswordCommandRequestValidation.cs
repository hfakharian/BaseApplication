using Application.Features.Request.UserProfile.Commands;
using Contract.PatternValidation;
using FluentValidation;

namespace Application.Features.RequestValidation.UserProfile.Commands
{
    public class UpdateProfileUserPasswordCommandRequestValidation : AbstractValidator<UpdateProfileUserPasswordCommandRequest>
    {
        public UpdateProfileUserPasswordCommandRequestValidation()
        {
            RuleFor(x => x.UserPassword)
                .NotNull()
                .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUserPassword_Password_Empty);

            When(x => x.UserPassword != null,
                () =>
                {
                    RuleFor(x => x.UserPassword.CurrentPassword)
                    .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternPassword))
                    .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUserPassword_Password_CurrentPassword_Invalid);

                    RuleFor(x => x.UserPassword.NewPassword)
                    .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternPassword))
                    .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUserPassword_Password_NewPassword_Invalid);

                    RuleFor(x => x.UserPassword.RepeatNewPassword)
                    .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternPassword))
                    .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUserPassword_Password_RepeatNewPassword_Invalid);

                    When(x => {
                        return !string.IsNullOrEmpty(x.UserPassword.NewPassword) && !string.IsNullOrEmpty(x.UserPassword.RepeatNewPassword);
                        },
                        () =>
                        {
                            RuleFor(x => new { x.UserPassword.NewPassword, x.UserPassword.RepeatNewPassword })
                            .Must(x => x.NewPassword.Equals(x.RepeatNewPassword))
                            .WithMessage(Contract.Resources.UserProfile.UserProfileResource.Profile_Commands_UpdateProfileUserPassword_Password_NewPassword_NotEqual);
                        });
                    });
        }
    }
}
