using Contract.Repositories;
using Contract.Repositories.User;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.User
{
    public class UserRepository : GenericRepository<Domain.Entities.User.User>, IUserRepository
    {
        readonly EntityDBContext context;

        public UserRepository(EntityDBContext context) : base(context)
        {
            this.context = context;
        }
       
    }
}
