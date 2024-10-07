using Contract.Repositories;
using Contract.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Exceptions;
using Persistence.Repositories.User;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityDBContext context;
        private bool disposed = false;
        public UnitOfWork(EntityDBContext context)
        {
            this.context = context;
        }


        #region User Schema
        private IRoleRepository? _roleRepository;
        private IUserRepository? _userRepository;
        private IUserDetailRepository? _userDetailRepository;
        private IUnitRepository? _unitRepository;
        private IUnitDetailRepository? _unitDetailRepository;
        private IUserUnitRoleRepository? _userUnitRoleRepository;
        private IMenuRepository? _menuRepository;
        #endregion


        #region User Schema
        
        public IRoleRepository RoleRepository =>
            _roleRepository ??= new RoleRepository(context);

        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(context);

        public IUserDetailRepository UserDetailRepository =>
            _userDetailRepository ??= new UserDetailRepository(context);

        public IUnitRepository UnitRepository =>
            _unitRepository ??= new UnitRepository(context);

        public IUnitDetailRepository UnitDetailRepository =>
            _unitDetailRepository ??= new UnitDetailRepository(context);

        public IUserUnitRoleRepository UserUnitRoleRepository =>
           _userUnitRoleRepository ??= new UserUnitRoleRepository(context);

        public IMenuRepository MenuRepository =>
            _menuRepository ??= new MenuRepository(context);
        #endregion


        public async Task SaveAsync()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    await context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw new PersistenceException(ex.Message);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
