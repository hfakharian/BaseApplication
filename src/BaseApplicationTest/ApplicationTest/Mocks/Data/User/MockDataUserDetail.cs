using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks.Data.User
{
    public class MockDataUserDetail
    {
        public static IEnumerable<Domain.Entities.User.UserDetail> getData()
        {
            return new List<Domain.Entities.User.UserDetail>
            {
                new Domain.Entities.User.UserDetail
                {
                    UserID = 1,
                    Address = "ST 11",
                    Image = "1234"
                },
                new Domain.Entities.User.UserDetail
                {
                    UserID = 2,
                    Address = "ST 22",
                    Image = "1234"
                },
                new Domain.Entities.User.UserDetail
                {
                    UserID = 3,
                    Address = "ST 33",
                    Image = "1234"
                },
            };
        }
    }
}
