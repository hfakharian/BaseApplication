using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Base.Utilities.User
{
    public class DataUserDetail
    {
        public static void Initialize(EntityDBContext context)
        {
            context.UserDetail.Add(new Domain.Entities.User.UserDetail
            {
                UserID = 1,
                Address = "ST 11",
                Image = "img 1",
            });

            context.UserDetail.Add(new Domain.Entities.User.UserDetail
            {
                UserID = 2,
                Address = "ST 22",
                Image = "img 2",
            });

            context.UserDetail.Add(new Domain.Entities.User.UserDetail
            {
                UserID = 3,
                Address = "ST 33",
                Image = "img 3",
            });


            context.SaveChanges();
        }
    }
}
