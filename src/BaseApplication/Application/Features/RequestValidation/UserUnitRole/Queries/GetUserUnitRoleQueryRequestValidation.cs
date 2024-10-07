using Application.Features.Request.UserUnitRole.Commands;
using Application.Features.Request.UserUnitRole.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RequestValidation.UserUnitRole.Queries
{
    public class GetUserUnitRoleQueryRequestValidation : AbstractValidator<GetUserUnitRoleQueryRequest>
    {
        public GetUserUnitRoleQueryRequestValidation()
        {
            RuleFor(x => x.UserID)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage(Contract.Resources.UserUnitRole.UserUnitRoleResource.UserUnitRole_User_Empty);

        }
    }
}
