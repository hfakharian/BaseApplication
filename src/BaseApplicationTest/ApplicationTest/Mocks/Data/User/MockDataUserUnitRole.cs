using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataUserUnitRole
    {
        public static IEnumerable<Domain.Entities.User.UserUnitRole> getData()
        {
            return new List<Domain.Entities.User.UserUnitRole>
            {
                new Domain.Entities.User.UserUnitRole
                {
                    UserID = 1,
                    UnitID = 1,
                    RoleID = 2,
                    User = MockDataUser.getData().FirstOrDefault(w => w.ID == 1),
                    Unit = MockDataUnit.getData().FirstOrDefault(w => w.ID == 1),
                    Role = MockDataRole.getData().FirstOrDefault(w => w.ID == 2),
                },
                new Domain.Entities.User.UserUnitRole
                {
                    UserID = 2,
                    UnitID = 1,
                    RoleID = 2,
                    User = MockDataUser.getData().FirstOrDefault(w => w.ID == 1),
                    Unit = MockDataUnit.getData().FirstOrDefault(w => w.ID == 1),
                    Role = MockDataRole.getData().FirstOrDefault(w => w.ID == 2),
                },
            };
        }
    }
}
