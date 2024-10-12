using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiIntegrationTest.Base.Utilities.User
{
    public class DataUser
    {
        public static void Initialize(EntityDBContext context)
        {
            context.User.Add(new Domain.Entities.User.User
            {
                ID = 1,
                UserType = Domain.Entities.User.Enum.UserType.System,
                UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                FirstName = "Hossein1",
                LastName = "Fakharian1",
                Email = "hofakharian1@gmail.com",
                Username = "hossein1",
                Password = "ERKHVCMhdP3nYPYqS9LAWq0o1jLMdvCC9DkzbXhMwjU/UiEr8BYddhgDy1LsG5ljCPLdgKTxAI3vGQQBCI61Xg==",
            });

            context.User.Add(new Domain.Entities.User.User
            {
                ID = 2,
                UserType = Domain.Entities.User.Enum.UserType.System,
                UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                FirstName = "Hossein2",
                LastName = "Fakharian2",
                Email = "hofakharian2@gmail.com",
                Username = "hossein2",
                Password = "ERKHVCMhdP3nYPYqS9LAWq0o1jLMdvCC9DkzbXhMwjU/UiEr8BYddhgDy1LsG5ljCPLdgKTxAI3vGQQBCI61Xg==",
            });

            context.User.Add(new Domain.Entities.User.User
            {
                ID = 3,
                UserType = Domain.Entities.User.Enum.UserType.System,
                UserStatus = Domain.Entities.User.Enum.UserStatus.Active,
                FirstName = "Hossein3",
                LastName = "Fakharian3",
                Email = "hofakharian3@gmail.com",
                Username = "hossein3",
                Password = "ERKHVCMhdP3nYPYqS9LAWq0o1jLMdvCC9DkzbXhMwjU/UiEr8BYddhgDy1LsG5ljCPLdgKTxAI3vGQQBCI61Xg==",
            });


            context.SaveChanges();
        }
    }
}
