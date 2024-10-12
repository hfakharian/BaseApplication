using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Base.Utilities.User
{
    public class DataUnitDetail
    {
        public static void Initialize(EntityDBContext context)
        {
            context.UnitDetail.Add(new Domain.Entities.User.UnitDetail
            {
                UnitID = 1,
                Address = "ST 11",
                Image = "img 1",
            });

            context.UnitDetail.Add(new Domain.Entities.User.UnitDetail
            {
                UnitID = 2,
                Address = "ST 22",
                Image = "img 2",
            });

            context.UnitDetail.Add(new Domain.Entities.User.UnitDetail
            {
                UnitID = 3,
                Address = "ST 33",
                Image = "img 3",
            });


            context.SaveChanges();
        }
    }
}
