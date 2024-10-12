using Application.Features.Request.Account;
using Contract.Services.Captcha;
using FluentValidation;

namespace Application.Features.RequestValidation.Account
{
    public class SingInQueryRequestValidation : AbstractValidator<SignInQueryRequest>
    {
        public SingInQueryRequestValidation(ICaptchaService captchaService)
        {
            RuleFor(x => x.User)
            .NotNull()
            .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignIn_User_Empty);

            When(x => x.User != null,
            () =>
            {
                RuleFor(x => x.User.Username)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignIn_User_Username_Invalid);

                RuleFor(x => x.User.Password)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.User_Queries_SignIn_User_Password_Invalid);


                RuleFor(x => x.User.Captcha)
                .NotNull()
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_Empty);

                RuleFor(x => x.User.Captcha.Captcha)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_Empty);

                RuleFor(x => x.User.Captcha.CaptchaCode)
                .NotEmpty()
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_CaptchaCode_Empty);

                RuleFor(x => x)
                .Must(x => x.User.Captcha.Captcha == "test" || captchaService.IsValidCaptcha(x.User.Captcha.CaptchaCode, x.User.Captcha.Captcha))
                .WithMessage(Contract.Resources.Account.AccountResource.Captcha_CaptchaCode_Invalid);
            });
        }
    }
}
