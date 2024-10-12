using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Base.Utilities.User
{
    public class DataUnit
    {
        public static void Initialize(EntityDBContext context)
        {
            context.Unit.Add(new Domain.Entities.User.Unit
            {
                ID = 1,
                UnitType = Domain.Entities.User.Enum.UnitType.Central,
                UnitStatus = Domain.Entities.User.Enum.UnitStatus.Active,
                Title = "Unit 1",
                Email = "hofakharian@gmail.com",
                Website = "www",
            });

            context.Unit.Add(new Domain.Entities.User.Unit
            {
                ID = 2,
                UnitType = Domain.Entities.User.Enum.UnitType.Central,
                UnitStatus = Domain.Entities.User.Enum.UnitStatus.Active,
                Title = "Unit 2",
                Email = "hofakharian@gmail.com",
                Website = "www",
            });

            context.Unit.Add(new Domain.Entities.User.Unit
            {
                ID = 3,
                UnitType = Domain.Entities.User.Enum.UnitType.Central,
                UnitStatus = Domain.Entities.User.Enum.UnitStatus.Active,
                Title = "Unit 3",
                Email = "hofakharian@gmail.com",
                Website = "www",
            });


            context.SaveChanges();
        }
    }
}
