using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataUnit
    {
        public static IEnumerable<Domain.Entities.User.Unit> getData()
        {
            return new List<Domain.Entities.User.Unit>
            {
                new Domain.Entities.User.Unit
                {
                    ID = 1,
                    UnitType = Domain.Entities.User.Enum.UnitType.Central,
                    UnitStatus = Domain.Entities.User.Enum.UnitStatus.Active,
                    Title = "Unit 1",
                    Email = "hofakharian@gmail.com",
                    Website = "www",
                    UnitDetail = MockDataUnitDetail.getData().FirstOrDefault(w => w.UnitID == 1),
                },
               new Domain.Entities.User.Unit
                {
                    ID = 2,
                    UnitType = Domain.Entities.User.Enum.UnitType.Central,
                    UnitStatus = Domain.Entities.User.Enum.UnitStatus.Active,
                    Title = "Unit 2",
                    Email = "hofakharian@gmail.com",
                    Website = "www",
                    UnitDetail = MockDataUnitDetail.getData().FirstOrDefault(w => w.UnitID == 2),
                },
               new Domain.Entities.User.Unit
                {
                    ID = 3,
                    UnitType = Domain.Entities.User.Enum.UnitType.Central,
                    UnitStatus = Domain.Entities.User.Enum.UnitStatus.Active,
                    Title = "Unit 3",
                    Email = "hofakharian@gmail.com",
                    Website = "www",
                    UnitDetail = MockDataUnitDetail.getData().FirstOrDefault(w => w.UnitID == 3),
                },
            };
        }
    }
}
