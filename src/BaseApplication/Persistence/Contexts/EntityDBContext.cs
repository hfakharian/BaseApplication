using Domain.Entities.Base;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistence.Exceptions;
using Persistence.Extensions;
using System.Reflection;

namespace Persistence.Contexts
{
    public class EntityDBContext : DbContext
    {

        public DbSet<Role>? Role { get; set; }
        public DbSet<Unit>? Unit { get; set; }
        public DbSet<UnitDetail>? UnitDetail { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<UserDetail>? UserDetail { get; set; }
        public DbSet<UserUnitRole>? UserUnitRole { get; set; }
        public DbSet<Menu>? Menu { get; set; }


        public EntityDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                DateTime currentTime = DateTime.UtcNow;
                foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Property("DateCreate").CurrentValue = currentTime;
                            break;
                        case EntityState.Modified:
                            entry.Property("DateUpdate").CurrentValue = currentTime;
                            break;
                    }
                }
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new PersistenceException(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // call the base if you are using Identity service.
            // Important
            base.OnModelCreating(modelBuilder);

            var BaseEntityType = typeof(IBaseEntity);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (BaseEntityType.IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).AddQueryFilter<IBaseEntity>(e => e.IsDeleted == false);
                }

            }
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
