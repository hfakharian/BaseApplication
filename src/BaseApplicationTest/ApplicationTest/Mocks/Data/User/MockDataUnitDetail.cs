using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataUnitDetail
    {
        public static IEnumerable<Domain.Entities.User.UnitDetail> getData()
        {
            return new List<Domain.Entities.User.UnitDetail>
            {
                new Domain.Entities.User.UnitDetail
                {
                    UnitID = 1,
                    Address = "ST 11",
                    Image = "1234"
                },
                new Domain.Entities.User.UnitDetail
                {
                    UnitID = 2,
                    Address = "ST 22",
                    Image = "1234"
                },
                new Domain.Entities.User.UnitDetail
                {
                    UnitID = 3,
                    Address = "ST 33",
                    Image = "1234"
                },
            };
        }
    }
}
