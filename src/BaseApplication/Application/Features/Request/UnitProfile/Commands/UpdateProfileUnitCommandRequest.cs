using Application.Wrappers;
using Domain.DataTransferObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Request.UnitProfile.Commands
{
    public class UpdateProfileUnitCommandRequest : BaseAuthenticatedRequestWrapper<UnitDTO>
    {
        public UnitDTO Unit { get; set; }
    }
}
