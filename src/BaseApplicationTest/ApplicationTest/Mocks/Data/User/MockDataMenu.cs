using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataMenu
    {
        public static IEnumerable<Menu> getData()
        {
            return new List<Menu>
            {
                new Menu
                {
                    ID = 1,
                    MenuType = Domain.Entities.User.Enum.MenuType.Link,
                    MenuStatus = Domain.Entities.User.Enum.MenuStatus.Active,
                    Title = "Menu 1"
                },
                new Menu
                {
                    ID = 2,
                    MenuType = Domain.Entities.User.Enum.MenuType.Link,
                    MenuStatus = Domain.Entities.User.Enum.MenuStatus.Active,
                    Title = "Menu 2"
                },
                new Menu
                {
                    ID = 3,
                    MenuType = Domain.Entities.User.Enum.MenuType.Link,
                    MenuStatus = Domain.Entities.User.Enum.MenuStatus.Active,
                    Title = "Menu 3"
                }
            };
        }
    }
}
