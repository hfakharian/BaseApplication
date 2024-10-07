
using Contract.Repositories.User;

namespace Contract.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region User Schema
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        IUserDetailRepository UserDetailRepository { get; }
        IUnitRepository UnitRepository { get; }
        IUnitDetailRepository UnitDetailRepository { get; }
        IUserUnitRoleRepository UserUnitRoleRepository { get; }
        IMenuRepository MenuRepository { get; }
        #endregion

        Task SaveAsync();
    }
}
