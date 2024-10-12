using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Base.Utilities.User
{
    public class DataUserUnitRole
    {
        public static void Initialize(EntityDBContext context)
        {
            context.UserUnitRole.Add(new Domain.Entities.User.UserUnitRole
            {
                UserID = 1,
                UnitID = 1,
                RoleID = 2,
            });

            context.UserUnitRole.Add(new Domain.Entities.User.UserUnitRole
            {
                UserID = 2,
                UnitID = 1,
                RoleID = 2,
            });


            context.SaveChanges();
        }
    }
}
