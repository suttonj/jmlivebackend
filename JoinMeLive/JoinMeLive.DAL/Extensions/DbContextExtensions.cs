using System.Data.Entity;

using JoinMeLive.DAL.Models;

namespace JoinMeLive.DAL.Extensions
{
    public static class DbContextExtensions
    {
        public static void SetAsModified<TEntity>(this DbContext dbcontext, TEntity modifiedEntity) where TEntity : class, IIdsEqual<TEntity>
        {
            var dbset = dbcontext.Set<TEntity>();

            if (!dbset.IsAttached(modifiedEntity))
            {
                dbset.Attach(modifiedEntity);
            }

            var entry = dbcontext.Entry(modifiedEntity);
            entry.State = EntityState.Modified;
        }
    }
}
