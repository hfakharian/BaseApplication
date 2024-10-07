using Contract.Repositories.User;
using Persistence.Contexts;

namespace Persistence.Repositories.User
{
    public class UserUnitRoleRepository : GenericRepository<Domain.Entities.User.UserUnitRole>, IUserUnitRoleRepository
    {
        private readonly EntityDBContext context;

        public UserUnitRoleRepository(EntityDBContext context) : base(context)
        {
            this.context = context;
        }
    }
}
