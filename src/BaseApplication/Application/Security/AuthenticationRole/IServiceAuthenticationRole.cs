using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security.AuthenticationRole
{
    public interface IServiceAuthenticationRole
    {
        Task<List<Claim>> GetClaimRoles(List<Claim> claims);
    }
}
