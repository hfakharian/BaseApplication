using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataRole
    {
        public static IEnumerable<Domain.Entities.User.Role> getData()
        {
            return new List<Domain.Entities.User.Role>
            {
                new Domain.Entities.User.Role
                {
                    ID = 1,
                    RoleType = Domain.Entities.User.Enum.RoleType.Private,
                    RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                    Title = "User",
                },
                new Domain.Entities.User.Role
                {
                    ID = 2,
                    RoleType = Domain.Entities.User.Enum.RoleType.Public,
                    RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                    Title = "UnitAdmin",
                },
                new Domain.Entities.User.Role
                {
                    ID = 3,
                    RoleType = Domain.Entities.User.Enum.RoleType.Public,
                    RoleStatus = Domain.Entities.User.Enum.RoleStatus.Active,
                    Title = "UnitLimit",
                },
            };
        }
    }
}
