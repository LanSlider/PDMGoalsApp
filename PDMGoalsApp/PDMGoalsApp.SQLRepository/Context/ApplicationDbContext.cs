using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PDMGoalsApp.Entity.User;

namespace PDMGoalsApp.SQLRepository.Context
{

    public class ApplicationDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<User> User { get; set; }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("auth");
            //put db configuration here
            base.OnModelCreating(builder);

            builder.AddEntityConfigurationsFromAssembly<IEntityMappingConfiguration>(GetType().Assembly);
        }

        private void AddTimestamps()
        {
            var entitiesAdded =
                this.ChangeTracker.Entries().Where(x => x.Entity is ICreated && x.State == EntityState.Added);
            foreach (var entity in entitiesAdded)
                ((ICreated)entity.Entity).Created = DateTime.UtcNow;
        }
    }
}
