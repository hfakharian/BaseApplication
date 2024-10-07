using Contract.Repositories;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.AuthenticationRole
{
    public class ServiceAuthenticationRole : IServiceAuthenticationRole
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceAuthenticationRole(
            IUnitOfWork unitOfWork
            )
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Claim>> GetClaimRoles(List<Claim> claims)
        {
            var user = claims.FirstOrDefault(w => w.Type == "user")!.Value;
            var unit = claims.FirstOrDefault(w => w.Type == "unit")!.Value;


            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(unit))
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));

                var role = await unitOfWork.UserUnitRoleRepository.FindByExpression(
                    w => w.IsAccepted == true && w.UserID == Int32.Parse(user) && w.UnitID == Int32.Parse(unit),
                    includeProperties:"Role");

                if(role is not null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Role.Title));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            return claims;
        }
    }
}
