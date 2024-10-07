using Contract.Repositories.User;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;

namespace Persistence.Repositories.User
{
    public class MenuRepository : GenericRepository<Domain.Entities.User.Menu>, IMenuRepository
    {
        readonly EntityDBContext context;

        public MenuRepository(EntityDBContext context) : base(context)
        {
            this.context = context;
        }
        
    }
}
