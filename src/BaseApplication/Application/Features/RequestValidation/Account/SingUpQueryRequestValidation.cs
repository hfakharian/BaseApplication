using Application.Features.Request.Account;
using Contract.PatternValidation;
using Contract.Services.Captcha;
using FluentValidation;

namespace Application.Features.RequestValidation.Account
{
    public class SingUpQueryRequestValidation : AbstractValidator<SignUpQueryRequest>
    {
        public SingUpQueryRequestValidation(ICaptchaService captchaService)
        {
            RuleFor(x => x.User)
            .NotNull()
            .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_Empty);

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
                .Must(x=> x.Length > 1)
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_LastName_Invalid);

                RuleFor(x => x.User.Email)
                .NotEmpty()
                .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternEmail))
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_Email_Invalid);

                RuleFor(x => x.User.Mobile)
                .NotEmpty()
                .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternMobile))
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_Mobile_Invalid);

                RuleFor(x => x.User.Username)
                .NotEmpty()
                .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternUserName))
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_Username_Invalid);

                RuleFor(x => x.User.Password)
                .NotEmpty()
                .Must(x => PatternValidator.IsValidPatternRegex(x, PatternRegex.PatternPassword))
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignUp_User_Password_Invalid);


                RuleFor(x => x.User.Captcha)
                .NotNull()
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_Empty);

                RuleFor(x => x.User.Captcha!.Captcha)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_Empty);

                RuleFor(x => x.User.Captcha!.CaptchaCode)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_CaptchaCode_Empty);

                RuleFor(x => x)
                .Must(x => captchaService.IsValidCaptcha(x.User.Captcha!.CaptchaCode, x.User.Captcha.Captcha))
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_CaptchaCode_Invalid);

            });
        }
    }
}
