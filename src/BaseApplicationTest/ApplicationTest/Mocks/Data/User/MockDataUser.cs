using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataUser
    {
        public static IEnumerable<Domain.Entities.User.User> getData()
        {
            return new List<Domain.Entities.User.User>
            {
                new Domain.Entities.User.User
                {
                    ID = 1,
                    UserType = Domain.Entities.User.Enum.UserType.System,
                    UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                    FirstName = "Hossein",
                    LastName = "Fakharian",
                    Email = "hofakharian@gmail.com",
                    Username = "hossein",
                    Password = "Password",
                    UserDetail = MockDataUserDetail.getData().FirstOrDefault(w => w.UserID == 1),
                },
                new Domain.Entities.User.User
                {
                    ID = 2,
                    UserType = Domain.Entities.User.Enum.UserType.System,
                    UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                    FirstName = "Hossein",
                    LastName = "Fakharian",
                    Email = "hofakharian@gmail.com",
                    Username = "hossein",
                    Password = "Password",
                    UserDetail = MockDataUserDetail.getData().FirstOrDefault(w => w.UserID == 2),
                },
                new Domain.Entities.User.User
                {
                    ID = 3,
                    UserType = Domain.Entities.User.Enum.UserType.System,
                    UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                    FirstName = "Hossein",
                    LastName = "Fakharian",
                    Email = "hofakharian@gmail.com",
                    Username = "hossein",
                    Password = "Password",
                    UserDetail = MockDataUserDetail.getData().FirstOrDefault(w => w.UserID == 3),
                }
            };
        }
    }
}
