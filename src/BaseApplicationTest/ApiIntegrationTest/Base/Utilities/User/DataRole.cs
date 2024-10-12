using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Base.Utilities.User
{
    public class DataRole
    {
        public static void Initialize(EntityDBContext context)
        {
            context.Role.Add(new Domain.Entities.User.Role
            {
                RoleType = Domain.Entities.User.Enum.RoleType.Private,
                RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                Title = "User",
            });

            context.Role.Add(new Domain.Entities.User.Role
            {
                RoleType = Domain.Entities.User.Enum.RoleType.Public,
                RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                Title = "UnitAdmin",
            });

            context.Role.Add(new Domain.Entities.User.Role
            {
                RoleType = Domain.Entities.User.Enum.RoleType.Public,
                RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                Title = "UnitLimit",
            });


            context.SaveChanges();
        }
    }
}
