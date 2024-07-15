using Microsoft.EntityFrameworkCore;

using MultiShop.Comment.Entities.Abstract;
using MultiShop.Comment.Entities.Concrete;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && e.State == EntityState.Added);

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && e.State == EntityState.Added);

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
