using Contract.Repositories.User;
using Domain.Entities.User;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.User
{
    public class RoleRepository : GenericRepository<Domain.Entities.User.Role>, IRoleRepository
    {
        readonly EntityDBContext context;

        public RoleRepository(EntityDBContext context) : base(context)
        {
            this.context = context;
        }

    }
}
