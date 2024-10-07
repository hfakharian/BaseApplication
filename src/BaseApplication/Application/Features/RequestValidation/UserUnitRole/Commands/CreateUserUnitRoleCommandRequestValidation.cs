using Application.Features.Request.UserUnitRole.Commands;
using FluentValidation;

namespace Application.Features.RequestValidation.UserUnitRole.Commands
{
    public class CreateUserUnitRoleCommandRequestValidation : AbstractValidator<CreateUserUnitRoleCommandRequest>
    {
        public CreateUserUnitRoleCommandRequestValidation()
        {
            RuleFor(x => x.UserUnitRole)
            .NotNull()
            .WithMessage(Contract.Resources.UserUnitRole.UserUnitRoleResource.UserUnitRole_Empty);

            When(x => x.UserUnitRole != null,
            () =>
            {
                RuleFor(x => x.UserUnitRole.UnitID)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(Contract.Resources.UserUnitRole.UserUnitRoleResource.UserUnitRole_Unit_Empty);

                RuleFor(x => x.UserUnitRole.UserID)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(Contract.Resources.UserUnitRole.UserUnitRoleResource.UserUnitRole_User_Empty);

                RuleFor(x => x.UserUnitRole.RoleID)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage(Contract.Resources.UserUnitRole.UserUnitRoleResource.UserUnitRole_Role_Empty);

            });
        }
    }
}
